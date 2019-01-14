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
    [Table("p_DocumentNDT")]
    public class DocumentNDT : CommonEntity
    {
        public Guid Person_ID { get; set; }        

        [Required]
        public string Number { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime? IssueDate { get; set; }

        [Required]
        public string OrganizationPublishedNDT { get; set; }

        // ---- foreign key relations -----

        public virtual Person Person { get; set; }

        // ---- child relations -----------

        public virtual ICollection<DocumentNDTIT> DocumentNDTITSet { get; set; }
        public virtual ICollection<DocumentNDT> Inserts { get; set; }

        [NotMapped]
        public bool HasInserts => Inserts.Any();

        [RunAtModelSetup]
        public static void SetupRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentNDT>()
                .HasOne(x => x.Person)
                .WithMany()
                .HasForeignKey(x => x.Person_ID)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
