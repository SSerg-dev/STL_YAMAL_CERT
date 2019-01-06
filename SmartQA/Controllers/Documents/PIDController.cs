using SmartQA.Auth;
using SmartQA.Controllers.Shared;
using SmartQA.DB;
using SmartQA.DB.Models.Documents;
using SmartQA.Models.Shared;

namespace SmartQA.Controllers.Documents
{
    public class PIDController : CommonEntityODataController<PID, EntityForm<PID>>
    {
        public PIDController(DataContext context, AppUserManager userManager) : base(context, userManager)
        {
        }
    }
}