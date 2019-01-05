using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartQA.Auth;
using SmartQA.Controllers.Shared;
using SmartQA.DB;
using SmartQA.DB.Models.Auth;
using SmartQA.Models;

namespace SmartQA.Controllers
{
    //[Authorize(Roles="Administrator")]
    public class AppUserController: CommonEntityODataController<AppUser, AppUserEdit>
    {
        public AppUserController(DataContext context, AppUserManager userManager) : base(context, userManager)
        {
        }

        public override IQueryable<AppUser> GetQuery()
            => GetDbSet()
                .Include(u => u.Employee)
                .ThenInclude(e => e.Person)
                .Include(u => u.AppUser_to_RoleSet)                
                .ThenInclude(ur => ur.Role)
                .AsQueryable();              
        
    }
}