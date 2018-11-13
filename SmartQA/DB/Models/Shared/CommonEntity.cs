using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Data.Helpers;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB.Models.Auth;
using SmartQA.DB.Models.People;

namespace SmartQA.DB.Models.Shared
{
    public class CommonEntity
    {
        public int RowStatus { get; set; }
        public DateTime Insert_DTS { get; set; }
        public DateTime Update_DTS { get; set; }
        public Guid Created_User_ID { get; set; }
        public Guid Modified_User_ID { get; set; }
        
        [ForeignKey("Created_User_ID")]
        public AppUser Created_User { get; set; }

        [ForeignKey("Modified_User_ID")]
        public AppUser Modified_User { get; set; }

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

    }
}
