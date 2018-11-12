using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DevExpress.XtraPrinting.Native;
using SmartQA1._1._2.Controllers;
using SmartQA1._1._2.DB.PermissionDb;
using SmartQA1._1._2.Models.Permission;
using SmartQA1._1._2.Models.Permission.ViewModels;

namespace SmartQA1._1._2.DB.PermissionDb
{
    public partial class EAVDocumentType
    {
        // map DocumentType_Code database field to in-app document type keys
        public static Dictionary<string, string> TypeNames = new Dictionary<string, string>
        {
            ["НАКС"] = "NAKS",
        };

        public DocumentTypeEditorHelper EditorHelper
        {
            get => new DocumentTypeEditorHelper(this);
        }

        public class DocumentTypeEditorHelper
        {
            public string EditorController { get; set; } = "Permission";
            public string EditorAction { get; set; }
            public string EditorView { get; set; }
            public string EditorViewModel { get; set; }

            public DocumentTypeEditorHelper(EAVDocumentType documentType)
            {
                var typeName = TypeNames[documentType.DocumentType_Code];
                EditorAction = $"DocumentEdit_{typeName}";
                EditorView = $"DocumentForms/{typeName}";                
                EditorViewModel = $"SmartQA1._1._2.Models.Permission.ViewModels.DocumentForm_{typeName}";
            }

            public dynamic GetViewModel(EAVHelper helper, EAVDocument document)
            {
                var type = Type.GetType(EditorViewModel);
                var methodInfo = type.GetMethod("Deserialize");
                var model = Activator.CreateInstance(type);
                methodInfo.Invoke(model, new object []{ helper, document });
                                
                return model;
            }
        }

        public ICollection<f_GetTemplate_Attr_Result> GetAttributes()
        {
            using (var context = new DEV_WEB_MainDataEntities())
            {
                return context.f_GetTemplate_Attr(DocumentType_Code).ToList();
            }
        }



    }
}