using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.PermissionDocuments
{
    [Table("p_DocumentNaks")]
    public class DocumentNaks : CommonEntity
    {
        public Guid Person_ID { get; set; }

        public Guid? ParentDocumentNaks_ID { get; set; }

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
        
        public virtual Person Person { get; set; }
        public virtual WeldType WeldType { get; set; }
        public virtual DocumentNaks ParentDocumentNaks { get; set; }

        // ---- child relations -----------
        
        public virtual ICollection<DocumentNaksAttest> DocumentNaksAttestSet { get; set; }       
        public virtual ICollection<DocumentNaks> Inserts { get; set; }

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

        [NotMapped]
        public bool HasInserts => Inserts.Any();

        [RunAtModelSetup]
        public static void SetupRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentNaks>()
                .HasOne(x => x.ParentDocumentNaks)
                .WithMany(x => x.Inserts)
                .HasForeignKey(x => x.ParentDocumentNaks_ID)
                .OnDelete(DeleteBehavior.Restrict);
               
            modelBuilder.Entity<DocumentNaks>()
                .HasOne(x => x.Person)
                .WithMany()
                .HasForeignKey(x => x.Person_ID)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<DocumentNaks>()
                .HasOne(x => x.WeldType)
                .WithMany()
                .HasForeignKey(x => x.WeldType_ID)
                .OnDelete(DeleteBehavior.Restrict);                              
        }

    }
    
}
