using Microsoft.EntityFrameworkCore;

using BikeRenting.Data;
using BikeRenting.Services.Data.Interfaces;
using BikeRenting.Web.ViewModels.Home;

namespace BikeRenting.Services.Data
{
    public class BikeService : IBikeService
    {
        private readonly BikeRentingDbContext dbContext;

        public BikeService(BikeRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<IndexViewModel>> LastThreeBikesAsync()
        {
            IEnumerable<IndexViewModel> lastThreeBikes = await this.dbContext
                .Bikes
                .OrderByDescending(b => b.CreatedOn)
                .Take(3)
                .Select(b => new IndexViewModel
                {
                    Id = b.Id.ToString(),
                    Title = b.Title,
                    ImageUrl = b.ImageUrl
                })
                .ToArrayAsync();

            return lastThreeBikes;
        }
    }
}
