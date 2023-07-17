using Microsoft.EntityFrameworkCore;

using BikeRenting.Data;
using BikeRenting.Services.Data.Interfaces;

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
    }
}
