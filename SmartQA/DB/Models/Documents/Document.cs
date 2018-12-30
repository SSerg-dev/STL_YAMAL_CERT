using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_Document")]
    public class Document : CommonEntity
    {
        [Required]
        [StringLength(255)]
        public string Document_Code { get; set; }
        
        [Required]
        public DateTimeOffset? Issue_Date { get; set; }

        [Required]
        public DateTime? Issue_Date_DT { get; set; }
        
        [StringLength(255)]
        public string Document_Number { get; set; }
        
        [Column(TypeName="date")]
        public DateTime? Document_Date { get; set; }
        
        public int? TotalSheets { get; set; }

        [StringLength(255)]
        public string Document_Name { get; set; }
        
        [Required]
        public int VersionNumber { get; set; }
        
        [Required]
        public bool IsActual { get; set; }
        
        public Guid DocumentType_ID { get; set; }

        public Guid Root_ID { get; set; }
        
        public Guid? Resp_Employee_ID { get; set; }     
                
        [ForeignKey("DocumentType_ID")]
        public virtual DocumentType DocumentType { get; set; }
        
        [ForeignKey("Root_ID")]
        public virtual Document Root { get; set; }
        
        [ForeignKey("Resp_Employee_ID")]
        public virtual Employee Resp_Employee { get; set; }
    }
}