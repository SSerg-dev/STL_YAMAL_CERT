using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SmartQA.Auth;
using SmartQA.DB;
using SmartQA.DB.Models.Auth;
using SmartQA.Util;

namespace SmartQA.Tests.Util
{
    class DB
    {
        public static void InitializeDbForTests(DataContext context)
        {            
            context.Set<AppUser>().AddRange(new AppUser
                    {
                        RowStatus = 0,
                        AppUser_Code = "test_user",
                        ID = Guid.NewGuid(),
                        Insert_DTS = DateTime.UtcNow,
                        Update_DTS = DateTime.UtcNow,
                        Created_User_ID = DataContext.rootUserId,
                        Modified_User_ID = DataContext.rootUserId,
                        User_Password = new Encryptor3DES(ApplicationUser.passKey).encrypt(
                            Encoding.UTF8.GetBytes("test_password"))
                    },
            
                     new AppUser
                     {
                         RowStatus = 0,
                         AppUser_Code = "test_user_nopassword",
                         ID = Guid.NewGuid(),
                         Insert_DTS = DateTime.UtcNow,
                         Update_DTS = DateTime.UtcNow,
                         Created_User_ID = DataContext.rootUserId,
                         Modified_User_ID = DataContext.rootUserId,
                         User_Password = null
                     }
                );
            
            
            context.SaveChanges();
        }
    }
}
