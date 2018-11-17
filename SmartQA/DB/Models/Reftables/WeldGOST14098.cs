using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Обозначение по ГОСТ 14098")]
    [Table("p_WeldGOST14098")]
    public class WeldGOST14098 : CommonEntity, IReftableEntity
    {
        [Key]
        public System.Guid WeldGOST14098_ID { get; set; }
        [Required]
        public string WeldGOST14098_Code { get; set; }
        public string Description_Rus { get; set; }

        [NotMapped]
        public string Title { get => WeldGOST14098_Code; set => WeldGOST14098_Code = value; }
        [NotMapped]
        public string Description { get => Description_Rus; set => Description_Rus = value; }
    }
}
