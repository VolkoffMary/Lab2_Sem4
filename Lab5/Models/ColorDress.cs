using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5.Models
{
    public class ColorDress
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }
        [Required]
        [ForeignKey("DressId")]
        public virtual Dress Dress { get; set; }
    }
}
