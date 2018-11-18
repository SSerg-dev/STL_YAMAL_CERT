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

        public static ICollection<TKey> GetM2MKeys<TKey>(this Object obj, Type to, string through = null)
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

            var m2mProperty = obj.GetType().GetProperty(through);
            var pt = m2mProperty.PropertyType;
            var m2mEntityType = pt.GetGenericArguments()[0];
            var toKeyProperty = m2mEntityType.GetProperty($"{to.Name}_ID");

            var m2mEntities = m2mProperty.GetValue(obj);
            if (m2mEntities == null)
            {
                return new List<TKey>();
            }

            var list = (List<object>)typeof(Enumerable)
                        .GetMethod("ToList")
                        .MakeGenericMethod(typeof(object))
                        .Invoke(null, new object[] {m2mEntities});
            return (List<TKey>) list.Select(x => toKeyProperty.GetValue(x)).Cast<TKey>().ToList();            
        }

        public static ICollection<Guid> GetM2MKeys(this Object obj, Type to, string through = null)
        {
            return GetM2MKeys<Guid>(obj, to, through);
        }

        public static void SetM2MKeys<TKey>(this Object obj, Type to, ICollection<TKey> value, string through = null)
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

            var existingIds = GetM2MKeys<TKey>(obj, to, through);

            var m2mProperty = obj.GetType().GetProperty(through);
            var pt = m2mProperty.PropertyType;
            var m2mEntityType = pt.GetGenericArguments()[0];
            var toKeyProperty = m2mEntityType.GetProperty($"{to.Name}_ID");

            var m2mEntities = m2mProperty.GetValue(obj);
            if (m2mEntities == null)
            {
                m2mEntities = Activator.CreateInstance(typeof(List<>).MakeGenericType(to));
            }

            var list = (List<object>) typeof(Enumerable)
                .GetMethod("ToList")
                .MakeGenericMethod(typeof(object))
                .Invoke(null, new object[] {m2mEntities});

            foreach (var rel in list.Where(x => !value.Contains((TKey) toKeyProperty.GetValue(x))))
            {
                to.GetMethod("MarkDeleted").Invoke(rel, new object[]{});                
            }

            foreach (var id in value.Where(x => !existingIds.Contains(x)))
            {
                var rel = Activator.CreateInstance(m2mEntityType);
                toKeyProperty.SetValue(rel, id);
                to.GetMethod("OnSave").Invoke(rel, new object[] { });
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

        public static void SetM2MKeys(this Object obj, Type to, ICollection<Guid> value, string through = null)
        {
            SetM2MKeys<Guid>(obj, to, value, through);
        }

    }
}
