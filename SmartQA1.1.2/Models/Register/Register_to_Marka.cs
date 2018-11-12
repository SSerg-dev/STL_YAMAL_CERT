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
    public class Register_to_Marka
    {
        private Guid Register_ID;
        private List<Guid> Markas;
        private uint Current_Iteration;

        private Guid UserId { get { return Guid.Parse(HttpContext.Current.User.Identity.GetUserId()); } }

        public Register_to_Marka(Guid Register_ID, uint Current_Iteration, List<Guid> markas)
        {
            this.Register_ID = Register_ID;
            this.Current_Iteration = Current_Iteration;

            Markas = markas;
        }
        public IResult<MsgIdPair> Save(WEB_MainDataEntities context)
        {
            var dbRelations = context.p_Register_to_Marka.Where(x => x.Register_ID == Register_ID && x.Iteration == Current_Iteration).ToList();

            var dbRelations_200 = dbRelations.Where(x => x.RowStatus == 200).ToList();
            var dbRelations_0 = dbRelations.Where(x => x.RowStatus == 0).ToList();

            var dbRelationsToCreate = Markas.Except(dbRelations.Select(x => x.Marka_ID).ToList()).ToList();
            var dbRelationsToRestore = dbRelations_200.Where(x => Markas.Contains(x.Marka_ID)).ToList();
            var dbRelationsToDelete = dbRelations_0.Where(x => !Markas.Contains(x.Marka_ID)).ToList();

            StoredProcedureAdapter spa = new StoredProcedureAdapter(context);
            MultipleSetsResultIdError<MsgIdPair> result = new MultipleSetsResultIdError<MsgIdPair>();

            foreach (var id in dbRelationsToCreate) Insert(spa, result, id);
            foreach (var relation in dbRelationsToRestore) Restore(spa, result, relation);
            foreach (var relation in dbRelationsToDelete) Delete(spa, result, relation);

            return result;
        }

        public IResult<T> Insert<T>(StoredProcedureAdapter spa, IResult<T> result, Guid marka_ID) where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure(
                result,
                "dbo",
                "Register_to_Marka_Insert",
                0,
                UserId,
                Register_ID,
                marka_ID,
                Current_Iteration
            );
        }
        public IResult<T> Restore<T>(StoredProcedureAdapter spa, IResult<T> result, p_Register_to_Marka obj) where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure(
                result,
                "dbo",
                "Register_to_Marka_Update",
                obj.Register_to_Marka_ID,
                200,
                UserId,
                Register_ID,
                obj.Marka_ID
            );
        }
        public IResult<T> Delete<T>(StoredProcedureAdapter spa, IResult<T> result, p_Register_to_Marka obj) where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure(
                result,
                "dbo",
                "Register_to_Marka_Delete",
                UserId,
                obj.Register_to_Marka_ID
            );
        }
    }
}