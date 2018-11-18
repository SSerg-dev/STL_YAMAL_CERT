using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using SmartQA.DB;
using System.Linq;
using Position = SmartQA.DB.Models.People.Position;

namespace SmartQA.Controllers
{
    [Produces("application/json")]
    public class PositionController : ODataController
    {
        private DataContext Context;
        public PositionController(DataContext context)
        {
            Context = context;
        }

        [EnableQuery]
        public IQueryable<Position> Get() => Context.Position
            .AsQueryable();

   
    }
}
