using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Сварочные материалы")]
    [Table("p_WeldMaterial")]
    public class WeldMaterial : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("WeldMaterial_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("WeldMaterial_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }
    }
}
