using SmartQA.DB.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//namespace SmartQA.DB.Models.Reftables
//{
//    [Display(Name = "Тестовый справочник")]
//    [Table("p_TestTypeRef")]
//    public class TestTypeRef : CommonEntity, IReftableEntity
//    {
//        [Key]
//        public System.Guid ID { get; set; }
//        [Required]
//        public string TestTypeRef_Code { get; set; }
//        public string Description_Rus { get; set; }

//        [NotMapped]
//        public string Title { get => TestTypeRef_Code; set => TestTypeRef_Code = value; }
//        [NotMapped]
//        public string Description { get => Description_Rus; set => Description_Rus = value; }
//    }
//}

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Тестовый справочник")]
    [Table("p_TestTypeRef")]
    public class TestTypeRef : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("TestTypeRef_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("TestTypeRef_Code")]
        public string Title { get; set; }

        [Column("Description_Rus")]
        public string Description { get; set; }
    }
}