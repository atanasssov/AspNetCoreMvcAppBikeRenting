using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

using static BikeRenting.Common.EntityValidationConstants.User;

namespace BikeRenting.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.RentedBikes = new HashSet<Bike>();
        }

        public virtual ICollection<Bike> RentedBikes { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;
    }
}
