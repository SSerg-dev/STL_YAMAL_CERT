using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartQA.Auth;
using SmartQA.DB;
using SmartQA.DB.Models.Auth;
using SmartQA.Util;

namespace SmartQA.Tests.Util
{
    class DB
    {
        public static async void InitializeDbForTests(DataContext context, AppUserManager appUserManager)
        {
            var user1 = new AppUser
            {
                RowStatus = 0,
                AppUser_Code = "test_user",
                ID = Guid.NewGuid(),
                Insert_DTS = DateTime.UtcNow,
                Update_DTS = DateTime.UtcNow,
                Created_User_ID = DataContext.rootUserId,
                Modified_User_ID = DataContext.rootUserId,
            };
            
            var user2 = new AppUser
            {
                RowStatus = 0,
                AppUser_Code = "test_user_nopassword",
                ID = Guid.NewGuid(),
                Insert_DTS = DateTime.UtcNow,
                Update_DTS = DateTime.UtcNow,
                Created_User_ID = DataContext.rootUserId,
                Modified_User_ID = DataContext.rootUserId,
            };
            
            user1.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(new ApplicationUser(user1), "test_password");
            
            context.Set<AppUser>().AddRange(user1, user2);            
            
            context.SaveChanges();            
        }
    }
}
