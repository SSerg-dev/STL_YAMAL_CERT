using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartQA1._1._2.DB.EntityFramework;
using SmartQA1._1._2.Models.Document;
using SmartQA1._1._2.Controllers;
using SmartQA1._1._2.DB.WebDb;
using SmartQA1._1._2.Models.ABDDocument;
using static SmartQA1._1._2.Service.ModelStateSerializer;

namespace SmartQA1._1._2.Controllers
{
    public class DocumentController : Controller
    {
        //[Authorize]
        public ActionResult Index()
        {
            return View("DocumentView", Document.GetList());
        }

        //[ValidateInput(false)]
        [Impersonate]
        //[Authorize]
        public ActionResult GridViewPartial([ModelBinder(typeof(DevExpressEditorsBinder))] string command)
        {
            var model = Document.GetList();
            if (command == "CANCELEDIT") DraftFileManager.GetInstance().Dispose();

            return PartialView("DocumentGridView", model.ToList());
        }
        [Impersonate]
        //[Authorize]
        public ActionResult GostPartial()
        {
            return PartialView("GostCombo");
        }
        [Impersonate]
        //[Authorize]
        public ActionResult PidPartial()
        {
            return PartialView("PidCombo");
        }
        [Impersonate]
        //[Authorize]
        public ActionResult EditForm(Guid? id)
        {
            Document document;
            using (var context = new WEB_MainDataEntities())
            {
                document = new Document(context, id);
            }

            System.Web.HttpContext.Current.Session["cleanFiles"] = document.DocumentFiles;
            return PartialView("DocumentFormEdit", document);
        }
        [Impersonate]
        //[Authorize]
        //[HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Document document)
        {
            ViewData["item"] = document;
            var model = Document.GetList();
            if (ModelState.IsValid)
            {
                using (var context = new WEB_MainDataEntities())
                {
                    var result = document.SaveNew(context);
                    if (!result.isValid) ViewData["EditError"] = result.Serialize();
                    ModelState.Serialize();
                }
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors. "+ ModelState.Serialize();
            }
                
            return PartialView("DocumentGridView", model.ToList());
        }
        [Impersonate]
        //[Authorize]
        //[HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Document document)
        {
            var model = Document.GetList();
            ViewData["item"] = document;
            if (ModelState.IsValid)
            {
                using (var context = new WEB_MainDataEntities())
                {
                    var filesLeft = (List<UI_FileStream>)System.Web.HttpContext.Current.Session["cleanFiles"];
                    var result = document.SaveExisting(filesLeft, context);
                    if (!result.isValid) ViewData["EditError"] = result.Serialize();
                }
                
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors." + ModelState.Serialize();
            }


            return PartialView("DocumentGridView", model.ToList());
        }
        [Impersonate]
        //[Authorize]
        //[HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(Guid Document_ID)
        {
            using (var context = new WEB_MainDataEntities())
            {
                var document = new Document(context, Document_ID);
                document.Delete();
            }
            var model = Document.GetList();
            return PartialView("DocumentGridView", model.ToList());
        }
        //NEW FILES
        [Impersonate]
        //[Authorize]
        public ActionResult FileControlUpload()
        {
            UploadControlExtension.GetUploadedFiles(
                "UploadControl",
                DocFileUploadSettings.UploadValidationSettings,
                DocFileUploadSettings.FileUploadComplete
            );
            return null;
        }
        [Impersonate]
        //[Authorize]
        //[ValidateInput(false)]
        public ActionResult GridViewNewFiles()
        {
            var model = DraftFileManager.GetInstance().Folder();
            return PartialView("DocNewFiles", model);
        }
        [Impersonate]
        //[Authorize]
        //[HttpPost, ValidateInput(false)]
        public ActionResult DeleteNewFile([ModelBinder(typeof(DevExpressEditorsBinder))] System.String name)
        {
            var dfm = DraftFileManager.GetInstance();
            dfm.DeleteFile(name);
            return PartialView("DocNewFiles", dfm.Folder());
        }
        //OLD FILES
        //[ValidateInput(false)]
        //public ActionResult DocExistingFiles()
        //{
        //    var model = (List<UI_FileStream>) System.Web.HttpContext.Current.Session["cleanFiles"];
        //    return PartialView("_DocExistingFiles", model);
        //}
        [Impersonate]
        //[Authorize]
        //[HttpPost, ValidateInput(false)]
        public ActionResult DocExistingFilesDelete([ModelBinder(typeof(DevExpressEditorsBinder))] Guid FileTable_ID)
        {
            var model = (List<UI_FileStream>)System.Web.HttpContext.Current.Session["cleanFiles"];
            var itemToDelete = model.First(x => x.FileTable_ID == FileTable_ID);
            model.Remove(itemToDelete);
            return PartialView("DocExistingFiles", model);
        }
    }
}