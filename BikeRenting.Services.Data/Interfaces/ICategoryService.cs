using BikeRenting.Web.ViewModels.Category;

namespace BikeRenting.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<BikeSelectCategoryFormModel>> AllCategoriesAsync();

        Task<bool> ExistsByIdAsync(int id);

        Task<IEnumerable<string>> AllCategoryNamesAsync();
    }
}
