using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartQA1._1._2.DB;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace SmartQA1._1._2
{
	//CLASS
	public class ABDFinalFolderList
	{
        public Guid ABDFinalFolder_ID { get; set; }
        public string ABDFinalFolder_Name { get; set; }

        public object getABDFinalFolderListBySet(string searchParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = QueryBank.ABDFinalFolderListBySet;
            myCommand.Parameters.AddWithValue("@searchParameter", searchParameter);
            var Rt = Repository.createRepository("nonsense");
            return Rt.fillModelTyped(new ABDFinalFolderList(), myCommand);
        }
	}
	//CLASS 
	public class ABDFinalFolder
	{
		public Guid ABDFinalFolder_ID { get; set; } 
        public string ABDFinalFolder_Name { get; set; } 
        public Guid ABDStatus_ID { get; set; } 
        public string Status_Eng { get; set; } 
        public string Status_Rus { get; set; } 
        public Guid SubContractor_Id { get; set; } 
        public string SubContractor_Name { get; set; } 
        public string CTR_RESP { get; set; }
        public string Transmittal_Code { get; set; }
        public int ListCount { get; set; }
        public string TitleObject_Name { get; set; }
        public string Marka_Name { get; set; }
        public int ReportOrder { get; set; }


        public DateTime Final_Compilation_Start_Date
        {
            get
            {
                return final_Compilation_Start_Date;
            }
            set
            {
                final_Compilation_Start_Date = value;
                Norm_Final_Compilation_Start_Date = DateKit.convertToUIDate(this.Final_Compilation_Start_Date);
            }
        }
        public DateTime Final_Compilation_Target_Date
        {
            get
            {
                return final_Compilation_Target_Date;
            }
            set
            {
                final_Compilation_Target_Date = value;
                Norm_Final_Compilation_Target_Date = DateKit.convertToUIDate(this.Final_Compilation_Target_Date);
            }
        }
        private DateTime final_Compilation_Start_Date;
        private DateTime final_Compilation_Target_Date;
        private string transmittal_Code;
        public string Norm_Final_Compilation_Start_Date;
		public string Norm_Final_Compilation_Target_Date;

	}
}
