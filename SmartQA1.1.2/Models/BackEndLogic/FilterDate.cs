using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace SmartQA1._1._2
{
    public class FilterDate
    {
        //TODO - implement non-casesensitive string comparison while searching up in the dictionary
        public bool Applied { get; private set; } = false;
        public FilterDate()
        {
        }
        public IQueryable<T> queryDecorate<T>(Filter inputFilter, IQueryable<T> inputQuery)
        {
            if (validate(inputFilter))
            {                
                Applied = true;
                var dateStart = $"{DateKit.String2DateTime(inputFilter.filterParams[1]):yyyy, MM, dd}";
                switch (short.Parse(inputFilter.filterParams[0]))
                {
                    case 0:
                        return string.IsNullOrWhiteSpace(inputFilter.filterParams[1]) ?
                            inputQuery.Where($"{ inputFilter.varName } = null") : inputQuery.Where
                            ($"{ inputFilter.varName } = null or { inputFilter.varName } <= DateTime({ dateStart })");
                    case 1:
                        return string.IsNullOrWhiteSpace(inputFilter.filterParams[1]) ? inputQuery
                            : inputQuery.Where($"{ inputFilter.varName } >= DateTime({ dateStart })");
                    case 2:
                        return string.IsNullOrWhiteSpace(inputFilter.filterParams[1]) ?
                            inputQuery.Where($"{ inputFilter.varName } = null")
                            : inputQuery.Where($"{ inputFilter.varName } = DateTime({ dateStart })");
                    case 3:
                        if (inputFilter.filterParams.Count > 2 && inputFilter.filterParams[2] != null)
                        return inputQuery.Where($"{ inputFilter.varName } >= DateTime({ dateStart })").Where
                        ($"{ inputFilter.varName } <= DateTime({DateKit.String2DateTime(inputFilter.filterParams[2]):yyyy, MM, dd})");
                        break;
                }
            }
            return inputQuery;
        }
        private bool validate(Filter filterToValidate)
        {
            //this function can occur when the methods of object-caller are invalid
            if (filterToValidate.type != "date")
                throw new InvalidOperationException("You've tried to apply not valid type filter");
            if (filterToValidate.filterParams?.Count == null || filterToValidate.filterParams.Count <= 1 ||
                filterToValidate.filterParams[0] == null || filterToValidate.filterParams[1] == null)
                return false;
            if (short.Parse(filterToValidate.filterParams[0]) != 3)
                return string.IsNullOrWhiteSpace(filterToValidate.filterParams[1]) ||
                    DateKit.DateTime2Sql(DateKit.String2DateTime(filterToValidate.filterParams[1])) != null;
            else if (filterToValidate.filterParams.Count > 2 && filterToValidate.filterParams[2] != null)
                return DateKit.DateTime2Sql(DateKit.String2DateTime(filterToValidate.filterParams[1]),
                    DateKit.String2DateTime(filterToValidate.filterParams[2])) != null;
            return false;
        }
    }
}