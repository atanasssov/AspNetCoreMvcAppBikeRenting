using System.ComponentModel.DataAnnotations;

using BikeRenting.Web.ViewModels.Category;

using static BikeRenting.Common.EntityValidationConstants.Bike;

namespace BikeRenting.Web.ViewModels.Bike
{
    public class BikeFormModel
    {
        public BikeFormModel()
        {
            this.Categories = new HashSet<BikeSelectCategoryFormModel>();
        }

        [Required]
        [StringLength(TitleMaxLength,MinimumLength =TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        [Range(typeof(decimal),PricePerMonthMinValue,PricePerMonthMaxValue)]
        [Display(Name = "Monthly Price")]
        public decimal PricePerMonth { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<BikeSelectCategoryFormModel> Categories { get; set; }


    }
}
