using SmartQA.DB.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartQA.DB.Models.Reftables
{

    [Display(Name = "Квалификационный разряд")]
    [Table("p_QualificationLevel")]
    public class QualificationLevel : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("QualificationLevel_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("QualificationLevel_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }
    }

}
