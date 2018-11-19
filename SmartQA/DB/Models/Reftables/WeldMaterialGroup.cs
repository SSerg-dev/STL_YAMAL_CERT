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
        [Column("WeldMaterialGroup_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("WeldMaterialGroup_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }
    }
}
