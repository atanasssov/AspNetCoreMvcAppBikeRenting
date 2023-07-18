using Microsoft.EntityFrameworkCore;

using BikeRenting.Data;
using BikeRenting.Services.Data.Interfaces;
using BikeRenting.Web.ViewModels.Agent;
using BikeRenting.Data.Models;

namespace BikeRenting.Services.Data
{
    public class AgentService : IAgentService
    {
        private readonly BikeRentingDbContext dbContext;

        public AgentService(BikeRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AgentExistsByUserIdAsync(string userId)
        {
            bool result = await this.dbContext
                .Agents
                .AnyAsync(a => a.UserId.ToString() == userId);

            return result;
        }

        public async Task<bool> AgentExistsByPhoneNumberAsync(string phoneNumber)
        {
            bool result = await this.dbContext
               .Agents
               .AnyAsync(a => a.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> HasRentsByUserIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .Include(u => u.RentedBikes) // not working if this is not icluded
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return false;
            }

            return user.RentedBikes.Any();

            //bool result = await this.dbContext
            //    .Bikes
            //    .AnyAsync(b => b.RenterId.ToString() == userId);
            //return result;

        }

        public async Task Create(string userId, BecomeAgentFormModel model)
        {
            Agent newAgent = new Agent
            {
                PhoneNumber = model.PhoneNumber,
                UserId = Guid.Parse(userId)
            };

            await this.dbContext.Agents.AddAsync(newAgent);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
