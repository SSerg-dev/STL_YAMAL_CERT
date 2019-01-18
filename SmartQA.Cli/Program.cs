using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Castle.Core.Configuration;
using Castle.DynamicProxy;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmartQA.DB;
using SmartQA.DB.Models.Auth;
using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json.Linq;
using SmartQA.DB.Models.Shared;
using SmartQA.DB.Util;


namespace SmartQA.Cli
{        
    
    class Program
    {
        public IServiceProvider ServiceProvider { get; set; }
        
        private static string[] ExcludeEntities = new[]
        {
            "Document",
            "Document_to_GOST",
            "Document_to_PID",
            "DocumentType",
            "DocumentStatus",
            "DocumentAttachment",
            "FileDesc",
            "Status",
            "RowStatus",
            "Parameter",          
//            "AppUser",          
//            "AppUser_to_Role",          
//            "Role",         
            "ContragentRole"
            
            
        };

        static void DbImport(DataContext context, StreamReader reader)
        {
            var converter = new EfJsonConverter(context);
            var objects = converter.Deserialize(reader.ReadToEnd());
            foreach (var obj in objects)
            {
                var objType = (obj is IProxyTargetAccessor)
                    ? ProxyUtil.GetUnproxiedType(obj)
                    : obj.GetType();

                Console.Write($"Importing {obj}... ");

                var existing = typeof(EfUtils)
                    .GetMethod("Find")
                    .MakeGenericMethod(objType)
                    .Invoke(null, new object[] {context, obj.GetPKey(context)});
                
                context.Find(objType, obj.GetPKey(context));
                if (existing != null)
                {
                    Console.WriteLine("exists, skipped");
                }
                else
                {
                    context.Add(obj);
                    Console.WriteLine("ok");
                }                                
            }
           
            
            context.SaveChanges();
        }

        static void DbExport(DataContext context, StreamWriter writer)
        {            
            var result = new JArray();
            var converter = new EfJsonConverter(context);
            foreach (var iet in 
                context.Model
                .GetEntityTypes()
                .Where(iet => !ExcludeEntities.Contains(iet.ClrType.Name))
                )
            {
                var coll = typeof(EfUtils).GetMethod("Query")
                    .MakeGenericMethod(iet.ClrType)
                    .Invoke(null, new[] {context});                
                
                Console.WriteLine($"Exporting {iet.ClrType.Name}...");
                                
                var objs = converter.Serialize((IEnumerable<object>) coll);
                foreach (var o in objs)
                {
                    result.Add(o);
                }
                               
                            
            }
            writer.Write(result.ToString());

        }
        
        static void Main(string[] args)
        {


            //var configPath = "C:\\Users\\mi\\source\\repos\\STL_YAMAL_CERT\\SmartQA\\appsettings.Development.json";                       
            //var dataFilePath = "C:\\Users\\mi\\source\\repos\\STL_YAMAL_CERT\\SmartQA.Cli\\data.json";
            var workingDir = Directory.GetCurrentDirectory();
            
            var configPath = Path.Join(workingDir, "../SmartQA/appsettings.Development.json");
            var dataFilePath = Path.Join(workingDir, "data_p.json");    
            
            IServiceCollection services = new ServiceCollection();
            var builder = new ConfigurationBuilder();

            //builder.AddJsonFile(Path.Join(workingDir, configPath));
            builder.AddJsonFile(configPath);
            var conf = builder.Build();
            
            Startup startup = new Startup(conf);
            startup.ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            var context = serviceProvider.GetService<DataContext>();
            

            Console.WriteLine("Starting");
            
//            using (StreamWriter sw = new StreamWriter(dataFilePath))
//            {
//                DbExport(context, sw);
//            }

            using (StreamReader sr = new StreamReader(dataFilePath))
            {
                DbImport(context, sr);
            }
            
        }

    }
}