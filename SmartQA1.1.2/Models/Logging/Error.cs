using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Web;
using SmartQA1._1._2.Exceptions;

namespace SmartQA1._1._2.Logging
{
    internal class Error
    {
        public int errorTypeId;
        public string message;
        public readonly string stackTrace;

        public Error(Exception ex)
        {
            switch (ex.InnerException ?? ex)
            {
                case DatabaseStateException dse:
                    errorTypeId = (int) ErrorTypes.ApplicationRuntimeError;
                    break;
                case SecurityException se:
                    errorTypeId = (int) ErrorTypes.SecurityError;
                    break;
                default:
                    errorTypeId = (int) ErrorTypes.ApplicationRuntimeError;
                    break;
            }

            //combine outer and inner exceptions:
            var stringBuilder = new StringBuilder();

            if (ex.InnerException != null)
            {

                stringBuilder.Append($"Outer: {ex.GetType()},");
                stringBuilder.Append($"{ex.Message},");
                stringBuilder.Append($"Data: {StringifyExceptionDataDictionary(ex)}");
                stringBuilder.Append(Environment.NewLine);

                var inEx = ex.InnerException;
                stringBuilder.Append($"Inner: {inEx.GetType()},");
                stringBuilder.Append($"{inEx.Message},");
                stringBuilder.Append($"Data: {StringifyExceptionDataDictionary(inEx)}");
                stringBuilder.Append(Environment.NewLine);
            }
            else
            {
                stringBuilder.Append($"{ex.GetType()},");
                stringBuilder.Append($"{ex.Message},");
                stringBuilder.Append($"Data: {StringifyExceptionDataDictionary(ex)}");
                stringBuilder.Append(Environment.NewLine);
            }
            stackTrace = ex.StackTrace;

            message = stringBuilder.ToString();
        }

        private string StringifyExceptionDataDictionary(Exception ex)
        {
            var userData = ex.Data;
            string stringified = String.Empty;

            //Проверяем наличие пользовательских сообщений в исключении ЛЮБОГО типа
            //и формируем мультистроку из таких сообщений, если их несколько
            if (userData.Count > 0)
            {
                stringified += String.Join(Environment.NewLine, userData.Values.OfType<String>());
            }
            else
            {
                stringified = "no data";
            }
            return stringified;
        }
    }
}