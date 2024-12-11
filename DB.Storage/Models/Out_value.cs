using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Storage.Models
{
    public class Out_value
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Enter_value))]
        public Guid Enter_valuesId { get; set; }

        [Required]
        public double sigma0 { get; set; }

        [Required]
        public double Q0 { get; set; }

        [Required]
        public double R { get; set; }

        [Required]
        public double teta { get; set; }

        public virtual Enter_value Enter_Value { get; set; }
    }
}
