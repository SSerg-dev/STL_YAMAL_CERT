using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using SmartQA1._1._2.Logging;

namespace SmartQA1._1._2.Models.Login
{
    // FIXME: legacy react stuff, remove after all forms have been moved to DevEx
    public abstract class LoginResult
    {
        public enum ResultCode {
            noError = 0,
            notValidUserCredentials = 1,
            applicationError = 2,
            isAlreadyLoggedOut = 3,
            notAuthentificatedUser = 4
        }
        public bool isAuth = false;
        public LoginResultUser user { get; protected set; }
        public int errorType //this field is intended to be read only by Json Serializer
        {
            get;

            protected set;
        }

        public string message { get; protected set; } = null;

        protected LoginResult(ResultCode code)
        {
            user = null;
            errorType = (int)code;
        }
        protected LoginResult(HttpContext httpContext)
        {
            httpContext.Session["isAuth"] = false;
            errorType = (int)ResultCode.notValidUserCredentials;
        }
        
        public bool isGoodResult()
        {
            return isAuth && errorType == 0;
        }
        public bool isBadResult()
        {
            return !isAuth && errorType != 0;
        }

    }
    /*
    public class LoginNotValidUserResult : LoginResult
    {
        public LoginNotValidUserResult(HttpContext httpContext) : base(ResultCode.notValidUserCredentials)
        {
            isAuth = false;
            httpContext.Session["isAuth"] = false;
        }
    }
    public class LoginOkResult : LoginResult
    {
        public LoginOkResult(HttpContext httpContext, UserIdentity user) : base(ResultCode.noError)
        {
            isAuth = true;
            httpContext.Session["isAuth"] = true;
            httpContext.Session["user"] = user;

            this.user = user;
            user?.ClearPasswords();
        }
    }
    
    public class LoginExceptionResult : LoginResult
    {
        public LoginExceptionResult(HttpContext httpContext, Exception ex) : base(ResultCode.applicationError)
        {
            isAuth = false;
            httpContext.Session["isAuth"] = false;
            message = (ex.InnerException ?? ex).Message;
        }
    }
        */
    public class LoginNotAuthenticatedResult : LoginResult
    {
        public LoginNotAuthenticatedResult(HttpContext httpContext) : base(ResultCode.notAuthentificatedUser)
        {
            isAuth = false;
            
        }
    }

    public class LoginAuthenticatedResult : LoginResult
    {
        public LoginAuthenticatedResult(HttpContext httpContext) : base(ResultCode.noError)
        {
            isAuth = true;
            var identity = httpContext.User.Identity;
            var Id = identity.GetUserId();
            var Name = identity.GetUserName();
            user = new LoginResultUser(identity);
        }
    }
    public class LoginResultUser
    {
        public Guid Id;
        public string Name;

        public LoginResultUser(IIdentity identity)
        {
            Id = Guid.Parse(identity.GetUserId());
            Name = identity.GetUserName();
        }
    }

}