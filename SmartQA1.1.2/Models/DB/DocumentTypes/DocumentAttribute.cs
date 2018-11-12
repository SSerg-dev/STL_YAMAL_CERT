using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SmartQA1._1._2.Models.Permission.DocumentTypes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EAVDocumentAttr : System.Attribute
    {
        public string DBAttributeCode;
        public bool MultipleValues;
        public Type RelatedEntity;

        public EAVDocumentAttr(
            string dbAttributeCode,
            bool multipleValues = false,
            Type relatedEntity = null)
        {
            this.DBAttributeCode = dbAttributeCode;
            this.MultipleValues = multipleValues;
            this.RelatedEntity = relatedEntity;
        }
    }

    public static class Util {
        public static EAVDocumentAttr EAVAttr(this PropertyInfo property)
        {
            var propertyAttrs = property.GetCustomAttributes(true);

            return (EAVDocumentAttr) propertyAttrs.SingleOrDefault(a => a is EAVDocumentAttr);
        }


        public static object CastToTypedList(this object list, Type type)
        {
            var x = typeof(Enumerable)
                .GetMethod("Cast")
                .MakeGenericMethod(type)
                .Invoke(null, new object[] { list });

            return typeof(Enumerable)
                .GetMethod("ToList")
                .MakeGenericMethod(type)
                .Invoke(null, new object[] { x });
        }
    }
}