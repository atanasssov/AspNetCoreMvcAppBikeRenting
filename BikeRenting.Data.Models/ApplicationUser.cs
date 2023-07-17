using Microsoft.AspNetCore.Identity;

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
    }
}
