using BikeRenting.Web.ViewModels.Rent;

namespace BikeRenting.Services.Data.Interfaces
{
    public interface IRentService
    {
        Task<IEnumerable<RentViewModel>> AllAsync();
    }
}
