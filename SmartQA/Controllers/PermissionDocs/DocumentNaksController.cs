using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartQA.Auth;
using SmartQA.Controllers.Shared;
using SmartQA.DB;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.PermissionDocuments;
using SmartQA.Models;

namespace SmartQA.Controllers.PermissionDocs
{
    [Produces("application/json")]
    public class DocumentNaksController : CommonEntityODataController<DocumentNaks, DocumentNaksEdit>
    {
        
        public DocumentNaksController(DataContext context, AppUserManager userManager) : base(context, userManager) { }
      
        public override IQueryable<DocumentNaks> GetQuery() => GetDbSet()            
            .Include(x => x.DocumentNaks_to_HIFGroupSet)
            
            .Include(x => x.DocumentNaksAttestSet)
            .ThenInclude(y => y.DocumentNaksAttest_to_DetailsTypeSet)
            .ThenInclude(z => z.DetailsType)

            .Include(x => x.DocumentNaksAttestSet)
            .ThenInclude(y => y.DocumentNaksAttest_to_JointKindSet)
            .ThenInclude(z => z.JointKind)
            
            .Include(x => x.DocumentNaksAttestSet)
            .ThenInclude(y => y.DocumentNaksAttest_to_SeamsTypeSet)
            .ThenInclude(z => z.SeamsType)

            .Include(x => x.DocumentNaksAttestSet)
            .ThenInclude(y => y.DocumentNaksAttest_to_WeldMaterialGroupSet)
            .ThenInclude(z => z.WeldMaterialGroup)

            .Include(x => x.DocumentNaksAttestSet)
            .ThenInclude(y => y.DocumentNaksAttest_to_WeldMaterialSet)
            .ThenInclude(z => z.WeldMaterial)

            .Include(x => x.DocumentNaksAttestSet)
            .ThenInclude(y => y.DocumentNaksAttest_to_WeldPositionSet)
            .ThenInclude(z => z.WeldPosition)

            .Include(x => x.WeldType)
            .AsQueryable();
      
    }
}
