using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Display(Name = "Должность")]
    [Table("p_Position")]
    public class Position : CommonEntity, IReftableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Position_ID")]
        public Guid ID { get; set; }

        [Required]
        [Column("Position_Code")]
        [StringLength(255)]
        public string Title { get; set; }
        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }
        [StringLength(255)]
        public string Description_Eng { get; set; }

        [ForeignKey("Division_ID")]
        public virtual Division Division { get; set; }
        public Guid? Division_ID { get; set; }
    }
}