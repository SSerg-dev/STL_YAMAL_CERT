using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Организация")]
    [Table("p_Contragent")]
    public class Contragent : CommonEntity, IReftableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Contragent_ID")]
        public Guid ID { get; set; }

        [Required]
        [Column("Contragent_Code")]
        [StringLength(255)]
        public string Title { get; set; }
        
        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Description_Eng { get; set; }
        
        public Guid? ContragentRole_ID { get; set; }
        
        [ForeignKey("ContragentRole_ID")]
        public virtual ContragentRole ContragentRole { get; set; }
    }
}