using SmartQA.DB.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartQA.DB.Models.Reftables
{

    [Display(Name = "Область ответственности")]
    [Table("p_Responsibility")]
    public class Responsibility : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("Responsibility_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("Responsibility_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }
    }

}
