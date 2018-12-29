using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Auth
{
    [Table("p_AppUser_to_Role")]
    public class AppUser_to_Role : M2MEntity
    {
        public System.Guid AppUser_ID { get; set; }
        public System.Guid Role_ID { get; set; }

        [ForeignKey("AppUser_ID")]
        public virtual AppUser AppUser { get; set; }
        [ForeignKey("Role_ID")]
        public virtual Role Role { get; set; }

    }
}
