using System;
using System.Linq;
using System.Linq.Dynamic;
using SmartQA1._1._2.Service;
using System.Runtime.ExceptionServices;
using SmartQA1._1._2.Logging;

namespace SmartQA1._1._2
{
    public class FilterOrderBy
    {
        private Filter filterBase;

        //used to switch the direction of sorting 
        bool isAscendingOrder = true;

        public FilterOrderBy(Filter inputFilter)
        {
            filterBase = inputFilter;
        }
        public IQueryable<T> queryDecorate<T>(IQueryable<T> inputQuery) where T : class
        {
            if (validate())
            {

                //throws System.Linq.Dynamic.ParseException in case of not valid columnName
                return isAscendingOrder
                    ? inputQuery.OrderBy(filterBase.varName)
                    : inputQuery.OrderBy($"{ filterBase.varName } DESC");
            }
            else return inputQuery;
        }
        private bool validate()
        {
            if (filterBase == null) return false;
            if (filterBase.type != "orderBy") throw new InvalidOperationException("Not valid type filter was applied to the orderBy fitler");

            try
            {
                isAscendingOrder = bool.Parse(filterBase.filterParams[0]);
                
            }
            catch (InvalidCastException icex)
            {
                //somebody tried to inject:
                icex.Data.Add("UserOrderByFilterParamConvert", "OrderByFilter isASC order parameter.");
                new Logger(icex).Log();
                throw;
            }
            return true;
        }
    }
}