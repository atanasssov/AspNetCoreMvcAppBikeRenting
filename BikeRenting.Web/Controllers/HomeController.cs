using Microsoft.AspNetCore.Mvc;

using BikeRenting.Web.ViewModels.Home;
using BikeRenting.Services.Data.Interfaces;

using static BikeRenting.Common.GeneralApplicationConstants;

namespace BikeRenting.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBikeService bikeService;

        public HomeController(IBikeService bikeService)
        {
            this.bikeService = bikeService;
        }

        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(AdminRoleName))
            {
                return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }

            IEnumerable<IndexViewModel> viewModel =
                await this.bikeService.LastThreeBikesAsync();

            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return this.View("Error404");
            }

            if (statusCode == 401)
            {
                return this.View("Error401");
            }

            return this.View();
        }
    }
}