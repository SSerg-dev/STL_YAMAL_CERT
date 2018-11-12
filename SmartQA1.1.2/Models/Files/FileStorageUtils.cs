using System;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Web;
using SmartQA1._1._2.DB.EntityFramework;
using System.Runtime.ExceptionServices;

namespace SmartQA1._1._2.Models.BusinessModels
{
    public class FileStorageUtils
    {
        public int ErrorCode { get; set; } = 0;
        public string FilesUploadResult { get; set; } = null;

        //Имя аргумента inputUploadFiles менять НЕЛЬЗЯ !!!
        //Оно должно быть таким же, как имя элемента <input type="file" name="inputUploadFiles">
        //в файле FileStorageCore.jsx, иначе будет приходить null из фронтэнда.
        public void Upload(HttpPostedFileBase[] inputUploadFiles)
        {
            using (var context = new FileStorageEntities())
            {
                ErrorCode = 0;
                string ErrorMessage = FilesUploadResult = null;

                StringBuilder sbFiles = new StringBuilder();
                string ErrMsgPrefix = $"в бэкэнде:{ Environment.NewLine }{ Environment.NewLine }";

                try
                {
                    //С помощью хранимой процедуры получаем путь к корневому каталогу для сохранения загружаемых файлов.
                    //Если нужно оперативно менять название таблицы p_FileShareTable,
                    //можно добавить ключ в web.config, который будет содержать имя таблицы,
                    //и читать значение ключа из конфига в переменную-аргумент метода Get_RootPath.
                    //Метод Get_RootPath убирать не нужно, т.к. путь к файловой шаре может быть изменён админами,
                    //которые работают в Technip.
                    //Название таблицы, если понадобится, меняем мы сами (наши SQL-разработчики).
                    string FilePath = $@"{ context.Get_RootPath("p_FileShareTable").First() }\";

                    if (inputUploadFiles != null && inputUploadFiles.Length > 0)
                    {
                        foreach (HttpPostedFileBase File in inputUploadFiles)
                        {
                            if (File != null)
                            {
                                File.SaveAs(FilePath + File.FileName);
                                sbFiles.AppendLine(Environment.NewLine).Append(File.FileName);
                            }
                        }
                    }
                    //Если во фронтэнде поменяли имя элемента <input type="file" name="inputUploadFiles">
                    //или аргумент inputUploadFiles не пришёл по каким-то другим причинам,
                    //пытаемся получить файлы из HttpContext.Current.Request.Files
                    else
                    {
                        HttpFileCollection Files = HttpContext.Current.Request.Files;

                        if (Files != null && Files.Count > 0)
                        {
                            HttpPostedFile File;
                            foreach (string fileKey in Files)
                            {
                                File = Files[fileKey];
                                if (File != null)
                                {
                                    File.SaveAs(FilePath + File.FileName);
                                    sbFiles.AppendLine(Environment.NewLine).Append(File.FileName);
                                }
                            }
                        }
                        else
                        {
                            ErrorCode = 1;
                            ErrorMessage = sbFiles.Append(ErrMsgPrefix)
                                .AppendLine("Аргумент \"inputUploadFiles\" равен null или не содержит ни одного файла.")
                                .Append("В HttpContext.Current.Request.Files не обнаружено ни одного файла.")
                                .ToString();
                            sbFiles.Clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.InnerException ?? ex);
                    ErrorCode = 1;
                    ErrorMessage = $"{ ErrMsgPrefix }{ (ex.InnerException ?? ex).Message }";
                }
                finally
                {
                    if (ErrorCode != 0)
                    {
                        if (sbFiles.Length > 0)
                        {
                            sbFiles
                            .Insert(0, "Файл(ы):")
                            .Insert(0, Environment.NewLine, 2)
                            .Insert(0, ErrorMessage)
                            .AppendLine(Environment.NewLine)
                            .Append("успешно загружен(ы).");
                        }
                        else sbFiles.Append(ErrorMessage);
                    }
                    if (sbFiles.Length > 0) FilesUploadResult = sbFiles.ToString().Trim();
                    else
                    {
                        ErrorCode = 1;
                        FilesUploadResult = $"{ ErrMsgPrefix }Не удалось сохранить файл(ы).";
                    }
                }
            }
        }
        public byte[] GetFileContentsById(Guid Stream_Id, out string FileName)
        {
            using (var context = new FileStorageEntities())
            {
                string fileName = null;

                byte[] FileContent =
                    System.IO.File
                    .ReadAllBytes
                    (
                        context.FileShareTables
                        .Where (x => x.Stream_Id == Stream_Id)
                        .ToList()
                        .Select(x => { fileName = x.FileName; return x.PathNonDefault; })
                        .FirstOrDefault()
                    );
                //Здесь можно использовать FileName = HttpUtility.UrlEncode(fileName),
                //но тогда пробелы будут заменены на знак "+", а не "%20",
                //и после этого нужно будет выполнить FileName = FileName.Replace("+", "%20"),
                //или делать замену "+" во фронтэнде ДО декодирования методом decodeURIComponent
                FileName = Uri.EscapeDataString(fileName);
                return
                    FileContent;
            }
        }
    }
}