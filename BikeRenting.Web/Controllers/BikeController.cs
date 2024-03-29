﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;

using BikeRenting.Web.ViewModels.Bike;
using BikeRenting.Services.Data.Interfaces;
using BikeRenting.Web.Infrastructure.Extensions;
using BikeRenting.Services.Data.Models.Bike;
using BikeRenting.Data.Models;

using static BikeRenting.Common.NotificationMessagesConstants;
using static BikeRenting.Common.GeneralApplicationConstants;

namespace BikeRenting.Web.Controllers
{
    [Authorize]
    public class BikeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IAgentService agentService;
        private readonly IBikeService bikeService;
        private readonly IUserService userSerive;
        private readonly IMemoryCache memoryCache;

        public BikeController(ICategoryService categoryService,
                              IAgentService agentService,
                              IBikeService bikeService,
                              IUserService userSerive,
                              IMemoryCache memoryCache)

        {
            this.categoryService = categoryService;
            this.agentService = agentService;
            this.bikeService = bikeService;
            this.userSerive = userSerive;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllBikesQueryModel queryModel)
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

            try
            {
                BikeFormModel formModel = new BikeFormModel()
                {
                    Categories = await this.categoryService.AllCategoriesAsync()
                };

                return View(formModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }


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

                string bikeId = await this.bikeService.CreateAndReturnIdAsync(model, agentId!);

                this.TempData[SuccessMessage] = "Bike was added successfully!";
                return this.RedirectToAction("Details", "Bike", new { id = bikeId });
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add a new bike! Please try again later or contact an administrator!");
                model.Categories = await this.categoryService.AllCategoriesAsync();

                return this.View(model);

            }

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool bikeExists = await this.bikeService.ExistsByIdAsync(id);
            if (!bikeExists)
            {
                this.TempData[ErrorMessage] = "Bike with the provided id does not exist!";

                return this.RedirectToAction("All", "Bike");
            }

            try
            {
                BikeDetailsViewModel viewModel = await this.bikeService.GetDetailsByIdAsync(id);


                string agentEmail = await this.agentService.GetAgentEmailByBikeIdAsync(id);


                viewModel.Agent.FullName = await userSerive
                    .GetFullNameByEmailAsync(agentEmail);

                return View(viewModel);
            }
            catch (Exception)
            {

                return this.GeneralError();
            }


        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool bikeExists = await this.bikeService.ExistsByIdAsync(id);

            if (!bikeExists)
            {
                this.TempData[ErrorMessage] = "Bike with the provided id does not exist!";

                return this.RedirectToAction("All", "Bike");
            }

            bool isUserAgent = await this.agentService.AgentExistsByUserIdAsync(this.User.GetId()!);
            if (!isUserAgent && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become agent in order to edit bike information!";

                return this.RedirectToAction("Become", "Agent");
            }

