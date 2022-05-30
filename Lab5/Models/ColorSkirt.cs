using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5.Models
{
    public class ColorSkirt
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }
        [Required]
        [ForeignKey("SkirtId")]
        public virtual Skirt Skirt { get; set; } 
    }
}
