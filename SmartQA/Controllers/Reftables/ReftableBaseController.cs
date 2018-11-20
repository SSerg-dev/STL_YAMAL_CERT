using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.Shared;
using SmartQA.Models;

namespace SmartQA.Controllers.Reftables
{
    [Authorize]
    [Produces("application/json")]
    public class ReftableBaseController<TEntity> : ODataController where TEntity : CommonEntity, IReftableEntity, new()
    {
        private DataContext Context;
        public ReftableBaseController(DataContext context)
        {
            Context = context;
        }

        public virtual DbSet<TEntity> GetDbSet()
            => ((DbSet<TEntity>)Context.GetType().GetProperty(typeof(TEntity).Name).GetValue(Context));

        public virtual IQueryable<TEntity> GetQuery()
            => GetDbSet()
                .OrderBy(x => x.Title)
                .AsQueryable();

        [EnableQuery]
        public IActionResult Get([FromODataUri] Guid key)
            => Ok(GetDbSet().Find(key));

        [EnableQuery]
        public IQueryable<TEntity> Get()
            => GetQuery();

        public IActionResult Post([FromBody]ReftableItem form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = new TEntity()
            {
                Title = form.Title,
                Description = form.Description                
            };

            item.OnSave();

            GetDbSet().Add(item);
                        
            Context.SaveChanges();

            return Created(item);
        }


        public IActionResult Patch([FromODataUri] Guid key, [FromBody]ReftableItem form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = GetDbSet().Find(key);
            form.Serialize(entity);

            entity.OnSave();

            Context.SaveChanges();

            return Updated(entity);
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
