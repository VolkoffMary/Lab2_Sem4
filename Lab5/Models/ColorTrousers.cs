using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5.Models
{
    public class ColorTrousers
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }
        [Required]
        [ForeignKey("TrousersId")]
        public virtual Trousers Trousers { get; set; }
    }
}
