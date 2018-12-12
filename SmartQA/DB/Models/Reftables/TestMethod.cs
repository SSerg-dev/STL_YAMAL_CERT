using SmartQA.DB.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartQA.DB.Models.Reftables
{

    [Display(Name = "Вид, метод испытания")]
    [Table("p_TestMethod")]
    public class TestMethod : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("TestMethod_ID")]
        public System.Guid ID { get; set; }

        [Column("Parent_Id")]
        public System.Guid? Parent_Id { get; set; }
        [Required]
        [Column("Structure_Level")]
        public int Structure_Level { get; set; }
        [Required]
        [Column("TestMethod_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }
    }
}