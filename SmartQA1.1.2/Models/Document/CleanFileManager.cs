using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using SmartQA1._1._2.DB.EntityFramework;

namespace SmartQA1._1._2.Models.ABDDocument
{
    public class CleanFileManager
    {
        private readonly string shareFolderPath = null;

        public CleanFileManager()
        {
            using (var context = new FileStorageEntities())
            {
                shareFolderPath = $@"{ context.Get_RootPath("p_FileShareTable").First() }\";
            }
        }

        /// <summary>
        /// Deleted all files from the FileShare. Specify file names with their relative path
        /// to the FileShare
        /// </summary>
        public void DeleteFiles(List<string> files)
        {
            foreach (var file in files)
            {
                string source = shareFolderPath + file;
                File.Delete(source);
            }
        }
    }
}