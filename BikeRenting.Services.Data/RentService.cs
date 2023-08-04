using Microsoft.EntityFrameworkCore;

using BikeRenting.Data;
using BikeRenting.Services.Data.Interfaces;
using BikeRenting.Web.ViewModels.Rent;

namespace BikeRenting.Services.Data
{
    public class RentService : IRentService
    {
        private readonly BikeRentingDbContext dbContext;

        public RentService(BikeRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<RentViewModel>> AllAsync()
        {
            IEnumerable<RentViewModel> allRents = await this.dbContext
                .Bikes
                .Include(b => b.Renter)
                .Include(b => b.Agent)
                .ThenInclude(a => a.User)
                .Where(b => b.RenterId.HasValue)
                .Select(b => new RentViewModel
                {
                    Title = b.Title,
                    ImageUrl = b.ImageUrl,
                    AgentFullName = b.Agent.User.FirstName + " " + b.Agent.User.LastName,
                    AgentEmail = b.Agent.User.Email,
                    RenterFullName = b.Renter!.FirstName + " " + b.Renter.LastName,
                    RenterEmail = b.Renter.Email
                })
                .ToArrayAsync();

            return allRents;
        }
    }
}
