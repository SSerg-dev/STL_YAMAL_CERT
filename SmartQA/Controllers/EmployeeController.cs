﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Mvc.Builders.DataSources;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB;
using SmartQA.DB.Models;
using SmartQA.DB.Models.People;

namespace SmartQA.Controllers
{
    [Produces("application/json")]
    public class EmployeeController : ODataController
    {
        private DataContext Context;
        public EmployeeController(DataContext context)
        {
            Context = context;
        }

        [EnableQuery]
        public IQueryable<Employee> Get() => Context.Employee            
            .Include(e => e.Person).AsQueryable();

   
    }
}
