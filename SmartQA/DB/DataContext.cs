using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Classification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding;
using SmartQA.DB.Models.Auth;
using SmartQA.DB.Models.Common;
using SmartQA.DB.Models.Documents;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.PermissionDocuments;
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;
using SmartQA.Models.Forms;
using SQLitePCL;

namespace SmartQA.DB
{
    public partial class DataContext : DbContext
    {        
        public static readonly Guid rootUserId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        private static readonly string rootUserDefaultPassword = "root_pwd_18";

        public DataContext() {}

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) {}
        
        public async Task<DateTime> GetConstructionSiteDT(DateTimeOffset datetimeoffset)
        {
            
            var resultParameter = new SqlParameter("@result", SqlDbType.DateTime2);            
            resultParameter.Direction = ParameterDirection.Output;
            await Database.ExecuteSqlCommandAsync("set @result = dbo.f_SiteDTS({0});", datetimeoffset, resultParameter);
            var result = (DateTime) resultParameter.Value;
                  
            return result;
        }

  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                // Add lazy-load proxies for related entities
                // for more details see https://docs.microsoft.com/ru-ru/ef/core/querying/related-data
                .UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.HasSequence<long>("Sequence_Document_Number");
            modelBuilder.HasSequence<long>("Sequence_CheckList_Number");
            modelBuilder.HasSequence<long>("Sequence_Register_Number");
            
            SetupCommonEntities(modelBuilder);
            SetupConstraints(modelBuilder);
            SetupInitialData(modelBuilder);
        }

        private void SetupCommonEntities(ModelBuilder modelBuilder)
        {
            
            var currentAssembly = typeof(Reftable).Assembly;

            var commonEntityTypes =  currentAssembly.GetExportedTypes().Where(
                x => x.IsSubclassOf(typeof(CommonEntity)) && !x.IsAbstract
            );            
            
            foreach (var commonType in commonEntityTypes)
            {
                typeof(CommonEntity)
                    .GetMethod("CommonModelSetup")
                    .MakeGenericMethod(commonType)
                    .Invoke(null, new object[] { modelBuilder });                
  
                if (commonType.GetCustomAttributes(true).FirstOrDefault(a => a is M2MAttribute) is M2MAttribute m2mAttr)
                {
                    var m2mRelName = $"{commonType.Name}Set";
                    var m2mRelNameLeft = m2mAttr.Left.GetProperty(m2mRelName) != null ? m2mRelName : null;
                    var m2mRelNameRight = m2mAttr.Right.GetProperty(m2mRelName) != null ? m2mRelName : null;
                                      
                    modelBuilder.Entity(commonType)
                        .HasOne(m2mAttr.Left, m2mAttr.Left.Name)                        
                        .WithMany(m2mRelNameLeft)
                        .HasForeignKey(m2mAttr.LeftFKey)
                        .OnDelete(DeleteBehavior.Restrict);

                    modelBuilder.Entity(commonType)
                        .HasOne(m2mAttr.Right, m2mAttr.Right.Name)
                        .WithMany(m2mRelNameRight)
                        .HasForeignKey(m2mAttr.RightFKey)
                        .OnDelete(DeleteBehavior.Restrict);
                }

                // call any custom setup methods on model 
                foreach (var setupMethod in commonType.GetMethods()
                    .Where(
                        m => m.GetCustomAttributes(true).Any(a => a is RunAtModelSetupAttribute) && m.IsStatic 
                    ))
                {
                    setupMethod.Invoke(null, new object[] { modelBuilder });                
                }                                 

            }            
            
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

                var ix = entity.GetType()                  
                    .GetMethod("HasIndex", new Type[] { (new string[]{}).GetType() })                    
                    .Invoke(entity, new object[] { new string[] {"Title"}});
                
                ix.GetType()
                    .GetMethod("IsUnique", new Type[] { typeof(bool) })
                    .Invoke(ix, new object[] { true });

            }

            modelBuilder.Entity<Parameter>()
                .HasIndex(u => u.Parameter_Code)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasIndex(u => u.Employee_Code)
                .IsUnique();

            modelBuilder.Entity<Contragent>()
                .HasIndex(u => u.Title)
                .IsUnique();

            modelBuilder.Entity<Division>()
                .HasIndex(u => u.Title)
                .IsUnique();

            modelBuilder.Entity<Position>()
                .HasIndex(u => u.Title)
                .IsUnique();

            modelBuilder.Entity<DocumentType>()
                .HasIndex(u => u.Title)
                .IsUnique();

            modelBuilder.Entity<Document_to_GOST>()
                .HasIndex(u => new {u.Document_ID, u.GOST_ID})
                .IsUnique();

            modelBuilder.Entity<Document_to_PID>()
                .HasIndex(u => new {u.Document_ID, u.PID_ID})
                .IsUnique();

            modelBuilder.Entity<GOST>()
                .HasIndex(u => u.GOST_Code)
                .IsUnique();

            modelBuilder.Entity<GOST_to_PID>()
                .HasIndex(u => new {u.GOST_ID, u.PID_ID})
                .IsUnique();

            modelBuilder.Entity<GOST_to_TitleObject>()
                .HasIndex(u => new {u.GOST_ID, u.TitleObject_ID})
                .IsUnique();

            modelBuilder.Entity<AppUser>()
                .HasIndex(u => u.AppUser_Code)
                .IsUnique();

            modelBuilder.Entity<AppUser_to_Role>()
                .HasIndex(u => new {u.AppUser_ID, u.Role_ID})
                .IsUnique();

        }               
    }
}
