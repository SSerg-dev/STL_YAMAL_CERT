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
	public partial class p_Contragent : IModelCanBeFilled<p_Contragent>
    {
        public IList<p_Contragent> fill(string searchParameter)
        {
            using (var context = new Entities())
            {
                return context.p_Contragent.OrderBy(x => x.Code).ToList();
            }
        }
        /*is this method deprecated???  - It's used inside ABDFinalFolder - 
         * but now don't write any test because there's hight probability of changin this class in future
         */
        public object getContragetByABDFinalFolderId(string ABDFinalFolderID)
        {
            using (var context = new Entities())
            {
                var guid = Guid.Parse(ABDFinalFolderID);
                var result = context.p_ABDFinalFolder_to_Contragent.Where(x => x.ABDFinalFolder_ID == guid)
                    .Select(x =>
                        context.p_Contragent.Where(y => y.Contragent_ID == x.Contragent_ID).ToList())
                        .ToList();
                return result.FirstOrDefault();
            }
        }
    }
}