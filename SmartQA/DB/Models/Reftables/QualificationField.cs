using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{

    [Display(Name = "Область аттестации")]
    [Table("p_QualificationField")]
    public class QualificationField : CommonEntity, IReftableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("QualificationField_ID")]
        public System.Guid ID { get; set; }

        [Column("Parent_ID")]
        public System.Guid? Parent_ID { get; set; }
        
        [Required]
        [Column("Structure_Level")]
        public int Structure_Level { get; set; }
        
        [Required]
        [Column("QualificationField_Code")]
        [StringLength(255)]
        public string Title { get; set; }
        
        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }
    }
}
