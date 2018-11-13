using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Dictionaries
{
    [Table("p_SeamsType")]
    public class SeamsType : CommonEntity
    {
        [Key]
        public System.Guid SeamsType_ID { get; set; }
        [Required]
        public string SeamsType_Code { get; set; }
        public string Description_Rus { get; set; }
    }
}
