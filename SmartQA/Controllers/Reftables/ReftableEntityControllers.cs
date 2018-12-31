using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartQA.Auth;
using SmartQA.DB;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.PermissionDocuments;
using SmartQA.DB.Models.Reftables;
using SmartQA.Models;

namespace SmartQA.Controllers.Reftables
{    
    public class WeldTypeController : ReftableBaseController<WeldType>
    {
        public WeldTypeController(DataContext context, AppUserManager userManager) : base(context, userManager)
        {
        }
    }

    public class HIFGroupController : ReftableBaseController<HIFGroup>
    {
        public HIFGroupController(DataContext context, AppUserManager userManager) : base(context, userManager)
        {}
    }

    public class DetailsTypeController : ReftableBaseController<DetailsType>
    {
        public DetailsTypeController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }

    public class JointKindController : ReftableBaseController<JointKind>
    {
        public JointKindController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }

    public class JointTypeController : ReftableBaseController<JointType>
    {
        public JointTypeController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }

    public class SeamsTypeController : ReftableBaseController<SeamsType>
    {
        public SeamsTypeController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }

    public class WeldGOST14098Controller : ReftableBaseController<WeldGOST14098>
    {
        public WeldGOST14098Controller(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }

    public class WeldingEquipmentAutomationLevelController : ReftableBaseController<WeldingEquipmentAutomationLevel>
    {
        public WeldingEquipmentAutomationLevelController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }

    public class WeldMaterialController : ReftableBaseController<WeldMaterial>
    {
        public WeldMaterialController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }

    public class WeldMaterialGroupController : ReftableBaseController<WeldMaterialGroup>
    {
        public WeldMaterialGroupController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }

    public class WeldPositionController : ReftableBaseController<WeldPosition>
    {
        public WeldPositionController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }
    public class TestTypeRefController : ReftableBaseController<TestTypeRef>
    {
        public TestTypeRefController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }
    public class InspectionTechniqueController : ReftableBaseController<InspectionTechnique>
    {
        public InspectionTechniqueController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }
    public class InspectionSubjectController : ReftableBaseController<InspectionSubject>
    {
        public InspectionSubjectController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }

    public class TestMethodController : ReftableBaseController<TestMethod>
    {
        public TestMethodController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }
    public class QualificationLevelController : ReftableBaseController<QualificationLevel>
    {
        public QualificationLevelController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }
    public class ResponsibilityController : ReftableBaseController<Responsibility>
    {
        public ResponsibilityController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }
    public class WeldPassesController : ReftableBaseController<WeldPasses>
    {
        public WeldPassesController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }
    public class QualificationFieldController : ReftableBaseController<QualificationField>
    {
        public QualificationFieldController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }
    public class ElectricalSafetyAbilitationController : ReftableBaseController<ElectricalSafetyAbilitation>
    {
        public ElectricalSafetyAbilitationController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }
    public class AccessToPIVoltageRangeController : ReftableBaseController<AccessToPIVoltageRange>
    {
        public AccessToPIVoltageRangeController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }
    public class AccessToPIStaffFunctionController : ReftableBaseController<AccessToPIStaffFunction>
    {
        public AccessToPIStaffFunctionController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }
    public class AuthToSignInspActsForWSUNController : ReftableBaseController<AuthToSignInspActsForWSUN>
    {
        public AuthToSignInspActsForWSUNController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }
    public class ShieldingGasController : ReftableBaseController<ShieldingGas>
    {
        public ShieldingGasController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }
    public class AttCenterNaksController : ReftableBaseController<AttCenterNaks>
    {
        public AttCenterNaksController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }    
    public class ContragentRoleController : ReftableBaseController<ContragentRole>
    {
        public ContragentRoleController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }
    public class ContragentController : ReftableBaseController<Contragent>
    {
        private DataContext _context;
        public ContragentController(DataContext context, AppUserManager userManager) : base(context, userManager)
        {
            _context = context;
        }

        [EnableQuery]
        public new IQueryable<Contragent> Get() => _context.Set<Contragent>().OrderBy(x => x.Description).AsQueryable();
    }
    public class PositionController : ReftableBaseController<Position>
    {
        public PositionController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }
    public class DivisionController : ReftableBaseController<Division>
    {
        public DivisionController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }
    public class StaffFunctionController : ReftableBaseController<StaffFunction>
    {
        public StaffFunctionController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }
    public class VoltageRangeController : ReftableBaseController<VoltageRange>
    {
        public VoltageRangeController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }
    public class LevelController : ReftableBaseController<Level>
    {
        public LevelController(DataContext context, AppUserManager userManager) : base(context, userManager)
        { }
    }

}
