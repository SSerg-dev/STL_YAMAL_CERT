using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Auth
{
    [Table("p_AppUser_to_Role")]
    [M2M(typeof(AppUser), typeof(Role))]
    public class AppUser_to_Role : CommonEntity
    {
        public System.Guid AppUser_ID { get; set; }
        public System.Guid Role_ID { get; set; }
        
        public virtual AppUser AppUser { get; set; }
        public virtual Role Role { get; set; }
    }
}