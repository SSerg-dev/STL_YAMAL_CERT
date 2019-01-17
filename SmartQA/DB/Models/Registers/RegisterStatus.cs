using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB.Models.Shared;
using SmartQA.DB.Models.Documents;

namespace SmartQA.DB.Models.Registers
{
    [Table("p_Register_to_Status")]
    public class RegisterStatus : CommonEntity
    {
        public Guid Register_ID { get; set; }
        public Guid Status_ID { get; set; }

        [Required]
        public DateTimeOffset? DTS_Start { get; set; }

        public DateTimeOffset? DTS_End { get; set; }
        public Guid? Parent_ID { get; set; }

        public virtual Register Register { get; set; }

        public virtual Status Status { get; set; }

        public virtual RegisterStatus PreviousStatus { get; set; }
        public virtual RegisterStatus NextStatus { get; set; }

        [RunAtModelSetup]
        public static void SetupRelations(ModelBuilder modelBuilder)
        {
            // setup primary key
            modelBuilder.Entity<RegisterStatus>()
                .Property(x => x.ID)
                .HasColumnName($"Register_to_Status_ID")
                .HasDefaultValueSql("newsequentialid()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<RegisterStatus>()
                .HasOne(ds => ds.Status)
                .WithMany()
                .HasForeignKey(ds => ds.Status_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RegisterStatus>()
                .HasOne(ds => ds.PreviousStatus)
                .WithOne(ds => ds.NextStatus)
                .HasForeignKey<RegisterStatus>(x => x.Parent_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RegisterStatus>()
                .HasOne(ds => ds.Register)
                .WithMany(d => d.RegisterStatusSet)
                .HasForeignKey(ds => ds.Register_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RegisterStatus>()
                .HasIndex(ds => new { ds.Register_ID });

            modelBuilder.Entity<RegisterStatus>()
                .HasIndex(ds => new { ds.Register_ID, ds.DTS_End })
                .HasFilter("(DTS_End is null)")
                .IsUnique();
        }
    }
}