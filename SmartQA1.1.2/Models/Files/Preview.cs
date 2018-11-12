using System;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Security;

namespace SmartQA1._1._2.Models.BusinessModels
{
    public class Preview : IDisposable
    {
        public string previewName;
        public string previewMainFile;
        public DateTime? LastWriteTime;
        IFileConverter fileConverter;
        public bool isCreated = false;
        private string fileExtension;
        private string previewExtension;
        private string folder;
        private string streamId;
        private string previewPath;

        public Preview(File file, string previewPath, string sessionId)
        {
            this.previewPath = previewPath;
            streamId = $"{file.Stream_Id}";
            previewName = $"{streamId}{sessionId}";
            fileExtension = file.FileType;
            LastWriteTime = file.LastWriteTime;

            if (fileExtension == "xlsx")
            {
                previewExtension = "html";
                fileConverter = new ExcelConverter
                (
                    previewPath,
                    file.PathNonDefault,
                    $@"{previewPath}\{previewName}",
                    null
                );
                isCreated = true;
            }
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            if(fileConverter!=null) previewMainFile = fileConverter.Convert(out folder, out previewMainFile);

            //stopwatch.Stop();
            //Debug.WriteLine("To create preview: " + stopwatch.ElapsedMilliseconds);
        }
        public object GetMainFile()
        {
            if (previewExtension == "html")
            {
                string htmlFile =
                    System.IO.File.ReadAllText(previewMainFile, Encoding.GetEncoding("windows-1251"));

                //replacing all local html links
                htmlFile = htmlFile.Replace($@"folder/", $"GetPreviewFile?Stream_Id={streamId}&fileName=");
                return htmlFile;
            }
            else return null;
        }
        //html documents only should call this method
        public object GetFileInFolder(string fileName)
        {
            if (folder == null) throw new SecurityException("File access violation");

            //try to check if this file exists in the folder:
            string[] filesInFolder = Directory.GetFiles(previewPath + folder);
            filesInFolder = filesInFolder.Select(x => Path.GetFileName(x)).ToArray();

            int filePosition = Array.IndexOf(filesInFolder, fileName);
            if (filePosition < 0) throw new SecurityException("File access violation");
            else
            {
                string file = System.IO.File
                    .ReadAllText($@"{previewPath}{folder}\{fileName}", Encoding.GetEncoding("windows-1251"));

                //escaping from not valid stylesheet link
                if (file.Contains("stylesheet.css"))
                    file = file.Replace("stylesheet.css",
                        $"GetPreviewFile?Stream_Id={streamId}&fileName=stylesheet.css");
                //escaping from not valid sheet links
                for (int i = 1; true; i++)
                {
                    if (file.Contains($@"href=""sheet{i:000}.html"))
                        file = file.Replace($@"href=""sheet{i:000}.html",
                            $@"href=""GetPreviewFile?Stream_Id={streamId}&fileName=sheet{i:000}.html");
                    else break;
                }
                return file;
            }
        }

        public void Dispose()
        {
            fileConverter.Dispose();            
            Debug.WriteLine("Disposing preview");
        }
        public static string UTF8toASCII(string text)
        {
            Encoding utf8 = Encoding.UTF8;
            Byte[] encodedBytes = utf8.GetBytes(text);
            Byte[] convertedBytes =
                    Encoding.Convert(Encoding.UTF8, Encoding.ASCII, encodedBytes);
            Encoding ascii = Encoding.ASCII;

            return ascii.GetString(convertedBytes);
        }
    }
}