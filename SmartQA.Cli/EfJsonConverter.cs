using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartQA.DB;
using SmartQA.DB.Models.Shared;
using StackExchange.Redis;

namespace SmartQA.Cli
{
    public class EfJsonConverter
    {
        private DataContext Context { get; set; }
        
        public EfJsonConverter(DataContext context)
        {
            Context = context;
        }


        private static Type[] supportedTypes = 
        {
            typeof(long),
            typeof(long?),
            typeof(int),
            typeof(int?),
            typeof(byte[]),
            typeof(byte[]),
            typeof(Guid),
            typeof(Guid?),
            typeof(float?),
            typeof(float),
            typeof(DateTime),
            typeof(DateTime?),
            typeof(DateTimeOffset),
            typeof(DateTimeOffset?),
            typeof(string),
        };

        /// <summary>
        /// Convert json array string to objects
        /// </summary>
        public IEnumerable<object> Deserialize(string jsonList)
        {            
            return JArray.Parse(jsonList).Select(x => FromJObject(x as JObject));
        } 
        
        public object FromJObject(JObject jobj)
        {            
            var typeName = jobj["__EntityType"].Value<string>();
            var entityType = Context.Model.FindEntityType(typeName);
            return jobj.ToObject(entityType.ClrType);
            
        }

        /// <summary>
        /// Convert objects to json array
        /// </summary>
        public JArray Serialize(IEnumerable<object> objects)
        {
            var arr = new JArray();
            foreach (var obj in objects)
            {
                arr.Add(ToJObject(obj));
            }
            
            return arr;
        }
        
        public JObject ToJObject(object obj)
        {                        
            dynamic item = new ExpandoObject();
            var dItem = item as IDictionary<string, object>;
            
            var objType = (obj is IProxyTargetAccessor)
                ? ProxyUtil.GetUnproxiedType(obj)
                : obj.GetType();
                  
            var entityType = Context.Model.GetEntityTypes().First(et => et.ClrType == objType);

            Console.WriteLine($"Exporting {obj})");
            
            dItem["__EntityType"] = entityType.Name;

            foreach (var prop in entityType.GetProperties())
            {
                dItem[prop.Name] = obj.GetType().GetProperty(prop.Name).GetValue(obj);  
            };
                       
            
            return JObject.FromObject(item);
        }
    }
}