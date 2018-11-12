using System;
using System.Linq;
using System.Web;
using System.Text;
using AutoMapper;
using SmartQA1._1._2.Service;
using System.Security.Cryptography;
using SmartQA1._1._2.DB.StoredProcedures;
using System.Runtime.ExceptionServices;
using SmartQA1._1._2.DB.Logging;
using Newtonsoft.Json;
using SmartQA1._1._2.Exceptions;
using SmartQA1._1._2.Logging;

namespace SmartQA1._1._2.Models.Login
{
    // FIXME: legacy react stuff, remove after all forms have been moved to DevEx
    [Serializable]
    public class UserIdentity
    {
        public Guid? Id;
        public string Name { get; set; } //ASP.NET model mapping to this field
        public string Password { get; set; }
        public byte[] PasswordEncryptedDB { private get; set; }
        public byte[] PasswordDecryptedDB { get; private set; }
        public string PasswordEncryptedFE { get; set; } //ASP.NET model mapping to this field
        public byte[] PasswordDecryptedFE { get; private set; }

        public string ShortName;
        public Guid? Division_ID;
        public string Division_Name;
        public Role_Code RoleCode;

        private static byte[] p1 = {
                0x32, 0x44, 0x65, 0x63,
                0x6C, 0x69, 0x6E, 0x65,
                0x34, 0x49, 0x6E, 0x63,
                0x6C, 0x69, 0x6E, 0x65
        };

        //this constructor is for ASP.NET Model binding:
        public UserIdentity()
        {
        }
        //this constructor is supposed to be used by linq to create new instance of the userIdentity when required
        public UserIdentity(Guid? userId, string userName, byte[] userPasswordEncryptedDB)
        {
            Id = userId;
            Name = userName;
            PasswordEncryptedDB = userPasswordEncryptedDB;
        }

        public UserIdentity(AppUser appUser)
        {
            Id = appUser.AppUser_ID;
            Name = appUser.AppUser_Code;
            PasswordEncryptedDB = appUser.User_Password;
        }
        public UserIdentity Clone()
        {
            //works until required members are of reference types
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserIdentity, UserIdentity>());
            IMapper mapper = config.CreateMapper();
            return mapper.Map<UserIdentity, UserIdentity>(this);
        }
        public void decrypt3DesUserPassword()
        {
            var TdesEncryptor = new Encryptor3DES(p1);
            if (PasswordEncryptedDB != null)
            {
                PasswordDecryptedDB = TdesEncryptor.decrypt(PasswordEncryptedDB);
                Password = Encoding.UTF8.GetString(PasswordDecryptedDB);
            }
            else
            {
                Password = null;
                PasswordDecryptedDB = null;
                var ex = new DatabaseStateException("Not valid password encrypted in current user table");
                new Logger(ex).Log();
                throw ex;
            }            
        }

        public void GetUserRole(LogAuthSchema context)
        {
            var result = new UserGetResult<MsgIdPair>(Id);
            var spa = new StoredProcedureAdapter(context);

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    if (Id == null) throw new ArgumentNullException("User id is null");

                    spa.ExecuteStoredProcedure(
                        result,
                        "dbo",
                        "User_FormType_Get",
                        Id
                    );
                    ShortName = result.ShortName;
                    Division_ID = result.Division_ID;
                    Division_Name = result.Division_Name;
                    //RoleCode = result.RoleCode;

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
                
            }
            
        }

        public void decryptRsaPassword(HttpContext context)
        {
            try
            {
                RSAParameters parameters = (RSAParameters)HttpContext.Current.Application["RSAparameters"];
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSA.ImportParameters(parameters);

                var enc = ToolKit.String2ByteArray(PasswordEncryptedFE);
                if (enc == null) throw new FormatException
                    ($"Зашифрованный пароль { PasswordEncryptedFE } или содержит нечётное количество символов," +
                    " или содержит только \"0x\", или пустой.");

                PasswordDecryptedFE = RSA.Decrypt(enc, false);
                Password = Encoding.UTF8.GetString(PasswordDecryptedFE);
            }
            catch (Exception ex)
            {
                PasswordDecryptedFE = null;

                switch (ex)
                {
                    case NullReferenceException nrEx:
                        (nrEx.InnerException ?? nrEx).Data.Add("NullReference", "RSAParameters retrieved from the session happened to be null value");
                        new Logger(nrEx.InnerException ?? nrEx).Log();
                        throw;
                    case FormatException fmtEx:
                        new Logger(fmtEx.InnerException ?? fmtEx).Log();
                        throw;
                    default:
                        new Logger(ex.InnerException ?? ex).Log();
                        throw;
                }
            }
        }
        //TRANSFERED TO NEW DB
        public static UserIdentity getUser(string userName)
        {
            using (var context = new LogAuthSchema())
            {
                var userDB = context.AppUser
                .FirstOrDefault(x => x.AppUser_Code == userName || x.AppUser_Code == @"TP\" + userName);
                var user = new UserIdentity(userDB);
                user.GetUserRole(context);
                return user;
            }
        }

        
        public static UserIdentity getUser(LogAuthSchema context, string userName)
        {
            return context.AppUser
                .Where(x => x.AppUser_Code == userName || x.AppUser_Code == @"TP\" + userName)
                .Select(x => new UserIdentity(x))
                .FirstOrDefault();
        }

        public IResult<MsgIdPair> CreateUpdateUserWithPasswordEncryption()
        {
            byte[] userPassword = Encoding.UTF8.GetBytes(Password);
            var TdesEncryptor = new Encryptor3DES(p1);
            var enc = TdesEncryptor.encrypt(userPassword);

            using (var context = new LogAuthSchema())
            {
                var result = new MultipleSetsResultIdError<MsgIdPair>();

                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        StoredProcedureAdapter spAdapter = new StoredProcedureAdapter(context);
                        
                        spAdapter.ExecuteStoredProcedure
                        (
                            result,
                            "dbo",
                            "AppUser_Insert",
                            "0",
                            "D9E0B7D7-A8EB-4A66-8FE8-09F6AF846E64", //User_ID - WebServerUser
                            Name, //User_Domain_Name
                            enc, //User password encrypted
                            "SmartQA1._1._2.Models.Login.UserIdentity"
                        );
                    }
                    catch (Exception ex)
                    {
                        result.AddException(ex);
                        throw;
                    }
                    finally
                    {
                        if (result.isValid) transaction.Commit(); else transaction.Rollback();
                    }
                }
                //asserting two operations - encryption and writing
                var newUser = getUser(Name);
                var dec = TdesEncryptor.decrypt(newUser.PasswordEncryptedDB);

                if (!dec.SequenceEqual(userPassword))
                {
                    var ex = new ApplicationException("Failed to insert encrypted password into current user table");
                    new Logger(ex).Log();
                    throw ex;
                }
                return result;
            }
        }
        
        public void ClearPasswords()
        {
            Password = null;
            PasswordDecryptedDB = null;
            PasswordDecryptedFE = null;
            PasswordEncryptedDB = null;
            PasswordEncryptedFE = null;
        }
        public bool isPasswordsCleared()
        {
            if
            (
                Password!=null
                || PasswordDecryptedDB != null
                || PasswordDecryptedFE != null
                || PasswordEncryptedDB != null
                || PasswordEncryptedFE != null
            ) return false;
            else return true;
        }
        public void SetTestPassword()
        {
            this.Password = "TestUserPassword";
        }
        public bool checkUserFE()
        {
            if (Name == null || PasswordEncryptedFE == null)
                return false;
            else return true;
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(new { name = Name, id = Id });
        }
    }
}