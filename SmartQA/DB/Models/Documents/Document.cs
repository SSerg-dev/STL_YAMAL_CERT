using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB.Models.Auth;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_Document")]
    public class Document : CommonEntity
    {
        [Required]
        [StringLength(255)]
        public string Document_Code { get; set; }
        
        [Required]
        public DateTimeOffset? Issue_Date { get; set; }

        [Required]
        public DateTime? Issue_Date_DT { get; set; }
        
        [StringLength(255)]
        public string Document_Number { get; set; }
        
        [Column(TypeName="date")]
        [DataType(DataType.Date)]
        public DateTime? Document_Date { get; set; }
        
        public int? TotalSheets { get; set; }

        [StringLength(255)]
        public string Document_Name { get; set; }
        
        [Required]
        public int VersionNumber { get; set; }
        
        [Required]
        public bool IsActual { get; set; }
        
        public Guid DocumentType_ID { get; set; }

        public Guid Root_ID { get; set; }
        
        public Guid? Resp_Employee_ID { get; set; }     
                
        public virtual DocumentType DocumentType { get; set; }
        public virtual Document Root { get; set; }
        public virtual Employee Resp_Employee { get; set; }
                        
        public virtual ICollection<DocumentStatus> DocumentStatusSet { get; set; } 
        
        [NotMapped]
        public virtual DocumentStatus DocumentStatus { get; set; }
        
        [RunAtModelSetup]
        public static void SetupRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>()
                .HasOne(d => d.Root)
                .WithMany()
                .HasForeignKey(x => x.Root_ID)
                .OnDelete(DeleteBehavior.Restrict); 
            
            modelBuilder.Entity<Document>()
                .HasOne(d => d.DocumentType)
                .WithMany()
                .HasForeignKey(x => x.DocumentType_ID)
                .OnDelete(DeleteBehavior.Restrict);            
            
            modelBuilder.Entity<Document>()
                .HasOne(d => d.Resp_Employee)
                .WithMany()
                .HasForeignKey(x => x.Resp_Employee_ID)
                .OnDelete(DeleteBehavior.Restrict);
                        
            modelBuilder.Entity<Document>()
                .HasAlternateKey(u => u.Document_Code);                ;

            modelBuilder.Entity<Document>()
                .Property(d => d.Document_Code)
                .HasDefaultValueSql("next value for [Sequence_Document_Number]");
                        

        }                
        
    }
}