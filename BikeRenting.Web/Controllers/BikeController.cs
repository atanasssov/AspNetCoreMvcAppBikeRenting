using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using BikeRenting.Web.ViewModels.Bike;
using BikeRenting.Services.Data.Interfaces;
using BikeRenting.Web.Infrastructure.Extensions;

using static BikeRenting.Common.NotificationMessagesConstants;
using BikeRenting.Services.Data.Models.Bike;

namespace BikeRenting.Web.Controllers
{
    [Authorize]
    public class BikeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IAgentService agentService;
        private readonly IBikeService bikeService;

        public BikeController(ICategoryService categoryService,
                              IAgentService agentService,
                              IBikeService bikeService)

        {
            this.categoryService = categoryService;
            this.agentService = agentService;
            this.bikeService = bikeService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllBikesQueryModel queryModel)
        {

            AllBikesFilteredAndPagedServiceModel serviceModel =
                await this.bikeService.AllAsync(queryModel);

            queryModel.Bikes = serviceModel.Bikes;
            queryModel.TotalBikes = serviceModel.TotalBikesCount;
            queryModel.Categories = await this.categoryService.AllCategoryNamesAsync();

            return this.View(queryModel);
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

        [HttpPost]
        public async Task<IActionResult> Add(BikeFormModel model)
        {
            bool isAgent = await this.agentService.AgentExistsByUserIdAsync(this.User.GetId()!);
            if (!isAgent)
            {
                TempData[ErrorMessage] = "You must become an agent in order to add new bikes!";

                return this.RedirectToAction("Become", "Agent");
            }

            bool categoryExists = await this.categoryService.ExistsByIdAsync(model.CategoryId);
            if (!categoryExists)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), "Selected category does not exist!");
            }

            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoriesAsync();

                return View(model);
            }

            try
            {
                string? agentId = await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);
               
                await this.bikeService.CreateAsync(model, agentId!);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add a new bike! Please try again later or contact an administrator!");

                model.Categories = await this.categoryService.AllCategoriesAsync();
                return this.View(model);

            }

            return this.RedirectToAction("All", "Bike");
        }

        [HttpGet]
        [AllowAnonymous]

        public async Task<IActionResult> Details(string id)
        {
            BikeDetailsViewModel? viewModel = await this.bikeService.GetDetailsByIdAsync(id);

            if (viewModel == null)
            {
                this.TempData[ErrorMessage] = "Bike with the provided id does not exist!";

                return this.RedirectToAction("All", "Bike");
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            List<BikeAllViewModel> myBikes = new List<BikeAllViewModel>();

            string userId = this.User.GetId()!;
            bool isUserAgent = await this.agentService.AgentExistsByUserIdAsync(userId);
            if (isUserAgent)
            {
                string? agentId = await this.agentService.GetAgentIdByUserIdAsync(userId);

                myBikes.AddRange(await this.bikeService.AllByAgentIdAsync(agentId!));
            }
            else
            {
                myBikes.AddRange(await this.bikeService.AllByUserIdAsync(userId!));
            }

            return this.View(myBikes);
        }
    }
}
