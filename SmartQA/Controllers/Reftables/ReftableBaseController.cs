using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartQA.Auth;
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
        private readonly DataContext _context;
        private readonly AppUserManager _userManager;

        public ReftableBaseController(DataContext context, AppUserManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public virtual DbSet<TEntity> GetDbSet()
            => ((DbSet<TEntity>)_context.GetType().GetProperty(typeof(TEntity).Name).GetValue(_context));

        public virtual IQueryable<TEntity> GetQuery()
            => GetDbSet()
                .OrderBy(x => x.Title)
                .AsQueryable();

        public async Task<IActionResult> Get([FromODataUri] Guid key)
        {
            var entity = await GetDbSet().FindAsync(key);
            return Ok(entity);
        }

        [EnableQuery]
        public IQueryable<TEntity> Get()
            => GetQuery();

        public async Task<IActionResult> Post([FromBody]ReftableItem form)
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

            item.OnSave(await _userManager.Get(User));

            GetDbSet().Add(item);
                        
            await _context.SaveChangesAsync();

            return Created(item);
        }


        public async Task<IActionResult> Patch([FromODataUri] Guid key, [FromBody]ReftableItem form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = GetDbSet().Find(key);
            form.Serialize(entity);

            entity.OnSave(await _userManager.Get(User));

            await _context.SaveChangesAsync();

            return Updated(entity);
        }


        public async Task<IActionResult> Delete([FromODataUri] Guid key)
        {

            var item = GetDbSet().Find(key);

            item.MarkDeleted();
            item.OnSave(await _userManager.Get(User));

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
