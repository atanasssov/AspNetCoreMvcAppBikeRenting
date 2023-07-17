using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BikeRenting.Data.Models;

namespace BikeRenting.Data.Configurations
{
    public class BikeEntityConfiguration : IEntityTypeConfiguration<Bike>
    {
        public void Configure(EntityTypeBuilder<Bike> builder)
        {
            builder
                .HasOne(b => b.Category)
                .WithMany(c => c.Bikes)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                 .HasOne(b => b.Agent)
                 .WithMany(a => a.OwnedBikes)
                 .HasForeignKey(b => b.AgentId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
