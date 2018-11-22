using System;
using System.Collections.Generic;
using System.Text;
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
            var userId = Guid.Parse("E43B02A5-1EF1-464D-B527-4EA9F9C6AF74");
            var user = new AppUser()
            {
                RowStatus = 0,
                AppUser_Code = "test_user",
                AppUser_ID = userId,
                Insert_DTS = DateTime.UtcNow,
                Update_DTS = DateTime.UtcNow,
                Created_User_ID = userId,
                Modified_User_ID = userId,
                User_Password = new Encryptor3DES(ApplicationUser.passKey).encrypt(
                    Encoding.UTF8.GetBytes("test_password"))
            };
            context.AppUser.Add(user);
            context.SaveChanges();
        }
    }
}
