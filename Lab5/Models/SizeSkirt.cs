using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5.Models
{
    public class SizeSkirt
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("SizeId")]
        public virtual Size Size { get; set; }
        [Required]
        [ForeignKey("SkirtId")]
        public virtual Skirt Skirt { get; set; }
    }
}
