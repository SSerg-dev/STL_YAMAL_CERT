using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [UseDefaultReftableEditor]
    [Display(Name = "Группа свариваемого материала")]
    [Table("p_WeldMaterialGroup")]
    public class WeldMaterialGroup : CommonEntity, IReftableEntity
    {
        [Required]
        [Column("WeldMaterialGroup_Code")]
        [StringLength(255)]
        public string Title { get; set; }

        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }
    }
}