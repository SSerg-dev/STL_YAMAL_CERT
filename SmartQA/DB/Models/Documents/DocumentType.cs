using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_DocumentType")]
    public class DocumentType : CommonEntity, IReftableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DocumentType_ID")]
        public Guid ID { get; set; }
        
        [Required]
        [Column("DocumentType_Code")]
        [StringLength(255)]
        public string Title { get; set; }
        
        [NotMapped]
        public string Description { get; set; }
    }
}