using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using BikeRenting.Web.ViewModels.Bike;
using BikeRenting.Services.Data.Interfaces;
using BikeRenting.Web.Infrastructure.Extensions;

using static BikeRenting.Common.NotificationMessagesConstants;

namespace BikeRenting.Web.Controllers
{
    [Authorize]
    public class BikeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IAgentService agentService;

        public BikeController(ICategoryService categoryService,
                              IAgentService agentService)

        {
            this.categoryService = categoryService;
            this.agentService = agentService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isAgent = await this.agentService.AgentExistsByUserIdAsync(this.User.GetId()!);
            if (!isAgent)
            {
                TempData[ErrorMessage] = "You must become an agent in order to add new bikes!";

                return this.RedirectToAction("Become", "Agent");
            }
            BikeFormModel formModel = new BikeFormModel()
            {
                Categories = await this.categoryService.AllCategoriesAsync()
            };

            return View(formModel);

        }
    }
}
