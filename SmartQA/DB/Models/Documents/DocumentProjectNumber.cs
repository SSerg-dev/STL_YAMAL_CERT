using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_DocumentProjectNumber")]
    public class DocumentProjectNumber : CommonEntity, IReftableEntity
    {
        [Required]
        [Column("DocumentProjectNumber_Code")]
        [StringLength(255)]
        public string Title { get; set; }
        
        [NotMapped]
        public string Description { get; set; }
    }
}