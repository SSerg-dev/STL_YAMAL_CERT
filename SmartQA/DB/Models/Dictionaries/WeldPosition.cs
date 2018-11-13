using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Dictionaries
{
    [Table("p_WeldPosition")]
    public class WeldPosition : CommonEntity
    {
        [Key]
        public System.Guid WeldPosition_ID { get; set; }
        [Required]
        public string WeldPosition_Code { get; set; }
        public string Description_Rus { get; set; }
    }
}
