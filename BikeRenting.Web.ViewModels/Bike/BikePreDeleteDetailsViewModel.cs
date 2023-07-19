using System.ComponentModel.DataAnnotations;

namespace BikeRenting.Web.ViewModels.Bike
{
    public class BikePreDeleteDetailsViewModel
    {
        public string Title { get; set; } = null!;

        public string Address { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;
    }
}
