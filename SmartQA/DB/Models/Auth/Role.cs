using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Auth
{
    [Table("p_Role")]
    public class Role : CommonEntity
    {
        [Key]
        public System.Guid Role_ID { get; set; }
        public string Role_Code { get; set; }

        [InverseProperty("Role")]
        public virtual List<AppUser_to_Role> AppUser_to_Roles { get; set; }
    }
}
