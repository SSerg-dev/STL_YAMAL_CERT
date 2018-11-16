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
        public System.Guid WeldType_ID { get; set; }
        [Required]
        public string WeldType_Code { get; set; }
        public string Description_Rus { get; set; }

        [NotMapped]
        public string Title { get => WeldType_Code; set => WeldType_Code = value; }
        [NotMapped]
        public string Description { get => Description_Rus; set => Description_Rus = value; }
    }
}
