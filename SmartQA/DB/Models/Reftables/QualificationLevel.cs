using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{

    [Display(Name = "Квалификационный разряд")]
    [Table("p_QualificationLevel")]
    public class QualificationLevel : CommonEntity, IReftableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("QualificationLevel_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("QualificationLevel_Code")]
        [StringLength(255)]
        public string Title { get; set; }
        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }
    }

}
