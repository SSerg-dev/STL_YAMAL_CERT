using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Xml;
using Microsoft.EntityFrameworkCore;
using SmartQA.Auth;
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
        public virtual ICollection<DocumentAttachment> DocumentAttachmentSet { get; set; }
        public virtual ICollection<Document> Revisions { get; set; }

        [NotMapped]
        public virtual Status Status
        {
            get => DocumentStatusSet.FirstOrDefault(ds => ds.RowStatus == 0)?.Status;
            set => Status_ID = value.ID;
        }
        
        [NotMapped]
        public Guid? Status_ID
        {
            get => Status?.ID;
            set {
                var now = DateTimeOffset.Now;
                var prev = DocumentStatusSet.FirstOrDefault(ds => ds.RowStatus == 0);
                if (prev != null)
                {
                    prev.RowStatus = 120;
                    prev.DTS_End = now;
                    AddToOnSaveCache(prev);
                }
    
                var s = new DocumentStatus
                {
                    DTS_Start = now,
                    Document = this,
                    PreviousStatus = prev,
                    RowStatus = 0,
                    Status_ID = (Guid) value
                };
                    
                DocumentStatusSet.Add(s);
                    
                AddToOnSaveCache(s); 
            }

        } 

        [RunAtModelSetup]
        public static void SetupRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>()
                .HasOne(d => d.Root)
                .WithMany(d => d.Revisions)
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
                .HasAlternateKey(u => u.Document_Code);

            modelBuilder.Entity<Document>()
                .Property(d => d.Document_Code)
                .HasDefaultValueSql("next value for [Sequence_Document_Number]");

            modelBuilder.Entity<Document>()
                .HasIndex(d => new {d.Root_ID, d.VersionNumber })
                .IsUnique();

            modelBuilder.Entity<Document>()
                .HasIndex(d => new {d.Root_ID});
            
            modelBuilder.Entity<Document>()
                .HasIndex(d => new { d.Root_ID, d.IsActual })
                .HasFilter("(IsActual = 1)")                
                .IsUnique();
          
        }               
        
        // ---- m2m relations -------------
        
        public virtual ICollection<Document_to_GOST> Document_to_GOSTSet { get; set; }
        [NotMapped]
        public ICollection<GOST> GOSTSet => this.GetM2MObjects<GOST>();
        [NotMapped]
        public ICollection<Guid> GOST_IDs
        {
            get => this.GetM2MKeys<GOST>();
            set => this.SetM2MKeys<GOST>(value);                
        }
        
        public virtual ICollection<Document_to_PID> Document_to_PIDSet { get; set; }
        [NotMapped]
        public ICollection<PID> PIDSet => this.GetM2MObjects<PID>();
        [NotMapped]
        public ICollection<Guid> PID_IDs
        {
            get => this.GetM2MKeys<PID>();
            set => this.SetM2MKeys<PID>(value);                
        }

        
    }
}