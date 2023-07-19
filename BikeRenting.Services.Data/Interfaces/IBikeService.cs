using BikeRenting.Services.Data.Models.Bike;
using BikeRenting.Web.ViewModels.Bike;
using BikeRenting.Web.ViewModels.Home;

namespace BikeRenting.Services.Data.Interfaces
{
    public interface IBikeService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeBikesAsync();

        Task CreateAsync(BikeFormModel formModel, string agentId);

        Task<AllBikesFilteredAndPagedServiceModel> AllAsync(AllBikesQueryModel queryModel);
    }
}
