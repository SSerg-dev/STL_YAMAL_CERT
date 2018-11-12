using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SmartQA1._1._2.App_Start;
using SmartQA1._1._2.DB.Logging;
using SmartQA1._1._2.Models.Login;
using SmartQA1._1._2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace SmartQA1._1._2.Authentication
{
    public class User : IUser<Guid>
    {
        public Guid Id { get; private set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        private static byte[] p1 = {
                0x32, 0x44, 0x65, 0x63,
                0x6C, 0x69, 0x6E, 0x65,
                0x34, 0x49, 0x6E, 0x63,
                0x6C, 0x69, 0x6E, 0x65
        };

        public User(AppUser dbUser)
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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, Guid> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public static User GetFromContext(HttpContext context)
        {
            var identity = context.User.Identity;
            if (identity.IsAuthenticated)
            {
                return context.GetOwinContext().GetUserManager<ApplicationUserManager>()
                    .FindById(Guid.Parse(identity.GetUserId()));
            }

            return null;
        }
    }
}