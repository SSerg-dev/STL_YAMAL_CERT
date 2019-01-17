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
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;
using SmartQA.DB.Models.Documents;

namespace SmartQA.DB.Models.Registers
{
    [Table("p_Register")]
    public class Register : CommonEntity
    {
        [Required]
        [StringLength(255)]
        public string Register_Code { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? Register_Date { get; set; }

        [Required]
        public int CurrentIteration { get; set; }

        public Guid? Customer_ID { get; set; }

        public Guid? Contractor_ID { get; set; }

        public Guid? SubContractor_ID { get; set; }

        public Guid? Resp_Employee_ID { get; set; }

        public Guid? WorkPackage_ID { get; set; }

        [StringLength(255)]
        public string Comment { get; set; }

        public virtual Contragent   Customer { get; set; }
        public virtual Contragent   Contractor { get; set; }
        public virtual Contragent   SubContractor { get; set; }
        public virtual Employee     Resp_Employee { get; set; }
        public virtual WorkPackage  WorkPackage { get; set; }

        public virtual ICollection<RegisterStatus> RegisterStatusSet { get; set; }
        public virtual ICollection<Register_to_Document> Register_to_DocumentSet { get; set; }

        [NotMapped]
        public virtual Status Status
        {
            get => RegisterStatusSet.FirstOrDefault(ds => ds.RowStatus == 0)?.Status;
            set => Status_ID = value.ID;
        }

        [NotMapped]
        public Guid? Status_ID
        {
            get => Status?.ID;
            set
            {
                var now = DateTimeOffset.Now;
                var prev = RegisterStatusSet.FirstOrDefault(ds => ds.RowStatus == 0);
                if (prev != null)
                {
                    prev.RowStatus = 120;
                    prev.DTS_End = now;
                    AddToOnSaveCache(prev);
                }

                var s = new RegisterStatus
                {
                    DTS_Start = now,
                    Register = this,
                    PreviousStatus = prev,
                    RowStatus = 0,
                    Status_ID = (Guid)value
                };

                RegisterStatusSet.Add(s);

                AddToOnSaveCache(s);
            }
        }
        [RunAtModelSetup]
        public static void SetupRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Register>()
                .HasOne(d => d.Resp_Employee)
                .WithMany()
                .HasForeignKey(x => x.Resp_Employee_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Register>()
                .HasAlternateKey(u => u.Register_Code);

            modelBuilder.Entity<Register>()
                .Property(d => d.Register_Code)
                .HasDefaultValueSql("next value for [Sequence_Register_Number]");

            modelBuilder.Entity<Register>()
                .HasOne(d => d.Customer)
                .WithMany()
                .HasForeignKey(x => x.Customer_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Register>()
                .HasOne(d => d.Contractor)
                .WithMany()
                .HasForeignKey(x => x.Contractor_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Register>()
                .HasOne(d => d.SubContractor)
                .WithMany()
                .HasForeignKey(x => x.SubContractor_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Register>()
                .HasOne(d => d.WorkPackage)
                .WithMany()
                .HasForeignKey(x => x.WorkPackage_ID)
                .OnDelete(DeleteBehavior.Restrict);

        }

            // ---- m2m relations -------------

        public virtual ICollection<Register_to_Marka> Register_to_MarkaSet { get; set; }
        [NotMapped]
        public ICollection<Marka> MarkaSet => this.GetM2MObjects<Marka>();
        [NotMapped]
        public ICollection<Guid> Marka_IDs
        {
            get => this.GetM2MKeys<Marka>();
            set => this.SetM2MKeys<Marka>(value);
        }

        public virtual ICollection<Register_to_TitleObject> Register_to_TitleObjectSet { get; set; }
        [NotMapped]
        public ICollection<TitleObject> TitleObjectSet => this.GetM2MObjects<TitleObject>();
        [NotMapped]
        public ICollection<Guid> TitleObject_IDs
        {
            get => this.GetM2MKeys<TitleObject>();
            set => this.SetM2MKeys<TitleObject>(value);
        }

    }

}
    


 
