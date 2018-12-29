using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [UseDefaultReftableEditor]
    [Display(Name = "Тип соединения")]
    [Table("p_JointType")]
    public class JointType : CommonEntity, IReftableEntity
    {
        [Required]
        [Column("JointType_Code")]
        [StringLength(255)]
        public string Title { get; set; }

        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }
    }
}