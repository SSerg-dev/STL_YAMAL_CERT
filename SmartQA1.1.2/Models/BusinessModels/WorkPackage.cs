using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartQA1._1._2.DB.WebDb
{
    public partial class WorkPackage : IModelCanBeFilled<WorkPackage>
    {
        public IList<WorkPackage> fill(string searchParameter = null)
        {
            using (var context = new WEB_MainDataEntities())
            {
                return context.WorkPackages.OrderBy(x => x.WorkPackage_Code).ToList();
            }
        }
    }
}