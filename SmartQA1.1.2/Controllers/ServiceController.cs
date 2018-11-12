using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartQA1._1._2.DB;
using System.Data.SqlClient;
using Newtonsoft.Json;
using SmartQA1._1._2.DB.WebDb;

namespace SmartQA1._1._2.Controllers{

	/*this controller is intented to be used to execute a variaty 
	 * of different operations: validation, comparison etc*/
    public class ServiceController : Controller
    {
        public JsonResult SearchPid(Filter inputTextFilter)
        {
            var result = PID.search(inputTextFilter);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchGost(Filter inputTextFilter)
        {
            var result = GOST.search(inputTextFilter);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public Guid? FindValueInDictionary(string tableName, string columnName, string value)
        {

            return null; 

            //using (var context = new Entities())
            //{
            //    var contextDbsetProperty = (typeof (Entities)).GetProperty(tableName);
            //    var tableClassType = Type.GetType(tableName);
            //    var column = tableClassType.GetProperty(columnName);

            //    IQueryable table = (IQueryable) contextDbsetProperty.GetValue(context);

            //    var result =
            //        (
            //            from member
            //            in table
            //            select member
            //        );
            //}
        }
    }
}