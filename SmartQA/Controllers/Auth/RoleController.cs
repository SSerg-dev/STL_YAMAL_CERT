using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartQA.Auth;
using SmartQA.DB;
using DBRole =  SmartQA.DB.Models.Auth.Role;

namespace SmartQA.Controllers
{
    [Authorize]
    public class RoleController: ODataController
    {        
        private readonly DataContext _context;
        private readonly AppUserManager _userManager;

        public RoleController(DataContext context, AppUserManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [EnableQuery]
        public SingleResult<DBRole> Get([FromODataUri] Guid key)
        {
            return SingleResult.Create(_context.Set<DBRole>().Where(x => x.ID == key));            
        }

        [EnableQuery]
        public IQueryable<DBRole> Get()
            => _context.Set<DBRole>().AsQueryable();

    }
}