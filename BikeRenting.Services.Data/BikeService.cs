using Microsoft.EntityFrameworkCore;

using BikeRenting.Data;
using BikeRenting.Services.Data.Interfaces;
using BikeRenting.Web.ViewModels.Home;
using BikeRenting.Web.ViewModels.Bike;
using BikeRenting.Data.Models;
using BikeRenting.Services.Data.Models.Bike;
using BikeRenting.Web.ViewModels.Bike.Enums;

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

        public async Task<AllBikesFilteredAndPagedServiceModel> AllAsync(AllBikesQueryModel queryModel)
        {
            IQueryable<Bike> bikesQuery = this.dbContext
                .Bikes
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                bikesQuery = bikesQuery
                    .Where(b => b.Category.Name == queryModel.Category);
            }

            if(!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                bikesQuery = bikesQuery
                    .Where(b => EF.Functions.Like(b.Title, wildCard) ||
                                EF.Functions.Like(b.Address, wildCard) ||
                                EF.Functions.Like(b.Description, wildCard));
            }

            bikesQuery = queryModel.BikeSorting switch
            {
                BikeSorting.Newest => bikesQuery
                    .OrderByDescending(b=> b.CreatedOn),
                BikeSorting.Oldest => bikesQuery
                    .OrderBy(b => b.CreatedOn),
                BikeSorting.PriceAscending => bikesQuery
                    .OrderBy(b => b.PricePerMonth),
                BikeSorting.PriceDescending => bikesQuery
                    .OrderByDescending(b => b.PricePerMonth),
                _ => bikesQuery
                    .OrderBy(b => b.RenterId != null)
                    .ThenByDescending(b => b.CreatedOn)
            };

            IEnumerable<BikeAllViewModel> allBikes = await bikesQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.BikesPerPage)
                .Take(queryModel.BikesPerPage)
                .Select(b => new BikeAllViewModel
                {
                    Id = b.Id.ToString(),
                    Title = b.Title,
                    Address = b.Address,
                    ImageUrl = b.ImageUrl,
                    PricePerMonth = b.PricePerMonth,
                    IsRented = b.RenterId.HasValue
                })
                .ToArrayAsync();

            int totalBikes = bikesQuery.Count();

            return new AllBikesFilteredAndPagedServiceModel()
            {
                TotalBikesCount = totalBikes,
                Bikes = allBikes
            };
          
        }
    }
}
