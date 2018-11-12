using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartQA1._1._2.DB.EntityFramework
{
    public partial class DesignAreaType : IModelCanBeFilled<DesignAreaType>
    {
        public IList<DesignAreaType> fill(string searchParameter)
        {
            using (var context = new Entities())
            {
                return context.DesignAreaTypes.OrderBy(x => x.DesignAreaType_Name).ToList();
            }
        }
    }
}