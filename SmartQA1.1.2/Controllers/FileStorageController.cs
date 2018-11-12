using SmartQA1._1._2.Models.Login;
using System.Collections.Generic;
using System.Web.Mvc;
using SmartQA1._1._2.Models.BusinessModels;
using System.Web;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mime;

namespace SmartQA1._1._2.Controllers
{
    public class FileStorageController : Controller
    {
        [Authorize]
        public ActionResult ShowPage()
        {
            return View();
        }
        [Impersonate]
        [Authorize]
        public JsonResult GetFileList(List<Filter> inputFilters)
        {
            FileList FL = new FileList();
            if (inputFilters != null) FL.Fill(inputFilters);
            return Json(FL, JsonRequestBehavior.AllowGet);
        }
        [Impersonate]
        [Authorize]
        public JsonResult UploadFiles(HttpPostedFileBase[] inputUploadFiles)
        {
            FileStorageUtils Files = new FileStorageUtils();
            Files.Upload(inputUploadFiles);
            return Json(Files, JsonRequestBehavior.AllowGet);
        }
        [Impersonate]
        [Authorize]
        public ActionResult DownloadFile(Guid Stream_Id)
        {
            try
            {
                return File(new FileStorageUtils().GetFileContentsById(Stream_Id, out string FileName),
                    MediaTypeNames.Application.Octet, FileName);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                return Content
                    ($"<h1 style=\"color:red\">Backend error:</h1><h2>{ (ex.InnerException ?? ex).Message }</h2>",
                    MediaTypeNames.Text.Html);
            }
        }
        [Impersonate]
        [Authorize]
        public Object GetPreview(Guid Stream_Id)
        {
            PreviewManager pm = PreviewManager.GetInstance();
            return pm.GetPreviewFile(Stream_Id);
        }
        public Object GetPreviewFile(Guid Stream_Id, string fileName)
        {
            PreviewManager pm = PreviewManager.GetInstance();
            return pm.GetFileInFolder(Stream_Id, fileName);
        }
    }
}