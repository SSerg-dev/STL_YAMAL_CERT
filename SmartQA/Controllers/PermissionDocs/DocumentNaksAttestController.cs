using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartQA.Controllers.Shared;
using SmartQA.DB;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.PermissionDocuments;
using SmartQA.Models;

namespace SmartQA.Controllers.PermissionDocs
{
    [Produces("application/json")]
    public class DocumentNaksAttestController : CommonEntityODataController<DocumentNaksAttest, DocumentNaksAttestEdit>
    {
        public DocumentNaksAttestController(DataContext context) : base(context) {}

        public override IQueryable<DocumentNaksAttest> GetQuery() => GetDbSet()            
            
            .Include(y => y.DocumentNaksAttest_to_DetailsTypeSet)
            .ThenInclude(z => z.DetailsType)
            
            .Include(y => y.DocumentNaksAttest_to_JointKindSet)
            .ThenInclude(z => z.JointKind)
            
            .Include(y => y.DocumentNaksAttest_to_SeamsTypeSet)
            .ThenInclude(z => z.SeamsType)
            
            .Include(y => y.DocumentNaksAttest_to_WeldMaterialGroupSet)
            .ThenInclude(z => z.WeldMaterialGroup)
            
            .Include(y => y.DocumentNaksAttest_to_WeldMaterialSet)
            .ThenInclude(z => z.WeldMaterial)
            
            .Include(y => y.DocumentNaksAttest_to_WeldPositionSet)
            .ThenInclude(z => z.WeldPosition)
            
            .AsQueryable();
    }
}
