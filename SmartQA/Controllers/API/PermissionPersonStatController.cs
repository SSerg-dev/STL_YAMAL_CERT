using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartQA.Auth;
using SmartQA.DB;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.PermissionDocuments;
using SmartQA.Models;
using SmartQA.Models.API;

namespace SmartQA.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class PermissionPersonStatController : Controller
    {
        protected readonly AppUserManager _userManager;
        protected readonly SignInManager<ApplicationUser> _signInManager;
        protected readonly AppSettings _appSettings;
        protected readonly DataContext _context;

        public PermissionPersonStatController(DataContext context,
            AppUserManager userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }
        
        [HttpGet]
        public async Task<IActionResult> PersonNaksCount()
        {
            var result =  _context.PersonNaksCount
                .FromSql(@"
                    select NaksCount, count(*) as PersonCount from
                        (select p_Person.Person_ID, count(DocumentNaks_ID) as NaksCount
                        from p_Person
                        left join p_DocumentNaks
                        on p_Person.Person_ID = p_DocumentNaks.Person_ID
                        group by p_Person.Person_ID) p
                    group by NaksCount;
                ");

            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> NaksValidCount()
        {
            var result =  _context.NaksValidCount
                .FromSql(@"
                    select n.IsValid, count(*) as Count from
                        (select 
                            CASE WHEN p_DocumentNaks.ValidUntil < CONVERT(date, GETDATE())
                            THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT)
                            END AS IsValid
                            from p_DocumentNaks) n                        
                    group by n.IsValid;
                ");
                
            
            return new JsonResult(result);
        }
            
        
    }
}