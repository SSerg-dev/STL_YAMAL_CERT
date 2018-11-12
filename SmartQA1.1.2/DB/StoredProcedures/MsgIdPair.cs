using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SmartQA1._1._2.DB.StoredProcedures
{
    public class MsgIdPair : IDataSet<MsgIdPair>
    {
        public int Id { get; set; }
        public string Msg { get; set; }

        public MsgIdPair ConvertFromException(Exception ex)
        {
            return new MsgIdPair
            {
                Id = 57777, //chosen new number for inner application exceptions
                Msg = ex.Message
            };
        }
        public MsgIdPair ConvertFromErrorMessage(string errorMessage)
        {
            return new MsgIdPair
            {
                Id = 57778,
                Msg = errorMessage
            };
        }

        public override string ToString()
        {
            if (Id != null && Msg != null) return $"{Id} {Msg}";
            return null;
        }
    }

}