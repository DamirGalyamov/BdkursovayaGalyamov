using System.ComponentModel.DataAnnotations;

namespace DB.Storage.Models
{
    public class kofC1
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public double alpha1 { get; set; }

        [Required]
        public double C1 { get; set; }
    }
}
