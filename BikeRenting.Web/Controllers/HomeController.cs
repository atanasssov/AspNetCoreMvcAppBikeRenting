using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using BikeRenting.Web.ViewModels.Home;
using BikeRenting.Data;
using BikeRenting.Services.Data.Interfaces;

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
            IEnumerable<IndexViewModel> viewModel =
                await this.bikeService.LastThreeBikesAsync();

            return View(viewModel);
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}