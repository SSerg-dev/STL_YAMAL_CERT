using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [Table("p_ContragentRole")]
    public class ContragentRole : CommonEntity, IReftableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ContragentRole_ID")]
        public Guid ID { get; set; }

        [Required]
        [Column("ContragentRole_Code")]
        [StringLength(255)]
        public string Title { get; set; }
        
        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }
    }
}