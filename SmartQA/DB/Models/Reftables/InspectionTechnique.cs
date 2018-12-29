using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{

    [Display(Name = "Вид контроля")]
    [Table("p_InspectionTechnique")]
    public class InspectionTechnique : CommonEntity, IReftableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("InspectionTechnique_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("InspectionTechnique_Code")]
        [StringLength(255)]
        public string Title { get; set; }
        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }
    }

}
