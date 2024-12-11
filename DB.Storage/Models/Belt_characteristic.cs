using System.ComponentModel.DataAnnotations;

namespace DB.Storage.Models
{
    public class Belt_characteristic
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(255)]
        public string profile_type { get; set; }

        [Required]
        public double sectional_area { get; set; }

        [Required]
        public double Loginlinear_density { get; set; }
    }
}
