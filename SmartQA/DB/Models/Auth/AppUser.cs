using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Auth
{    
    [Table("p_AppUser")]
    public class AppUser : CommonEntity
    {
        [Required]
        [StringLength(255)]
        public string AppUser_Code { get; set; }
        
        [StringLength(250)]
        public string Comment { get; set; }
               
        [StringLength(8000)]
        public byte[] User_Password { get; set; }
                
        [StringLength(8000)]
        public string PasswordHash { get; set; }
        
        public virtual ICollection<AppUser_to_Role> AppUser_to_RoleSet { get; set; }
                        
        public virtual Employee Employee { get; set; }
        
        [NotMapped]
        public ICollection<Role> RoleSet => this.GetM2MObjects<Role>();
        [NotMapped]
        public ICollection<Guid> Role_IDs
        {
            get => this.GetM2MKeys<Role>();
            set => this.SetM2MKeys<Role>(value);                
        }

        
    }
}
