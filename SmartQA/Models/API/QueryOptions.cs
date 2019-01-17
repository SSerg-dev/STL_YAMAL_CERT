using System.Collections;
using System.Collections.Generic;

namespace SmartQA.Models.API
{
    public class QueryOptions
    {
        public IList filter { get; set; }
        public int? skip { get; set; }
        public int? take { get; set; }
        public bool? requireTotalCount { get; set; }
    }
}