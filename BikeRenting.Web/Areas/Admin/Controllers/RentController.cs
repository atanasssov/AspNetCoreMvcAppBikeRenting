using Microsoft.AspNetCore.Mvc;

using BikeRenting.Services.Data.Interfaces;
using BikeRenting.Web.ViewModels.Rent;

namespace BikeRenting.Web.Areas.Admin.Controllers
{
    public class RentController : BaseAdminController
    {
        private readonly IRentService rentService;

        public RentController(IRentService rentService)
        {
            this.rentService = rentService;
        }

        [Route("Rent/All")]
        public async Task<IActionResult> All()
        {
            IEnumerable<RentViewModel> allRents = 
                await this.rentService.AllAsync();


            return this.View(allRents);
        }
    }
}
