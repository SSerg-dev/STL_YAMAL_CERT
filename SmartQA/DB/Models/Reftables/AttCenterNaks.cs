using SmartQA.DB.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Аттестационный центр НАКС")]
    [Table("p_AttCenterNaks")]
    public class AttCenterNaks : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("AttCenterNaks_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("AttCenterNaks_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }
        [Column("City")]
        public string City { get; set; }
    }
}
