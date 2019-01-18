using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.PermissionDocuments
{
    [Table("p_DocumentNDTIT")]
    public class DocumentNDTIT : CommonEntity
    {
        // ---- basic columns -------------        
        
        //public string InspectionSubject { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime? ValidUntil { get; set; }

        // ---- foreign keys --------------

        public Guid DocumentNDT_ID { get; set; }
        public Guid InspectionTechnique_ID { get; set; }
        public Guid Level_ID { get; set; }


        // ---- foreign key relations -----

        public virtual DocumentNDT DocumentNDT { get; set; }
        public virtual InspectionTechnique InspectionTechnique { get; set; }
        public virtual Level Level { get; set; }


        // ---- m2m relations -------------

        public virtual ICollection<DocumentNDTIT_to_InspectionSubject> DocumentNDTIT_to_InspectionSubjectSet { get; set; }

        [NotMapped]
        public ICollection<InspectionSubject> InspectionSubjectSet => this.GetM2MObjects<InspectionSubject>();
        [NotMapped]
        public ICollection<Guid> InspectionSubject_IDs
        {
            get => this.GetM2MKeys<InspectionSubject>();
            set => this.SetM2MKeys<InspectionSubject>(value);
        }
        [RunAtModelSetup]
        public static void SetupRelations(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DocumentNDTIT>()
                .HasOne(x => x.DocumentNDT)
                .WithMany(x => x.DocumentNDTITSet)
                .HasForeignKey(x => x.DocumentNDT_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DocumentNDTIT>()
                .HasOne(x => x.InspectionTechnique)
                .WithMany()
                .HasForeignKey(x => x.InspectionTechnique_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DocumentNDTIT>()
                .HasOne(x => x.Level)
                .WithMany()
                .HasForeignKey(x => x.Level_ID)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
