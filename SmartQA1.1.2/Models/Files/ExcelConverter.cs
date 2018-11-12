using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using Microsoft.CSharp.RuntimeBinder;
using System.Runtime.InteropServices;

namespace SmartQA1._1._2.Models
{
    public class ExcelConverter : IFileConverter
    {
        public string sheetName = null;

        private Application excel;
        private Workbook xls = null;
        private object missing = Type.Missing;
        private object format = XlFileFormat.xlHtml;
        private bool isSheetFound = false;
        private string destinationFileName;
        private string mainFileCreated;
        private string previewPath;
        private string fileToConvert;

        public ExcelConverter()
        {

        }
        public ExcelConverter(string previewPath, string fileToConvert, string destinationFileName, string sheetName)
        {
            this.previewPath = previewPath;
            this.sheetName = sheetName;
            this.fileToConvert = fileToConvert;
            this.destinationFileName = destinationFileName;
        }

        public string Convert(out string folder, out string mainFileCreated)
        {
            excel = new Application();
            Workbooks workbooks = excel.Workbooks;

            try
            {
                

                Stopwatch sw = new Stopwatch();
                sw.Start();

               

                xls = workbooks.Open(fileToConvert, 0, true);
                excel.DisplayAlerts = false;
                /*
                xls = excel.Workbooks.Open(
                    fileName,   missing,    (object)true,
                    missing,    missing,    missing,
                    missing,    missing,    missing,
                    missing,    missing,    missing,
                    missing,    missing,    missing
                );
                */

                sw.Stop();
                Console.WriteLine("To open excel: " + sw.ElapsedMilliseconds);

                System.Collections.IEnumerator wsEnumerator = excel.ActiveWorkbook.Worksheets.GetEnumerator();

                if (!String.IsNullOrEmpty(sheetName))
                {
                    foreach (Worksheet sheet in xls.Sheets)
                    {
                        if (sheet.Name == sheetName)
                        {
                            convertAndSaveWorkSheet(sheet);
                            isSheetFound = true;
                            break;
                        }
                    }
                    if (!isSheetFound && xls.Sheets.Count > 0)
                    {
                        throw new InvalidOperationException("No such sheet found in the file");
                    }
                }
                else
                {
                    xls.SaveAs
                    (
                        destinationFileName + ".html", format, missing,
                        missing, missing, missing,
                        XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, missing,
                        missing, missing, missing
                    );
                    xls.Close(false, missing, missing);
                    Marshal.ReleaseComObject(xls);
                    xls = null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                folder = null;
                mainFileCreated = null;
                return null;
            }
            finally
            {
                Marshal.ReleaseComObject(workbooks);
                workbooks = null;
                excel.Quit();
                Marshal.ReleaseComObject(excel);
                excel = null;
                GC.Collect();
            }
            folder = destinationFileName + "_files";
            folder = folder.Replace(previewPath, "");
            folder = folder.Replace(@"\", "");
            mainFileCreated = destinationFileName + ".html";
            mainFileCreated = mainFileCreated.Replace(previewPath, "");
            return destinationFileName + ".html";
        }
        public void Dispose()
        {
            try
            {
                System.IO.Directory.Delete(destinationFileName + "_files", true);
                System.IO.File.Delete(destinationFileName + ".html");
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            
        }
        private void convertAndSaveWorkSheet(Worksheet sheet)
        {
            try
            {
                //Stopwatch sw = new Stopwatch();
                //sw.Start();

                Workbook newBook = excel.Workbooks.Add();
                sheet.Copy(newBook.Sheets[1]);

                newBook.SaveAs(
                    destinationFileName + ".html", format, missing,
                    missing, missing, missing,
                    XlSaveAsAccessMode.xlNoChange, missing, missing,
                    missing, missing, missing
                );
                newBook.Close(false, missing, missing);
                Marshal.ReleaseComObject(newBook);
                newBook = null;

                //sw.Stop();
                //Debug.WriteLine("To save excel: " + sw.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                Dispose();
            }
        }
    }
}