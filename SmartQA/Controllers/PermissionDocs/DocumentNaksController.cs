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
            .Include(x => x.DocumentNaks_to_HIFGroupSet)
            .Include(x => x.WeldType)
            .AsQueryable();

        public IActionResult Post([FromBody]DocumentNaksEdit documentNaksForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var documentNaks = new DocumentNaks();
            documentNaksForm.Serialize(Context, documentNaks);
            documentNaks.OnSave();

            Context.DocumentNaks.Add(documentNaks);
            Context.SaveChanges();

            return Created(documentNaks);
        }    

        public IActionResult Patch([FromODataUri] Guid key, [FromBody]DocumentNaksEdit documentNaksForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var documentNaks = Context.DocumentNaks.Find(key);
            documentNaksForm.Serialize(Context, documentNaks);

            documentNaks.OnSave();            

            Context.SaveChanges();

            return Updated(documentNaks);
        }

    }
}
