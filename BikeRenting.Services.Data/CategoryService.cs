﻿using Microsoft.EntityFrameworkCore;

using BikeRenting.Data;
using BikeRenting.Services.Data.Interfaces;
using BikeRenting.Web.ViewModels.Category;

namespace BikeRenting.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly BikeRentingDbContext dbContext;

        public CategoryService(BikeRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<BikeSelectCategoryFormModel>> AllCategoriesAsync()
        {
            IEnumerable<BikeSelectCategoryFormModel> allCategories =
                await this.dbContext
                .Categories
                .Select(c => new BikeSelectCategoryFormModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .OrderBy(c => c.Name)
                .AsNoTracking()
                .ToArrayAsync();

            return allCategories;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await this.dbContext
                .Categories
                .AnyAsync(c => c.Id == id);

            return result;
        }

        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            IEnumerable<string> allNames = await this.dbContext
                .Categories
                .Select(c => c.Name)
                .ToArrayAsync();

            return allNames;
        }

    }
}
