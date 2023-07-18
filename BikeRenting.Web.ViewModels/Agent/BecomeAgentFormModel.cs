using System.ComponentModel.DataAnnotations;

using static BikeRenting.Common.EntityValidationConstants.Agent;

namespace BikeRenting.Web.ViewModels.Agent
{
    public class BecomeAgentFormModel
    {
        [Required]
        [Phone]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, 
            ErrorMessage = "The field Phone must be with a minimum length of 7 and a maximum length of 18!")]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;
    }
}
