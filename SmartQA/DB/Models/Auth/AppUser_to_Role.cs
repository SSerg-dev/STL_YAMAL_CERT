using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Auth
{
    [Table("p_AppUser_to_Role")]
    public class AppUser_to_Role : CommonEntity
    {
        [Key]
        public System.Guid AppUser_to_Role_ID { get; set; }

        public System.Guid AppUser_ID { get; set; }
        public System.Guid Role_ID { get; set; }

        [ForeignKey("AppUser_ID")]
        public AppUser AppUser { get; set; }
        [ForeignKey("Role_ID")]
        public Role Role { get; set; }

    }
}
