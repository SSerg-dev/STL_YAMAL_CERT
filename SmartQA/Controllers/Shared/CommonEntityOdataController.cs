using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartQA.Auth;
using SmartQA.DB;
using SmartQA.DB.Models.Shared;
using SmartQA.Models.Shared;

namespace SmartQA.Controllers.Shared
{
    [Authorize]
    [Produces("application/json")]    
    public class CommonEntityODataController<TEntity, TForm> : ODataController
        where TEntity : CommonEntity, new()
        where TForm : EntityForm<TEntity>, new ()

    {
        protected readonly DataContext _context;
        protected readonly AppUserManager _userManager;

        public CommonEntityODataController(DataContext context, AppUserManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public virtual DbSet<TEntity> GetDbSet()
            => _context.Set<TEntity>();
        
        public virtual IQueryable<TEntity> GetQuery()
            => GetDbSet().AsQueryable();

        public virtual async Task<IActionResult> Get([FromODataUri] Guid key)
        {
            var entity = await GetDbSet().FindAsync(key);
            return Ok(entity);
        }

        [EnableQuery]
        public virtual IQueryable<TEntity> Get()
            => GetQuery();       

        public virtual async Task<IActionResult> Post([FromBody]TForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = new TEntity();
            form.Serialize(entity);

            entity.OnSave(_context, await _userManager.Get(this.User));

            GetDbSet().Add(entity);

            await _context.SaveChangesAsync();

            return Created(entity);
        }

        public virtual async Task<IActionResult> Patch([FromODataUri] Guid key, [FromBody]TForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = GetDbSet().Find(key);
            form.Serialize(entity);

            entity.OnSave(_context, await _userManager.Get(this.User));

            await _context.SaveChangesAsync();

            return Updated(entity);
        }

        public virtual async Task<IActionResult> Delete([FromODataUri] Guid key)
        {

            var item = GetDbSet().Find(key);

            item.MarkDeleted();
            item.OnSave(_context, await _userManager.Get(this.User));

            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
