using System.ComponentModel.DataAnnotations;

namespace GarageApp.Data.Models
{
    public class Garage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Location { get; set; } = null!;

        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
