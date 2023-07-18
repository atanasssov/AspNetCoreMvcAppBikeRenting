using BikeRenting.Web.ViewModels.Category;

namespace BikeRenting.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<BikeSelectCategoryFormModel>> AllCategoriesAsync();
    }
}
