using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BikeRenting.Data.Models;

namespace BikeRenting.Data.Configurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.GenerateCategories());
        }

        private Category[] GenerateCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category category;

            category = new Category
            {
                Id = 1,
                Name = "Road bike"
            };
            categories.Add(category);

            category = new Category
            {
                Id = 2,
                Name = "Mountain bike"
            };
            categories.Add(category);

            category = new Category
            {
                Id = 3,
                Name = "Touring bike"
            };
            categories.Add(category);




            return categories.ToArray();
        }
    }
}
