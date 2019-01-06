using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Auth
{
    [Table("p_Role")]
    public class Role : CommonEntity
    {
        [Required]
        [StringLength(255)]
        public string Role_Code { get; set; }
        
        public virtual List<AppUser_to_Role> AppUser_to_RoleSet { get; set; }
    }
}
