using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BikeRenting.Common.EntityValidationConstants.Agent;

namespace BikeRenting.Data.Models
{
    public class Agent
    {
        public Agent()
        {
            this.Id = Guid.NewGuid();
            this.OwnedBikes = new HashSet<Bike>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;

        public virtual ICollection<Bike> OwnedBikes { get; set; }
    }
}
