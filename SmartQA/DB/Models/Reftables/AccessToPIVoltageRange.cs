using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [UseDefaultReftableEditor]
    [Display(Name = "Допуск к работе в электроустановках напряжением")]    
    [Table("p_AccessToPIVoltageRange")]
    public class AccessToPIVoltageRange : CommonEntity, IReftableEntity
    {
        [Required]
        [Column("AccessToPIVoltageRange_Code")]
        [StringLength(255)]
        public string Title { get; set; }

        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }
    }
}