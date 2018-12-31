using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_Document_to_Status")]
    [M2M(typeof(Document), typeof(Status))]
    public class Document_to_Status : CommonEntity
    {
        public Guid Document_ID { get; set; }
        public Guid Status_ID { get; set; }

        [Required]
        public DateTimeOffset? DTS_Start { get; set; }

        public DateTimeOffset? DTS_End { get; set; }
        public Guid? Parent_ID { get; set; }
        
        public virtual Document Document { get; set; }
        
        public virtual Status Status { get; set; }
        
        public virtual Document_to_Status Parent { get; set; }
                  
        [RunAtModelSetup]
        public static void SetupRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document_to_Status>()
                .HasOne(d => d.Parent)
                .WithMany()
                .HasForeignKey(x => x.Parent_ID)
                .OnDelete(DeleteBehavior.Restrict);             
        }
    }
}