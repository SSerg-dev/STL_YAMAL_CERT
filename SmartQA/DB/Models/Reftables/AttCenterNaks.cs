using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [UseDefaultReftableEditor]
    [Display(Name = "Аттестационный центр НАКС")]
    [Table("p_AttCenterNaks")]
    public class AttCenterNaks : CommonEntity, IReftableEntity
    {
        [Column("City")] public string City { get; set; }

        [Required]
        [Column("AttCenterNaks_Code")]
        [StringLength(255)]
        public string Title { get; set; }

        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }
    }
}