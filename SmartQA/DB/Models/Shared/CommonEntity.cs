using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB.Models.Auth;
using SmartQA.DB.Models.People;

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

        public void MarkDeleted()
        {
            this.RowStatus = 200;
        }

        public virtual void OnSave()
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
                // TODO: Replace when proper authentication is added
                Created_User_ID = Guid.Parse("E43B02A5-1EF1-464D-B527-4EA9F9C6AF74");
            }

            Update_DTS = DateTime.UtcNow;

            // TODO: Replace when proper authentication is added
            Modified_User_ID = Guid.Parse("E43B02A5-1EF1-464D-B527-4EA9F9C6AF74");
        }
    }
}
