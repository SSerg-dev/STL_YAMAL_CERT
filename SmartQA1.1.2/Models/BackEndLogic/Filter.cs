using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SmartQA1._1._2
{
    public class Filter //MIRROR MODEL
    {
        //TODO - also add variable name;
        //TODO - also create dictionary of variables
        /*  This class is used just for transfering arguments that came from front-end
		    to the selectQueryFactory and binding Json to model */

        public string varName { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public List<String> options { get; set; }
        public List<String> guidList { get; set; }
        public List<String> filterParams { get; set; }

        public Filter() //default constructor for MVC model binding:
        {
        }
        //this constructor is used during creating test filter instances
        public Filter(string varName, string type)
        {
            this.varName = varName;
            this.type = type;
            this.filterParams = new List<String>();
        }
        public Filter Clone()
        {
            Filter outPutFilter = new Filter();
            outPutFilter.varName = this.varName;
            outPutFilter.name = this.name;
            outPutFilter.type = this.type;
            outPutFilter.options = this.options != null ? new List<String>(this.options) : null;
            outPutFilter.guidList = this.guidList != null ? new List<String>(this.guidList) : null;
            outPutFilter.filterParams = this.filterParams != null ? new List<String>(this.filterParams) : null;

            return outPutFilter;
        }

    }
}