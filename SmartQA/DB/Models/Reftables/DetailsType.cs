using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Table("p_DetailsType")]
    public class DetailsType : CommonEntity
    {
        [Key]
        public System.Guid DetailsType_ID { get; set; }
        [Required]
        public string DetailsType_Code { get; set; }
        public string Description_Rus { get; set; }
    }
}
