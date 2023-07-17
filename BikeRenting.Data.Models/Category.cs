using System.ComponentModel.DataAnnotations;

using static BikeRenting.Common.EntityValidationConstants.Category;

namespace BikeRenting.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Bikes = new HashSet<Bike>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Bike> Bikes { get; set; }
    }
}
