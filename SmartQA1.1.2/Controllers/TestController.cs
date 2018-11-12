using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Security.Principal;
using SmartQA1._1._2.Models.Login;
using SmartQA1._1._2.DB.EntityFramework;

namespace SmartQA1._1._2.Controllers
{
    public class TestController : Controller
    {
        public ActionResult ShowMainView()
        {
            int i = 0;
            return View("MainView");
        }
        public ActionResult Increment(int i)
        {
            i++;
            return PartialView("FormLayout", i);
        }
        [Impersonate]
        [Authorize]
        public JsonResult lingerOnReadingFile()
        {
            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            System.Diagnostics.Debug.WriteLine("Current user: " + wi.Name);
            string _fileName = null;
            Guid streamId = Guid.Parse("28CC81B6-1460-E811-A9E9-005056947B15");

            //this is just test for valid impersonalisation:
            using (var context = new FileStorageEntities())
            {
                string filePath =
                    context.FileShareTables
                    .Where(x => x.Stream_Id == streamId)
                    .ToList()
                    .Select(x => { _fileName = x.FileName; return x.PathNonDefault; })
                    .FirstOrDefault();

                //opening file stream
                var fileStream = System.IO.File.OpenRead(filePath);
                Thread.Sleep(10000);
                fileStream.Close();
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
	}
}