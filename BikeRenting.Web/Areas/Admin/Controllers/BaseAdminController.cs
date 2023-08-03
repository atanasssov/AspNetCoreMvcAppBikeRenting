using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static BikeRenting.Common.GeneralApplicationConstants;

namespace BikeRenting.Web.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class BaseAdminController : Controller
    {
        
    }
}
