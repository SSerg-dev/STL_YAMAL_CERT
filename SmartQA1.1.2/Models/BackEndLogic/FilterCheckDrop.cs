using System;
using System.Linq;
using System.Linq.Dynamic;

namespace SmartQA1._1._2
{
    public class FilterCheckDrop
	{
		public Filter inputFilter { get; set; }

        public FilterCheckDrop()
        {

        }      
        public IQueryable<T> queryDecorate<T>(Filter inputFilter, IQueryable<T> inputQuery)
        {
            if (validate(inputFilter))
            {
                string colName = inputFilter.varName;

                string dynamicQuery = string.Empty;

                for(int i=0; i<inputFilter.filterParams.Count(); i++)
                {
                    if (i != 0) dynamicQuery += " or ";
                    dynamicQuery += $"{ colName } == Guid(\"{ inputFilter.filterParams[i].ToUpper() }\")";
                }
                inputQuery = string.IsNullOrEmpty(dynamicQuery) ? inputQuery : inputQuery.Where(dynamicQuery);
            }
            return inputQuery;
        }
        private bool validate(Filter inputFilter)
        {
            //this exception can fire only while debugging
            if (inputFilter.type != "checkDrop") throw new InvalidOperationException("You've tried to apply not valid type filter");

            return inputFilter.filterParams != null
                && inputFilter.filterParams.Count != 0;
        }
    }
}