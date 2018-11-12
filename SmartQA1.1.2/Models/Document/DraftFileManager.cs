using System;
using System.Linq;
using System.Web;
using System.IO;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using SmartQA1._1._2.DB.EntityFramework;
using System.Runtime.ExceptionServices;
using SmartQA1._1._2.DB.WebDb;

namespace SmartQA1._1._2.Models.ABDDocument
{
    public class DraftFileManager : IDisposable
    {
        private string draftSharePath;
        private string shareFolderPath;
        private string folderName;
        private string sessionId;
        private static object objectLock = new object();
        private BlockingCollection<string> draftFileList;

        private DraftFileManager() 
        {
            using (var context = new FileStorageEntities())
            {

                //Если нужно оперативно менять названия таблиц p_FileShareTable_Draft и p_FileShareTable,
                //можно добавить ключи в web.config, которые будут содержать имена таблиц,
                //и читать значения ключей из конфига в переменную - аргумент метода Get_RootPath.
                //Метод Get_RootPath убирать не нужно, т.к. путь к файловым шарам может быть изменён админами,
                //которые работают в Technip.
                //Названия таблиц, если понадобится, меняем мы сами (наши SQL-разработчики).
                draftSharePath = $@"{context.Get_RootPath("p_FileShareTable_Draft").First()}\";
                shareFolderPath = $@"{context.Get_RootPath("p_FileShareTable").First()}\";
            }

            folderName = HttpContext.Current.Session.SessionID + @"\";
            HttpContext.Current.Session["DraftFileManager"] = this;
            sessionId = HttpContext.Current.Session.SessionID;
            draftFileList = new BlockingCollection<string>();
        }
        //Session singleton:
        public static DraftFileManager GetInstance()
        {
            Object instance = HttpContext.Current.Session["DraftFileManager"];
            lock (objectLock)
            {
                if (instance == null)
                {
                    return new DraftFileManager();
                }
                else
                {
                    return (DraftFileManager)instance;
                }
            }
        }
        public FileResult UploadFiles()
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;

            //check if folder exists - create it otherwise
            if (!Directory.Exists(draftSharePath + folderName))
                Directory.CreateDirectory(draftSharePath + folderName);

            try
            {
                foreach (string fileKey in files)
                {
                    files[fileKey].SaveAs(draftSharePath + folderName + files[fileKey].FileName);
                    draftFileList.Add(files[fileKey].FileName);
                }
                return new FileResult();
            }
            catch (Exception ex)
            {
                return new FileResult(ex);
            }
        }
        public List<UI_FileStream> Folder()
        {
            if (!Directory.Exists(draftSharePath + folderName)) return new List<UI_FileStream>();

            var files = Directory.GetFiles(draftSharePath + folderName);
            List<UI_FileStream> result = new List<UI_FileStream>();

            foreach (var file in files) result.Add(new UI_FileStream()
            {
                name = Path.GetFileName(file),
                last_write_time = Directory.GetLastWriteTime(file) //doesn't work - shows upload date
            });
            return result;
        }

        /// <summary>
        /// Moves files from \25_AsBuilt_Documentation_Draft folder
        /// to \25_AsBuilt_Documentation. Returns file names with their absolute path
        /// to be used inside SQL procedure
        /// </summary>
        public List<string> MoveFiles(string subfolder)
        {
            var result = new List<string>();

            while (TryMoveNextFile(out var fileName, subfolder))
            {
                result.Add(shareFolderPath + subfolder + fileName);
            }
            return result;
        }

        public FileResult DeleteFile(string fileName)
        {
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));

            if (!draftFileList.TryTake(out fileName)) return null;

            try
            {
                File.Delete(draftSharePath + folderName + fileName);

                //if folder contains no items, than we
                //try to delete it thread-safely.
                //Exception is sent when somebody puts
                //a file inside directory while this 
                //code it trying to delete it
                if (!Directory.EnumerateFileSystemEntries(draftSharePath + folderName).Any())
                {
                    Directory.Delete(draftSharePath + folderName);
                }
                return new FileResult();
            }
            catch (Exception ex)
            {
                return new FileResult(ex);
            }
        }

        public bool TryMoveNextFile(out string fileName)
        {
            if (draftFileList.Count > 0)
            {
                fileName = draftFileList.Take(); //remove single file name

                File.Move(
                    draftSharePath + folderName + fileName,
                    shareFolderPath + fileName
                );
                return true;
            }
            fileName = null;
            return false;
        }

        public bool TryMoveNextFile(out string fileName, string subfolderName)
        {
            if (draftFileList.Count > 0)
            {
                //check if folder exists - create it otherwise
                if (!Directory.Exists(shareFolderPath + subfolderName))
                    Directory.CreateDirectory(shareFolderPath + subfolderName);

                fileName = draftFileList.Take(); //remove single file name

                string destination = shareFolderPath + subfolderName + fileName;
                string source = draftSharePath + folderName + fileName;

                if (File.Exists(destination)) File.Delete(destination);
                File.Move(source, destination);

                return true;
            }
            fileName = null;
            return false;
        }

        

        //FileResult is not requested by the FE, so there's no return typef
        public void SaveDevExpressFile(DevExpress.Web.UploadedFile file)
        {
            //check if folder exists - create it otherwise
            if (!Directory.Exists(draftSharePath + folderName))
                Directory.CreateDirectory(draftSharePath + folderName);

            draftFileList.Add(file.FileName);
            file.SaveAs(draftSharePath + folderName + file.FileName);
        }
        public void Dispose()
        {
            draftFileList.Dispose();
            //deleting the whole folder of the session:
            HttpContext.Current.Session["DraftFileManager"] = null;
            if(Directory.Exists(draftSharePath + folderName))
                Directory.Delete(draftSharePath + folderName, true);
        }
    }
}