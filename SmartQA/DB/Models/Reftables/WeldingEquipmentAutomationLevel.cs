using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [UseDefaultReftableEditor]
    [Display(Name = "Степень автоматизации сварочного оборудования")]
    [Table("p_WeldingEquipmentAutomationLevel")]
    public class WeldingEquipmentAutomationLevel : CommonEntity, IReftableEntity
    {
        [Required]
        [Column("WeldingEquipmentAutomationLevel_Code")]
        [StringLength(255)]
        public string Title { get; set; }

        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }
    }
}