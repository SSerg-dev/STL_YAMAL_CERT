using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB.Models.Files;
using SmartQA.DB.Models.Shared;
using SmartQA.DB.Models.Documents;

namespace SmartQA.DB.Models.Registers
{
    [Table("p_Register_to_Document")]
    public class Register_to_Document : CommonEntity
    {

        public Guid Register_ID { get; set; }
        public Guid Document_ID { get; set; }

        public int Iteration { get; set; }
        public int NumberInRegister { get; set; }
        public int SheetFolderNumber { get; set; }

        [StringLength(255)]
        public string Comment { get; set; }

        public virtual Register Register { get; set; }
        public virtual Document Document { get; set; }
        

        [RunAtModelSetup]
        public static void SetupRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Register_to_Document>()
                .HasOne(df => df.Register)
                .WithMany(d => d.Register_to_DocumentSet)
                .HasForeignKey(x => x.Register_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Register_to_Document>()
                .HasOne(df => df.Document)
                .WithOne()
                .HasForeignKey<Register_to_Document>(df => df.Document_ID)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}