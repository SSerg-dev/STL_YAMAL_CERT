using SmartQA.DB.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartQA.DB.Models.Reftables
{

    [Display(Name = "Право подписи актов освидетельствования работ, конструкций, сетей")]
    [Table("p_AuthToSignInspActsForWSUN")]
    public class AuthToSignInspActsForWSUN : CommonEntity, IReftableEntity
    {
        [Key]
        [Column("AuthToSignInspActsForWSUN_ID")]
        public System.Guid ID { get; set; }

        [Required]
        [Column("AuthToSignInspActsForWSUN_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }
    }

}
