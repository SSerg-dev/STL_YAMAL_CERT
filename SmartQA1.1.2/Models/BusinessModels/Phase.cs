using System;
using System.Collections.Generic;
using System.Linq;
using SmartQA1._1._2.DB.EntityFramework;
using AutoMapper;
using System.Diagnostics;

namespace SmartQA1._1._2.DB.EntityFramework
{
    public partial class Phase : IModelCanBeFilled<Phase>
    {
        public IList<Phase> fill(string searchParameter)
        {
            using (var context = new Entities())
            {
                return context.Phases
                        .OrderBy
                        (x => x.Phase_Name)
                        .ToList();
            }
        }
    }
}
 