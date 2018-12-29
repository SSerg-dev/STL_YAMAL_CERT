using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.PermissionDocuments
{
    [Table("p_DocumentNaks_to_HIFGroup")]
    public class DocumentNaks_to_HIFGroup : M2MEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DocumentNaks_to_HIFGroup_ID { get; set; }

        public Guid DocumentNaks_ID { get; set; }
        public Guid HIFGroup_ID { get; set; }

        [ForeignKey("DocumentNaks_ID")]
        public virtual DocumentNaks DocumentNaks { get; set; }
        [ForeignKey("HIFGroup_ID")]
        public virtual HIFGroup HIFGroup { get; set; }
    }
}
