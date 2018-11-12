using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartQA1._1._2.DB;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace SmartQA1._1._2.DB.EntityFramework
{
	public partial class R_Structure : IModelCanBeFilled<R_Structure>
    {
        public IList<R_Structure> fill(string searchParameter)
        {
            using (var context = new Entities())
            {
                return context.R_Structure.OrderBy(x => x.Structure_Name).ToList();
            }
        }
    }
}