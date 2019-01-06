using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [UseDefaultReftableEditor]
    [Display(Name = "Группы персонала")]
    [Table("p_StaffFunction")]
    public class StaffFunction : CommonEntity, IReftableEntity
    {
        [Required]
        [Column("StaffFunction_Code")]
        [StringLength(255)]
        public string Title { get; set; }

        [Column("Description_Rus")]
        [StringLength(500)]
        public string Description { get; set; }
    }
}
