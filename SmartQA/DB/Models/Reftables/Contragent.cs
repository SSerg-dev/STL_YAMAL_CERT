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
        [Key]
        [Column("Contragent_ID")]
        public Guid ID { get; set; }

        [Required]
        [Column("Contragent_Code")]
        public string Title { get; set; }
        [Column("Description_Rus")]
        public string Description { get; set; }

        public string Description_Eng { get; set; }
    }
}