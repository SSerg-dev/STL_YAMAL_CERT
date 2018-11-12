using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartQA1._1._2.Models.ABDDocument;
using SmartQA1._1._2.DB.EntityFramework;

namespace SmartQA1._1._2.Controllers
{
    public class ABDDocumentController : Controller
    {
        // GET: ABDDocument
        [Authorize]
        public ActionResult ShowPage()
        {
            return View("ABDDocument");
        }
        public JsonResult GetABDDocumentList(List<Filter> inputFilters)
        {
            ABDDocumentList adl = new ABDDocumentList();
            if(inputFilters!=null) adl.fill(inputFilters);
            return Json(adl, JsonRequestBehavior.AllowGet); 
        }
        [Impersonate]
        [Authorize]
        public JsonResult UploadFile()
        {
            DraftFileManager dfm = DraftFileManager.GetInstance();
            var result = dfm.UploadFiles();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [Impersonate]
        [Authorize]
        public JsonResult DeleteFile(string fileName)
        {
            DraftFileManager dfm = DraftFileManager.GetInstance();
            var result = dfm.DeleteFile(fileName);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [Impersonate]
        [Authorize]
        public JsonResult DisposeUploadedFiles()
        {
            DraftFileManager dfm = DraftFileManager.GetInstance();
            dfm.Dispose();
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDocumentFiles(Guid documentId)
        {
            var files = ABDDocumentFull.GetDocumentFiles(documentId);
            return Json(files, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetABDDocumentById(Guid documentId)
        {
            var document = ABDDocumentFull.GetDocumentById(documentId);
            return Json(document, JsonRequestBehavior.AllowGet);
        }
        [Impersonate]
        [Authorize]
        public JsonResult SaveABDDocument(ABDDocumentFull document)
        {
            var result = document.Save();
            if (result != null) return Json(result.Serialize(), JsonRequestBehavior.AllowGet);
            else return Json(null, JsonRequestBehavior.AllowGet);
        }
        [Impersonate]
        [Authorize]
        public JsonResult DeleteABDDocument(ABDDocumentFull document)
        {
            var result = document.Delete();
            if (result != null) return Json(result.Serialize(), JsonRequestBehavior.AllowGet);
            else return Json(null, JsonRequestBehavior.AllowGet);
        }

    }
}