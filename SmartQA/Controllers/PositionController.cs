using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Mvc.Builders.DataSources;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB;
using SmartQA.DB.Models;
using SmartQA.DB.Models.People;
using Position = SmartQA.DB.Models.People.Position;

namespace SmartQA.Controllers
{
    [Produces("application/json")]
    public class PositionController : ODataController
    {
        private DataContext Context;
        public PositionController(DataContext context)
        {
            Context = context;
        }

        [EnableQuery]
        public IQueryable<Position> Get() => Context.Position
            .AsQueryable();

   
    }
}
