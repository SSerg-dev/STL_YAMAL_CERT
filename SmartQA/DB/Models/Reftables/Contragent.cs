using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB.Models.PermissionDocuments;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Reftables
{
    [UseDefaultReftableEditor]
    [Display(Name = "Организация")]
    [Table("p_Contragent")]
    public class Contragent : CommonEntity, IReftableEntity
    {
        [StringLength(255)] public string Description_Eng { get; set; }

        public Guid? ContragentRole_ID { get; set; }
        
        public virtual ContragentRole ContragentRole { get; set; }

        [Required]
        [Column("Contragent_Code")]
        [StringLength(255)]
        public string Title { get; set; }

        [Column("Description_Rus")]
        [StringLength(255)]
        public string Description { get; set; }

        [RunAtModelSetup]
        public static void SetupRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contragent>()
                .HasOne(x => x.ContragentRole)
                .WithMany()
                .HasForeignKey(x => x.ContragentRole_ID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}