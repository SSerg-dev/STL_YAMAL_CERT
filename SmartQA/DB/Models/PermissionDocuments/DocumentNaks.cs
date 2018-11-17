using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using SmartQA.DB.Models.Auth;

using SmartQA.DB.Models.People;
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.PermissionDocuments
{
    [Table("p_DocumentNaks")]
    public class DocumentNaks : CommonEntity
    {
        [Key]
        public Guid DocumentNaks_ID { get; set; }
                
        public Guid Person_ID { get; set; }
               
        [Required]
        public string Number { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime? IssueDate { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime? ValidUntil { get; set; }

        [Required]
        public string Schifr { get; set; }

        public Guid WeldType_ID { get; set; }

        [ForeignKey("Person_ID")]
        public virtual Person Person { get; set; }

        [ForeignKey("WeldType_ID")]
        public virtual WeldType WeldType { get; set; }

        [InverseProperty("DocumentNaks")]
        public virtual ICollection<DocumentNaks_to_HIFGroup> DocumentNaks_to_HIFGroupSet { get; set; }

        [NotMapped]
        public List<Guid> HIFGroup_IDs
        {
            get => DocumentNaks_to_HIFGroupSet.Select(x => x.HIFGroup_ID).ToList();
            set {
                if (DocumentNaks_to_HIFGroupSet == null)
                {
                    DocumentNaks_to_HIFGroupSet = new List<DocumentNaks_to_HIFGroup>();
                }

                var existingIds = DocumentNaks_to_HIFGroupSet?.Select(x => x.HIFGroup_ID) ;

                foreach (var rel in DocumentNaks_to_HIFGroupSet.Where(x => !value.Contains(x.HIFGroup_ID)))
                {
                    rel.MarkDeleted();
                }

                foreach (var id in value.Where(x => !existingIds.Contains(x)))
                {
                    var rel = new DocumentNaks_to_HIFGroup()
                    {
                        HIFGroup_ID = id
                    };
                    rel.OnSave();
                    DocumentNaks_to_HIFGroupSet.Add(rel);
                }
            }
        }

    }
    
}
