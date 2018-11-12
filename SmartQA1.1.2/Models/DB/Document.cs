using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Dynamic;
using System.Linq;
using System.Globalization;
using System.Linq.Dynamic;
using System.Reflection;
using System.Web;
using DevExpress.XtraPrinting.Native;
using Microsoft.Ajax.Utilities;
using NodaTime;
using SmartQA1._1._2.Authentication;
using SmartQA1._1._2.BusinessModels;
using SmartQA1._1._2.Controllers;
using SmartQA1._1._2.Models.Permission;
using SmartQA1._1._2.Models.Permission.DocumentTypes;


//using SmartQA1._1._2.Models.Permission.DocumentTypes;

namespace SmartQA1._1._2.DB.PermissionDb
{
    [MetadataType(typeof(DocumentMetadata))]
    public partial class EAVDocument
    {
        public void RetrieveAttributes(EAVHelper helper)
        {
            var values = GetAttributeValues();
            FromAttributes(helper, values);
        }

        public void Save(EAVHelper helper, Guid? Employee_ID)
        {
            var values = ToAttributes(helper);                            

            using (var context = new DEV_WEB_MainDataEntities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (Document_ID == Guid.Empty)
                        {
                            ObjectParameter o_Entity_ID = new ObjectParameter("o_Entity_ID", typeof(string));
                            var isError = new ObjectParameter("o_isError", typeof(bool));
                            
                            var result = context.Document_Insert(
                                "0",
                                User.GetFromContext(HttpContext.Current).Id.ToString(),
                                DocumentType_ID.ToString(),
                                Document_Name ?? "ttt",
                                Document_Title ?? "ttt",
                                Document_Revision ?? "0",
                                null,
                                Document_Number,
                                Document_Date?.ToString("yyyy-MM-dd"),
                                Document_Parent_ID?.ToString(),
                                o_Entity_ID,
                                isError).ToList();

                            if (Convert.ToBoolean(isError.Value))
                            {
                                throw new Exception("Error when saving document");
                            }

                            Document_ID = Guid.Parse(o_Entity_ID.Value.ToString());

                            o_Entity_ID = new ObjectParameter("o_Entity_ID", typeof(string));
                            isError = new ObjectParameter("o_isError", typeof(bool));

                            var employeeToDocumentResult = context.Employee_to_Document_Insert(
                                "0",
                                User.GetFromContext(HttpContext.Current).Id.ToString(),
                                Employee_ID?.ToString(),
                                Document_ID.ToString(),
                                o_Entity_ID,
                                isError).ToList();

                            if (Convert.ToBoolean(isError.Value))
                            {
                                throw new Exception("Error when linking document to employee");
                            }
                        }
                        else
                        {
                            var isError = new ObjectParameter("o_isError", typeof(bool));
                            var result = context.Document_Update(
                                Document_ID.ToString(),
                                "0",
                                User.GetFromContext(HttpContext.Current).Id.ToString(),
                                DocumentType_ID.ToString(),
                                Document_Name,
                                Document_Title,
                                Document_Revision,
                                Reponsible_Employee_ID?.ToString(),
                                Document_Number,
                                Document_Date?.ToString("yyyy-MM-dd"),
                                Document_Parent_ID?.ToString(),
                                isError
                            ).ToList();

                            if (Convert.ToBoolean(isError.Value))
                            {
                                throw new Exception("Error when updating document");
                            }
                        }

                        var typeAttributes = context.f_GetTemplate_Attr(DocumentType.DocumentType_Code).ToList();

                        foreach (var entry in values)
                        {
                            var idsToDelete = (from a in context.DocumentAttributes
                                    .Include(x => x.AttributeType)
                                where a.Document_ID == Document_ID
                                      && a.AttributeType.AttributeType_Code == entry.Key
                                      && !entry.Value.Contains(a.DocumentAttribute_Value)
                                select a.DocumentAttribute_ID).ToList();

                            foreach (var id in idsToDelete)
                            {
                                ObjectParameter isError = new ObjectParameter("o_isError", typeof(bool));

                                var result = context.DocumentAttribute_Delete(
                                    id.ToString(),
                                    User.GetFromContext(HttpContext.Current).Id.ToString(),
                                    isError).ToList();

                                if (Convert.ToBoolean(isError.Value))
                                {
                                    throw new Exception("Error when saving attribute");
                                }
                            }

                            var existingValues = (from a in context.DocumentAttributes
                                    .Include(x => x.AttributeType)
                                where a.Document_ID == Document_ID
                                      && a.AttributeType.AttributeType_Code == entry.Key
                                      && entry.Value.Contains(a.DocumentAttribute_Value)
                                select a.DocumentAttribute_Value).ToList();

                            foreach (var value in entry.Value.Where(v => !existingValues.Contains(v)))
                            {
                                ObjectParameter entityId = new ObjectParameter("o_Entity_ID", typeof(string));
                                ObjectParameter isError = new ObjectParameter("o_isError", typeof(bool));

                                var result = context.DocumentAttribute_Insert(
                                    "0",
                                    User.GetFromContext(HttpContext.Current).Id.ToString(),
                                    value,
                                    (from at in typeAttributes
                                        where at.AttributeType_Code == entry.Key
                                        select at.AttributeType_ID.ToString()).Single(),
                                    Document_ID.ToString(),
                                    "0",
                                    entityId,
                                    isError).ToList();

                                if (Convert.ToBoolean(isError.Value))
                                {
                                    throw new Exception("Error when saving attribute");
                                }
                            }

                        }

                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private object ConvertValueFromDBAttribute(EAVHelper helper, PropertyInfo property, List<string> attributeValues)
        {
            var fieldAttr = property.EAVAttr();
            var fieldType = fieldAttr.MultipleValues ? property.PropertyType.GenericTypeArguments[0] : property.PropertyType;
            
            object fieldValues;

            if (Nullable.GetUnderlyingType(fieldType) != null)
            {
                fieldType = Nullable.GetUnderlyingType(fieldType);
            }

            if (fieldType == fieldAttr.RelatedEntity)
            {                                                
                var values = attributeValues.Select(
                    k => helper.GetEntity(fieldType, Guid.Parse(k))
                );

                fieldValues = values.CastToTypedList(fieldType);                
            }
            else if(fieldType == typeof(Guid))
            {
                fieldValues = attributeValues.Select(Guid.Parse).ToList();
            }
            else if (fieldType == typeof(LocalDate))
            {
                fieldValues = attributeValues.Select(x => LocalDate.FromDateTime(DateTime.Parse(x))).ToList();
            }
            else
            {
                fieldValues = attributeValues;
            }

            if (fieldAttr.MultipleValues)
            {
                return fieldValues;
            }
            else
            {
                return ((IEnumerable) fieldValues).OfType<object>().FirstOrDefault();
            }                          
        }

        private List<string> ConvertValueToDBAttribute(EAVHelper helper, PropertyInfo property)
        {
            var fieldAttr = property.EAVAttr();
            var fieldType = fieldAttr.MultipleValues ? property.PropertyType.GenericTypeArguments[0] : property.PropertyType;

            var attributeValues = new List<string>();
            var fieldValues = (IEnumerable)(fieldAttr.MultipleValues ? property.GetValue(this) : new List<object>() { property.GetValue(this) });

            if (Nullable.GetUnderlyingType(fieldType) != null)
            {
                fieldType = Nullable.GetUnderlyingType(fieldType);
            }

            if (fieldType == fieldAttr.RelatedEntity)
            {
                attributeValues = fieldValues.Cast<object>().Select(
                    v => helper.GetPrimaryKey(v).ToString()
                ).ToList();
            }
            else if (fieldType == typeof(Guid))
            {
                attributeValues = fieldValues.OfType<Guid>().Select(x => x.ToString()).ToList();
            }
            else if (fieldType == typeof(LocalDate))
            {
                attributeValues = fieldValues.OfType<LocalDate>().Select(x => x.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)).ToList();
            }
            else
            {
                attributeValues = fieldValues.OfType<object>().Select(x => x.ToString()).ToList();
            }

            return attributeValues;
        }

        protected virtual void FromAttributes(EAVHelper helper, Dictionary<string, List<string>> attributes)
        {            
            var attrValues = GetAttributeValues();
            var type = GetType();
            foreach (var property in type.GetProperties())
            {                
                if (property.EAVAttr() is EAVDocumentAttr fieldAttr)
                {
                    property.SetValue(this, ConvertValueFromDBAttribute(
                        helper,
                        property,
                        attrValues.GetValueOrDefault(fieldAttr.DBAttributeCode, new List<string>())));                        
                }               
            }
        }

        protected virtual Dictionary<string, List<string>> ToAttributes(EAVHelper helper)
        {
            var dict = new Dictionary<string, List<string>>();
            var type = GetType();

            foreach (var property in type.GetProperties().Where(p => p.EAVAttr() != null))
            {
                var fieldAttr = property.EAVAttr();
                dict[fieldAttr.DBAttributeCode] = ConvertValueToDBAttribute(helper, property);                                    
            }

            return dict;
        }

        protected Dictionary<string, List<string>> GetAttributeValues() {
            var dict = new Dictionary<string, List<string>>();

            foreach (var attr in DocumentAttributes)
            {
                var key = attr.AttributeType.AttributeType_Code;
                if (!dict.ContainsKey(key)) dict[key] = new List<string>();
                dict[key].Add(attr.DocumentAttribute_Value);
            }

            return dict;
        }

        public virtual void UseAsTemplate(EAVDocument target)
        {
            target.Document_Parent_ID = Document_ID;
            target.DocumentType = DocumentType;
            target.DocumentType_ID = DocumentType.DocumentType_ID;
            target.Document_Name = Document_Name;
            target.Document_Title = Document_Title;

            Type type = GetType();
            foreach (var property in type.GetProperties().Where(p => p.EAVAttr() != null))
            {
                var fieldAttr = property.EAVAttr();               
                property.SetValue(target, property.GetValue(this));                              
            }            
        }
    
        public static EAVDocument Create(EAVDocument template)
        {
            EAVDocument newDocument;

            switch (template.DocumentType.DocumentType_Code)
            {
                case "НАКС":
                    newDocument = new Document_Naks();
                    break;
                default:
                    newDocument = new EAVDocument();
                    break;
            }

            template.UseAsTemplate(newDocument);

            return newDocument;
        }
        
    }

    public class DocumentMetadata
    {
        [Required]
        [Display(Name = "Номер")]
        public string Document_Number { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата выдачи")]
        public DateTime Document_Date{ get; set; }
    }
}