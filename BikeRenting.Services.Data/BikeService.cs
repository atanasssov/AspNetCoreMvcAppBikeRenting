﻿using Microsoft.EntityFrameworkCore;

using BikeRenting.Data;
using BikeRenting.Data.Models;
using BikeRenting.Services.Data.Interfaces;
using BikeRenting.Services.Data.Models.Bike;
using BikeRenting.Web.ViewModels.Home;
using BikeRenting.Web.ViewModels.Bike;
using BikeRenting.Web.ViewModels.Agent;
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
                .Where(b => b.IsActive)
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
                .Where(b => b.IsActive)
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

        public async Task<IEnumerable<BikeAllViewModel>> AllByAgentIdAsync(string agentId)
        {

            IEnumerable<BikeAllViewModel> allAgentBikes = await this.dbContext
                .Bikes
                .Where(b => b.IsActive)
                .Where(b => b.AgentId.ToString() == agentId)
                .Select(b => new BikeAllViewModel
                {
                    Id = b.Id.ToString(),
                    Title =b.Title,
                    Address = b.Address,
                    ImageUrl = b.ImageUrl,
                    PricePerMonth = b.PricePerMonth,
                    IsRented = b.RenterId.HasValue
                })
                .ToArrayAsync();

            return allAgentBikes;
        }

        public async Task<IEnumerable<BikeAllViewModel>> AllByUserIdAsync(string userId)
        {
            IEnumerable<BikeAllViewModel> allUserBikes = await this.dbContext
               .Bikes
               .Where(b => b.IsActive)
               .Where(b => b.RenterId.HasValue && b.RenterId.ToString()== userId)
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

            return allUserBikes;
        }

        public async Task<BikeDetailsViewModel> GetDetailsByIdAsync(string bikeId)
        {
            Bike bike = await this.dbContext
                .Bikes
                .Include(b => b.Category)
                .Include(b => b.Agent)
                .ThenInclude(a => a.User)
                .Where(b => b.IsActive)
                .FirstAsync(b => b.Id.ToString() == bikeId);

         

            return new BikeDetailsViewModel
            {
                Id = bike.Id.ToString(),
                Title = bike.Address,
                Address = bike.Address,
                ImageUrl = bike.ImageUrl,
                PricePerMonth = bike.PricePerMonth,
                IsRented = bike.RenterId.HasValue,
                Description = bike.Description,
                Category = bike.Category.Name,
                Agent = new AgentInfoOnBikeViewModel()
                {
                    Email = bike.Agent.User.Email,
                    PhoneNumber = bike.Agent.PhoneNumber

                }
            };
                
        }

        public async Task<bool> ExistsByIdAsync(string bikeId)
        {
            bool result = await this.dbContext
                .Bikes
                .Where(b => b.IsActive)
                .AnyAsync(b => b.Id.ToString() == bikeId);

            return result;
        }

        public async Task<BikeFormModel> GetBikeForEditByIdAsync(string bikeId)
        {
            Bike bike = await this.dbContext
                .Bikes
                .Include(b => b.Category)
                .Where(b => b.IsActive)
                .FirstAsync(b => b.Id.ToString() == bikeId);

            return new BikeFormModel
            {
                Title = bike.Title,
                Address = bike.Address,
                Description = bike.Description,
                ImageUrl = bike.ImageUrl,
                PricePerMonth = bike.PricePerMonth,
                CategoryId = bike.CategoryId
            };
        }
    }
}
