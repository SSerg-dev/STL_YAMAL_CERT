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
    public class ABDFinalSetList
    {
        public Guid ABDFinalSet_ID { get; set; }
        public string ABDFinalSet_Number { get; set; }

        private Repository Rt = Repository.createRepository("nonsense");
        private SqlCommand myCommand = new SqlCommand();

        public object fill(string searchParameter)
        {
            myCommand.CommandText = QueryBank.ABDFinalSetGetList;
            return Rt.fillModelTyped(new ABDFinalSetList(), myCommand);
		}
        public object getABDFinalSetByFolder(string ABDFinalFolderID)
        {
            myCommand.CommandText = QueryBank.ABDFinalSetGetSetByFolder;
            myCommand.Parameters.AddWithValue("@searchParameter", ABDFinalFolderID);
            return Rt.fillModelTyped(new ABDFinalSetList(), myCommand);
        }
    }
    public class ABDFinalSet
    {
		public Guid ABDFinalSet_ID { get; set; }
        public string ABDFinalSet_Number { get; set; }
        public Guid TitleObject_ID { get; set; }
        public string TitleObject_Name { get; set; }
        public string TitleDescriptionRus { get; set; }
        public string TitleReportColor { get; set; }
        public Guid Marka_ID { get; set; }
        public string Marka_Name { get; set; }
        public string MarkaDescriptionRus { get; set; }
        public string MarkaReportColor { get; set; }

        private Repository Rt = Repository.createRepository("nonsense");
        private SqlCommand myCommand = new SqlCommand();

        public object getABDFinalSetHeadBySetId(string ABDFinalFolder_ID)
		{
			SqlCommand myCommand = new SqlCommand();
			myCommand.CommandText = QueryBank.ABDFinalSetGetSetHead;
            myCommand.Parameters.AddWithValue("@searchParameter", ABDFinalFolder_ID);
            return Rt.fillModelTyped(new ABDFinalSet(), myCommand);
		}
	}
}