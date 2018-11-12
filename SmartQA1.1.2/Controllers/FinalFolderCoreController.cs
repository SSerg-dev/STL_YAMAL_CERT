using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SmartQA1._1._2.Models.Login;

namespace SmartQA1._1._2.Controllers
{
    public class FinalFolderCoreController : Controller
    {
        //1-st: supply client with the page itself:
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
		//This method provides FinalFolderList filtered by the user
		public JsonResult getABDFinalFolderTypedFilteredList(List<Filter> inputFilters)
		{
            FinalFolderList FL = new FinalFolderList();
            if (inputFilters != null) FL.fill(inputFilters);
            return Json(FL, JsonRequestBehavior.AllowGet);
		}
    }
}