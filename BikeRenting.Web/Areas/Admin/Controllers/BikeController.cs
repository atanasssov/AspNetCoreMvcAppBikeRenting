using Microsoft.AspNetCore.Mvc;

using BikeRenting.Services.Data.Interfaces;
using BikeRenting.Web.Areas.Admin.ViewModels.Bike;
using BikeRenting.Web.Infrastructure.Extensions;

namespace BikeRenting.Web.Areas.Admin.Controllers
{
    public class BikeController : BaseAdminController
    {
        private readonly IAgentService agentService;
        private readonly IBikeService bikeService;

        public BikeController(IAgentService agentService, IBikeService bikeService)
        {
            this.agentService = agentService;
            this.bikeService = bikeService;
        }
        public async Task<IActionResult> Mine()
        {
            string? agentId =
                await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);
            MyBikesViewModel viewModel = new MyBikesViewModel()
            {
                AddedBikes = await this.bikeService.AllByAgentIdAsync(agentId!),
                RentedBikes = await this.bikeService.AllByUserIdAsync(this.User.GetId()!),
            };

            return this.View(viewModel);
        }
    }
}
