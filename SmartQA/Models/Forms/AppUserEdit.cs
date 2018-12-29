using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SmartQA.Auth;
using SmartQA.DB.Models.Auth;
using SmartQA.Models.Shared;
using SmartQA.Util;

namespace SmartQA.Models
{
    public class AppUserEdit: EntityForm<AppUser>
    {
        public Guid? AppUser_ID { get; set; }
        
        [Required]
        public string AppUser_Code { get; set; }
        public string User_Password { get; set; }
        public List<Guid> Role_IDs { get; set; }
        
        public override void Serialize(AppUser entity)
        {
            entity.AppUser_Code = AppUser_Code;
            entity.Role_IDs = Role_IDs;

            entity.User_Password = string.IsNullOrEmpty(User_Password)
                ? null
                : new Encryptor3DES(ApplicationUser.passKey).encrypt(
                    Encoding.UTF8.GetBytes(User_Password)
                );
        }
    }
}