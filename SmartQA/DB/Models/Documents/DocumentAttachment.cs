using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB.Models.Files;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_DocumentAttachment")]
    public class DocumentAttachment : CommonEntity    
    {
        public Guid Document_ID { get; set; }
        public Guid FileDesc_ID { get; set; }
        
        public string Description { get; set; }
        
        public virtual Document Document { get; set; }
        public virtual FileDesc FileDesc { get; set; }

        [RunAtModelSetup]
        public static void SetupRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentAttachment>()
                .HasOne(df => df.Document)
                .WithMany(d => d.DocumentAttachmentSet)
                .HasForeignKey(x => x.Document_ID)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<DocumentAttachment>()
                .HasOne(df => df.FileDesc)
                .WithOne()
                .HasForeignKey<DocumentAttachment>(df => df.FileDesc_ID)
                .OnDelete(DeleteBehavior.Restrict);
            
            
        }
    }
}