using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Table("p_WeldMaterialGroup")]
    public class WeldMaterialGroup : CommonEntity
    {
        [Key]
        public System.Guid WeldMaterialGroup_ID { get; set; }
        [Required]
        public string WeldMaterialGroup_Code { get; set; }
        public string Description_Rus { get; set; }
    }
}
