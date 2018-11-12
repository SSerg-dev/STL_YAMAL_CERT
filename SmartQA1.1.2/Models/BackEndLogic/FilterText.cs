using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic;

namespace SmartQA1._1._2
{
    public class FilterText
    {
        public bool Applied { get; private set; } = false;
        public FilterText()
        {
        }
        public IQueryable<T> queryDecorate<T>(Filter inputFilter, IQueryable<T> inputQuery)
        {
            if (inputFilter.type != "text") throw new InvalidOperationException("You've tried to apply not valid type filter");

            if (validate(inputFilter))
            {
                Applied = inputFilter.filterParams[1] == string.Empty ? false : true;
                Debug.WriteLine($"Col: { inputFilter.varName }");
                switch (short.Parse(inputFilter.filterParams[0]))
                {
                    case 0: return inputQuery.Where($"{inputFilter.varName}.Contains(\"{inputFilter.filterParams[1]}\")");
                    case 1: return inputQuery.Where($"!{inputFilter.varName}.Contains(\"{inputFilter.filterParams[1]}\")");
                    case 2: return inputQuery.Where($"{inputFilter.varName}=\"{inputFilter.filterParams[1]}\"");
                    case 3: return inputQuery.Where($"!{inputFilter.varName}=\"{inputFilter.filterParams[1]}\"");
                    default: return inputQuery;
                }
            }
            return inputQuery;
        }
        private bool validate(Filter filterToValidate)
        {
            //this function can occur when the methods of object-caller are invalid
            if (filterToValidate.type != "text") throw new InvalidOperationException("You've tried to apply not valid type filter");            

            return (
                filterToValidate.filterParams != null
                && filterToValidate.filterParams.Count > 1
                && filterToValidate.filterParams[0] != null
                && filterToValidate.filterParams[1] !=null
            );
        }
	}
}