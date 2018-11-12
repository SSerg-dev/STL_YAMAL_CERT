using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using SmartQA1._1._2.DB.EntityFramework;
using Newtonsoft.Json;

namespace SmartQA1._1._2
{
    public class FilterFileContent
    {
        private Filter filterBase;
        FileStorageEntities fileContext;

        //Output-параметры для хранимой процедуры поиска по содержимому файла
        ObjectParameter foundList;
        ObjectParameter o_IsError;

        public FilterFileContent(Filter inputFilter, DbContext context)
        {
            filterBase = inputFilter;

            //implemented only for one type of the context
            if (context is FileStorageEntities)
            {
                fileContext = context as FileStorageEntities;
            }
            else throw new InvalidCastException("FileContent is not implemented for that type of DbContext");
        }
        public List<Guid> GetFileList(List<Guid> inputGuids, bool isFiltersApplied)
        {
            if (validate())
            {
                var serializedGuidList = isFiltersApplied ?
                                JsonConvert.SerializeObject(inputGuids.Select(x => new { stream_id = x }))
                                : string.Empty;

                //implemented only for one type of the context
                if (fileContext != null)
                {
                    foundList = new ObjectParameter("foundList", typeof(String));
                    o_IsError = new ObjectParameter("o_IsError", typeof(Boolean));

                    var result = fileContext.SearchInFiles
                            (
                                serializedGuidList,
                                filterBase.filterParams[0],
                                foundList,
                                o_IsError
                            )
                            .ToList();

                    //return empty list in case of error
                    if ((bool)o_IsError.Value) return new List<Guid>();

                    //return empty list in case no files were found
                    string JsonStreamIds = foundList.Value.ToString();
                    if (String.IsNullOrEmpty(JsonStreamIds)) return new List<Guid>();

                    return
                        JsonConvert.DeserializeAnonymousType
                            (
                                JsonStreamIds,
                                new List<Guid>().Select(x => new { stream_id = x })
                            )
                        .Select(x => x.stream_id)
                        .ToList();
                }
                else return null;
            }
            else return inputGuids;
        }
        public bool validate()
        {
            if (filterBase == null) return false;
            if (filterBase.filterParams == null) return false;
            if (filterBase.filterParams.Count == 0) return false;
            if (String.IsNullOrWhiteSpace(filterBase.filterParams[0])) return false;
            return true;
        }
    }
}