using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;
using SmartQA1._1._2.Models.Login;

namespace SmartQA1._1._2.Controllers
{
    public class ImpersonateAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            System.Diagnostics.Debug.WriteLine("Filter impersonation");
            
            var adapter = new ThreadImpersonationAdapter();
            filterContext.HttpContext.Items["impersonationAdapter"] = adapter;

            if (adapter.ImpersonateFromContext(HttpContext.Current))
                System.Diagnostics.Debug.WriteLine("Successful impersonation");
            else
                System.Diagnostics.Debug.WriteLine("Impersonation failed");

            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            System.Diagnostics.Debug.WriteLine("Current user: " + wi.Name);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            (filterContext.HttpContext.Items["impersonationAdapter"] as ThreadImpersonationAdapter)?.Dispose();
        }
    }
}