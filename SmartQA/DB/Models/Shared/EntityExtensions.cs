using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SmartQA.DB.Models.Shared
{
    public static class EntityExtensions
    {
        // this kinda works, but looks really messy
        // TODO: clean up and introduce some clarity

        private static PropertyInfo GetM2MProperty(object obj, Type to, string through = null)
        {
            if (through == null)
            {                
                var t = obj.GetType();
                if (t.Namespace == "Castle.Proxies")
                {
                    t = t.BaseType;
                }
                through = $"{t.Name}_to_{to.Name}Set";             
            }
            return obj.GetType().GetProperty(through);
        }

        public static ICollection<TEntity> GetM2MObjects<TEntity>(this object obj, string through = null)
        {
            var m2mProperty = GetM2MProperty(obj, typeof(TEntity), through);
            var m2mEntityType = m2mProperty.PropertyType.GetGenericArguments()[0];
            var targetProperty = m2mEntityType.GetProperty(typeof(TEntity).Name);

            var m2mEntities = GetM2MProperty(obj, typeof(TEntity), through).GetValue(obj);

            var m2mEntitiesObj = (IEnumerable<object>) typeof(Enumerable)
                .GetMethod("Cast")
                .MakeGenericMethod(typeof(object))
                .Invoke(null, new object[] { m2mEntities });

            return m2mEntitiesObj.Select(x => targetProperty.GetValue(x)).Cast<TEntity>().ToList();                        
        }

        public static ICollection<TKey> GetM2MKeys<TKey, TEntity>(this object obj, string through = null)
        {

            var m2mProperty = GetM2MProperty(obj, typeof(TEntity), through);            
            var m2mEntityType = m2mProperty.PropertyType.GetGenericArguments()[0];
            var toKeyProperty = m2mEntityType.GetProperty($"{typeof(TEntity).Name}_ID");

            var m2mEntities = m2mProperty.GetValue(obj);
            if (m2mEntities == null)
            {
                return new List<TKey>();
            }

            var list = (List<object>)typeof(Enumerable)
                        .GetMethod("ToList")
                        .MakeGenericMethod(typeof(object))
                        .Invoke(null, new object[] {m2mEntities});
            return list.Select(x => toKeyProperty.GetValue(x)).Cast<TKey>().ToList();            
        }

        public static ICollection<Guid> GetM2MKeys<TEntity>(this Object obj, string through = null)
        {
            return GetM2MKeys<Guid, TEntity>(obj, through);
        }

        public static void SetM2MKeys<TKey, TEntity>(this Object obj, ICollection<TKey> value, string through = null)
        {
            var m2mProperty = GetM2MProperty(obj, typeof(TEntity), through);                                    
            var m2mEntityType = m2mProperty.PropertyType.GetGenericArguments()[0];
            var toKeyProperty = m2mEntityType.GetProperty($"{typeof(TEntity).Name}_ID");

            var m2mEntities = m2mProperty.GetValue(obj);
            if (m2mEntities == null)
            {
                m2mEntities = Activator.CreateInstance(typeof(List<>).MakeGenericType(typeof(TEntity)));
            }

            var list = (List<object>) typeof(Enumerable)
                .GetMethod("ToList")
                .MakeGenericMethod(typeof(object))
                .Invoke(null, new object[] {m2mEntities});

            foreach (var rel in list.Where(x => !value.Contains((TKey) toKeyProperty.GetValue(x))))
            {
                typeof(TEntity).GetMethod("MarkDeleted").Invoke(rel, new object[]{});                
            }

            var existingIds = GetM2MKeys<TKey, TEntity>(obj, through);

            foreach (var id in value.Where(x => !existingIds.Contains(x)))
            {
                var rel = Activator.CreateInstance(m2mEntityType);
                toKeyProperty.SetValue(rel, id);

                if (obj is CommonEntity entity)
                {                    
                    entity.AddM2MToCache((CommonEntity) rel);
                }
                
                list.Add(rel);                
            }

            var en = typeof(Enumerable)
                .GetMethod("Cast")
                .MakeGenericMethod(m2mEntityType)
                .Invoke(null, new object[] { list });

            var result = typeof(Enumerable)
                .GetMethod("ToList")
                .MakeGenericMethod(m2mEntityType)
                .Invoke(null, new object[] { en });

            m2mProperty.SetValue(obj, result);
        }

        public static void SetM2MKeys<TEntity>(this Object obj, ICollection<Guid> value, string through = null)
        {
            SetM2MKeys<Guid, TEntity>(obj, value, through);
        }

    }
}
