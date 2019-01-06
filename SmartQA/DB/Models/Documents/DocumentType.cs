using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_DocumentType")]
    [UseDefaultReftableEditor]
    [Display(Name = "Тип документа")]
    public class DocumentType : CommonEntity, IReftableEntity
    {
        [Required]
        [Column("DocumentType_Code")]
        [StringLength(255)]
        public string Title { get; set; }
        
        [StringLength(255)]
        [Column("Description_Rus")]
        public string Description { get; set; }
    }
}