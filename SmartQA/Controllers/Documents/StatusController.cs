using SmartQA.Auth;
using SmartQA.Controllers.Shared;
using SmartQA.DB;
using SmartQA.DB.Models.Documents;
using SmartQA.Models.Shared;

namespace SmartQA.Controllers.Documents
{
    public class StatusController : CommonEntityODataController<Status, EntityForm<Status>>
    {
        public StatusController(DataContext context, AppUserManager userManager) : base(context, userManager)
        {
        }
    }
}