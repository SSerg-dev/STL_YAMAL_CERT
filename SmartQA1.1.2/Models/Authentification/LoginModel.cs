using System;
using System.Security.Cryptography;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SmartQA1._1._2.Exceptions;
using System.Security;
using SmartQA1._1._2.Logging;
using SmartQA1._1._2.App_Start;

namespace SmartQA1._1._2.Models.Login
{

    // FIXME: legacy react stuff, remove after all forms have been moved to DevEx
    public class LoginModel
    {
        /*
        public static LoginResult Login(UserIdentity userFE) //FE - frontEnd
        {
            try
            {
                //this is clearly application error - error in FE
                if (userFE.Name == null) throw new NullReferenceException("Null user name");

                var userDB = UserIdentity.getUser(userFE.Name);

                //not valid user name:
                if (userDB == null)
                {
                    return new LoginNotValidUserResult(HttpContext.Current);
                }
                else userDB.decrypt3DesUserPassword();

                if (userDB.PasswordDecryptedDB == null)
                {
                    var ex = new DatabaseStateException($"The password is not encrypted for user: { userFE.Serialize() }");
                    new Logger(ex).Log();
                    throw ex;
                }

                userFE.decryptRsaPassword(HttpContext.Current);

                byte[] passFE = userFE.PasswordDecryptedFE;
                byte[] passDB = userDB.PasswordDecryptedDB;

                //not valid user password:
                if (!passDB.SequenceEqual(passFE))
                {
                    if (ThreadImpersonationAdapter.CheckDomainUser(userFE.Name, userFE.Password, userDB.Id))
                        throw new DatabaseStateException("Пароль пользователя для веб-приложения должен быть таким же,"
                                                         + $" как и для входа в домен Windows.{Environment.NewLine}"
                                                         + $"Обновите пароль пользователя {userFE.Name} в БД.");
                    else return new LoginNotValidUserResult(HttpContext.Current);
                }
                
                //check if it's domain user:
                if (ThreadImpersonationAdapter.CheckDomainUser(userDB.Name, userDB.Password, userDB.Id))
                    GetOkResultAndImpersonalise(userDB);
                else
                {
                    var ex = new SecurityException("Access is prohibited for domain users.");
                    throw ex;
                }

                return new LoginOkResult(HttpContext.Current, userDB);
            }
            catch (Exception ex)
            {
                new Logger(ex).Log();
                return new LoginExceptionResult(HttpContext.Current, ex);
            };
        }
        public static LoginResult Logout()
        {
            return new LoginNotAuthenticatedResult(HttpContext.Current);
        }
        */
        //no input parameters are required because this method uses session cookies

        public static LoginResult checkLogin()
        {
            var identity = HttpContext.Current.User.Identity;

            if (!identity.IsAuthenticated)
            {
                return new LoginNotAuthenticatedResult(HttpContext.Current);
            }
            else
            {
                return new LoginAuthenticatedResult(HttpContext.Current);
            }
        }
        /*
        public static LoginResult registerNewUser(UserIdentity userFE)
        {
            try
            {
                userFE.decryptRsaPassword(HttpContext.Current);

                string userName = userFE.Name;
                string userPass = userFE.Password;

                //check if this user exists in current domain
                bool isValid = ThreadImpersonationAdapter.CheckDomainUser(userName, userPass, userFE.Id);
                if(!isValid) return new LoginNotValidUserResult(HttpContext.Current);

                //checking if the user has specified right credentials - TP or not TP slashed:
                userFE = UserIdentity.getUser(userName);
                if (userFE == null)
                {
                    userName = $@"TP\{ userName }";
                    userFE = UserIdentity.getUser(userName);
                }
                if (userFE == null) return new LoginNotValidUserResult(HttpContext.Current);

                var result = userFE.CreateUpdateUserWithPasswordEncryption();

                var userDB = UserIdentity.getUser(userName);
                GetOkResultAndImpersonalise(userDB);
                return new LoginOkResult(HttpContext.Current, userFE);

            }
            catch (Exception ex)
            {
                return new LoginExceptionResult(HttpContext.Current, ex);
            }
        }
        */
        /*assumed that the password will come after decryption and has type byte[]
         * so the return type of this method is byte[]
         * */
        /*
       public static string sendRsaPublicKey()
       {
           var context = HttpContext.Current;
           var parameters = (RSAParameters)context.Application["RSAparameters"];
           var publicKey = new
           {
               n = BitConverter.ToString(parameters.Modulus).Replace("-", string.Empty).ToLower(),
               e = BitConverter.ToString(parameters.Exponent).Replace("-", string.Empty).ToLower(),
           };
           return JsonConvert.SerializeObject(publicKey);
       }

       private static bool GetOkResultAndImpersonalise(UserIdentity user)
       {
           using (var tia = new ThreadImpersonationAdapter())
           {
               bool impersonationResult = tia.Impersonate(user.Name, user.Password);
               if (!impersonationResult)
               {
                   var ex = new ApplicationException("Failed user impersonation");
                   new Logger(ex).Log();
                   throw ex;
               }
               return impersonationResult;
           }
       }
               */
    }
}