using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using BikeRenting.Data.Models;

namespace BikeRenting.Data
{
    public class BikeRentingDbContext : IdentityDbContext<ApplicationUser,IdentityRole<Guid>, Guid>
    {
        public BikeRentingDbContext(DbContextOptions<BikeRentingDbContext> options)
            : base(options)
        {

        }
    }
}