using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.PermissionDocuments;

namespace SmartQA.Controllers.PermissionDocs
{
    [Route("api/PremissionDocs/[controller]")]
    public class DocumentNaksController
    {
        private DataContext Context;
        public DocumentNaksController(DataContext context)
        {
            Context = context;
        }

        [EnableQuery]
        public IQueryable<DocumentNaks> Get() => Context.DocumentNaks
            .Include(e => e.Person).AsQueryable();

    }
}
