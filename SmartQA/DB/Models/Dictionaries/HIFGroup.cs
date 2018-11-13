using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Dictionaries
{
    [Table("p_HIFGroup")]
    public class HIFGroup : CommonEntity
    {
        [Key]
        public Guid HIFGroup_ID { get; set; }

        [Required]
        public string HIFGroup_Code { get; set; }
        public string Description_Rus { get; set; }
    }
}
