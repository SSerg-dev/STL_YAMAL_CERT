using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using SmartQA1._1._2.DB.StoredProcedures;
using SmartQA1._1._2.DB.WebDb;
using SmartQA1._1._2.Models.Login;

namespace SmartQA1._1._2.Models.Register
{
    public class Register_to_Document
    {
        private readonly Guid Register_ID;
        private readonly List<UI_Register_ListItem> Documents;
        private readonly uint Current_Iteration;

        private Guid UserId { get { return Guid.Parse(HttpContext.Current.User.Identity.GetUserId()); } }

        public Register_to_Document(Guid Register_ID, uint Current_Iteration, List<UI_Register_ListItem> documents)
        {
            this.Register_ID = Register_ID;
            this.Current_Iteration = Current_Iteration;

            Documents = documents;
        }

        public IResult<MsgIdPair> Save(WEB_MainDataEntities context)
        {
            List<Guid> _documentId = Documents.Select(x => x.Document_ID).ToList();
            var dbRelations = context.p_Register_to_Document
                .Where(x => x.Register_ID == Register_ID && x.Iteration == Current_Iteration)
                .OrderBy(x=>x.NumberInRegister)
                .ToList();

            List<p_Register_to_Document> dbRelations_200 = dbRelations.Where(x => x.RowStatus == 200).ToList();
            List<p_Register_to_Document> dbRelations_0 = dbRelations.Where(x => x.RowStatus == 0).ToList();

            List<Guid> dbRelationsToCreate = _documentId.Except(dbRelations.Select(x => x.Document_ID).ToList()).ToList();
            List<p_Register_to_Document> dbRelationsToRestore = dbRelations_200.Where(x => _documentId.Contains(x.Document_ID)).ToList();
            List<p_Register_to_Document> dbRelationsToDelete = dbRelations_0.Where(x => !_documentId.Contains(x.Document_ID)).ToList();

            List<p_Register_to_Document> dbRelationToDoNothing = dbRelations_0.Except(dbRelationsToDelete).ToList();

            StoredProcedureAdapter spa = new StoredProcedureAdapter(context);
            MultipleSetsResultIdError<MsgIdPair> result = new MultipleSetsResultIdError<MsgIdPair>();

            //this particular order of foreach blocks is very important for enumerating Documents in Registers in right order
            uint i = 0;
            foreach (var relation in dbRelationToDoNothing) Update(spa, result, relation, i++);
            foreach (var document in Documents)
            {
                if (dbRelationsToCreate.Contains(document.Document_ID)) Insert(spa, result, document.Document_ID, i++);

                var documentToRestore = dbRelationsToRestore.First(x => x.Document_ID == document.Document_ID);
                if (documentToRestore != null) Update(spa, result, documentToRestore, i++);

                var documentToDelete = dbRelationsToDelete.First(x => x.Document_ID == document.Document_ID);
                if (documentToDelete != null) Delete(spa, result, documentToDelete);
            }

            return result;
        }

        public IResult<T> Insert<T>(StoredProcedureAdapter spa, IResult<T> result, Guid document_ID, uint NumberInRegister)
            where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure(
                result,
                "dbo",
                "Register_to_Document_Insert",
                0,
                UserId,
                Register_ID,
                document_ID,
                Current_Iteration,
                NumberInRegister,
                0, //SheetFolderNumber
                null // Comment
            );
        }

        public IResult<T> Update<T>(StoredProcedureAdapter spa, IResult<T> result, p_Register_to_Document obj,
            uint NumberInRegister) where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure(
                result,
                "dbo",
                "Register_to_Document_Update",
                obj.Register_to_Document_ID,
                0,
                UserId,
                Register_ID,
                obj.Document_ID,
                Current_Iteration,
                NumberInRegister,
                0, //SheetFolderNumber
                null //Comment
            );
        }

        public IResult<T> Delete<T>(StoredProcedureAdapter spa, IResult<T> result, p_Register_to_Document obj)
            where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure(
                result,
                "dbo",
                "Register_To_Document_Delete",
                UserId,
                obj.Register_to_Document_ID
            );
        }
    }

}