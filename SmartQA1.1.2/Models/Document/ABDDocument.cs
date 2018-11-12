using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Diagnostics;
using System.Data.SqlClient;
using SmartQA1._1._2.DB;
using SmartQA1._1._2.Models.ABDDocument;
using SmartQA1._1._2.DB.StoredProcedures;
using SmartQA1._1._2.Models.Login;
using System.IO;
using Microsoft.AspNet.Identity;

namespace SmartQA1._1._2.DB.EntityFramework
{
    //CLASS
    public class ABDDocumentList
    {
        public int resultsFound { get; set; }
        public IEnumerable<ABDDocumentFull> documentList { get; set; }

        public void fill(List<Filter> inputFilters)
        {
            resultsFound = 0;
            documentList = null;

            using (var context = new Entities())
            {
                try
                {
                    // 1 step
                    var documentId = context.ABDDocumentFulls.OrderBy(x => x.ABDDocument_Number);

                    // 2 step
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    // 3-4 step
                    QueryFactory queryFactory = new QueryFactory(inputFilters);

                    // 5-6 step
                    //retrievning the whole list of Register_ID that will satisfy our criterea (wanted registers)
                    var _documentId = (queryFactory.concatenateFilters(documentId))
                    .Select(x => x.ABDDocument_ID)
                    .ToList()
                    .Distinct()
                    .ToList();

                    // 7 step
                    stopwatch.Stop();
                    Debug.WriteLine(stopwatch.ElapsedMilliseconds + "To retrieve ABDDocument list");
                    stopwatch.Start();

                    // 8 step
                    resultsFound = _documentId.Count();

                    // 9 step 
                    //skipping and taking:
                    List<Guid> _documentIDSkipped = queryFactory.ApplyRowNumFilter(_documentId);

                    // 10 step
                    // gathering all other information about the registers which ID's are in the list of wanted registers
                    var documents =
                        (
                            from member
                            in context.ABDDocumentFulls
                            where _documentIDSkipped.Contains(member.ABDDocument_ID)
                            select member
                        )
                        .ToList();

                    // 11 step
                    documents = queryFactory.ApplyOrderByFilter(documents);

                    // 12 step
                    var _temp = documents
                        .GroupBy(x=>x.ABDDocument_ID)
                        .Select(x => ABDDocumentFull.Concatenate(x));

                    documentList = _temp;
                }
                catch (Exception ex) {
                    Debug.WriteLine(ex.InnerException ?? ex);
                    resultsFound = 0;
                    documentList = null;
                }
            }
        }
    }
    //CLASS
    public partial class  ABDDocumentFull
    {
        public string PID_ID_concatenated { get; set; }
        public string PID_Code_concatenated { get; set; }
        public string GOST_ID_concatenated { get; set; }
        public string GOST_Code_concatenated { get; set; }
        public string Issue_Date_UINormalized { get; set; }
        public List<ABDDocument_to_FileTable_StreamFull> files { get; set; }

        private IResult<MsgIdPair> result;
        private StoredProcedureAdapter spAdapter;
        private Guid UserId { get { return Guid.Parse(HttpContext.Current.User.Identity.GetUserId()); } }

