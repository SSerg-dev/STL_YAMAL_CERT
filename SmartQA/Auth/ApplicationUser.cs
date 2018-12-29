using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SmartQA.DB.Models.Auth;
using SmartQA.Util;

namespace SmartQA.Auth
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public override Guid Id { get; set; }
        public override string UserName { get; set; }
        public string Password { get; set; }

        public static byte[] passKey = {
            0x32, 0x44, 0x65, 0x63,
            0x6C, 0x69, 0x6E, 0x65,
            0x34, 0x49, 0x6E, 0x63,
            0x6C, 0x69, 0x6E, 0x65
        };

        public ApplicationUser(AppUser dbUser)
        {
            Id = dbUser.ID;
            UserName = dbUser.AppUser_Code;
            var PasswordEncryptedDB = dbUser.User_Password;
                        
            Password = dbUser.User_Password == null ?
                null :
                Encoding.UTF8.GetString(new Encryptor3DES(passKey).decrypt(PasswordEncryptedDB));
                    
        }

        public bool CheckPassword(string password)
        {
            return Password != null && Password.Equals(password);
        }

        
    }
}
