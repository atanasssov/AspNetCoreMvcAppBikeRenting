using System.ComponentModel.DataAnnotations;

using static BikeRenting.Common.EntityValidationConstants.Agent;

namespace BikeRenting.Web.ViewModels.Agent
{
    public class BecomeAgentFormModel
    {
        [Required]
        [Phone]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;
    }
}
