using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using BikeRenting.Web.Infrastructure.Extensions;
using BikeRenting.Services.Data.Interfaces;

using static BikeRenting.Common.NotificationMessagesConstants;

namespace BikeRenting.Web.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService agentService)
        {
            this.agentService = agentService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = this.User.GetId();

            bool isAgent = await this.agentService.AgentExistsByUserIdAsync(userId!);
            if(isAgent)
            {
                TempData[ErrorMessage] = "You are already an agent!";

                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }
    }
}
