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
    public class Register_to_TitleObject
    {
        private readonly Guid Register_ID;
        private readonly List<Guid> TitleObjects;
        private readonly uint Current_Iteration;

        private Guid UserId { get { return Guid.Parse(HttpContext.Current.User.Identity.GetUserId()); } }

        public Register_to_TitleObject(Guid Register_ID, uint Current_Iteration, List<Guid> titleObjects)
        {
            this.Register_ID = Register_ID;
            this.Current_Iteration = Current_Iteration;

            TitleObjects = titleObjects;
        }
        public IResult<MsgIdPair> Save(WEB_MainDataEntities context)
        {
            //retrieving the existing to-relations:
            var dbRelations = context.p_Register_to_TitleObject.Where(x => x.Register_ID == Register_ID && x.Iteration == Current_Iteration).ToList();

            var dbRelations_200 = dbRelations.Where(x => x.RowStatus == 200).ToList();
            var dbRelations_0 = dbRelations.Where(x => x.RowStatus == 0).ToList();

            List<Guid> dbRelationsToCreate = TitleObjects.Except(dbRelations.Select(x => x.TitleObject_ID).ToList()).ToList();
            List<p_Register_to_TitleObject> dbRelationsToRestore = dbRelations_200.Where(x => TitleObjects.Contains(x.TitleObject_ID)).ToList();
            List<p_Register_to_TitleObject> dbRelationsToDelete = dbRelations_0.Where(x => !TitleObjects.Contains(x.TitleObject_ID)).ToList();

            StoredProcedureAdapter spa = new StoredProcedureAdapter(context);
            MultipleSetsResultIdError<MsgIdPair>  result = new MultipleSetsResultIdError<MsgIdPair>();

            foreach (var id in dbRelationsToCreate) Insert(spa, result, id);
            foreach (var relation in dbRelationsToRestore) Restore(spa, result, relation);
            foreach (var relation in dbRelationsToDelete) Delete(spa, result, relation);

            return result;
        }

        public IResult<T> Insert<T>(StoredProcedureAdapter spa, IResult<T> result, Guid titleObject_ID) where T: IDataSet<T>
        {
            return spa.ExecuteStoredProcedure(
                result,
                "dbo",
                "Register_to_TitleObject_Insert",
                0, //RowStatus
                UserId,
                Register_ID,
                titleObject_ID,
                Current_Iteration
            );
        }
        public IResult<T> Restore<T>(StoredProcedureAdapter spa, IResult<T> result, p_Register_to_TitleObject obj) where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure(
                result,
                "dbo",
                "Register_to_TitleObject_Update",
                obj.Register_to_TitleObject_ID,
                0, //RowStatus
                UserId,
                Register_ID,
                obj.TitleObject_ID,
                Current_Iteration
            );
        }
        public IResult<T> Delete<T>(StoredProcedureAdapter spa, IResult<T> result, p_Register_to_TitleObject obj) where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure(
                result,
                "dbo",
                "Register_to_TitleObject_Delete",
                UserId,
                obj.Register_to_TitleObject_ID
            );
        }

    }
}