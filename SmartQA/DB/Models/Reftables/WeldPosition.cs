using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Положение при сварке")]
    [Table("p_WeldPosition")]
    public class WeldPosition : CommonEntity, IReftableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("WeldPosition_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("WeldPosition_Code")]
        [StringLength(255)]
        public string Title { get; set; }

        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }
    }
}
