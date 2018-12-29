using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [UseDefaultReftableEditor]
    [Display(Name = "Право подписи актов освидетельствования работ, конструкций, сетей")]
    [Table("p_AuthToSignInspActsForWSUN")]
    public class AuthToSignInspActsForWSUN : CommonEntity, IReftableEntity
    {
        [Required]
        [Column("AuthToSignInspActsForWSUN_Code")]
        [StringLength(255)]
        public string Title { get; set; }

        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }
    }
}