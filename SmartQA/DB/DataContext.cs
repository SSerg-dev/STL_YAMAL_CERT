using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB.Models;
using SmartQA.DB.Models.Auth;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.PermissionDocuments;
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;


namespace SmartQA.DB
{
    public class DataContext : DbContext
    {
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Role> Role { get; set; }        
        public DbSet<AppUser_to_Role> AppUser_to_Role { get; set; }        

        public DbSet<Person> Person { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Division> Division { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Contragent> Contragent { get; set; }

        public DbSet<DetailsType> DetailsType { get; set; }
        public DbSet<HIFGroup> HIFGroup { get; set; }
        public DbSet<JointKind> JointKind { get; set; }
        public DbSet<JointType> JointType { get; set; }
        public DbSet<SeamsType> SeamsType { get; set; }
        public DbSet<WeldGOST14098> WeldGOST14098 { get; set; }
        public DbSet<WeldingEquipmentAutomationLevel> WeldingEquipmentAutomationLevel { get; set; }
        public DbSet<WeldMaterial> WeldMaterial { get; set; }
        public DbSet<WeldMaterialGroup> WeldMaterialGroup { get; set; }
        public DbSet<WeldPosition> WeldPosition { get; set; }
        public DbSet<WeldType> WeldType { get; set; }

        public DbSet<DocumentNaks> DocumentNaks { get; set; }
        public DbSet<DocumentNaks_to_HIFGroup> DocumentNaks_to_HIFGroup { get; set; }

        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            CommonEntity.CommonModelSetup<Contragent>(modelBuilder);
            CommonEntity.CommonModelSetup<AppUser>(modelBuilder);
            CommonEntity.CommonModelSetup<Role>(modelBuilder);
            CommonEntity.CommonModelSetup<AppUser_to_Role>(modelBuilder);
                
            modelBuilder.Entity<AppUser_to_Role>()
                .HasOne(ur => ur.Created_User);
            modelBuilder.Entity<AppUser_to_Role>()
                .HasOne(ur => ur.AppUser);
            modelBuilder.Entity<AppUser_to_Role>()
                .HasOne(ur => ur.Modified_User);                            

            CommonEntity.CommonModelSetup<Person>(modelBuilder);

//            modelBuilder
//                .Entity<Person>()
//                .Property(p => p.BirthDate)
//                .HasConversion(new LocalDateValueConverter());


            CommonEntity.CommonModelSetup<Employee>(modelBuilder);                
            CommonEntity.CommonModelSetup<Division>(modelBuilder);                
            CommonEntity.CommonModelSetup<Position>(modelBuilder);                
            CommonEntity.CommonModelSetup<Contragent>(modelBuilder);

            CommonEntity.CommonModelSetup<DetailsType>(modelBuilder);
            CommonEntity.CommonModelSetup<HIFGroup>(modelBuilder);
            CommonEntity.CommonModelSetup<JointKind>(modelBuilder);
            CommonEntity.CommonModelSetup<JointType>(modelBuilder);
            CommonEntity.CommonModelSetup<SeamsType>(modelBuilder);
            CommonEntity.CommonModelSetup<WeldGOST14098>(modelBuilder);
            CommonEntity.CommonModelSetup<WeldingEquipmentAutomationLevel>(modelBuilder);
            CommonEntity.CommonModelSetup<WeldMaterial>(modelBuilder);
            CommonEntity.CommonModelSetup<WeldMaterialGroup>(modelBuilder);
            CommonEntity.CommonModelSetup<WeldPosition>(modelBuilder);
            CommonEntity.CommonModelSetup<WeldType>(modelBuilder);

            CommonEntity.CommonModelSetup<DocumentNaks>(modelBuilder);
            CommonEntity.CommonModelSetup<DocumentNaks_to_HIFGroup>(modelBuilder);

//            modelBuilder
//                .Entity<DocumentNaks>()
//                .Property(p => p.IssueDate)
//                .HasConversion(new LocalDateValueConverter());
//
//            modelBuilder
//                .Entity<DocumentNaks>()
//                .Property(p => p.ValidUntil)
//                .HasConversion(new LocalDateValueConverter());


        }
    }
}
