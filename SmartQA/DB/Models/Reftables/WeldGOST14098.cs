using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Обозначение по ГОСТ 14098")]
    [Table("p_WeldGOST14098")]
    public class WeldGOST14098 : CommonEntity, IReftableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("WeldGOST14098_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("WeldGOST14098_Code")]
        [StringLength(255)]
        public string Title { get; set; }
        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }
    }
}
