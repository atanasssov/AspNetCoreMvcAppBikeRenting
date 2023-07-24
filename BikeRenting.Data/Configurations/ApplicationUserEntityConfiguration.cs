using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BikeRenting.Data.Models;

namespace BikeRenting.Data.Configurations
{
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.FirstName)
                .HasDefaultValue("Test FirstName");

            builder.Property(u => u.LastName)
                .HasDefaultValue("Test LastName");
        }
    }
}
