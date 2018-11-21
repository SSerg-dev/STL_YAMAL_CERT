using SmartQA.DB.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartQA.DB.Models.Reftables
{
    
    [Display(Name = "Объект контроля")]
    [Table("p_InspectionSubject")]
    public class InspectionSubject : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("InspectionSubject_ID")]
        public System.Guid ID { get; set; }

        [Column("Parent_Id")]
        public System.Guid Parent_Id { get; set; }
        [Required]
        [Column("Structure_Level")]
        public int Structure_Level { get; set; }
        [Required]
        [Column("InspectionSubject_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }
    }
}
