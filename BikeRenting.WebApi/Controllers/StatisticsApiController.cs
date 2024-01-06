using Microsoft.AspNetCore.Mvc;

using BikeRenting.Services.Data.Interfaces;
using BikeRenting.Services.Data.Models.Statistics;

namespace BikeRenting.WebApi.Controllers
{
    [Route("api/statistics")]
    [ApiController]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IBikeService bikeService;

        public StatisticsApiController(IBikeService bikeService)
        {
            this.bikeService = bikeService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(StatisticsServiceModel))]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetStatistics()

        {
            try
            {
                StatisticsServiceModel serviceModel =
                    await this.bikeService.GetStatisticsAsync();

                return this.Ok(serviceModel);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
    }
}
