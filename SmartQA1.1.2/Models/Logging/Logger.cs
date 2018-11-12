using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using SmartQA1._1._2.DB.Logging;
using SmartQA1._1._2.DB.StoredProcedures;
using SmartQA1._1._2.Models.Login;

namespace SmartQA1._1._2.Logging
{
    public class Logger
    {
        private Error error;
        private readonly UserIdentity appUser;
        private readonly AppUserTask appUserTask;
        private readonly AppUserTaskMessage appUserTaskMessage;

        
        /// <summary>
        /// Creates Logger instance from exception or its inner exception
        /// </summary>
        /// <param name="ex"></param>

        public Logger(Exception exception)
        {
            error = new Error(exception);

            string defaultUserName = System.Configuration.ConfigurationManager.AppSettings["defaultAppUser"];
            string defaultAppUserTask = System.Configuration.ConfigurationManager.AppSettings["defaultUserTask"];

            using (var context = new LogAuthSchema())
            {
                appUserTask = context.AppUserTask.FirstOrDefault(x => x.TaskName == defaultAppUserTask);
                if (appUserTask == null)
                {
                    var wrapper = new ArgumentNullException(
                        "Couldn't find the corresponding row for the WebApp Task_Name in AppUserTask view", 
                        exception);
                    FileLog(wrapper);
                }

                appUser = UserIdentity.getUser(defaultUserName);
                if (appUser == null)
                {
                    var wrapper = new ArgumentNullException(
                        "Couldn't find the default AppUser in AppUser view. Default user: " 
                        + defaultUserName,
                        exception);
                    FileLog(wrapper);
                }

                appUserTaskMessage = context.AppUserTaskMessage.FirstOrDefault(x => x.AppUserTaskMessage_Code == error.errorTypeId);
                if (appUserTaskMessage == null)
                {
                    var wrapper = new ArgumentNullException(
                        "Couldn't find the AppUserTaskMessage for AppUserTaskMessage_Code " 
                        + error.errorTypeId,
                        exception);
                    FileLog(wrapper);
                }
            }
        }
        /// <summary>
        /// Writes error to the DB.
        /// If failed, writes into the logFile at Iis machine
        /// or at current machine in current application location
        /// </summary>
        public void Log()
        {
            using (var context = new LogAuthSchema())
            using(var transaction = context.Database.BeginTransaction())
            {
                IResult<MsgIdPair> result = new MultipleSetsResultIdError<MsgIdPair>();
                try
                {
                    
                    StoredProcedureAdapter spAdapter = new StoredProcedureAdapter(context);
                    insertTaskLog(spAdapter, result);
                    if (!result.isValid)
                    {
                        var ex = new ApplicationException("Couldn't log to the DB "+result.Serialize());
                        FileLog(ex);
                    }
                }
                catch (Exception ex)
                {
                    var wrapper = new ApplicationException("Couldn't log to the DB " + result.Serialize(), ex);
                    result.AddException(wrapper);
                    FileLog(wrapper);
                }
                finally
                {
                    if (result.isValid) transaction.Commit(); else transaction.Rollback();
                }
            }
        }

        private void FileLog(Exception ex)
        {
            error = new Error(ex);
            FileLog(error);
        }
        private void FileLog(Error error)
        {

            try
            {
                string fileMessage = $"{error.message} " +
                                     $"StackTrace: {error.stackTrace} " +
                                     $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}{Environment.NewLine}";

                string solutionDirDebug = AppDomain.CurrentDomain.BaseDirectory;
                solutionDirDebug = Directory.GetParent(solutionDirDebug).FullName;

                string appDomainDirProd = @"E:\SmartPlantLog\log.txt";

                string fileLogDirectory;

#if (DEBUG)
                fileLogDirectory = solutionDirDebug;
#else
                fileLogDirectory = appDomainDirProd;
#endif

                File.AppendAllText(fileLogDirectory+@"\LoggerDebugLog.txt", fileMessage, Encoding.Default);
            }
            catch (Exception ex)
            {
                //there's nothing left to do...
            }

        }
        private IResult<T> insertTaskLog<T>(StoredProcedureAdapter spa, IResult<T> result) where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure
            (
                result,
                "dbo",
                "AppUserTaskLog_Insert",
                "0",
                appUser.Id,
                appUserTask.AppUserTask_ID,
                appUserTaskMessage.AppUserTaskMessage_ID,
                null, //file path
                null, //file name
                error.message, //description rus
                null, //description eng
                error.stackTrace
            );
        }
        
    }
}