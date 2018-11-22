using SmartQA.DB.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartQA.DB.Models.Reftables
{

    [Display(Name = "Допуск к работе в электроустановках в качестве")]
    [Table("p_AccessToPIStaffFunction")]
    public class AccessToPIStaffFunction : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("AccessToPIStaffFunction_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("AccessToPIStaffFunction_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }
    }

}
