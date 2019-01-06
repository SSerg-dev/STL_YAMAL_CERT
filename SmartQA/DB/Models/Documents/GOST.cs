using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.Documents
{
    [Table("p_GOST")]
    public class GOST : CommonEntity
    {
        [Required]
        [StringLength(255)]
        public string GOST_Code { get; set; }
        
        [StringLength(255)]
        public string Description_Rus { get; set; }
        
        public Guid? Marka_ID { get; set; }
        
        public virtual Marka Marka { get; set; }
        
        
        // ---- m2m relations -------------

        public virtual ICollection<GOST_to_PID> GOST_to_PIDSet { get; set; }

        [NotMapped]
        public ICollection<PID> PIDSet => this.GetM2MObjects<PID>();
        [NotMapped]
        public ICollection<Guid> PID_IDs
        {
            get => this.GetM2MKeys<PID>();
            set => this.SetM2MKeys<PID>(value);                
        }        
        
        public virtual ICollection<GOST_to_TitleObject> GOST_to_TitleObjectSet { get; set; }

        [NotMapped]
        public ICollection<TitleObject> TitleObjectSet => this.GetM2MObjects<TitleObject>();
        [NotMapped]
        public ICollection<Guid> TitleObject_IDs
        {
            get => this.GetM2MKeys<TitleObject>();
            set => this.SetM2MKeys<TitleObject>(value);                
        }

        [RunAtModelSetup]
        public static void SetupRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GOST>()
                .HasOne(x => x.Marka)
                .WithMany()
                .HasForeignKey(x => x.Marka_ID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}