using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartQA1._1._2.Models.ABDDocument;

namespace SmartQA1._1._2.Models.Document
{
    public class DocFileUploadSettings
    {

        public static DevExpress.Web.UploadControlValidationSettings UploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".png", ".pdf", ".txt", ".rtf", ".doc", ".docx", ".xls", ".xlsx" },
            MaxFileSize = 4000000
        };
        public static void FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            if (e.UploadedFile.IsValid)
            {
                DraftFileManager.GetInstance().SaveDevExpressFile(e.UploadedFile);
            }
        }
    }
}