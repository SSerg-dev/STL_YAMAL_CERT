using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Web.Optimization;
using SmartQA1._1._2.Models.Login;
using SmartQA1._1._2.Models.ABDDocument;
using SmartQA1._1._2.Models.BusinessModels;

namespace SmartQA1._1._2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.DefaultBinder = new DevExpress.Web.Mvc.DevExpressEditorsBinder();

            //generate new RSA key for all users:
            InitRsaKey();
        }

        protected void InitRsaKey()
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            var parameters = RSA.ExportParameters(true);

            Application["RSAparameters"] = parameters;
        }
        protected void Application_End()
        {
            System.Diagnostics.Debug.WriteLine("Exit of the application");
        }
        public override void Dispose()
        {
            System.Diagnostics.Debug.WriteLine("Exit by the dispose");
            base.Dispose();
        }
        private void Session_Start(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Timeout = 180;
            
            System.Diagnostics.Debug.WriteLine("Session start");
        }
        private void Session_End(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session end");
        }
    }

}
