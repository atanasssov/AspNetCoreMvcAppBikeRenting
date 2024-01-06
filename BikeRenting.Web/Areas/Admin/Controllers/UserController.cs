using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

using BikeRenting.Services.Data.Interfaces;
using BikeRenting.Web.ViewModels.User;

using static BikeRenting.Common.GeneralApplicationConstants;

namespace BikeRenting.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;

        public UserController(IUserService userService, IMemoryCache memoryCache)
        {
            this.userService = userService;
            this.memoryCache = memoryCache;
        }

        [Route("User/All")]
        public async Task<IActionResult> All()
        {
            object cachedUsers = this.memoryCache.Get(UsersCacheKey);
            IEnumerable<UserViewModel> users;

            if (cachedUsers is IEnumerable<UserViewModel> cachedUserViewModels)
            {
                users = cachedUserViewModels;
            }
            else
            {
                users = await this.userService.AllAsync();

                MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(UsersCacheDurationMinutes));

                this.memoryCache.Set(UsersCacheKey, users, cacheOptions);
            }

            return View(users);
        }
    }
}
