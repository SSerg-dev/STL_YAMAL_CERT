using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [UseDefaultReftableEditor]
    [Display(Name = "Группа по электробезопасности")]
    [Table("p_ElectricalSafetyAbilitation")]
    public class ElectricalSafetyAbilitation : CommonEntity, IReftableEntity
    {
        [Required]
        [Column("ElectricalSafetyAbilitation_Code")]
        [StringLength(255)]
        public string Title { get; set; }

        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }
    }
}