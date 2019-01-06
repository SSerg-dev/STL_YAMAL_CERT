using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.IO;
using System.Linq;
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


namespace SmartQA.Cli
{        
    
    class Program
    {
        public IServiceProvider ServiceProvider { get; set; }

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
                
                var existing = context.Find(objType, obj.GetPKey(context));
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
            foreach (var iet in context.Model.GetEntityTypes())                
            {                
                var coll = context.GetType().GetMethod("Set").MakeGenericMethod(iet.ClrType).Invoke(
                    context, new object[] { });

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
            //var configPath = "../SmartQA/appsettings.Development.json";                       
            const string configPath = "../SmartQA/appsettings.Production.json";                       
            var workingDir = Directory.GetCurrentDirectory();
            
            IServiceCollection services = new ServiceCollection();
            var builder = new ConfigurationBuilder();
                        
            builder.AddJsonFile(Path.Join(workingDir, configPath));
            var conf = builder.Build();
            
            Startup startup = new Startup(conf);
            startup.ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            var context = serviceProvider.GetService<DataContext>();
            
//            var logger = serviceProvider.GetService<ILoggerFactory>()
//                .CreateLogger<Program>();
                   
            Console.WriteLine("ok");
            
            using (StreamWriter sw = new StreamWriter("data.json"))
            {
                DbExport(context, sw);
            }

//            using (StreamReader sr = new StreamReader("data.json"))
//            {
//                DbImport(context, sr);
//            }
            
        }

    }
}