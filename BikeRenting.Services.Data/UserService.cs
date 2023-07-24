using Microsoft.EntityFrameworkCore;

using BikeRenting.Data;
using BikeRenting.Data.Models;
using BikeRenting.Services.Data.Interfaces;

namespace BikeRenting.Services.Data
{
    public class UserService : IUserService
    {
        private readonly BikeRentingDbContext dbContext;

        public UserService(BikeRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> GetFullNameByEmailAsync(string email)
        {
            ApplicationUser? user = await dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
