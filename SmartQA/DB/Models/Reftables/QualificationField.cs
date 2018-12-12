using SmartQA.DB.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartQA.DB.Models.Reftables
{

    [Display(Name = "Область аттестации")]
    [Table("p_QualificationField")]
    public class QualificationField : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("QualificationField_ID")]
        public System.Guid ID { get; set; }

        [Column("Parent_Id")]
        public System.Guid? Parent_Id { get; set; }
        [Required]
        [Column("Structure_Level")]
        public int Structure_Level { get; set; }
        [Required]
        [Column("QualificationField_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }
    }
}
