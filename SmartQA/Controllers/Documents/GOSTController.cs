using SmartQA.Auth;
using SmartQA.Controllers.Shared;
using SmartQA.DB;
using SmartQA.DB.Models.Documents;
using SmartQA.Models.Shared;

namespace SmartQA.Controllers.Documents
{
    public class GOSTController : CommonEntityODataController<GOST, EntityForm<GOST>>
    {
        public GOSTController(DataContext context, AppUserManager userManager) : base(context, userManager)
        {
        }
    }
}