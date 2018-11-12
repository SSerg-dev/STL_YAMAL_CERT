using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartQA1._1._2.DB.StoredProcedures;
using SmartQA1._1._2.Models.Login;

namespace SmartQA1._1._2.DB.Logging
{

    public partial class AppUser
    {
        internal bool ValidatePassword(string password)
        {
            // FIXME: check password
            return true;
        }

        public Role_Code GetUserRole(LogAuthSchema context)
        {
            var result = new UserGetResult<MsgIdPair>(AppUser_ID);
            var spa = new StoredProcedureAdapter(context);

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    spa.ExecuteStoredProcedure(
                        result,
                        "dbo",
                        "User_FormType_Get",
                        AppUser_ID
                    );

                    var RoleCode = result.RoleCode;
                    return RoleCode;
                    
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }

            }

        }
    }
}
