using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.Shared;
using SmartQA.Models;

namespace SmartQA.Controllers.Reftables
{
    public class ReftableBaseController<TModel> : ODataController where TModel : CommonEntity, IReftableEntity, new()
    {
        private DataContext Context;
        public ReftableBaseController(DataContext context)
        {
            Context = context;
        }

        [EnableQuery]
        public IQueryable<TModel> Get()
        {
            return ((DbSet<TModel>)Context.GetType().GetProperty(typeof(TModel).Name).GetValue(Context))
                .AsQueryable();
        }

        private DbSet<TModel> GetDbSet()
            => ((DbSet<TModel>)Context.GetType().GetProperty(typeof(TModel).Name).GetValue(Context));        

        public IActionResult Post([FromBody]ReftableItem form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = new TModel()
            {
                Title = form.Title,
                Description = form.Description                
            };

            item.OnSave();

            GetDbSet().Add(item);
                        
            Context.SaveChanges();

            return Created(item);
        }

        public IActionResult Delete([FromODataUri] Guid key)
        {

            var item = GetDbSet().Find(key);

            item.MarkDeleted();

            Context.SaveChanges();

            return Ok();
        }
    }
}
