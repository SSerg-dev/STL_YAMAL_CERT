using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Objects;

namespace SmartQA1._1._2
{
    public class ProcedureResult
    {
        public string Entity_ID;
        public string Entity_Name; //sometimes readable number
        public string Error_ID
        {
            set
            {
                if (value == null || value != "0")
                    isValid = false;
                else
                {
                    isValid = true;
                    error_ID = value;
                }
            }
            get
            {
                return error_ID;
            }
        }
        private string error_ID;
        public string Error_Message;
        public string Stored_Procedure_Name;
        public bool isValid;

        public ProcedureResult()
        {
            this.Error_ID = "0";
            this.Error_Message = String.Empty;
        }
        public ProcedureResult(ObjectParameter Entity_ID, ObjectParameter Entity_Number, ObjectParameter Error_ID, ObjectParameter Error_Message, String Stored_Procedure_Name)
        {
            this.Entity_ID = Entity_ID.Value.ToString();
            this.Entity_Name = Entity_Number.Value.ToString();
            this.Error_ID = Error_ID.Value.ToString();
            this.Error_Message = Error_Message.Value.ToString();
            this.Stored_Procedure_Name = Stored_Procedure_Name;
        }
        public ProcedureResult(Exception ex)
        {
            this.Entity_ID = null;
            this.Entity_Name = null;
            //Нужен какой-то другой номер ошибки, например, больше 50000.
            //До 50000 зарезервирован диапазон у SQL-сервера.
            this.Error_ID = "28";
            this.Error_Message = (ex.InnerException ?? ex).Message;
        }
        public static ProcedureResult EmptyPositiveResult()
        {
            var result = new ProcedureResult();
            result.Entity_ID = null;
            result.Entity_Name = null;
            result.Error_ID = "0";
            result.Error_ID = String.Empty;
            result.isValid = true;
            return result;
        }

    }
}