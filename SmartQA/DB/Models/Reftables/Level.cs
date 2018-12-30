using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [UseDefaultReftableEditor]
    [Display(Name = "Уровень специалиста")]
    [Table("p_Level")]
    public class Level : CommonEntity, IReftableEntity
    {
        [Required]
        [Column("Level_Code")]
        [StringLength(255)]
        public string Title { get; set; }

        [Column("Description_Rus")]
        [StringLength(500)]
        public string Description { get; set; }

    }
}
