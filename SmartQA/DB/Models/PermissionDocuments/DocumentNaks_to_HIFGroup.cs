using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.PermissionDocuments
{
    [Table("p_DocumentNaks_to_HIFGroup")]
    [M2M(typeof(DocumentNaks), typeof(HIFGroup))]
    public class DocumentNaks_to_HIFGroup : CommonEntity
    {
        public Guid DocumentNaks_ID { get; set; }
        public Guid HIFGroup_ID { get; set; }
        
        public virtual DocumentNaks DocumentNaks { get; set; }        
        public virtual HIFGroup HIFGroup { get; set; }
    }
}
