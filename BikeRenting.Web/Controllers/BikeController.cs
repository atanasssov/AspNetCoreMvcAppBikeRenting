using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BikeRenting.Web.Controllers
{
    [Authorize]
    public class BikeController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
        }
    }
}
