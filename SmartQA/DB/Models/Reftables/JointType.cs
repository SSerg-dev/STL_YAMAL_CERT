using SmartQA.DB.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Тип соединения")]
    [Table("p_JointType")]
    public class JointType : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("JointType_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("JointType_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }
    }
}
