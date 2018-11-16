using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.PermissionDocuments
{
    [Table("p_DocumentNaks_to_HIFGroup")]
    public class DocumentNaks_to_HIFGroup : CommonEntity
    {
        [Key]
        public Guid DocumentNaks_to_HIFGroup_ID { get; set; }

        public Guid DocumentNaks_ID { get; set; }
        public Guid HIFGroup_ID { get; set; }

        [ForeignKey("DocumentNaks_ID")]
        public DocumentNaks DocumentNaks { get; set; }
        [ForeignKey("HIFGroup_ID")]
        public HIFGroup HIFGroup { get; set; }
    }
}
