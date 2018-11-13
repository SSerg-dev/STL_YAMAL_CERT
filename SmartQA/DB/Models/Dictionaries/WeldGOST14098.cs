using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Dictionaries
{
    [Table("p_WeldGOST14098")]
    public class WeldGOST14098 : CommonEntity
    {
        [Key]
        public System.Guid WeldGOST14098_ID { get; set; }
        [Required]
        public string WeldGOST14098_Code { get; set; }
        public string Description_Rus { get; set; }
    }
}
