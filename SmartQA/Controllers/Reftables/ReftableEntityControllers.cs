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
    public class WeldTypeController : ReftableBaseController<WeldType>
    {
        public WeldTypeController(DataContext context) : base(context)
        { }
    }

    public class HIFGroupController : ReftableBaseController<HIFGroup>
    {
        public HIFGroupController(DataContext context) : base(context)
        {}
    }

    public class DetailsTypeController : ReftableBaseController<DetailsType>
    {
        public DetailsTypeController(DataContext context) : base(context)
        { }
    }

    public class JointKindController : ReftableBaseController<JointKind>
    {
        public JointKindController(DataContext context) : base(context)
        { }
    }

    public class JointTypeController : ReftableBaseController<JointType>
    {
        public JointTypeController(DataContext context) : base(context)
        { }
    }

    public class SeamsTypeController : ReftableBaseController<SeamsType>
    {
        public SeamsTypeController(DataContext context) : base(context)
        { }
    }

    public class WeldGOST14098Controller : ReftableBaseController<WeldGOST14098>
    {
        public WeldGOST14098Controller(DataContext context) : base(context)
        { }
    }

    public class WeldingEquipmentAutomationLevelController : ReftableBaseController<WeldingEquipmentAutomationLevel>
    {
        public WeldingEquipmentAutomationLevelController(DataContext context) : base(context)
        { }
    }

    public class WeldMaterialController : ReftableBaseController<WeldMaterial>
    {
        public WeldMaterialController(DataContext context) : base(context)
        { }
    }

    public class WeldMaterialGroupController : ReftableBaseController<WeldMaterialGroup>
    {
        public WeldMaterialGroupController(DataContext context) : base(context)
        { }
    }

    public class WeldPositionController : ReftableBaseController<WeldPosition>
    {
        public WeldPositionController(DataContext context) : base(context)
        { }
    }
}
