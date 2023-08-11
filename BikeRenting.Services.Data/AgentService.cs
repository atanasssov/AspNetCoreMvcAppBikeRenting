using Microsoft.EntityFrameworkCore;

using BikeRenting.Data;
using BikeRenting.Services.Data.Interfaces;
using BikeRenting.Web.ViewModels.Agent;
using BikeRenting.Data.Models;

//using static BikeRenting.Common.EntityValidationConstants;

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

        public async Task<string?> GetAgentIdByUserIdAsync(string userId)
        {
            Agent? agent = await this.dbContext
                .Agents
                .FirstOrDefaultAsync(a => a.UserId.ToString() == userId);

            if(agent == null)
            {
                return null;
            }

            return agent.Id.ToString();
        }

        public async Task<bool> HasBikeWithIdAsync(string? userId, string bikeId)
        {
            Agent? agent = await this.dbContext
                .Agents
                .Include(a => a.OwnedBikes)
                .FirstOrDefaultAsync(a => a.UserId.ToString() == userId);

            if(agent == null)
            {
                return false;
            }

            bikeId = bikeId.ToLower();
            return agent.OwnedBikes.Any(b => b.Id.ToString() == bikeId);
        }

        // to be changed
        public async Task<string> GetAgentEmailByBikeIdAsync(string bikeId)
        {
            Bike bike = await this.dbContext
                .Bikes
                .Include(b => b.Agent)
                .FirstAsync(b => b.Id.ToString() == bikeId);

            string agentId = bike.AgentId.ToString();

            Agent agent = await this.dbContext
                .Agents
                .FirstAsync(a => a.Id.ToString() == agentId);

            string userId = agent.UserId.ToString();

            ApplicationUser user = await this.dbContext
                .Users
                .FirstAsync(u => u.Id.ToString() == userId);
            return user.Email;
        }

     
    }
}
