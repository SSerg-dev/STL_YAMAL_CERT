using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartQA.Auth;
using SmartQA.DB;
using SmartQA.DB.Models.People;
using SmartQA.Models;

namespace SmartQA.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class EmployeeController : ODataController
    {
        private readonly DataContext _context;
        private readonly AppUserManager _userManager;

        public EmployeeController(DataContext context, AppUserManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [EnableQuery]
        public IQueryable<Employee> Get() => _context.Set<Employee>()
            .OrderBy(x => x.Person.LastName).ThenByDescending(x => x.Person.FirstName).ThenByDescending(x => x.Person.SecondName)
            .AsQueryable();


        [EnableQuery]
        public IActionResult Get([FromODataUri] Guid key)
        {
            return Ok(_context.Set<Employee>().Single(x => x.ID == key));
        }

        public async Task<IActionResult> Post([FromBody]EmployeeEdit employeeForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = new Employee
            {
                Employee_Code = Guid.NewGuid().ToString(),                
                Person = new Person
                {
                    Person_Code = Guid.NewGuid().ToString(),                    
                 }
            };

            var user = await _userManager.Get(User);
            employeeForm.Serialize(employee);
            employee.OnSave(_context, user);
            employee.Person.OnSave(_context, user);

            _context.Set<Person>().Add(employee.Person);
            _context.Set<Employee>().Add(employee);
            _context.SaveChanges();

            return Created(employee);
        }

        public async Task<IActionResult> Put([FromODataUri] Guid key, [FromBody]EmployeeEdit employeeForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var employee = _context.Set<Employee>()
                .Include(x => x.Person)
                .Single(x => x.ID == key);
            employeeForm.Serialize(employee);

            var user = await _userManager.Get(User);
            employee.OnSave(_context, user);
            employee.Person.OnSave(_context, user);

            _context.SaveChanges();

            return Updated(employee);
        }

        public async Task<IActionResult> Patch([FromODataUri] Guid key, [FromBody]EmployeeEdit employeeForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = _context.Set<Employee>()
                .Include(x => x.Person)
                .Single(x => x.ID == key);
            employeeForm.Serialize(employee);

            var user = await _userManager.Get(User);
            employee.OnSave(_context, user);
            employee.Person.OnSave(_context, user);

            _context.SaveChanges();
            
            return Updated(employee);
        }

        public async Task<IActionResult> Delete([FromODataUri] Guid key)
        {
            var employee = _context.Set<Employee>()
                .Include(x => x.Person)
                .Single(x => x.ID == key);

            employee.MarkDeleted();
            employee.OnSave(_context, await _userManager.Get(User));

            _context.SaveChanges();

            return Ok();
        }
    }
}
