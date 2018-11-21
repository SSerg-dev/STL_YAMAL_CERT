using SmartQA.DB.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartQA.DB.Models.Reftables
{

    [Display(Name = "Вид контроля")]
    [Table("p_InspectionTechnique")]
    public class InspectionTechnique : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("InspectionTechnique_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("InspectionTechnique_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }
    }

}
