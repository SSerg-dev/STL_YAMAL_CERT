using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Newtonsoft.Json;
using SmartQA1._1._2.DB.EntityFramework;
using System.Data.Entity;
using System.Diagnostics;
using System.Security;
using SmartQA1._1._2.Logging;
using SmartQA1._1._2.Service;

namespace SmartQA1._1._2
{
    public class QueryFactory
    {
        public bool isFiltersApplied { get; private set; } = false;
        Dictionary<string, int> filterDict;
        private List<Filter> filters;
        private FilterRowNum rowNumFilter;
        private FilterOrderBy orderByFilter;
        private FilterFileContent fileContentFilter;

        public QueryFactory()
        {
            createFilterTypeDictionary();
        }
        public QueryFactory(List<Filter> inputFilters)
        {
            createFilterTypeDictionary();
            filters = inputFilters;

            //removing rowNum filter so it won't be applied in concatenateFitlers method - apply it in another method
            Filter _rowNum = filters.FirstOrDefault(x => x.type == "rowNum");
            if (_rowNum != null)
            {
                rowNumFilter = new FilterRowNum(_rowNum);
                if (!rowNumFilter.validateFilter()) throw new InvalidOperationException("You've tried to apply not valid RowNum filter");
                else inputFilters.Remove(_rowNum);
            }

            //creating new instance of OrderByFilter
            Filter _orderBy = inputFilters.FirstOrDefault(x => x.type == "orderBy");
            if (_orderBy != null)
            {
                orderByFilter = new FilterOrderBy(_orderBy);
            }
        }
        public QueryFactory(List<Filter> inputFilters, DbContext context) : this(inputFilters)
        {
            //removing fileContent filter so it won't be applied in concatenateFilters method
            Filter _fileContent = inputFilters.FirstOrDefault(x => x.type == "fileContent");
            fileContentFilter = new FilterFileContent(_fileContent, context);
            if (_fileContent != null) inputFilters.Remove(_fileContent);
        }
        public List<T> ApplyRowNumFilter<T>(List<T> inputList)
        {
            return rowNumFilter.skipTakeToList(inputList).ToList();
        }
        public List<T> ApplyOrderByFilter<T>(List<T> queryable) where T: class
        {
            if (orderByFilter != null)
                return orderByFilter.queryDecorate(queryable.AsQueryable()).ToList();
            else
                return queryable.ToList();
        }
        public List<Guid> ApplyFileContentFilter(List<Guid> inputGuids)
        {
            return fileContentFilter.GetFileList(inputGuids, isFiltersApplied);
        }
        //THIS METHOD IS TO BECOME DEPRECATED AFTER REFACTORING
        public IQueryable<T> concatenateFilters<T>(IQueryable<T> inputSet) where T:class
        {
            IQueryable<T> outPut = inputSet;
            if (filters != null && filters.Count != 0)
                foreach (var filter in filters)
                {
                    try
                    {
                        if (filter != null && filter.type != null)
                        {
                            if (filterDict.ContainsKey(filter.type))
                            {
                                switch (filterDict[filter.type])
                                {
                                    case 0:
                                        FilterText fText = new FilterText();
                                        outPut = fText.queryDecorate<T>(filter, outPut);
                                        isFiltersApplied |= fText.Applied;
                                        break;
                                    case 1:
                                        outPut = (new FilterCheckDrop()).queryDecorate<T>(filter, outPut);
                                        break;
                                    case 2:
                                        FilterDate fDate = new FilterDate();
                                        outPut = fDate.queryDecorate<T>(filter, outPut);
                                        isFiltersApplied |= fDate.Applied;
                                        break;
                                    case 3: //RowNum
                                        Debug.WriteLine("RowNum filter hasn't been removed");
                                        break;
                                    case 4: //OrderBy
                                        outPut = (new FilterOrderBy(filter)).queryDecorate(outPut);
                                        break;
                                    case 5: //Title
                                        break;
                                    case 6: //Drop
                                        throw new NotImplementedException("Filter type Drop is not created");
                                    case 7: //FileContent
                                        Debug.WriteLine("File content filter hasn't been removed");
                                        break;
                                }
                            }
                            else
                            {
                                var ex = new SecurityException("Not valid filterType was applied. Filter type: "+filter.type);
                                throw ex;
                            }
                        }
                    }
                    //in case there're no corresponding columns - somebody is trying to inject
                    catch (System.Linq.Dynamic.ParseException linqParseException)
                    {
                        var ex = new SecurityException(
                            "Not valid filter parameters applied. Filter object: "
                            + JsonConvert.SerializeObject(filter),
                            linqParseException);
                        throw ex;
                    }
                }
            return outPut;
        }
        private void createFilterTypeDictionary()
        {
            filterDict = new Dictionary<string, int>();
            /*every filter has to be registered in this dictionary:
                 * also this list have to be consistant in proper FilterLine React component*/
            filterDict.Add("text", 0);
            filterDict.Add("checkDrop", 1);
            filterDict.Add("date", 2);
            filterDict.Add("rowNum", 3);
            filterDict.Add("orderBy", 4);
            filterDict.Add("title", 5);
            filterDict.Add("drop", 6);
            filterDict.Add("fileContent", 7);
        }
    }
}