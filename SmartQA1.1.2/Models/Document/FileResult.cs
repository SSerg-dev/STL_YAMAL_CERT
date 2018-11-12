using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartQA1._1._2.Models.ABDDocument
{
    public class FileResult
    {
        public bool isValid { get; private set; }
        public string message { get; private set; }

        public FileResult()
        {
            isValid = true;
        }
        public FileResult(Exception ex)
        {
            isValid = false;
            message = ex.ToString();
        }
    }
}