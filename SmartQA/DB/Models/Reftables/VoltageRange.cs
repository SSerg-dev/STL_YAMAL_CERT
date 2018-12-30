using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [UseDefaultReftableEditor]
    [Display(Name = "Диапозоны напряжения")]
    [Table("p_VoltageRange")]
    public class VoltageRange : CommonEntity, IReftableEntity
    {
        [Required]
        [Column("VoltageRange_Code")]
        [StringLength(255)]
        public string Title { get; set; }

        [Column("Description_Rus")]
        [StringLength(500)]
        public string Description { get; set; }
    }
}
