using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Auth;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.People
{
    [Table("p_Position")]
    public class Position : CommonEntity
    {
        [Key]
        public System.Guid Position_ID { get; set; }
        [Required]
        public string Position_Code { get; set; }

        public System.Guid Division_ID { get; set; }

        public string Description_Eng { get; set; }
        public string Description_Rus { get; set; }

        [ForeignKey("Division_ID")]
        public virtual Division Division { get; set; }

    }
}
