using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5.Models
{
    public class ColorTShirt
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }
        [Required]
        [ForeignKey("TShirtId")]
        public virtual TShirt TShirt { get; set; } 
    }
}
