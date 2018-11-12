using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using NodaTime;
using SmartQA1._1._2.Models.Permission.DocumentTypes;

namespace SmartQA1._1._2.Models.Permission.ViewModels
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DocumentFormField : System.Attribute
    {
        public Type ChoicesEntity;

        public DocumentFormField(Type choicesEntity = null)
        {
            ChoicesEntity = choicesEntity;
        }

        public virtual void SerializeToDocument(EAVHelper helper, PropertyInfo property, object viewModel, DB.PermissionDb.EAVDocument document)
        {
            var value = property.GetValue(viewModel);            
            var documentProperty = document.GetType().GetProperty(property.Name);
            var eavAttr = documentProperty?.EAVAttr();
            if (eavAttr != null && eavAttr.RelatedEntity != null)
            {
                if (eavAttr.MultipleValues) 
                    documentProperty.SetValue(document, 
                        ((IEnumerable)value).Cast<Guid>()
                        .Select(k => helper.GetEntity(eavAttr.RelatedEntity, k))
                        .CastToTypedList(eavAttr.RelatedEntity)
                    );
                else
                {
                    var k = (Guid) value;
                    if (k == Guid.Empty)
                        documentProperty.SetValue(document, null);
                    else
                        documentProperty.SetValue(document, helper.GetEntity(eavAttr.RelatedEntity, k));
                }
            }
            else
            {
                documentProperty?.SetValue(document, value);
            }            
        }

        public virtual void DeserializeFromDocument(EAVHelper helper, PropertyInfo property, object viewModel, DB.PermissionDb.EAVDocument document)
        {
            var documentProperty = document.GetType().GetProperty(property.Name);
            var eavAttr = documentProperty?.EAVAttr();
            if (eavAttr != null && eavAttr.RelatedEntity != null)
            {
                if (eavAttr.MultipleValues)
                {
                    property.SetValue(viewModel, 
                        ((IEnumerable)documentProperty?.GetValue(document)).Cast<object>()
                        .Select(helper.GetPrimaryKey).ToList());
                }
                    
                else
                {
                    var e = (object)documentProperty?.GetValue(document);
                    if (e == null)
                        property.SetValue(viewModel, null);
                    else
                        property.SetValue(viewModel, helper.GetPrimaryKey(e));
                }
            }
            else
            {
                property.SetValue(viewModel, documentProperty?.GetValue(document));                
            }        
                
            
        }

    }

    public class DateDocumentFormField : DocumentFormField
    {
        public override void SerializeToDocument(EAVHelper helper, PropertyInfo property, object viewModel, DB.PermissionDb.EAVDocument document)
        {
            var value = (DateTime?)property.GetValue(viewModel);
            var valueTransformed = value == null ? (LocalDate?)null : LocalDate.FromDateTime((DateTime)value);
            var documentProperty = document.GetType().GetProperty(property.Name);
            documentProperty?.SetValue(document, valueTransformed);
        }

        public override void DeserializeFromDocument(EAVHelper helper, PropertyInfo property, object viewModel, DB.PermissionDb.EAVDocument document)
        {
            // TODO: this seems overly complicated, refactor

            var documentProperty = document.GetType().GetProperty(property.Name);
            var value = documentProperty?.GetValue(document);

            if (value != null && Nullable.GetUnderlyingType(value.GetType()) == null)
            {
                var valueTransformed = ((LocalDate)value).ToDateTimeUnspecified();
                property.SetValue(viewModel, valueTransformed);                
            }
            else
            {
                var valueTransformed = ((LocalDate?)value)?.ToDateTimeUnspecified();
                property.SetValue(viewModel, valueTransformed);

            }
        }

    }
}