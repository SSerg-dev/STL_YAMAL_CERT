using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB;
using SmartQA.DB.Models.Shared;
using SmartQA.Models;
using SmartQA.Models.Shared;

namespace SmartQA.Controllers.Shared
{
    [Produces("application/json")]
    public class CommonEntityODataController<TEntity, TForm> : ODataController
        where TEntity : CommonEntity, new()
        where TForm : EntityForm<TEntity>, new ()

    {
        private DataContext Context;
        public CommonEntityODataController(DataContext context)
        {
            Context = context;
        }

        public virtual DbSet<TEntity> GetDbSet()
            => ((DbSet<TEntity>)Context.GetType().GetProperty(typeof(TEntity).Name).GetValue(Context));

        public virtual IQueryable<TEntity> GetQuery()
            => GetDbSet().AsQueryable();

        [EnableQuery]
        public IActionResult Get([FromODataUri] Guid key)
            => Ok(GetDbSet().Find(key));
        
        [EnableQuery]
        public IQueryable<TEntity> Get()
            => GetQuery();       

        public IActionResult Post([FromBody]TForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = new TEntity();
            form.Serialize(entity);

            entity.OnSave();

            GetDbSet().Add(entity);

            Context.SaveChanges();

            return Created(entity);
        }

        public IActionResult Patch([FromODataUri] Guid key, [FromBody]TForm form)
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
