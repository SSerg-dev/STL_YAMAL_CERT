using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartQA1._1._2.Controllers
{
    [Authorize]
    public class MainMenuController : Controller
    {
        // FIXME: legacy react stuff, remove after all forms have been moved to DevEx
        public ActionResult showMainMenu()
        {
            //ViewBag.isAuth = "not redirected from another page";
            return View("MainMenu");
        }

        public ActionResult ShowDxMenu(string gridName)
        {
            bool isAuth = true;
            KeyValuePair<bool, string> model = new KeyValuePair<bool, string>(isAuth, gridName);

            return PartialView("~/Views/Shared/MainMenu.cshtml", model);
        }
    }
}