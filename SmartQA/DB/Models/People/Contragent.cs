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
    [Table("p_Contragent")]
    public class Contragent : CommonEntity
    {
        [Key]
        public System.Guid Contragent_ID { get; set; }
        [Required]
        public string Contragent_Code { get; set; }

        public string Description_Eng { get; set; }
        public string Description_Rus { get; set; }

    }
}
