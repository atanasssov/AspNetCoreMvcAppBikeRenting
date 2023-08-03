using Microsoft.AspNetCore.Mvc;

namespace BikeRenting.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
