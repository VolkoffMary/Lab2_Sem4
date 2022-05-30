using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5.Models
{
    public class SizeTShirt
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("SizeId")]
        public virtual Size Size { get; set; }
        [Required]
        [ForeignKey("TShirtId")]
        public virtual TShirt TShirt { get; set; }
    }
}
