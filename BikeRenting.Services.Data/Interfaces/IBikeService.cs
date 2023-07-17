using BikeRenting.Web.ViewModels.Home;

namespace BikeRenting.Services.Data.Interfaces
{
    public interface IBikeService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeBikesAsync();
    }
}
