using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SmartQA1._1._2.App_Start;
using SmartQA1._1._2.Logging;
using SmartQA1._1._2.Models.Login;
using SmartQA1._1._2.Service;

namespace SmartQA1._1._2.Controllers
{
    // FIXME: legacy react stuff, remove after all forms have been moved to DevEx
    public class LoginController : Controller 
    {
        /*
        //this method is a sand box to implement encryption and cookies
        public JsonResult Login(UserIdentity user)
        {
            var result = LoginModel.Login(user);
            if (!result.isUserPasswordsNull())
            {
                var ex = new SecurityException("Tried to pass viral information to FE");
                new Logger(ex).Log();
                //process has to be crashed
                throw ex;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        */
        //returns credentials for the current session:
        public JsonResult checkLogin()
        {
            return Json(LoginModel.checkLogin(), JsonRequestBehavior.AllowGet);
        }
        /*
        public JsonResult getRSAPublicKeyPassword()
        {
            //TODO - implement session inialization here
            return Json(LoginModel.sendRsaPublicKey(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Logout()
        {
            return Json(LoginModel.Logout(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Register(UserIdentity user)
        {
            return Json(LoginModel.registerNewUser(user), JsonRequestBehavior.AllowGet);
        }
*/
    }
}