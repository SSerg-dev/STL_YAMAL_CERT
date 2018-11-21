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

        private static byte[] p1 = {
            0x32, 0x44, 0x65, 0x63,
            0x6C, 0x69, 0x6E, 0x65,
            0x34, 0x49, 0x6E, 0x63,
            0x6C, 0x69, 0x6E, 0x65
        };

        public ApplicationUser(AppUser dbUser)
        {
            Id = dbUser.AppUser_ID;
            UserName = dbUser.AppUser_Code;
            var PasswordEncryptedDB = dbUser.User_Password;
            if (dbUser.User_Password != null)
            {
                var TdesEncryptor = new Encryptor3DES(p1);
                var PasswordDecryptedDB = TdesEncryptor.decrypt(PasswordEncryptedDB);
                Password = Encoding.UTF8.GetString(PasswordDecryptedDB);
            }            
        }

        public bool CheckPassword(string password)
        {
            return Password.Equals(password);
        }

        
    }
}
