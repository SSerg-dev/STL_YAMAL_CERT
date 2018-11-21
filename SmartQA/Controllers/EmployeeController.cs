using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB;
using SmartQA.DB.Models.People;
using SmartQA.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SmartQA.Auth;

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
        public IQueryable<Employee> Get() => _context.Employee                        
            .AsQueryable();


        [EnableQuery]
        public IActionResult Get([FromODataUri] Guid key)
        {
            return Ok(_context.Employee.Single(x => x.Employee_ID == key));
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
            employee.OnSave(user);
            employee.Person.OnSave(user);

            _context.Person.Add(employee.Person);
            _context.Employee.Add(employee);
            _context.SaveChanges();

            return Created(employee);
        }

        public async Task<IActionResult> Put([FromODataUri] Guid key, [FromBody]EmployeeEdit employeeForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var employee = _context.Employee
                .Include(x => x.Person)
                .Single(x => x.Employee_ID == key);
            employeeForm.Serialize(employee);

            var user = await _userManager.Get(User);
            employee.OnSave(user);
            employee.Person.OnSave(user);

            _context.SaveChanges();

            return Updated(employee);
        }

        public async Task<IActionResult> Patch([FromODataUri] Guid key, [FromBody]EmployeeEdit employeeForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = _context.Employee
                .Include(x => x.Person)
                .Single(x => x.Employee_ID == key);
            employeeForm.Serialize(employee);

            var user = await _userManager.Get(User);
            employee.OnSave(user);
            employee.Person.OnSave(user);

            _context.SaveChanges();
            
            return Updated(employee);
        }

        public async Task<IActionResult> Delete([FromODataUri] Guid key)
        {
            var employee = _context.Employee
                .Include(x => x.Person)
                .Single(x => x.Employee_ID == key);

            employee.MarkDeleted(await _userManager.Get(User));

            _context.SaveChanges();

            return Ok();
        }

    }
}
