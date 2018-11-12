using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartQA1._1._2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}