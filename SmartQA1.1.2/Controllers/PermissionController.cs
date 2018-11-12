using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Web.Mvc.Html;
using DevExpress.Web.Mvc.UI;
using DevExpress.XtraPrinting;
using SmartQA1._1._2.DB.PermissionDb;
using SmartQA1._1._2.Service;
using SmartQA1._1._2.Models.Permission;
using SmartQA1._1._2.Models.Permission.ViewModels;
using Document = SmartQA1._1._2.DB.PermissionDb.EAVDocument;

namespace SmartQA1._1._2.Controllers
{
    [Authorize]
    public class PermissionController : Controller
    {
        // GET: Permission
        public ActionResult ShowMainView()
        {
            return View("MainView");
        }

        [ValidateInput(false)]
        public ActionResult EmployeeList_Partial()
        {
            using (var context = new DEV_WEB_MainDataEntities())
            {
                //var viewModel = GridViewExtension.GetViewModel("EmployeeList");

                var model = context.Employees
                    .Include(e => e.Person)
                    .Include(e => e.Contragent)
                    .Include(e => e.Position)
                    .OrderBy(e => e.Person.LastName)
                    .ThenBy(e => e.Person.FirstName)
                    .ThenBy(e => e.Person.SecondName)
                    .ToList();
                return PartialView("EmployeeList_Partial", model);
            }
        }

        [HttpPost]
        public ActionResult EmployeeDetails(Guid Employee_ID)
        {
            using (var context = new DEV_WEB_MainDataEntities())
            {
                var model = context.Employees
                    .Include(e => e.Person)
                    .Include(e => e.Contragent)
                    .Include(e => e.Position)
                    .Single(e => e.Employee_ID == Employee_ID);
                return PartialView("EmployeeDetails_Partial", model);
            }
        }

        [HttpPost]
        public ActionResult DocumentEdit_NAKS(DocumentForm_NAKS model, bool initialOpen = false)
        {
            using (var context = new DEV_WEB_MainDataEntities())
            {
                var helper = new EAVHelper(context, typeof(Document_Naks));
               
                ViewData["FieldChoices"] = model.GetFieldChoices(helper);                

                // don't call validation when we first open a document for editing                
                if (initialOpen)
                {
                    return PartialView("DocumentForms/NAKS", model);
                }

                if (!ModelState.IsValid)
                {
                    return PartialView("DocumentForms/NAKS", model);
                }

                Document_Naks document;
                if (model.Document_ID == Guid.Empty)
                {
                    var template = (Document_Naks)
                        context.EAVDocuments.Single(x => x.Document_ID == model.DocumentTemplate_ID);
                                        
                    document = (Document_Naks) Document.Create(template);
                }
                else
                {
                    document = (Document_Naks) context.EAVDocuments
                        .Single(d => d.Document_ID == model.Document_ID);
                }

                model.Serialize(helper, document);
                document.Save(helper, model.Employee_ID);
                return Json(new 
                {
                    Success = true,
                    Document_ID = document.Document_ID,
                });                
            }
        }

        [HttpPost]
        public ActionResult DocumentEdit_NaksAttest(DocumentForm_NaksAttest model, Guid NaksDocument_ID, bool initialOpen = false)
        {
            using (var context = new DEV_WEB_MainDataEntities())
            {
                var helper = new EAVHelper(context, typeof(Document_NaksAttest));

                if (model == null)
                {
                    model = new DocumentForm_NaksAttest();
                }
                ViewData["FieldChoices"] = model.GetFieldChoices(helper);

                // don't call validation when we first open a document for editing                
                if (initialOpen)
                {
                    return PartialView("DocumentForms/NaksAttest", model);
                }

                if (!ModelState.IsValid)
                {
                    return PartialView("DocumentForms/NaksAttest", model);
                }

                return Json(new
                {
                    Success = true,
                //    Document_ID = document.Document_ID,
                });
            }
        }

        public ActionResult DocumentList_NaksAttest(Guid Document_ID)
        {
            using (var context = new DEV_WEB_MainDataEntities())
            {
                var helper = new EAVHelper(context, typeof(Document_NaksAttest));
                var naksDocument = context.EAVDocuments.Single(d => d.Document_ID == Document_ID);
                var attestDocs = context.EAVDocuments
                    .Include(d => d.DocumentAttributes)
                    .Include(d => d.DocumentRelationsFrom)
                    .Where(d => d.DocumentRelationsFrom.Any(r => r.DocumentFrom_ID == Document_ID))
                    .ToList()
                    .Select(d =>
                        {
                            var doc = (Document_NaksAttest) d;
                            doc.RetrieveAttributes(helper);
                            return doc;
                        })
                    .ToList();

                return PartialView("DocumentList_NaksAttest_Partial", attestDocs);
            }
        }

