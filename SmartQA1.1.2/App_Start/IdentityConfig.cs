using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Owin;
using SmartQA1._1._2.Authentication;
using SmartQA1._1._2.DB.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace SmartQA1._1._2.App_Start
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<User, Guid>
    {
        public ApplicationUserManager(IUserStore<User, Guid> store)
            : base(store)
        {
        }

        public override Task<bool> CheckPasswordAsync(User user, string password)
        {
            return Task.FromResult(user.CheckPassword(password));
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore(context.Get<LogAuthSchema>()));
          
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<User, Guid>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }

        public override Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
            => UserManager.FindByNameAsync(userName)
                .ContinueWith((task) =>
                {
                    var user = task.Result;
        
                    if (user != null && user.CheckPassword(password))
                    {
                        var identity = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                        AuthenticationManager.SignIn(
                            new AuthenticationProperties() { IsPersistent = isPersistent },
                            identity);

                        return SignInStatus.Success;
                    }
                    return SignInStatus.Failure;
                });
        
    }

}