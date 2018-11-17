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
        public System.Guid WeldingEquipmentAutomationLevel_ID { get; set; }
        [Required]
        public string WeldingEquipmentAutomationLevel_Code { get; set; }
        public string Description_Rus { get; set; }

        [NotMapped]
        public string Title { get => WeldingEquipmentAutomationLevel_Code; set => WeldingEquipmentAutomationLevel_Code = value; }
        [NotMapped]
        public string Description { get => Description_Rus; set => Description_Rus = value; }
    }
}
