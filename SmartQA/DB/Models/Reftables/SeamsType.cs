using SmartQA.DB.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Типы швов")]
    [Table("p_SeamsType")]
    public class SeamsType : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("SeamsType_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("SeamsType_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }
    }
}
