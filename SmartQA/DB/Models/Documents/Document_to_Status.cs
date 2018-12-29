using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_Document_to_Status")]
    public class Document_to_Status : M2MEntity
    {
        public Guid Document_ID { get; set; }
        public Guid Status_ID { get; set; }

        public DateTime DTS_Start { get; set; }
        public DateTime? DTS_End { get; set; }
        public Guid? Parent_ID { get; set;  }
        
        [ForeignKey("Document_ID")]
        public virtual Document Document { get; set; }
        [ForeignKey("Status_ID")]
        public virtual Status Status { get; set; }
        [ForeignKey("Parent_ID")]
        public virtual Document_to_Status Parent { get; set; }
        
    }
}