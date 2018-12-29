using System;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB.Models.Auth;
using SmartQA.DB.Models.Common;
using SmartQA.DB.Models.Documents;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.PermissionDocuments;
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;
using SmartQA.Models.Forms;

namespace SmartQA.DB
{
    public partial class DataContext : DbContext
    {
        
        public static readonly Guid rootUserId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        private static readonly string rootUserDefaultPassword = "root_pwd_18";

        public DbSet<RowStatus> RowStatus { get; set; }
        
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Role> Role { get; set; }        
        public DbSet<AppUser_to_Role> AppUser_to_Role { get; set; }        

        public DbSet<Person> Person { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Division> Division { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Contragent> Contragent { get; set; }
        public DbSet<ContragentRole> ContragentRole { get; set; }

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
        public DbSet<TestMethod> TestMethod { get; set; }
        public DbSet<QualificationLevel> QualificationLevel { get; set; }
        public DbSet<Responsibility> Responsibility { get; set; }
        public DbSet<WeldPasses> WeldPasses { get; set; }
        public DbSet<QualificationField> QualificationField { get; set; }
        public DbSet<ElectricalSafetyAbilitation> ElectricalSafetyAbilitation { get; set; }
        public DbSet<AccessToPIVoltageRange> AccessToPIVoltageRange { get; set; }
        public DbSet<AccessToPIStaffFunction> AccessToPIStaffFunction { get; set; }
        public DbSet<AuthToSignInspActsForWSUN> AuthToSignInspActsForWSUN { get; set; }
        public DbSet<ShieldingGas> ShieldingGas { get; set; }
        public DbSet<AttCenterNaks> AttCenterNaks { get; set; }

        public DbSet<DocumentNaks> DocumentNaks { get; set; }
        public DbSet<DocumentNaks_to_HIFGroup> DocumentNaks_to_HIFGroup { get; set; }

        public DbSet<DocumentNaksAttest> DocumentNaksAttest { get; set; }
        public DbSet<DocumentNaksAttest_to_DetailsType> DocumentNaksAttest_to_DetailsType { get; set; }
        public DbSet<DocumentNaksAttest_to_SeamsType> DocumentNaksAttest_to_SeamsType { get; set; }
        public DbSet<DocumentNaksAttest_to_WeldMaterialGroup> DocumentNaksAttest_to_WeldMaterialGroup { get; set; }
        public DbSet<DocumentNaksAttest_to_WeldMaterial> DocumentNaksAttest_to_WeldMaterial { get; set; }
        public DbSet<DocumentNaksAttest_to_WeldPosition> DocumentNaksAttest_to_WeldPosition { get; set; }
        public DbSet<DocumentNaksAttest_to_JointKind> DocumentNaksAttest_to_JointKind { get; set; }
        public DbSet<DocumentNaksAttest_to_WeldGOST14098> DocumentNaksAttest_to_WeldGOST14098 { get; set; }
        public DbSet<DocumentNaksAttest_to_JointType> DocumentNaksAttest_to_JointType { get; set; }

        public DbSet<Marka> Marka { get; set; }
        public DbSet<TitleObject> TitleObject { get; set; }
        
        public DbSet<PID> PID { get; set; }
        public DbSet<GOST> GOST { get; set; }
        public DbSet<GOST_to_TitleObject> GOST_to_TitleObject { get; set; }
        public DbSet<GOST_to_PID> GOST_to_PID { get; set; }
        
        public DbSet<Status> Status { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<DocumentProjectNumber> DocumentProjectNumber { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Document_to_GOST> Document_to_GOST { get; set; }
        public DbSet<Document_to_PID> Document_to_PID { get; set; }
        public DbSet<Document_to_Status> Document_to_Status { get; set; }
     
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
                .HasOne(ur => ur.AppUser)
                .WithMany(u => u.AppUser_to_RoleSet);
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
            modelBuilder.Entity<DocumentNaks>()
                .HasOne(d => d.ParentDocumentNaks)
                .WithMany(d => d.Inserts);

            CommonEntity.CommonModelSetup<DocumentNaks_to_HIFGroup>(modelBuilder);

            CommonEntity.CommonModelSetup<DocumentNaksAttest>(modelBuilder);
            CommonEntity.CommonModelSetup<DocumentNaksAttest_to_DetailsType>(modelBuilder);
            CommonEntity.CommonModelSetup<DocumentNaksAttest_to_SeamsType>(modelBuilder);
            CommonEntity.CommonModelSetup<DocumentNaksAttest_to_WeldMaterialGroup>(modelBuilder);
            CommonEntity.CommonModelSetup<DocumentNaksAttest_to_WeldMaterial>(modelBuilder);
            CommonEntity.CommonModelSetup<DocumentNaksAttest_to_WeldPosition>(modelBuilder);
            CommonEntity.CommonModelSetup<DocumentNaksAttest_to_JointKind>(modelBuilder);
            CommonEntity.CommonModelSetup<DocumentNaksAttest_to_WeldGOST14098>(modelBuilder);
            CommonEntity.CommonModelSetup<DocumentNaksAttest_to_JointType>(modelBuilder);
            
            // ----- documents ----
            CommonEntity.CommonModelSetup<PID>(modelBuilder);
            CommonEntity.CommonModelSetup<GOST>(modelBuilder);
            CommonEntity.CommonModelSetup<GOST_to_TitleObject>(modelBuilder);
            CommonEntity.CommonModelSetup<GOST_to_PID>(modelBuilder);
            CommonEntity.CommonModelSetup<Status>(modelBuilder);
            CommonEntity.CommonModelSetup<Document>(modelBuilder);
            CommonEntity.CommonModelSetup<Document_to_PID>(modelBuilder);
            CommonEntity.CommonModelSetup<Document_to_GOST>(modelBuilder);
            CommonEntity.CommonModelSetup<Document_to_Status>(modelBuilder);         
            
            modelBuilder.Entity<Document>()
                .HasOne(d => d.Root)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Document_to_Status>()
                .HasOne(d => d.Parent)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.HasSequence<long>("Sequence_Document_Number");
            modelBuilder.HasSequence<long>("Sequence_CheckList_Number");
            modelBuilder.HasSequence<long>("Sequence_Register_Number");
            
            SetupConstraints(modelBuilder);
            SetupInitialData(modelBuilder);
        }

        private void SetupConstraints(ModelBuilder modelBuilder)
        {        
            // ----- reftables ----------
            foreach (var reftableType in Reftable.GetReftableTypes())
            {
                var entity = modelBuilder.GetType()
                    .GetMethod("Entity", new Type[] {})
                    .MakeGenericMethod(reftableType)
                    .Invoke(modelBuilder, new object[] { });

                var ak = entity.GetType()
                    .GetMethod("HasAlternateKey", new Type[] { (new string[]{}).GetType() })
                    .Invoke(entity, new object[] { new string[] {"Title"}});

            }
            
            modelBuilder.Entity<Employee>()
                .HasAlternateKey(u => u.Employee_Code)
                .HasName("UQ_p_Employee");

            modelBuilder.Entity<Contragent>()
                .HasAlternateKey(u => u.Title)
                .HasName("UQ_p_Contragent");
            
            // TODO: rework or remove this
            modelBuilder.Entity<Division>()
                .HasAlternateKey(u => u.Division_Code)
                .HasName("UQ_p_Division");
            
            modelBuilder.Entity<DocumentType>()
                .HasAlternateKey(u => u.Title)
                .HasName("UQ_p_DocumentType");
            
            modelBuilder.Entity<Document>()
                .HasAlternateKey(u => u.Document_Code)
                .HasName("UQ_p_Document");
            
            modelBuilder.Entity<Document_to_GOST>()
                .HasAlternateKey(u => new { u.Document_ID, u.GOST_ID })
                .HasName("UQ_p_Document_to_GOST");
            
            modelBuilder.Entity<Document_to_PID>()
                .HasAlternateKey(u => new { u.Document_ID, u.PID_ID })
                .HasName("UQ_p_Document_to_PID");

            modelBuilder.Entity<GOST>()
                .HasAlternateKey(u => u.GOST_Code)
                .HasName("UQ_p_GOST");
            
            modelBuilder.Entity<GOST_to_PID>()
                .HasAlternateKey(u => new { u.GOST_ID, u.PID_ID })
                .HasName("UQ_p_GOST_to_PID");
            
            modelBuilder.Entity<GOST_to_TitleObject>()
                .HasAlternateKey(u => new { u.GOST_ID, u.TitleObject_ID })
                .HasName("UQ_p_GOST_to_TitleObject");
            
            modelBuilder.Entity<AppUser>()
                .HasAlternateKey(u => u.AppUser_Code)
                .HasName("UQ_p_AppUser");
            
            modelBuilder.Entity<AppUser_to_Role>()
                .HasAlternateKey(u => new { u.AppUser_ID, u.Role_ID })
                .HasName("UQ_p_AppUser_to_Role");

        }

        
    }
}
