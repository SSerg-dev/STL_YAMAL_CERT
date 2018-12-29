using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_Document_to_PID")]
    public class Document_to_PID : M2MEntity
    {
        public Guid Document_ID { get; set; }
        public Guid PID_ID { get; set; }

        [ForeignKey("Document_ID")]
        public virtual Document Document { get; set; }
        [ForeignKey("PID_ID")]
        public virtual PID PID { get; set; }
    }
}