using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_Document_to_GOST")]
    [M2M(typeof(Document), typeof(GOST))]
    public class Document_to_GOST : CommonEntity
    {
        public Guid Document_ID { get; set; }
        public Guid GOST_ID { get; set; }

        public virtual Document Document { get; set; }
        public virtual GOST GOST { get; set; }
    }
}