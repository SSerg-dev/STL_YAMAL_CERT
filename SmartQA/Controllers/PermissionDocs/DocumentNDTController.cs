using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartQA.Auth;
using SmartQA.Controllers.Shared;
using SmartQA.DB;
using SmartQA.DB.Models.PermissionDocuments;
using SmartQA.Models;
using System.Linq;

namespace SmartQA.Controllers.PermissionDocs
{
    [Produces("application/json")]
    public class DocumentNDTController : CommonEntityODataController<DocumentNDT, DocumentNDTEdit>
    {

        public DocumentNDTController(DataContext context, AppUserManager userManager) : base(context, userManager) { }
        public override IQueryable<DocumentNDT> GetQuery() => GetDbSet()            

            .Include(x => x.DocumentNDTITSet)
            .ThenInclude(y => y.DocumentNDTIT_to_InspectionSubjectSet)
            .ThenInclude(z => z.InspectionSubject)
            
            .AsQueryable();
    }
}
