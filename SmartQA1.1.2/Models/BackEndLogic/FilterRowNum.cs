using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace SmartQA1._1._2
{
    public class FilterRowNum
    {
        int param0;
        int param1;
        private Filter filterBase;

        /*This FilterRowNum requires inputFilter with 2 parameters:
		 * param0 - start RowNum
		 * param1 - added difference */
        public FilterRowNum(Filter inputFilter)
        {
            filterBase = inputFilter;
        }
        [Obsolete]
        public IQueryable<T> queryDecorate<T>(IQueryable<T> inputQuery) =>
            validateFilter() ? inputQuery.Skip(param0).Take(param1).Select(x => x) : inputQuery;
        public List<T> skipTakeToList<T>(List<T> inputList) =>
            validateFilter() ? inputList.Skip(param0).Take(param1).ToList() : new List<T>();
        public bool validateFilter()
        {
            if (filterBase.type != "rowNum") throw new InvalidOperationException("You've tried to apply not valid type filter");
            if (filterBase.filterParams == null) return false;
            if (filterBase.filterParams.Count < 2) return false;
            if (filterBase.filterParams[0] == null) return false;
            if (filterBase.filterParams[1] == null) return false;
            try
            {
                param0 = int.Parse(filterBase.filterParams[0]);
                param1 = int.Parse(filterBase.filterParams[1]);
                if (param0 < 0) return false;
                if (param1 < 0) return false;
                if (param1 > 50) param1 = 50; //you can't retrieve more than 50 lines
            }
            catch (InvalidCastException) { return false; }
            catch (FormatException) { return false; }

            return true;
        }
    }
}