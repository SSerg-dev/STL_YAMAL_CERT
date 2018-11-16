using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Mvc.Builders.DataSources;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB;
using SmartQA.DB.Models;
using SmartQA.DB.Models.People;
using SmartQA.Models;

namespace SmartQA.Controllers
{
    [Produces("application/json")]
    public class EmployeeController : ODataController
    {
        private readonly DataContext Context;

        public EmployeeController(DataContext context)
        {
            Context = context;
        }

        [EnableQuery]
        public IQueryable<Employee> Get() => Context.Employee                        
            .AsQueryable();


        [EnableQuery]
        public IActionResult Get([FromODataUri] Guid key)
        {
            return Ok(Context.Employee.Single(x => x.Employee_ID == key));
        }

        public IActionResult Post([FromBody]EmployeeEdit employeeForm)
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
            
            employeeForm.Serialize(employee);
            employee.OnSave();
            employee.Person.OnSave();

            Context.Person.Add(employee.Person);
            Context.Employee.Add(employee);
            Context.SaveChanges();

            return Created(employee);
        }

        public IActionResult Put([FromODataUri] Guid key, [FromBody]EmployeeEdit employeeForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = Context.Employee
                .Include(x => x.Person)
                .Single(x => x.Employee_ID == key);
            employeeForm.Serialize(employee);

            employee.OnSave();
            employee.Person.OnSave();

            Context.SaveChanges();

            return Updated(employee);
        }

        public IActionResult Patch([FromODataUri] Guid key, [FromBody]EmployeeEdit employeeForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = Context.Employee
                .Include(x => x.Person)
                .Single(x => x.Employee_ID == key);
            employeeForm.Serialize(employee);

            employee.OnSave();
            employee.Person.OnSave();

            Context.SaveChanges();
            
            return Updated(employee);
        }

        public IActionResult Delete([FromODataUri] Guid key)
        {
            var employee = Context.Employee
                .Include(x => x.Person)
                .Single(x => x.Employee_ID == key);

            employee.MarkDeleted();

            Context.SaveChanges();

            return Ok();
        }

    }
}
