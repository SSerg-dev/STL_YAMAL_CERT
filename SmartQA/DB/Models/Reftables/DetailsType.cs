using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Вид деталей")]
    [Table("p_DetailsType")]
    public class DetailsType : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("DetailsType_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("DetailsType_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }        
    }
}
