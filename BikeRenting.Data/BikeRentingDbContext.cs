using System.Reflection;

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

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Bike> Bikes { get; set; } = null!;

        public DbSet<Agent> Agents { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(BikeRentingDbContext)) ??
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}