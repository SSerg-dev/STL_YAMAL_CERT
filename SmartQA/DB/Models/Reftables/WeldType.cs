using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Вид (способ) сварки (наплавки)")]
    [Table("p_WeldType")]    
    public class WeldType : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("WeldType_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("WeldType_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }
    }
}