        public void NormalizeDate()
        {
            Issue_Date_UINormalized = DateKit.convertToUIDate(Issue_Date);
        }
        public static ABDDocumentFull Concatenate(IGrouping<Guid, ABDDocumentFull> singleGroupedDocument)
        {
            ABDDocumentFull okModel = singleGroupedDocument.FirstOrDefault();
            okModel.NormalizeDate();

            okModel.PID_Code_concatenated = String.Join("/",
                singleGroupedDocument
                .Select(x => x.PID_ID).Distinct());

            okModel.PID_Code_concatenated = String.Join("/",
                singleGroupedDocument
                .Select(x => x.PID_Code).Distinct());

            okModel.GOST_ID_concatenated = String.Join("/",
                singleGroupedDocument
                .Select(x => x.GOST_ID).Distinct());

            okModel.GOST_Code_concatenated = String.Join("/",
                singleGroupedDocument
                .Select(x => x.GOST_Code).Distinct());

            return okModel;
        }
        //this method should stay static in case we need this info separetely from the 
        //document itself in FE
        public static List<ABDDocument_to_FileTable_StreamFull> GetDocumentFiles(Guid documentId)
        {
            using (var context = new Entities())
            {
                var files = context.ABDDocument_to_FileTable_StreamFull
                    .Where(x => x.ABDDocument_ID == documentId && x.Row_Status<100)
                    .ToList();
                foreach (var file in files) file.NormalizeDate();
                return files;
            }
        }
        public static ABDDocumentFull GetDocumentById(Guid documentId)
        {
            using (var context = new Entities())
            {
                var documentGrouping = context.ABDDocumentFulls
                    .Where(x => x.ABDDocument_ID == documentId)
                    .GroupBy(x => x.ABDDocument_ID)
                    .FirstOrDefault();

                var singleDocument = Concatenate(documentGrouping);
                singleDocument.files = GetDocumentFiles(singleDocument.ABDDocument_ID);

                return singleDocument;
            }
        }
        public IResult<MsgIdPair> Save()
        {
            //escape from null or empty document;
            if (String.IsNullOrEmpty(ABDDocument_Name)) return null;

            result = new MultipleSetsResultIdError<MsgIdPair>();

            using (var entities = new Entities())
            using (var fileStorageEntities = new FileStorageEntities())
            {
                using (var entitiesTransaction = entities.Database.BeginTransaction())
                {
                    try
                    {
                        
                        spAdapter = new StoredProcedureAdapter(entities);

                        if (ABDDocument_ID == null || ABDDocument_ID == Guid.Empty) //CREATING NEW
                        {
                            Create(spAdapter, result);
                            result.AddParentId();
                            if (result.isValid) ABDDocument_ID = (Guid)result.GetLastObject();
                            else return result;
                        }
                        else //UPDATE THE EXISTING
                        {
                            Update(spAdapter, result);
                            if (!result.isValid) return result;


                            //all operations are executed [ABDDocument_to_FileTable_Stream_ID]
                            List<Guid> FeExistingFiles = null;
                            if (files != null && files.Count > 0)
                                FeExistingFiles = files.Select(x => x.ABDDocument_to_FileTable_Stream_ID).ToList();
                            else
                                FeExistingFiles = new List<Guid>();

                            List<Guid> DbExistingFiles = entities.ABDDocument_to_FileTable_StreamFull
                                .Where(x => x.ABDDocument_ID == ABDDocument_ID && x.Row_Status < 100)
                                .Select(x => x.ABDDocument_to_FileTable_Stream_ID)
                                .ToList();

                            IEnumerable<Guid> filesToDelete = DbExistingFiles.Except(FeExistingFiles);
                            foreach (Guid fileId in filesToDelete)
                            {
                                DeleteFile(spAdapter, result, fileId);
                            }

                            var DbExistingDeletedFiles = entities.ABDDocument_to_FileTable_StreamFull
                                .Where(x => x.ABDDocument_ID == ABDDocument_ID && x.Row_Status == 200)
                                .Select(x => x.ABDDocument_to_FileTable_Stream_ID)
                                .ToList();

                            IEnumerable<Guid> filesToUpdate = DbExistingDeletedFiles.Intersect(FeExistingFiles);
                            foreach (Guid relationId in filesToUpdate)
                            {
                                var fileId = entities.ABDDocument_to_FileTable_StreamFull
                                    .Where(x => x.ABDDocument_to_FileTable_Stream_ID == relationId)
                                    .Select(x => x.FileTable_Stream_ID).FirstOrDefault();

                                UpdateFile(spAdapter, result, fileId, relationId);
                            }
                        }
                        moveFiles(spAdapter, result, fileStorageEntities);

                        return result;
                    }
                    catch (Exception ex)
                    {
                        result.AddException(ex);
                        return result;
                    }
                    finally //finally block is operated before any return statement
                    {
                        if (result.isValid) entitiesTransaction.Commit(); else entitiesTransaction.Rollback();
                    }
                }
            }
        }
        public IResult<MsgIdPair> Delete()
        {
            //escape from null ABDDocument:
            if (ABDDocument_ID == null || ABDDocument_ID == Guid.Empty) return null;

            using (var context = new Entities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        spAdapter = new StoredProcedureAdapter(context);
                        result = new MultipleSetsResultIdError<MsgIdPair>();

                        Delete(spAdapter, result);
                        return result;
                    }
                    catch (Exception ex)
                    {
                        result.AddException(ex);
                        return result;
                    }
                    finally
                    {
                        if (result.isValid) transaction.Commit(); else transaction.Rollback();
                    }
                }
            }
        }
        private IResult<T> moveFiles<T>(StoredProcedureAdapter spa, IResult<T> result, FileStorageEntities context) where T : IDataSet<T>
        {
            DraftFileManager Dfm = DraftFileManager.GetInstance();
            while (true)
            {
                string fileName = null;
                try
                {
                    if (Dfm.TryMoveNextFile(out fileName))
                    {
                        Guid newStreamId = context.FileShareTables
                            .Where(x => x.FileName == fileName)
                            .Select(x => x.Stream_Id)
                            .First();
                        CreateFile(spa, result, newStreamId);
                    }
                    else break;
                }
                catch (IOException ioex) {
                    result.AddException(ioex);
                }
            }
            return result;
        }
        private IResult<T> Create<T>(StoredProcedureAdapter spa, IResult<T> procedureResult) where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure
            (
                procedureResult,
                "dbo",
                "ABDDocument_Insert",
                "0",
                UserId.ToString(),
                ABDDocument_Name,
                ABDDocument_Number,
                Issue_Date.ToString(), 
                Sheet_Folder_Number.ToString(),
                Total_Sheets.ToString(),
                Number_in_Folder.ToString(),
                ABDFinalFolder_Name
            );
        }
        private IResult<T> Update<T>(StoredProcedureAdapter spa, IResult<T> procedureResult) where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure
            (
                procedureResult,
                "dbo",
                "ABDDocument_Update",
                ABDDocument_ID,
                "0",
                UserId.ToString(),
                ABDDocument_Name,
                ABDDocument_Number,
                Issue_Date.ToString(),
                Sheet_Folder_Number.ToString(),
                Total_Sheets.ToString(),
                Number_in_Folder.ToString(),
                ABDFinalFolder_Name
            );
        }
        private IResult<T> Delete<T>(StoredProcedureAdapter spa, IResult<T> procedureResult) where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure
            (
                procedureResult,
                "dbo",
                "ABDDocument_Delete",
                UserId.ToString(),
                ABDDocument_ID
            );
        }
        private IResult<T> CreateFile<T>(StoredProcedureAdapter spa, IResult<T> procedureResult, Guid fileStream_Id) where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure
            (
                procedureResult,
                "dbo",
                "ABDDocument_to_FileTable_Stream_Insert",
                "0",
                UserId.ToString(),
                ABDDocument_ID,
                fileStream_Id
            );
        }
        private IResult<T> UpdateFile<T>(StoredProcedureAdapter spa, IResult<T> procedureResult, Guid fileStream_Id, Guid relation_Id) where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure
            (
                procedureResult,
                "dbo",
                "ABDDocument_to_FileTable_Stream_Update",
                relation_Id,
                "0",
                UserId.ToString(),
                ABDDocument_ID,
                fileStream_Id
            );
        }
        private IResult<T> DeleteFile<T>(StoredProcedureAdapter spa, IResult<T> procedureResult, Guid relation_Id) where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure
            (
                procedureResult,
                "dbo",
                "ABDDocument_To_FileTable_Stream_Delete",
                UserId.ToString(),
                relation_Id
            );
        }
    }
}