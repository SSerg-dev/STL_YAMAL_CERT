using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Группа свариваемого материала")]
    [Table("p_WeldMaterialGroup")]
    public class WeldMaterialGroup : CommonEntity, IReftableEntity
    {
        [Key]
        public System.Guid WeldMaterialGroup_ID { get; set; }
        [Required]
        public string WeldMaterialGroup_Code { get; set; }
        public string Description_Rus { get; set; }

        [NotMapped]
        public string Title { get => WeldMaterialGroup_Code; set => WeldMaterialGroup_Code = value; }
        [NotMapped]
        public string Description { get => Description_Rus; set => Description_Rus = value; }
    }
}
