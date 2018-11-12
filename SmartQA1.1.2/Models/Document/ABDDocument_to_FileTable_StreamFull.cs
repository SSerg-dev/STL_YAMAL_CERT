using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartQA1._1._2.DB.EntityFramework
{
    public partial class ABDDocument_to_FileTable_StreamFull
    {
        public string last_write_time_UINormalized { get; set; }

        public void NormalizeDate()
        {
            last_write_time_UINormalized = DateKit.convertToUIDate(last_write_time);
        }
    }
}