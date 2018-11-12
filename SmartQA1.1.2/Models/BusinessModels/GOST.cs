using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;

namespace SmartQA1._1._2.DB.WebDb
{
    public partial class GOST : IModelCanBeFilled<GOST>
	{
        public IList<GOST> fill(string searchParameter)
        {
            using (var context = new WEB_MainDataEntities())
            {
                var result = context.GOSTs.OrderBy(x => x.GOST_Code).ToList();
                return result;
            }
        }
        public static List<GOST> search(Filter textFilter)
        {
            if (textFilter.filterParams != null)
            {
                textFilter.varName = "GOST_Code";
                List<Filter> inputFilters = new List<Filter>() { textFilter };

                using (var context = new WEB_MainDataEntities())
                {
                    var query = context.GOSTs.OrderBy(x => x.GOST_Code);
                    QueryFactory queryFactory = new QueryFactory(inputFilters);

                    var result = (queryFactory.concatenateFilters(query)).ToList();

                    var maximumResultNumber =
                        short.Parse(WebConfigurationManager.AppSettings["MaximumServiceSearchResult"]);

                    if (result != null && result.Count > maximumResultNumber)
                    {

                        GOST tooBigResult = new GOST { GOST_ID = Guid.Empty };
                        return new List<GOST> { tooBigResult };
                    }
                    else return result;
                }
            }
            else return null;
        }
    }
}