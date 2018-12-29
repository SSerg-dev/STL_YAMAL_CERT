using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartQA.Auth;
using SmartQA.DB.Models.Auth;
using SmartQA.DB.Models.Common;

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

            modelBuilder.Entity<T>().HasOne(typeof(RowStatus))
                .WithMany()
                .HasForeignKey("RowStatus")
                .OnDelete(DeleteBehavior.Restrict);

             foreach (var guidPkey in typeof(T).GetProperties().Where(p => 
                 p.GetCustomAttributes(true).Any(a => a is KeyAttribute) && p.PropertyType == typeof(Guid)))
             {
                 modelBuilder.Entity<T>()
                     .Property(guidPkey.Name)
                     .HasDefaultValueSql("newsequentialid()")
                     .ValueGeneratedOnAdd();
             }
        }

        public void MarkDeleted()
        {
            this.RowStatus = 200;            
        }

        public virtual void OnSave(DbContext context, ApplicationUser applicationUser)
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
            
            M2MEntityCache?.ForEach(x =>
            {
                if (x.RowStatus != 200)
                {
                    x.OnSave(context, applicationUser);
                }
                else
                {
                    context.Remove((object) x);
                }
            });
        }

        [NotMapped] private List<CommonEntity> M2MEntityCache { get; set; }

        public void AddM2MToCache(CommonEntity m2mEntity)
        {
            if (M2MEntityCache == null)
            {
                M2MEntityCache = new List<CommonEntity>();
            }
            M2MEntityCache.Add(m2mEntity);
        }

    }
}
