using System;
using System.Collections.Generic;
using System.Linq;
using SmartQA1._1._2.DB.EntityFramework;
using AutoMapper;
using System.Diagnostics;

namespace SmartQA1._1._2.DB.EntityFramework
{
    public partial class ProcessPhase : IModelCanBeFilled<ProcessPhase>
    {
        public IList<ProcessPhase> fill(string searchParameter)
        {
            using (var context = new Entities())
            {
                return context.ProcessPhases.OrderBy(x => x.ProcessPhase_Name).ToList();
            }
        }
    }
}