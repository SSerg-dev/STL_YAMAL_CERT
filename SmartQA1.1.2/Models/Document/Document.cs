using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Microsoft.AspNet.Identity;
using SmartQA1._1._2;
using SmartQA1._1._2.DB.EntityFramework;
using SmartQA1._1._2.DB.StoredProcedures;
using SmartQA1._1._2.DB.WebDb;
using SmartQA1._1._2.Exceptions;
using SmartQA1._1._2.Logging;
using SmartQA1._1._2.Models.ABDDocument;
using SmartQA1._1._2.Models.Login;

namespace SmartQA1._1._2.Models.Document
{
    //make this class partial later
    public class Document
    {
        public Guid Document_ID { get; set; }

        public string Document_Code
        {
            get { return _Document_Code; }
            set { _Document_Code = value; folder = Document_Code + @"\";} 
        }

        private string _Document_Code;

        public string Document_Number { get; set; }
        public Guid DocumentType_ID { get; set; }
        public string DocumentType_Code { get; set; }
        public DateTime? Document_Date { get; set; }
        public DateTime? Issue_Date { get; set; }
        public uint? TotalSheets { get; set; } //only positibe integer
        public string Document_Name { get; set; }
        public Guid? Parent_ID { get; set; }
        public string Responsible { get; set; } //map this property after implementing in the DB
        public int? FilesQTY { get; set; }
        public Guid Status_ID { get; set; }
        public string Status_Name { get; set; }
        public Guid Document_to_Status_ID { get; set; }

        public List<UI_FileStream> DocumentFiles;
        public IList<DocumentType> DocumentTypes;
        public List<Status> DocumentStatuses;

        public Guid? GOST_ID { get; set; }
        public string Gost_Code;
        public Guid? Document_to_GOST_ID { get; set; }

        public Guid? PID_ID { get; set; }
        public string PID_Code;
        public Guid? Document_to_PID_ID { get; set; }

        public bool IsEditEnabled { get; set; } //for UI - determines if user can edit document card
        public bool IsStatusChangeEnabled { get; set; } //for new documents this property is set to false

        private IResult<MsgIdPair> result;
        private StoredProcedureAdapter spAdapter;
        private string folder; //folder in FileShare where all document files are kept
        private WEB_MainDataEntities context;

        private Guid UserId { get { return Guid.Parse(HttpContext.Current.User.Identity.GetUserId()); } }

        /// <summary>
        /// Default parameterless constructor used by the AutoMapper
        /// </summary>
        public Document()
        {
        }
        /// <summary>
        /// Used by the controller to create new document or retrieve the existing document for editing
        /// </summary>
        public Document(WEB_MainDataEntities context, Guid? Document_ID = null)
        {    
            this.context = context;

            if (Document_ID != null)
            {
                RetrieveExistingDocument((Guid) Document_ID);
            }
            else CreateNewDocument();

            DocumentTypes = context.DocumentTypes.OrderBy(x => x.DocumentType_Code).ToList();
            DocumentStatuses = context.Status.Where(x => x.StatusEntity == "Document").ToList();

            //whether document edit enabled is defined on it's status
            try
            {
                IsEditEnabled = !(bool) context.Status.First(x => x.Status_ID == Status_ID).EntityLocked;
            }
            catch (InvalidOperationException ioe) //https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.first?view=netframework-4.7.2#System_Linq_Enumerable_First__1_System_Collections_Generic_IEnumerable___0__System_Func___0_System_Boolean__
            {
                throw new DatabaseStateException(
                    "No Status found in view Status or Status_ID of the template " +
                    "T_Document_List is invalid. Status of template: " +Status_ID, 
                    ioe);
            }
        }
        /// <summary>
        /// Used to create new Document
        /// </summary>
        public void CreateNewDocument()
        {
            //retrieve template from the DB:
            T_Document_List template = null;
            try
            {
                template = context.T_Document_List.Single();
            }
            catch (InvalidOperationException ioe)
            {
                var databaseStateException =
                    new DatabaseStateException(
                        "No parent template or more than one found " +
                        "for UI_Document_List in T_Document view", ioe);
                throw databaseStateException;
            }
            
            var cfg = new MapperConfiguration(c => c.CreateMap<T_Document_List, Document>());
            var mapper = cfg.CreateMapper();
            mapper.Map(template, this);

            Issue_Date = DateTime.Now;
            Document_Code = context.Document_SequenceNumber().First().ToString();

            IsStatusChangeEnabled = false;
        }
        /// <summary>
        /// Used to retrieve the existing document for editings
        /// </summary>
        private void RetrieveExistingDocument(Guid Document_ID)
        {
            var dbDocument = context.UI_Document_List.First(x => x.Document_ID == Document_ID);
            var cfg = new MapperConfiguration(c => c.CreateMap<UI_Document_List, Document>());
            var mapper = cfg.CreateMapper();

            mapper.Map(dbDocument, this);

            //associating GOST:
            var Gost = context.UI_Document_to_GOST.FirstOrDefault(x => x.Document_ID == Document_ID);
            if (Gost != null)
            {
                GOST_ID = Gost.GOST_ID;
                Gost_Code = Gost.GOST_Code;
                Document_to_GOST_ID = Gost.Document_to_GOST_ID;
            }

            //associating Pid:
            var Pid = context.UI_Document_to_PID.FirstOrDefault(x => x.Document_ID == Document_ID);
            if (Pid != null)
            {
                PID_ID = Pid.PID_ID;
                PID_Code = Pid.PID_Code;
                Document_to_PID_ID = Pid.Document_to_PID_ID;
            }

            DocumentFiles = context.UI_FileStream.Where(x => x.Document_ID == Document_ID).ToList();

            IsStatusChangeEnabled = true;
        }
        public static List<UI_Document_List> GetList()
        {
            using (WEB_MainDataEntities db = new WEB_MainDataEntities())
            {
                return db.UI_Document_List.OrderBy(x=>x.Document_Code).ToList();
            }
        }

        public IResult<MsgIdPair> SaveNew(WEB_MainDataEntities context)
        {
            var newDocument = new Document(context);

            using (var db = new WEB_MainDataEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    result = new MultipleSetsResultIdError<MsgIdPair>();
                    spAdapter = new StoredProcedureAdapter(db);

                    try
                    {
                        //CREATE DOCUMENT
                        Insert(spAdapter, result);
                        if (!result.isValid) return result;

                        Document_ID = (Guid)result.GetLastObject();

                        if (GOST_ID != null) GostInsert(spAdapter, result);
                        if (PID_ID != null) PidInsert(spAdapter, result);

                        StatusInsert(spAdapter, result);
                    }
                    catch (Exception ex)
                    {
                        result.AddException(ex);
                        new Logger(ex).Log();
                        return result;
                    }
                    finally
                    {
                        if (result.isValid) transaction.Commit(); else transaction.Rollback();
                    }
                }
                return SaveNewFiles(spAdapter, result, db);
            }
        }
        public IResult<MsgIdPair> SaveExisting(List<UI_FileStream> filesLeft, WEB_MainDataEntities context)
        {
            using (var db = new WEB_MainDataEntities())
            {
                Document oldDocument = new Document(context, Document_ID);

                DocumentFiles = db.UI_FileStream.Where(x => x.Document_ID == Document_ID).ToList();
                var filesToDelete = filesLeft != null ? DocumentFiles?.Except(filesLeft).ToList() : null;

                using (var transaction = db.Database.BeginTransaction())
                {
                    result = new MultipleSetsResultIdError<MsgIdPair>();
                    spAdapter = new StoredProcedureAdapter(db);

                    
                    try
                    {
                        //UPDATE DOCUMENT  
                        Update(spAdapter, result);
                        if (!result.isValid) return result;

                        if (oldDocument.GOST_ID == null)
                        {
                            if (GOST_ID != null) GostInsert(spAdapter, result);
                        }
                        else
                        {
                            if (oldDocument.Document_to_GOST_ID == null)
                            {
                                throw new DatabaseStateException(
                                    "GOST_ID is not null, but Document_to_GOST_ID is null for Document: "
                                    + oldDocument.Document_ID);
                            }
                            if (GOST_ID == null) GostDelete(spAdapter, result, (Guid) oldDocument.Document_to_GOST_ID);
                            else if (GOST_ID != oldDocument.GOST_ID)
                                GostUpdate(spAdapter, result, (Guid)oldDocument.Document_to_GOST_ID);

                        }

                        if (oldDocument.PID_ID == null)
                        {
                            if (PID_ID != null) PidInsert(spAdapter, result);
                        }
                        else
                        {
                            if (oldDocument.Document_to_PID_ID == null)
                            {
                                throw new DatabaseStateException(
                                    "PID_ID is not null, but Document_to_PID_ID is null for Document: "
                                    + oldDocument.Document_ID
                                );
                            }
                            if (PID_ID == null) PidDelete(spAdapter, result, (Guid) oldDocument.Document_to_PID_ID);
                            else if (PID_ID != oldDocument.PID_ID)
                                PidUpdate(spAdapter, result, (Guid)oldDocument.Document_to_PID_ID);
                        }
                        
                        if (Status_ID != oldDocument.Status_ID)
                        {
                            try
                            {
                                StatusUpdate(spAdapter, result, oldDocument.Document_to_Status_ID);
                            }
                            catch (InvalidOperationException ioe)
                            {
                                throw new DatabaseStateException(
                                    "Document_to_Status_ID was null for document "+Document_ID, ioe);
                            }
                        }                                                                               
                        
                        //delete required files:
                        //foreach (var fileToDelete in filesToDelete)
                        //{
                        //    FileDelete(spAdapter, result, fileToDelete.Document_to_FileTable_ID);
                        //}
                    }
                    catch (Exception ex)
                    {
                        result.AddException(ex);
                        new Logger(ex).Log();
                        return result;
                    }
                    finally
                    {
                        if (result.isValid) transaction.Commit(); else transaction.Rollback();
                    }
                }

                return SaveNewFiles(spAdapter, result, db, oldDocument, filesToDelete);
            }
        }
        /// <summary>
        /// This method calls DraftFileManager to save files to \25_AsBuilt_Documentation,
        /// opens new transaction,
        /// then establishes connection of the current document to new FileStreams
        /// This method is transparent for exception bubbling (no catch blocks)
        /// </summary>
        private IResult<T> SaveNewFiles<T>(StoredProcedureAdapter spa, IResult<T> result, WEB_MainDataEntities db, Document oldDocument = null ,List<UI_FileStream> filesMarkedForDelete = null) where T : IDataSet<T>
        {
            //saving new files (File system operation): 
            List<String> newFileNames;
            if (!result.isValid) return result;
            try
            {
                //File system operations happen outside SQL Server transaction:
                newFileNames = DraftFileManager.GetInstance().MoveFiles(folder);
            }
            catch (Exception ex)
            {
                result.AddException(ex);
                return result;
            }
            

            //saving new streams (DB operation):
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    //escape if no files have been moved:
                    if (newFileNames != null && newFileNames.Count > 0)
                    {
                        //retrieving new Stream_Id
                        List<FileShareTable> newFileStreams;
                        using (var sqlFileShare = new FileStorageEntities())
                        {
                            newFileStreams =
                            (
                                from fileStream in sqlFileShare.FileShareTables
                                where newFileNames.Contains(fileStream.PathNonDefault)
                                select fileStream
                            ).ToList();
                        }

                        //updating existing streams
                        if (oldDocument != null && oldDocument.DocumentFiles != null && oldDocument.DocumentFiles.Any())
                        {
                            var streamsToUpdate =
                                from oldStream in oldDocument.DocumentFiles
                                join newStream in newFileStreams on oldStream.name equals newStream.FileName
                                select new
                                {
                                    oldStreamId = oldStream.FileTable_ID,
                                    streamToDocumentId = oldStream.Document_to_FileTable_ID,
                                    newStreamId = newStream.Stream_Id
                                };
                            if (streamsToUpdate != null && streamsToUpdate.Any())
                            {
                                foreach (var stream in streamsToUpdate)
                                {
                                    FileUpdate(spAdapter, result, stream.streamToDocumentId, stream.newStreamId);
                                    newFileStreams.RemoveAll(x => x.Stream_Id == stream.newStreamId);

                                    //no need to delete files that were marked as files for deleting, but
                                    //than user decided to attach them again
                                    filesMarkedForDelete?.RemoveAll(x => x.FileTable_ID == stream.oldStreamId);
                                }
                            }
                        }

                        //inserting new streams that were left after updating
                        foreach (var stream in newFileStreams)
                        {
                            FileInsert(spAdapter, result, stream.Stream_Id);
                        }
                    }

                    //deleting old files that were marked for deleting after updating
                    if (filesMarkedForDelete != null)
                        foreach (var stream in filesMarkedForDelete)
                            FileDelete(spAdapter, result, stream.Document_to_FileTable_ID);
                }
                catch (Exception ex)
                {
                    result.AddException(ex);
                    new Logger(ex).Log();
                    return result;
                }
                finally
                {
                    if (result.isValid) {transaction.Commit();} else transaction.Rollback();
                }
                //File system operations happen outside SQL Server transaction
                //transaction must been commited:
                if (!result.isValid) return result;

