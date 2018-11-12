using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using SmartQA1._1._2.DB.WebDb;
using System.Web.Mvc;
using Newtonsoft.Json;
using SmartQA1._1._2.Models.Register;

namespace SmartQA1._1._2.Controllers
{
    public class RegisterController : Controller
    {
        public ActionResult Index()
        {
            return View("MainView", Register.GetList());
        }

        SmartQA1._1._2.DB.WebDb.WEB_MainDataEntities db = new SmartQA1._1._2.DB.WebDb.WEB_MainDataEntities();

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = db.UI_Register_List;
            return PartialView("_GridViewPartial", model.ToList());
        }

        public ActionResult EditForm(Guid? id)
        {
            Register register;
            using (var context = new WEB_MainDataEntities())
            {
                register = new Register(context, id);

                //putting the current register to the context so it can be retrieved then
                //and compared with the latest data came from FE
                System.Web.HttpContext.Current.Session["register"] = register;

                //putting the current register to the ViewData dictionary so it can be 
                //available across all views and partial views
                ViewData["register"] = register;
            }
            return PartialView("FormLayout", register);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] SmartQA1._1._2.DB.WebDb.UI_Register_List item)
        {
            var model = db.UI_Register_List;
            if (ModelState.IsValid)
            {
                try
                {
                    
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Register register)
        {
            var model = db.UI_Register_List;
            if (ModelState.IsValid)
            {
                try
                {
                    
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Guid Register_ID)
        {
            var model = db.UI_Register_List;
            if (Register_ID != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Register_ID == Register_ID);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartial", model.ToList());
        }

        SmartQA1._1._2.DB.WebDb.WEB_MainDataEntities db1 = new SmartQA1._1._2.DB.WebDb.WEB_MainDataEntities();

        [ValidateInput(false)]
        public ActionResult DocumentsInRevision([ModelBinder(typeof(DevExpressEditorsBinder))] uint Iteration)
        {
            var currentRegister = (Register) System.Web.HttpContext.Current.Session["register"];
            return PartialView("RevisionGridView", currentRegister.GetRevision(Iteration));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DocumentsInRevisionDelete([ModelBinder(typeof(DevExpressEditorsBinder))] Guid Document_ID)
        {
            var currentRegister = (Register)System.Web.HttpContext.Current.Session["register"];
            currentRegister.RemoveDocument(Document_ID);
            return PartialView("RevisionGridView", currentRegister.LatestRevision);

            //Todo - add Error handling to the UserView
        }

        SmartQA1._1._2.DB.WebDb.WEB_MainDataEntities db3 = new SmartQA1._1._2.DB.WebDb.WEB_MainDataEntities();

        [ValidateInput(false)]
        public ActionResult DocumentLibrary(int id)
        {
            ViewData["id"] = id;
            ViewData["EditError"] = null;

            var model = db3.UI_Document_List;
            return PartialView("DocumentLibrary", model.ToList());
        }

        /// ADD EXISTING DOCUMENT
        [HttpPost, ValidateInput(false)]
        public ActionResult DocumentLibraryAddDocument([ModelBinder(typeof(DevExpressEditorsBinder))] Guid Document_ID, int id)
        {
            using (var context = new WEB_MainDataEntities())
            {
                ViewData["id"] = id;
                ViewData["EditError"] = null;

                var model = db3.UI_Document_List;

                var currentRegister = (Register)System.Web.HttpContext.Current.Session["register"];

                var result = currentRegister.AddDocument(context, Document_ID);
                if(!result) ViewData["EditError"] = "Документ уже был добавлен к ревизии";
                    
                return PartialView("DocumentLibrary", model.ToList());
            }
        }
    }
}