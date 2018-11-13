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
    [Table("p_Division")]
    public class Division : CommonEntity
    {
        [Key]
        public System.Guid Division_ID { get; set; }
        [Required]
        public string Division_Code { get; set; }

        public System.Guid? Contragent_ID { get; set; }

        public string Division_Name { get; set; }        
        
        [ForeignKey("Contragent_ID")]
        public Contragent Contragent { get; set; }
    }
}
