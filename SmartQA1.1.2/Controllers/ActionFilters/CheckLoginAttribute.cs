using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using System.Diagnostics;
using SmartQA1._1._2.Models.Login;

namespace SmartQA1._1._2.Controllers
{
    public class CheckLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = HttpContext.Current.Session["user"];
            //check if user is logged in:
            if (!LoginModel.checkLogin().isAuth)
            {
                var actionDescriptor = (ReflectedActionDescriptor)filterContext.ActionDescriptor;
                MethodInfo controllerMethodInfo = actionDescriptor.MethodInfo;
                var actionResult = controllerMethodInfo.ReturnType;

                //here's the embranchement - whether it's JsonResult or ActionResult:
                if (actionResult.Name == "ActionResult")
                {
                    filterContext.Result = (new MainMenuController()).showUnAuthMenu();
                }
                else //if it's JsonResult
                {
                    filterContext.Result = new JsonResult
                    {
                        Data = null,
                        ContentEncoding = System.Text.Encoding.UTF8,
                        ContentType = "application/json",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
            }
        }
    }
}