                if (filesMarkedForDelete != null)
                {
                    var clf = new CleanFileManager();
                    var fileGuidsToDelete = filesMarkedForDelete.Select(x => x.FileTable_ID).ToList();
                    var fileNamesForDelete =
                        oldDocument.DocumentFiles
                            .Where(x => fileGuidsToDelete.Contains(x.FileTable_ID))
                            .Select(x=>folder+x.name)
                            .ToList();
                    clf.DeleteFiles(fileNamesForDelete);
                }
            }
             
            return result;
        }

        public IResult<MsgIdPair> Delete()
        {
            result = new MultipleSetsResultIdError<MsgIdPair>();
            spAdapter = new StoredProcedureAdapter(context);

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Delete(spAdapter, result);
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

            return result;
        }
        private void Insert<T>(StoredProcedureAdapter spa, IResult<T> result) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Document_Insert",
                "0",
                UserId.ToString(),
                Document_Code,
                Document_Number,
                DocumentType_ID.ToString(),
                DateKit.DateTime2Sql(Document_Date),
                DateKit.DateTime2Sql(Issue_Date),
                TotalSheets.ToString(),
                Document_Name,
                Parent_ID
            );
        }
        private void Update<T>(StoredProcedureAdapter spa, IResult<T> result) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Document_Update",
                Document_ID,
                "0",
                UserId,
                Document_Code,
                Document_Number,
                DocumentType_ID.ToString(),
                DateKit.DateTime2Sql(Document_Date),
                DateKit.DateTime2Sql(Issue_Date),
                TotalSheets.ToString(),
                Document_Name,
                Parent_ID
            );
        }
        private void Delete<T>(StoredProcedureAdapter spa, IResult<T> result) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Document_Delete",
                UserId.ToString(),
                Document_ID
            );
        }
        private void GostUpdate<T>(StoredProcedureAdapter spa, IResult<T> result, Guid Document_to_GOST_ID) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Document_to_GOST_Update",
                Document_to_GOST_ID,
                "0",
                UserId,
                Document_ID,
                GOST_ID
            );
        }
        private void GostInsert<T>(StoredProcedureAdapter spa, IResult<T> result) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Document_to_GOST_Insert",
                "0",
                UserId,
                Document_ID,
                GOST_ID
            );
        }
        private void GostDelete<T>(StoredProcedureAdapter spa, IResult<T> result, Guid Document_to_GOST_ID) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
