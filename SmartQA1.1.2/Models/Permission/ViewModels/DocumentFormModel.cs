using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using SmartQA1._1._2.DB.PermissionDb;

namespace SmartQA1._1._2.Models.Permission.ViewModels
{
    public class DocumentFormModel<DocType>
        where DocType : DB.PermissionDb.EAVDocument
    {
        [Required]
        public System.Guid DocumentType_ID { get; set; }        
        public System.Guid DocumentTemplate_ID { get; set; }        
        public System.Guid? Employee_ID { get; set; }
        public System.Guid? Document_Parent_ID { get; set; }

        [Required]
        public System.Guid Document_ID { get; set; }

        public virtual void Deserialize(EAVHelper helper, DocType document)
        {
            Document_Parent_ID = document.Document_Parent_ID;            
            DocumentType_ID = document.DocumentType_ID;
            Document_ID = document.Document_ID;

            foreach (var property in GetType().GetProperties())
            {
                if (property.GetCustomAttributes(true).SingleOrDefault(a => a is DocumentFormField) is DocumentFormField
                    formFieldAttr)
                {
                    formFieldAttr.DeserializeFromDocument(helper, property, this, document);
                }
            }            
        }

        public virtual void Serialize(EAVHelper helper, DocType document)
        {
            document.DocumentType_ID = DocumentType_ID;
            document.Document_Parent_ID = Document_Parent_ID;            
            document.Document_ID = Document_ID;

            foreach (var property in GetType().GetProperties())
            {
                if (property.GetCustomAttributes(true).SingleOrDefault(a => a is DocumentFormField) is DocumentFormField
                    formFieldAttr)
                {
                    formFieldAttr.SerializeToDocument(helper, property, this, document);
                }
            }
        }

        public Dictionary<string, ICollection<object>> GetFieldChoices(EAVHelper helper)
        {
            var result = new Dictionary<string, ICollection<object>>();
            foreach (var property in GetType().GetProperties()
                .Where(prop => prop.GetCustomAttributes(true).Any(att => att is DocumentFormField)))
            {
                var fieldAtt = (DocumentFormField)property.GetCustomAttributes(true).Single(a => a is DocumentFormField);
                if (fieldAtt.ChoicesEntity != null)
                {
                    result[property.Name] = helper.GetEntities(fieldAtt.ChoicesEntity).OrderBy(x => x.ToString()).ToList();
                }
            }

            return result;
        }
    }
}