using Microsoft.EntityFrameworkCore;

using BikeRenting.Data;
using BikeRenting.Services.Data.Interfaces;
using BikeRenting.Web.ViewModels.Home;
using BikeRenting.Web.ViewModels.Bike;
using BikeRenting.Data.Models;

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

        public async Task CreateAsync(BikeFormModel formModel, string agentId)
        {
            Bike newBike = new Bike()
            {
                Title = formModel.Title,
                Address = formModel.Address,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                PricePerMonth = formModel.PricePerMonth,
                CategoryId = formModel.CategoryId,
                AgentId = Guid.Parse(agentId),
            };

            await this.dbContext.Bikes.AddAsync(newBike);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
