using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_Document_to_PID")]
    [M2M(typeof(Document), typeof(PID))]
    public class Document_to_PID : CommonEntity
    {
        public Guid Document_ID { get; set; }
        public Guid PID_ID { get; set; }

        public virtual Document Document { get; set; }
        public virtual PID PID { get; set; }
    }
}