using Microsoft.EntityFrameworkCore;

using BikeRenting.Data;
using BikeRenting.Data.Models;
using BikeRenting.Services.Data.Interfaces;
using BikeRenting.Web.ViewModels.User;

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

        public async Task<string> GetFullNameByIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);
            if (user == null)
            {
                return string.Empty;
            }

            return $"({user.FirstName} {user.LastName})";
        }

        public async Task<IEnumerable<UserViewModel>> AllAsync()
        {
            List<UserViewModel> allUsers = await this.dbContext
                .Users
                .Select(u => new UserViewModel()
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    FullName = u.FirstName + " " + u.LastName
                })
                .ToListAsync();

            foreach (UserViewModel user in allUsers)
            {
                Agent? agent = this.dbContext
                    .Agents
                    .FirstOrDefault(a => a.UserId.ToString() == user.Id);
                if (agent != null)
                {
                    user.PhoneNumber = agent.PhoneNumber;
                }
                else
                {
                    user.PhoneNumber = string.Empty;
                }
            }

            return allUsers;
        }
    } 
}
