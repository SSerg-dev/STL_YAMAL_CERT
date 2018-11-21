using Microsoft.EntityFrameworkCore;
using SmartQA.Auth;
using SmartQA.DB.Models.Auth;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartQA.DB.Models.Shared
{
    public class CommonEntity
    {
        [Required]
        public int? RowStatus { get; set; }
        [Required]
        public DateTime? Insert_DTS { get; set; }
        [Required]
        public DateTime? Update_DTS { get; set; }
        public Guid Created_User_ID { get; set; }
        public Guid Modified_User_ID { get; set; }
        
        [ForeignKey("Created_User_ID")]
        public virtual AppUser Created_User { get; set; }

        [ForeignKey("Modified_User_ID")]
        public virtual AppUser Modified_User { get; set; }


        public static void CommonModelSetup<T>(ModelBuilder modelBuilder) where T : CommonEntity
        {            
            modelBuilder.Entity<T>()
                .HasOne(x => x.Created_User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<T>()
                .HasOne(x => x.Modified_User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<T>()
                .HasQueryFilter(x => x.RowStatus < 100);
        }

        public void MarkDeleted(ApplicationUser applicationUser)
        {
            this.RowStatus = 200;
            this.OnSave(applicationUser);
        }

        public virtual void OnSave(ApplicationUser applicationUser)
        {                        
            if (RowStatus == null)
            {
                RowStatus = 0;
            }
            if (Insert_DTS == null)
            {
                Insert_DTS = DateTime.UtcNow;                
            }

            if (Created_User_ID == Guid.Empty)
            {                
                Created_User_ID = applicationUser.Id;
            }

            Update_DTS = DateTime.UtcNow;            
            Modified_User_ID = applicationUser.Id;
        }
    }
}
