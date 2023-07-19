using BikeRenting.Services.Data.Models.Bike;
using BikeRenting.Web.ViewModels.Bike;
using BikeRenting.Web.ViewModels.Home;

namespace BikeRenting.Services.Data.Interfaces
{
    public interface IBikeService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeBikesAsync();

        Task<string> CreateAndReturnIdAsync(BikeFormModel formModel, string agentId);

        Task<AllBikesFilteredAndPagedServiceModel> AllAsync(AllBikesQueryModel queryModel);

        Task<IEnumerable<BikeAllViewModel>> AllByAgentIdAsync (string agentId);

        Task<IEnumerable<BikeAllViewModel>> AllByUserIdAsync(string userId);

        Task<BikeDetailsViewModel> GetDetailsByIdAsync(string bikeId);

        Task<bool> ExistsByIdAsync(string bikeId);

        Task<BikeFormModel> GetBikeForEditByIdAsync(string bikeId);

        Task<bool> IsAgentWithIdOwnerOfBikeWithIdAsync(string bikeId, string agentId);

        Task EditBikeByIdAndFormModelAsync(string bikeId, BikeFormModel formModel);

        Task<BikePreDeleteDetailsViewModel> GetBikeForDeleteByIdAsync(string bikeId);

        Task DeleteBikeByIdAsync(string bikeId);

    }
}
