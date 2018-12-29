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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public System.Guid AppUser_ID { get; set; }
        
        [Required]
        [StringLength(255)]
        public string AppUser_Code { get; set; }
        
        [StringLength(250)]
        public string Comment { get; set; }
        
        [Required]
        [StringLength(8000)]
        public byte[] User_Password { get; set; }
        
        [InverseProperty("AppUser")]
        public virtual ICollection<AppUser_to_Role> AppUser_to_RoleSet { get; set; }
                
        [NotMapped]
        public ICollection<Role> RoleSet => this.GetM2MObjects<Role>();
        [NotMapped]
        public ICollection<Guid> Role_IDs
        {
            get => this.GetM2MKeys<Role>();
            set => this.SetM2MKeys<Role>(value);                
        }
        //
//        [InverseProperty("Created_User")]
//        public List<AppUser> CreatedBy_Users { get; set; }
//        [InverseProperty("Modified_User")]
//        public List<AppUser> ModifiedBy_Users { get; set; }

    }
}
