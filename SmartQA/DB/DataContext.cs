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
using SmartQA.Models.Forms;


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
        public DbSet<TestTypeRef> TestTypeRef { get; set; }
        public DbSet<InspectionTechnique> InspectionTechnique { get; set; }
        public DbSet<InspectionSubject> InspectionSubject { get; set; }

        public DbSet<DocumentNaks> DocumentNaks { get; set; }
        public DbSet<DocumentNaks_to_HIFGroup> DocumentNaks_to_HIFGroup { get; set; }

        public DbSet<DocumentNaksAttest> DocumentNaksAttest { get; set; }
        public DbSet<DocumentNaksAttest_to_DetailsType> DocumentNaksAttest_to_DetailsType { get; set; }
        public DbSet<DocumentNaksAttest_to_SeamsType> DocumentNaksAttest_to_SeamsType { get; set; }
        public DbSet<DocumentNaksAttest_to_WeldMaterialGroup> DocumentNaksAttest_to_WeldMaterialGroup { get; set; }
        public DbSet<DocumentNaksAttest_to_WeldMaterial> DocumentNaksAttest_to_WeldMaterial { get; set; }
        public DbSet<DocumentNaksAttest_to_WeldPosition> DocumentNaksAttest_to_WeldPosition { get; set; }
        public DbSet<DocumentNaksAttest_to_JointKind> DocumentNaksAttest_to_JointKind { get; set; }

        public DataContext() {}

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) {}
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                // Add lazy-load proxies for related entities
                // for more details see https://docs.microsoft.com/ru-ru/ef/core/querying/related-data
                .UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ----- auth ---------------
            CommonEntity.CommonModelSetup<AppUser>(modelBuilder);
            CommonEntity.CommonModelSetup<Role>(modelBuilder);
            CommonEntity.CommonModelSetup<AppUser_to_Role>(modelBuilder);
                
            modelBuilder.Entity<AppUser_to_Role>()
                .HasOne(ur => ur.Created_User);
            modelBuilder.Entity<AppUser_to_Role>()
                .HasOne(ur => ur.AppUser);
            modelBuilder.Entity<AppUser_to_Role>()
                .HasOne(ur => ur.Modified_User);

            // ----- people -------------
            CommonEntity.CommonModelSetup<Person>(modelBuilder);
            CommonEntity.CommonModelSetup<Employee>(modelBuilder);                
            CommonEntity.CommonModelSetup<Division>(modelBuilder);                
            CommonEntity.CommonModelSetup<Position>(modelBuilder);                
            CommonEntity.CommonModelSetup<Contragent>(modelBuilder);

            // ----- reftables ----------
            foreach (var reftableType in Reftable.GetReftableTypes())
            {
                typeof(CommonEntity)
                    .GetMethod("CommonModelSetup")
                    .MakeGenericMethod(reftableType)
                    .Invoke(null, new object[] { modelBuilder });
            }

            // ----- permission docs ----
            CommonEntity.CommonModelSetup<DocumentNaks>(modelBuilder);
            CommonEntity.CommonModelSetup<DocumentNaks_to_HIFGroup>(modelBuilder);

            CommonEntity.CommonModelSetup<DocumentNaksAttest>(modelBuilder);
            CommonEntity.CommonModelSetup<DocumentNaksAttest_to_DetailsType>(modelBuilder);
            CommonEntity.CommonModelSetup<DocumentNaksAttest_to_SeamsType>(modelBuilder);
            CommonEntity.CommonModelSetup<DocumentNaksAttest_to_WeldMaterialGroup>(modelBuilder);
            CommonEntity.CommonModelSetup<DocumentNaksAttest_to_WeldMaterial>(modelBuilder);
            CommonEntity.CommonModelSetup<DocumentNaksAttest_to_WeldPosition>(modelBuilder);
            CommonEntity.CommonModelSetup<DocumentNaksAttest_to_JointKind>(modelBuilder);

        }
    }
}
