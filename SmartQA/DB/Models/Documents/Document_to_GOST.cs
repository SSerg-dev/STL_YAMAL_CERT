using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_Document_to_GOST")]
    public class Document_to_GOST : M2MEntity
    {
        public Guid Document_ID { get; set; }
        public Guid GOST_ID { get; set; }

        [ForeignKey("Document_ID")]
        public virtual Document Document { get; set; }
        [ForeignKey("GOST_ID")]
        public virtual GOST GOST { get; set; }
    }
}