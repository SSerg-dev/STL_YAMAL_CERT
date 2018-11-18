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

        public string Schifr { get; set; }

        public Guid WeldType_ID { get; set; }

        // ---- foreign key relations -----

        [ForeignKey("Person_ID")]
        public virtual Person Person { get; set; }

        [ForeignKey("WeldType_ID")]
        public virtual WeldType WeldType { get; set; }

        // ---- child relations -----------

        [InverseProperty("DocumentNaks")]
        public virtual ICollection<DocumentNaksAttest> DocumentNaksAttestSet { get; set; }

        // ---- m2m relations -------------

        [InverseProperty("DocumentNaks")]
        public virtual ICollection<DocumentNaks_to_HIFGroup> DocumentNaks_to_HIFGroupSet { get; set; }
        [NotMapped]
        public ICollection<HIFGroup> HIFGroupSet => this.GetM2MObjects<HIFGroup>();
        [NotMapped]
        public ICollection<Guid> HIFGroup_IDs
        {
            get => this.GetM2MKeys<HIFGroup>();
            set => this.SetM2MKeys<HIFGroup>(value);                
        }

    }
    
}
