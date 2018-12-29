using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [UseDefaultReftableEditor]
    [Display(Name = "Тестовый справочник")]
    [Table("p_TestTypeRef")]
    public class TestTypeRef : CommonEntity, IReftableEntity
    {
        [StringLength(255)] public string Description_Eng { get; set; }


        [Required]
        [Column("TestTypeRef_Code")]
        [StringLength(255)]
        public string Title { get; set; }

        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }
    }
}