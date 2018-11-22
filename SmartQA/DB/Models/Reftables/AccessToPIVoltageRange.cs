using SmartQA.DB.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartQA.DB.Models.Reftables
{

    [Display(Name = "Допуск к работе в электроустановках напряжением")]
    [Table("p_AccessToPIVoltageRange")]
    public class AccessToPIVoltageRange : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("AccessToPIVoltageRange_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("AccessToPIVoltageRange_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }
    }

}
