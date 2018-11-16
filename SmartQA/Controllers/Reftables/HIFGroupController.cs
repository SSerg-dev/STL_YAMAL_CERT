using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartQA.DB;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.PermissionDocuments;
using SmartQA.DB.Models.Reftables;
using SmartQA.Models;

namespace SmartQA.Controllers.Reftables
{
    [Produces("application/json")]
    public class HIFGroupController : ReftableBaseController<HIFGroup>
    {
        public HIFGroupController(DataContext context) : base(context)
        {}
    }
}
