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

            if (string.IsNullOrEmpty(User_Password))
            {
                // set garbage password if none provided when creating new user 
                if (entity.User_Password == null)
                {
                    entity.User_Password = new Encryptor3DES(ApplicationUser.passKey).encrypt(
                        Encoding.UTF8.GetBytes(Guid.NewGuid().ToString())
                    );
                }
            }
            else
            {
                entity.User_Password = new Encryptor3DES(ApplicationUser.passKey).encrypt(
                    Encoding.UTF8.GetBytes(User_Password)
                );
            }

        }
    }
}