using BikeRenting.Web.ViewModels.Bike;

namespace BikeRenting.Web.Areas.Admin.ViewModels.Bike
{
    public class MyBikesViewModel
    {
        public IEnumerable<BikeAllViewModel> AddedBikes { get; set; } = null!;

        public IEnumerable<BikeAllViewModel> RentedBikes { get; set; } = null!;
    }
}