            string? agentId = await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);
            bool isAgentOwner = await this.bikeService.IsAgentWithIdOwnerOfBikeWithIdAsync(id, agentId!);
            if (!isAgentOwner && !this.User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must be the agent owner of the bike which you want to edit!";

                return this.RedirectToAction("Mine", "Bike");
            }

            try
            {
                BikeFormModel formModel = await this.bikeService.GetBikeForEditByIdAsync(id);
                formModel.Categories = await this.categoryService.AllCategoriesAsync();

                return this.View(formModel);
            }
            catch (Exception)
            {

                return this.GeneralError();
            }


        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, BikeFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoriesAsync();
                return this.View(model);
            }

            bool bikeExists = await this.bikeService.ExistsByIdAsync(id);

            if (!bikeExists)
            {
                this.TempData[ErrorMessage] = "Bike with the provided id does not exist!";

                return this.RedirectToAction("All", "Bike");
            }

            bool isUserAgent = await this.agentService.AgentExistsByUserIdAsync(this.User.GetId()!);
            if (!isUserAgent && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become agent in order to edit bike information!";

                return this.RedirectToAction("Become", "Agent");
            }

            string? agentId = await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);
            bool isAgentOwner = await this.bikeService.IsAgentWithIdOwnerOfBikeWithIdAsync(id, agentId!);
            if (!isAgentOwner && !this.User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must be the agent owner of the bike which you want to edit!";

                return this.RedirectToAction("Mine", "Bike");
            }

            try
            {
                await this.bikeService.EditBikeByIdAndFormModelAsync(id, model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to update the bike. Please, try again later or contact an administrator!");
                model.Categories = await this.categoryService.AllCategoriesAsync();

                return this.View(model);
            }

            this.TempData[SuccessMessage] = "Bike was edited successfully!";
            return this.RedirectToAction("Details", "Bike", new { id }); // id is parameter of Details
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool bikeExists = await this.bikeService.ExistsByIdAsync(id);

            if (!bikeExists)
            {
                this.TempData[ErrorMessage] = "Bike with the provided id does not exist!";

                return this.RedirectToAction("All", "Bike");
            }

            bool isUserAgent = await this.agentService.AgentExistsByUserIdAsync(this.User.GetId()!);
            if (!isUserAgent && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become agent in order to edit bike information!";

                return this.RedirectToAction("Become", "Agent");
            }

            string? agentId = await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);
            bool isAgentOwner = await this.bikeService.IsAgentWithIdOwnerOfBikeWithIdAsync(id, agentId!);
            if (!isAgentOwner && !this.User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must be the agent owner of the bike which you want to edit!";

                return this.RedirectToAction("Mine", "Bike");
            }

            try
            {
                BikePreDeleteDetailsViewModel viewModel = await this.bikeService
                    .GetBikeForDeleteByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }


        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, BikePreDeleteDetailsViewModel model)
        {
            bool bikeExists = await this.bikeService.ExistsByIdAsync(id);

            if (!bikeExists)
            {
                this.TempData[ErrorMessage] = "Bike with the provided id does not exist!";

                return this.RedirectToAction("All", "Bike");
            }

            bool isUserAgent = await this.agentService.AgentExistsByUserIdAsync(this.User.GetId()!);
            if (!isUserAgent && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become agent in order to edit bike information!";

                return this.RedirectToAction("Become", "Agent");
            }

            string? agentId = await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);
            bool isAgentOwner = await this.bikeService.IsAgentWithIdOwnerOfBikeWithIdAsync(id, agentId!);
            if (!isAgentOwner && !this.User.IsAdmin())
            {
                TempData[ErrorMessage] = "You must be the agent owner of the bike which you want to edit!";

                return this.RedirectToAction("Mine", "Bike");
            }

            try
            {
                await this.bikeService.DeleteBikeByIdAsync(id);

                this.TempData[WarningMessage] = "The bike was successfully deleted!";
                return this.RedirectToAction("Mine", "Bike");
            }
            catch (Exception)
            {

                return this.GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            if (this.User.IsInRole(AdminRoleName))
            {
                return this.RedirectToAction("Mine", "Bike", new { Area = AdminAreaName });
            }

            List<BikeAllViewModel> myBikes = new List<BikeAllViewModel>();

            string userId = this.User.GetId()!;
            bool isUserAgent = await this.agentService.AgentExistsByUserIdAsync(userId);

            try
            {
                if (User.IsAdmin())
                {
                    string? agentId = await this.agentService.GetAgentIdByUserIdAsync(userId);

                    // added bikes as an agent
                    myBikes.AddRange(await this.bikeService.AllByAgentIdAsync(agentId!));

                    //rented bikes as an user
                    myBikes.AddRange(await this.bikeService.AllByUserIdAsync(userId!));


                    myBikes = myBikes
                        .DistinctBy(b => b.Id)
                        .ToList();
                }

                else if (isUserAgent)
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
            catch (Exception)
            {

                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Rent(string id)
        {
            bool bikeExists = await this.bikeService.ExistsByIdAsync(id);
            if (!bikeExists)
            {
                this.TempData[ErrorMessage] = "Bike with provided id does not exist! Please, try again!";

                return this.RedirectToAction("All", "Bike");
            }

            bool isBikeRented = await this.bikeService.IsRentedAsync(id);
            if (isBikeRented)
            {
                this.TempData[ErrorMessage] = "Selected bike is already rented by another user! Please, select another bike!";

                return this.RedirectToAction("All", "Bike");
            }

            // checking if it is agent and it is not admin
            // enables only users (not agents) and admins to rent bikes

            bool isUserAgent = await this.agentService.AgentExistsByUserIdAsync(this.User.GetId()!);

            if (isUserAgent && !User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "Agents can not rent bikes! Please, register as a user!";

                return this.RedirectToAction("Index", "Home");
            }

            // checking if the user is admin
            // restricts to rent bikes which are added by him

            string? agentId = await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);
            bool isAgentOwner = await this.bikeService.IsAgentWithIdOwnerOfBikeWithIdAsync(id, agentId!);

            if (isAgentOwner)
            {
                this.TempData[ErrorMessage] = "Admin agents can not rent bikes which are added by them!";

                return this.RedirectToAction("Mine", "Bike");
            }

            try
            {
                await this.bikeService.RentBikeAsync(id, this.User.GetId()!);

            }
            catch (Exception)
            {
                return this.GeneralError();
            }

            this.memoryCache.Remove(RentsCacheKey);

            return this.RedirectToAction("Mine", "Bike");
        }

        public async Task<IActionResult> Leave(string id)
        {
            bool bikeExists = await this.bikeService.ExistsByIdAsync(id);
            if (!bikeExists)
            {
                this.TempData[ErrorMessage] = "Bike with provided id does not exist! Please, try again!";

                return this.RedirectToAction("All", "Bike");
            }

            bool isBikeRented = await this.bikeService.IsRentedAsync(id);
            if (!isBikeRented)
            {
                this.TempData[ErrorMessage] = "Selected bike is not rented! Only rented bikes can be left!";

                return this.RedirectToAction("Mine", "Bike");
            }

            bool IsCurrenUserRenterOfTheBike = await this.bikeService
                .IsRentedByUserWithIdAsync(id, this.User.GetId()!);
            if (!IsCurrenUserRenterOfTheBike)
            {
                this.TempData[ErrorMessage] = "You must be the renter of the bike in order to leave it!";

                return this.RedirectToAction("Mine", "Bike");
            }

            try
            {
                await this.bikeService.LeaveBikeAsync(id);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

            this.memoryCache.Remove(RentsCacheKey);

            return this.RedirectToAction("Mine", "Bike");

        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occured. Please, try again later or contact an administrator!";

            return this.RedirectToAction("Index", "Home");
        }
    }
}
