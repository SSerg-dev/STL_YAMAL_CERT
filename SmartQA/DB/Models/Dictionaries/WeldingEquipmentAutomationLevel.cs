using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Dictionaries
{
    [Table("p_WeldingEquipmentAutomationLevel")]
    public class WeldingEquipmentAutomationLevel : CommonEntity
    {
        [Key]
        public System.Guid WeldingEquipmentAutomationLevel_ID { get; set; }
        [Required]
        public string WeldingEquipmentAutomationLevel_Code { get; set; }
        public string Description_Rus { get; set; }
    }
}
