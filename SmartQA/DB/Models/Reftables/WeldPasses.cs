using SmartQA.DB.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartQA.DB.Models.Reftables
{

    [Display(Name = "Слои шва")]
    [Table("p_WeldPasses")]
    public class WeldPasses : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("WeldPasses_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("WeldPasses_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }
    }

}
