using SmartQA.DB.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartQA.DB.Models.Reftables
{

    [Display(Name = "Группа по электробезопасности")]
    [Table("p_ElectricalSafetyAbilitation")]
    public class ElectricalSafetyAbilitation : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("ElectricalSafetyAbilitation_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("ElectricalSafetyAbilitation_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }
    }

}
