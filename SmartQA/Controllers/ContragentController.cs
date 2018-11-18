using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using SmartQA.DB;
using SmartQA.DB.Models.People;
using System.Linq;

namespace SmartQA.Controllers
{
    [Produces("application/json")]
    public class ContragentController : ODataController
    {
        private DataContext Context;
        public ContragentController(DataContext context)
        {
            Context = context;
        }

        [EnableQuery]
        public IQueryable<Contragent> Get() => Context.Contragent
            .AsQueryable();

   
    }
}
