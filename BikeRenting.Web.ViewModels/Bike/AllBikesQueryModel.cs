using System.ComponentModel.DataAnnotations;

using BikeRenting.Web.ViewModels.Bike.Enums;

using static BikeRenting.Common.GeneralApplicationConstants;

namespace BikeRenting.Web.ViewModels.Bike
{
    public class AllBikesQueryModel
    {
        public AllBikesQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.BikesPerPage = EntitiesPerPage;

            this.Categories = new HashSet<string>();
            this.Bikes = new HashSet<BikeAllViewModel>();
        }

        public string? Category { get; set; }

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Bikes By")]
        public BikeSorting BikeSorting { get; set; }

        public int CurrentPage { get; set; }

        public int BikesPerPage { get; set; }

        public int TotalBikes { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<BikeAllViewModel> Bikes { get; set; }


    }
}
