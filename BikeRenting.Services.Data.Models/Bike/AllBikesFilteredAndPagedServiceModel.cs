using BikeRenting.Web.ViewModels.Bike;

namespace BikeRenting.Services.Data.Models.Bike
{
    public class AllBikesFilteredAndPagedServiceModel
    {
        public AllBikesFilteredAndPagedServiceModel()
        {
            this.Bikes = new HashSet<BikeAllViewModel>();
        }

        public int TotalBikesCount { get; set; }

        public IEnumerable<BikeAllViewModel> Bikes { get; set; }

    }
}
