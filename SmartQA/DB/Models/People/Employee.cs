using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB.Models.Auth;
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;

namespace SmartQA.DB.Models.People
{  
    [Table("p_Employee")]
    public class Employee : CommonEntity
    {
        [Required]
        [StringLength(255)]
        public string Employee_Code { get; set; }
        
        public System.Guid Person_ID { get; set; }

        public Guid Position_ID { get; set; }
        
        public Guid? AppUser_ID { get; set; }
        public Guid? Contragent_ID { get; set; }
    
        public virtual Person Person { get; set; }    
        public virtual AppUser AppUser { get; set; }     
        public virtual Contragent Contragent { get; set; }     
        public virtual Position Position { get; set; }

        [RunAtModelSetup]
        public static void SetupRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(x => x.Person)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.Person_ID)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Employee>()
                .HasOne(x => x.AppUser)
                .WithOne(u => u.Employee)
                .HasForeignKey<Employee>(x => x.AppUser_ID)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Employee>()
                .HasOne(x => x.Contragent)
                .WithMany()
                .HasForeignKey(x => x.Contragent_ID)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Employee>()
                .HasOne(x => x.Position)
                .WithMany()
                .HasForeignKey(x => x.Position_ID)
                .OnDelete(DeleteBehavior.Restrict);            
            
        }
    }
}
