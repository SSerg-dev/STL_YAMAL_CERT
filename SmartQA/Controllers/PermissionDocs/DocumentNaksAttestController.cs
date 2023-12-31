﻿using Microsoft.AspNetCore.Mvc;
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
    public class DocumentNaksAttestController : CommonEntityODataController<DocumentNaksAttest, DocumentNaksAttestEdit>
    {
        public DocumentNaksAttestController(DataContext context, AppUserManager userManager) : base(context, userManager) { }

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

            .Include(y => y.DocumentNaksAttest_to_WeldGOST14098Set)
            .ThenInclude(z => z.WeldGOST14098)

            .Include(y => y.DocumentNaksAttest_to_JointTypeSet)
            .ThenInclude(z => z.JointType)

            .AsQueryable();
    }
}
