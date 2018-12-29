using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Тестовый справочник")]
    [Table("p_TestTypeRef")]
    public class TestTypeRef : CommonEntity, IReftableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TestTypeRef_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("TestTypeRef_Code")]
        [StringLength(255)]
        public string Title { get; set; }

        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Description_Eng { get; set; }
    }
}