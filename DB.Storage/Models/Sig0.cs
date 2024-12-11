using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Storage.Models
{
    public class Sig0
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(Enter_value))]
        public Guid Enter_ValueId { get; set; }

        [Required]

        public double enter_sig0 { get; set; }

        public virtual Enter_value Enter_Value { get; set; }
    }
}
