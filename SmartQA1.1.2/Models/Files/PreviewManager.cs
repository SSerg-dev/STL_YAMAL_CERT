using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using SmartQA1._1._2.DB.EntityFramework;

namespace SmartQA1._1._2.Models.BusinessModels
{
    public class PreviewManager : IDisposable
    {
        private Dictionary<Guid, Preview> previewList;
        private string sessionId;
        private static object objectLock = new object();
        
        private PreviewManager()
        {
            previewList = new Dictionary<Guid, Preview>();
            HttpContext.Current.Session["PreviewManager"] = this;
            sessionId = HttpContext.Current.Session.SessionID;
        }
        //Session singleton:
        public static PreviewManager GetInstance()
        {
            Object instance = HttpContext.Current.Session["PreviewManager"];
            lock (objectLock)
            {
                if (instance == null)
                {
                    return new PreviewManager();
                }
                else
                {
                    return (PreviewManager)instance;
                }
            }
        }
        public object GetPreviewFile(Guid streamId)
        {
            Preview preview = null;

            //current preview has already been created
            if (previewList.TryGetValue(streamId, out preview))
            {
                //check if the file hasn't changed 

                using (var context = new FileStorageEntities())
                {
                    
                    var dbLastWriteTime = context.FileShareTables
                        .Where(x => x.Stream_Id == streamId)
                        .Select(x => x.LastWriteTime)
                        .FirstOrDefault();

                    if (preview.LastWriteTime == dbLastWriteTime)
                        return preview.GetMainFile();
                    else previewList.Remove(streamId);
                }
            }
            using (var context = new FileStorageEntities())
            {
                var file = new FileList().GetFileById(streamId);

                //Если нужно оперативно менять название таблицы p_FileShareTable_Preview,
                //можно добавить ключ в web.config, который будет содержать имя таблицы,
                //и читать значение ключа из конфига в переменную - аргумент метода Get_RootPath.
                //Метод Get_RootPath убирать не нужно, т.к. путь к файловой шаре может быть изменён админами,
                //которые работают в Technip.
                //Название таблицы, если понадобится, меняем мы сами (наши SQL-разработчики).
                preview = new Preview(file, $@"{ context.Get_RootPath("p_FileShareTable_Preview").First() }\", sessionId);
                previewList.Add(streamId, preview);
            }
            return preview.GetMainFile();
        }
        //html documents only should call this method
        public object GetFileInFolder(Guid streamId, string fileName)
        {
            Preview preview = null;
            if (previewList.TryGetValue(streamId, out preview))
            {
                return preview.GetFileInFolder(fileName);
            }
            else throw new SecurityException("File access violation");
        }
        public void Dispose()
        {
            foreach (Preview prev in previewList.Values) {
                prev.Dispose();
            }
            previewList.Clear();
        }
    }
}