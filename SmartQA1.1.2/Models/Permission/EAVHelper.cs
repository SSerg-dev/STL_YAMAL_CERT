using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using SmartQA1._1._2.DB.PermissionDb;
using SmartQA1._1._2.Models.Permission.DocumentTypes;

namespace SmartQA1._1._2.Models.Permission
{
    public class EAVHelper
    {

        private Dictionary<Type, Dictionary<Guid, object>> EntityCache { get; set; }
            = new Dictionary<Type, Dictionary<Guid, object>>();

        public Type DocumentType { get; set; }
        private DEV_WEB_MainDataEntities Context { get; set; }

        public EAVHelper(DEV_WEB_MainDataEntities context, Type documentType)
        {
            this.DocumentType = documentType;
            this.Context = context;
        }

        public ICollection<object> GetEntities(Type entityType)
        {
            if (!EntityCache.ContainsKey(entityType))
            {
                FetchEntities(entityType);
            }

            return EntityCache[entityType].Values;
        }

        public object GetEntity(Type entityType, Guid key)
        {
            if (!EntityCache.ContainsKey(entityType))
            {
                FetchEntities(entityType);
            }
            return EntityCache[entityType][key];
        }

        private void FetchEntities(Type entityType)
        {                       
            var setMethod = typeof(ObjectContext).GetMethod("CreateObjectSet", new Type[] { })
                .MakeGenericMethod(entityType);
            var set = setMethod.Invoke(((IObjectContextAdapter)Context).ObjectContext, new object[] { });
            
            var entityDict = new Dictionary<Guid, object>();

            foreach (var obj in (IEnumerable<object>)set)
            {
                entityDict[GetPrimaryKey(obj)] = obj;
            }

            EntityCache[entityType] = entityDict;
           
        }

        public Guid GetPrimaryKey(object obj)
        {
            var entityType = obj.GetType();
            var objectSetType = typeof(ObjectSet<>).MakeGenericType(entityType);

            var setMethod = typeof(ObjectContext).GetMethod("CreateObjectSet", new Type[] { })
                .MakeGenericMethod(obj.GetType());
            var set = setMethod.Invoke(((IObjectContextAdapter)Context).ObjectContext, new object[] { });
            var primaryKeyPropertyName = ((EntitySet)objectSetType.GetProperty("EntitySet").GetValue(set))
                .ElementType.KeyMembers.Select(k => k.Name).Single();
            var primaryKeyProperty = entityType.GetProperty(primaryKeyPropertyName);

            return (Guid) primaryKeyProperty.GetValue(obj);
        }

    }
}