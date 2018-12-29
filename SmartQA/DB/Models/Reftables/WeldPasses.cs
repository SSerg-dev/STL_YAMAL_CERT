using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{

    [Display(Name = "Слои шва")]
    [Table("p_WeldPasses")]
    public class WeldPasses : CommonEntity, IReftableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("WeldPasses_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("WeldPasses_Code")]
        [StringLength(255)]
        public string Title { get; set; }
        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }
    }

}
