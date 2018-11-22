using SmartQA.DB.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartQA.DB.Models.Reftables
{

    [Display(Name = "Защитный газ")]
    [Table("p_ShieldingGas")]
    public class ShieldingGas : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("ShieldingGas_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("ShieldingGas_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }
    }

}
