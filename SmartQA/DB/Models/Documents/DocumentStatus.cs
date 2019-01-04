using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_Document_to_Status")]    
    public class DocumentStatus : CommonEntity
    {                   
        public Guid Document_ID { get; set; }
        public Guid Status_ID { get; set; }

        [Required]
        public DateTimeOffset? DTS_Start { get; set; }

        public DateTimeOffset? DTS_End { get; set; }
        public Guid? Parent_ID { get; set; }
        
        public virtual Document Document { get; set; }
        
        public virtual Status Status { get; set; }
        
        public virtual DocumentStatus PreviousStatus { get; set; }        
                  
        [RunAtModelSetup]
        public static void SetupRelations(ModelBuilder modelBuilder)
        {                        
            // setup primary key
            modelBuilder.Entity<DocumentStatus>()
                .Property(x => x.ID)
                .HasColumnName($"Document_to_Status_ID")
                .HasDefaultValueSql("newsequentialid()")
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<DocumentStatus>()
                .HasOne(ds => ds.Status)
                .WithMany()
                .HasForeignKey(ds => ds.Status_ID)
                .OnDelete(DeleteBehavior.Restrict);  
            
            modelBuilder.Entity<DocumentStatus>()
                .HasOne(ds => ds.PreviousStatus)                
                .WithMany()
                .HasForeignKey(x => x.Parent_ID)                
                .OnDelete(DeleteBehavior.Restrict);  
            
            modelBuilder.Entity<DocumentStatus>()
                .HasOne(ds => ds.Document)
                .WithMany(d => d.DocumentStatusSet)
                .HasForeignKey(ds => ds.Document_ID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}