(
                result,
                "dbo",
                "Document_to_GOST_Delete",
                UserId,
                Document_to_GOST_ID
            );
        }
        private void PidInsert<T>(StoredProcedureAdapter spa, IResult<T> result) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Document_to_PID_Insert",
                "0",
                UserId,
                Document_ID,
                PID_ID
            );
        }
        private void PidUpdate<T>(StoredProcedureAdapter spa, IResult<T> result, Guid Document_to_PID_ID) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Document_to_PID_Update",
                Document_to_PID_ID,
                "0",
                UserId,
                Document_ID,
                PID_ID
            );
        }
        private void PidDelete<T>(StoredProcedureAdapter spa, IResult<T> result, Guid Document_to_PID_ID) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Document_to_PID_Delete",
                UserId,
                Document_to_PID_ID
            );
        }
        private void FileInsert<T>(StoredProcedureAdapter spa, IResult<T> result, Guid FileTable_ID) 
            where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Document_to_FileTable_Insert",
                "0",
                UserId,
                Document_ID,
                FileTable_ID
            );
        }

        private void FileUpdate<T>(StoredProcedureAdapter spa, IResult<T> result, Guid DocToStream, Guid newStream)
            where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Document_to_FileTable_Update",
                DocToStream,
                "0",
                UserId,
                Document_ID,
                newStream
            );
        }

        private void FileDelete<T>(StoredProcedureAdapter spa, IResult<T> result, Guid DocToFile_ID)
            where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Document_To_FileTable_Delete",
                UserId,
                DocToFile_ID
            );
        }

        private void StatusInsert<T>(StoredProcedureAdapter spa, IResult<T> result) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Document_to_Status_Insert",
                "0",
                UserId,
                Document_ID,
                Status_ID,
                null
            );
        }
        private void StatusUpdate<T>(StoredProcedureAdapter spa, IResult<T> result, Guid Document_to_Status_ID) where T : IDataSet<T>
        {
            spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "Document_to_Status_Update",
                Document_to_Status_ID,
                "0",
                UserId,
                Document_ID,
                Status_ID
            );
        }
    }
}