using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BikeRenting.Common.EntityValidationConstants.Bike;

namespace BikeRenting.Data.Models
{
    public class Bike
    {

        public Bike()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        public decimal PricePerMonth { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        [ForeignKey(nameof(Agent))]
        public Guid AgentId { get; set; }

        public virtual Agent Agent { get; set; } = null!;

        public Guid? RenterId { get; set; }

        public virtual ApplicationUser? Renter { get; set; }
    }
}
