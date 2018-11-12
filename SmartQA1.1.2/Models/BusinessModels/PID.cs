using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;

namespace SmartQA1._1._2.DB.WebDb
{
    public partial class PID : IModelCanBeFilled<PID>
    {
        public IList<PID> fill(string searchParameter)
        {
            using (var context = new WEB_MainDataEntities())
            {
                var _temp = context.PIDs.OrderBy(x => x.PID_Code).ToList();
                return _temp;
            }
        }
        public static List<PID> search(Filter textFilter)
        {
            if (textFilter.filterParams != null)
            {
                textFilter.varName = "PID_Code";
                List<Filter> inputFilters = new List<Filter>() { textFilter };

                using (var context = new WEB_MainDataEntities())
                {
                    var query = context.PIDs.OrderBy(x => x.PID_Code);
                    QueryFactory queryFactory = new QueryFactory(inputFilters);

                    var result = (queryFactory.concatenateFilters(query)).ToList();

                    var maximumResultNumber =
                        short.Parse(WebConfigurationManager.AppSettings["MaximumServiceSearchResult"]);

                    if (result != null && result.Count > maximumResultNumber)
                    {
                        PID tooBigResult = new PID();
                        tooBigResult.PID_ID = Guid.Empty;
                        return new List<PID>() { tooBigResult };
                    }
                    else return result;
                }
            }
            else return null;
        }
    }
}