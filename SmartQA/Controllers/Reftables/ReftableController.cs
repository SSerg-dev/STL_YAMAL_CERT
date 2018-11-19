using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB;
using SmartQA.Models.Forms;

namespace SmartQA.Controllers.Reftables
{
    public class ReftableController : ODataController
    {
        private DataContext Context;
        public ReftableController(DataContext context)
        {
            Context = context;
        }

        [EnableQuery]
        public IQueryable<Reftable> Get()
        {
            return Reftable.GetList().AsQueryable();
        }

    }
}
