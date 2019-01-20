using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string PasswordHash { get; set; }

        public ApplicationUser(AppUser dbUser)
        {
            Id = dbUser.ID;
            UserName = dbUser.AppUser_Code;            
            PasswordHash = dbUser.PasswordHash;
        }
        
        public AppUser Save(AppUser dbUser)
        {            
            dbUser.PasswordHash = PasswordHash;
            return dbUser;
        }
    }
}
