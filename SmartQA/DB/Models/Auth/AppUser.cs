using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Auth
{    
    [Table("p_AppUser")]
    public class AppUser : CommonEntity
    {
        [Key]
        public System.Guid AppUser_ID { get; set; }
        public string AppUser_Code { get; set; }
        
        public string Comment { get; set; }
        public byte[] User_Password { get; set; }
        
        [InverseProperty("AppUser")]
        public List<AppUser_to_Role> AppUser_to_Roles { get; set; }

        [InverseProperty("Created_User")]
        public List<AppUser> CreatedBy_Users { get; set; }
        [InverseProperty("Modified_User")]
        public List<AppUser> ModifiedBy_Users { get; set; }

    }
}
