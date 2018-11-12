using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using System.ComponentModel;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Text;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using SmartQA1._1._2.App_Start;
using Microsoft.AspNet.Identity;
using SmartQA1._1._2.Authentication;

namespace SmartQA1._1._2.Models.Login
{
    public class ThreadImpersonationAdapter : IDisposable
    {
        private const string domain = "TP";
        private Win32SafeHandler token = null;

        public bool Impersonate(string userName, string userPass)
        {
            //this should be solved another way:
            if (userName.StartsWith(@"TP\")) userName = userName.Substring(3);

            WindowsIdentity wi;
            try
            {
                wi = createWindowsIdentity(userName, userPass);
            }
            catch (Win32Exception wex)
            {
                return false;
            }
            if (wi == null) return false;
            wi.Impersonate();

            Thread.CurrentPrincipal = getNewGenericPrincipal(wi);
            System.Web.HttpContext.Current.Session["WindowsIdentity"] = wi;
            return true;
        }
        public static bool CheckDomainUser(string userName, string userPass, Guid? userId = null)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "RU300VM0011.tp.tpnet.intra."))
            {
                //this should be solved another way:
                if (pc.ValidateCredentials(userName.StartsWith(@"TP\") ? userName.Substring(3) : userName, userPass))
                    return true;
                else
                {
                    //TODO - implement failed logging
                    return false;
                }
            }
        }
        public bool ImpersonateFromContext(HttpContext context)
        {
            var user = User.GetFromContext(context);
            if (user != null) return Impersonate(user.UserName, user.Password);
                
            return false;
        }

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
        int dwLogonType, int dwLogonProvider, out Win32SafeHandler token);

        private WindowsIdentity createWindowsIdentity(string userName, string userPass)
        {
    
            bool isLogin = LogonUser
                (
                    userName,
                    domain,
                    userPass,
                    (int)LogonTypes.LOGON32_LOGON_INTERACTIVE,
                    (int)LogonProviders.LOGON32_PROVIDER_DEFAULT,
                    out token
                );
            if (isLogin)
            {
                return new WindowsIdentity(token.DangerousGetHandle());
            }
            else
            {
                int errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode);
            }
        }
        private static GenericPrincipal getNewGenericPrincipal(WindowsIdentity wi)
        {
            string[] roles = new string[3];
            if (wi.IsAuthenticated) roles[0] = "NetworkUser";
            if (wi.IsGuest) roles[1] = "GuestUser";
            if (wi.IsSystem) roles[2] = "SystemUser";

            GenericIdentity gi = new GenericIdentity(wi.Name, wi.AuthenticationType);
            return new GenericPrincipal(gi, roles);
        }
        public void Dispose()
        {
            if(token!=null) token.Dispose();
        }
    }
}