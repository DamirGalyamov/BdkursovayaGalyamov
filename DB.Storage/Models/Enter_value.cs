using System.ComponentModel.DataAnnotations;

namespace DB.Storage.Models
{
    public class Enter_value
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(255)]
        public string belt_type { get; set; }

        [Required, MaxLength(255)]
        public string profile_type { get; set; }

        [Required]
        public double Z { get; set; }

        [Required]
        public double C3 { get; set; }

        [Required]
        public double F { get; set; }

        [Required]
        public double xi { get; set; }

        [Required]
        public double alpha1 { get; set; }
    }
}
