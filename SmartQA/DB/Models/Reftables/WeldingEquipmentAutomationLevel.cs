using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Степень автоматизации сварочного оборудования")]
    [Table("p_WeldingEquipmentAutomationLevel")]
    public class WeldingEquipmentAutomationLevel : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("WeldingEquipmentAutomationLevel_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("WeldingEquipmentAutomationLevel_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }
    }
}