        public ActionResult DocumentEdit(Guid Employee_ID, Guid? Document_ID, bool isTemplate)
        {
            using (var context = new DEV_WEB_MainDataEntities())
            {                
                var document = context.EAVDocuments
                    .Include(d => d.DocumentType)
                    .Include(d => d.DocumentAttributes)
                    .Include(d => d.DocumentAttributes.Select(a => a.AttributeType))
                    .Single(d => d.Document_ID == Document_ID);

                var helper = new EAVHelper(context, document.GetType());                

                document.RetrieveAttributes(helper);

                var model = isTemplate ? Document.Create(document) : document;
                
                ViewData["DocumentTypeEditor"] = model.DocumentType.EditorHelper;
                ViewData["DocumentFormViewModel"] = model.DocumentType.EditorHelper.GetViewModel(helper, model);
                ViewData["Employee_ID"] = Employee_ID;
                ViewData["DocumentTemplate_ID"] = isTemplate ? document.Document_ID : Guid.Empty;

                return PartialView("DocumentEdit_Partial", model);
            }
        }

        public ActionResult EmployeeEdit(Guid? Employee_ID)
        {
            using (var context = new DEV_WEB_MainDataEntities())
            {
                if (Employee_ID == null)
                {
                    return PartialView("EmployeeEdit_Partial", new Employee());
                }
                else
                {                   
                    return PartialView("EmployeeEdit_Partial", context.Employees
                        .Include(e => e.Person)
                        .Single(x => x.Employee_ID == Employee_ID));
                }
            }
        }

        [HttpPost]
        public ActionResult EmployeeEdit_Form(EmployeeEdit model, bool initialOpen = false)
        {
            using (var context = new DEV_WEB_MainDataEntities())
            {

                ViewData["FieldChoices"] = new Dictionary<string, object>()
                {
                    ["Contragent"] = context.UI_Contragent.OrderBy(x => x.Contragent_Code).ToList(),
                    ["Position"] = context.UI_Position.OrderBy(x => x.Position_Description).ToList(),
                };

                // don't call validation when we first open a document for editing                
                if (initialOpen)
                {
                    return PartialView("EmployeeEdit_Form_Partial", model);
                }

                if (!ModelState.IsValid)
                {
                    return PartialView("EmployeeEdit_Form_Partial", model);
                }

                Employee dbModel;
                if (model.Employee_ID?.Equals(Guid.Empty) ?? true)
                {
                    dbModel = new Employee();
                }
                else
                {
                    dbModel = context.Employees
                        .Include(e => e.Person)
                        .Single(x => x.Employee_ID == model.Employee_ID);
                }

                model.Serialize(dbModel);

                dbModel.Save();

                return Json(new
                {
                    Success = true,
                    
                });
            }
        }

        [HttpPost]
        public ActionResult EmployeeDelete(Guid Employee_ID)
        {
            using (var context = new DEV_WEB_MainDataEntities())
            {
                var dbModel = context.Employees
                    .Single(x => x.Employee_ID == Employee_ID);
                dbModel.Delete();
            }            

            return EmployeeList_Partial();
        }

        [HttpPost]
        public ActionResult DocumentSave(Guid? Employee_ID, string DocumentType_Code, string Document_Name,
            string Document_Title, Guid?[] titleIDs, Guid?[] markIDs, string Document_Number, DateTime? Document_Date,
            string titleCode = null, string markaCode = null)
        {
            Personal model;

            using (var context = new DEV_WEB_MainDataEntities())
            {
                model = new Personal();
                model.Employee_ID = Employee_ID;
                model.DocumentType_Code = DocumentType_Code;
                model.Document_Number = Document_Number;
                model.Document_Date = Document_Date;
                model.Document_Name = Document_Name;
                model.Document_Title = Document_Title;
                model.TitleObject = context.TitleObject.Where(x => titleIDs.Contains(x.TitleObject_ID)).ToList();
                model.Marka = context.Marka.Where(x => markIDs.Contains(x.Marka_ID)).ToList();

                model.SaveNewDoc(context);

                return Redirect("~/Permission"); // View("MainView", Personal.GetList());
            }

        }

        [ValidateInput(false)]
        public ActionResult EmployeeDetails_DocumentTree_Partial(Guid? Person_ID, Guid? Employee_ID)
        {
            ViewBag.Employee_ID = Employee_ID;
            return PartialView("EmployeeDetails_DocumentTree_Partial", PersonDocument.GetList(Person_ID, Employee_ID));
        }


    }
}