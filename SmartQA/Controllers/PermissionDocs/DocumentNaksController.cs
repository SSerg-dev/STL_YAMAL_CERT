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
using SmartQA.Models;

namespace SmartQA.Controllers.PermissionDocs
{
    [Produces("application/json")]
    public class DocumentNaksController : ODataController
    {
        private DataContext Context;
        public DocumentNaksController(DataContext context)
        {
            Context = context;
        }

        [EnableQuery]
        public IQueryable<DocumentNaks> Get() => Context
            .DocumentNaks
            .AsQueryable();

        public IActionResult Post([FromBody]DocumentNaksEdit documentNaksForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var documentNaks = new DocumentNaks();

//            Context.Person.Add(employee.Person);
//            Context.Employee.Add(employee);
//            Context.SaveChanges();

            return Created(documentNaks);
        }

    }
}
