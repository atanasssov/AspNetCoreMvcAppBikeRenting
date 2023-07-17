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
                .Property(b => b.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

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

            builder.HasData(this.GenerateBikes());
        }

        private Bike[] GenerateBikes()
        {
            ICollection<Bike> bikes = new HashSet<Bike>();

            Bike bike;

            bike = new Bike()
            {
                Title = "Twitter Gravel V2 RS24 ROAD CARBON BIKE",
                Address = "Aleksandar Stamboliyski Blvd 31, 1000 Sofia Center, Sofia",
                Description = "Brand new road carbon bike. Very comfortable and fast.",
                ImageUrl = "https://ae01.alicdn.com/kf/Scff11857dfc7461f9eb84244f5d6e920C.jpg_640x640Q90.jpg_.webp",
                PricePerMonth = 300.00M,
                CategoryId = 1,
                AgentId = Guid.Parse("ABB45694-E4C3-4A7C-80F7-BB249EE975A1"), 
                RenterId = Guid.Parse("C6174679-B1EA-4627-832D-D666AA928AAB") 
            };
            bikes.Add(bike);

            bike = new Bike()
            {
                Title = "Apollo Valier Mens Mountain Bike",
                Address = "Sokolska 6А, 9002 Varna Center, Varna",
                Description = "Off-road bike for rough terrain like mountain, desert, or rocks with specially design.",
                ImageUrl = "https://cdn.media.halfords.com/i/washford/560463_ss_03?w=620&h=480&qlt=default&fmt=auto&v=1",
                PricePerMonth = 250.00M,
                CategoryId = 2,
                AgentId = Guid.Parse("ABB45694-E4C3-4A7C-80F7-BB249EE975A1"), 
               
            };
            bikes.Add(bike);

            bike = new Bike()
            {
                Title = "Trek 1120 Adventure Touring Bike",
                Address = "Rue du Trône 129, 1050 Ixelles, Belgium",
                Description = "Comfortable and capable of carrying heavy loads. Brand new.",
                ImageUrl = "https://www.blazingbikes.co.uk/media/catalog/product/1/1/1120_21_33304_a_accessory1.jpg",
                PricePerMonth = 180.00M,
                CategoryId = 3,
                AgentId = Guid.Parse("ABB45694-E4C3-4A7C-80F7-BB249EE975A1"), 

            };
            bikes.Add(bike);

            return bikes.ToArray();
        }
    }
}
