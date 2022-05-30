using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5.Models
{
    public class PhotoTShirt
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("PhotoId")]
        public virtual Photo Photo { get; set; }
        [Required]
        [ForeignKey("TShirtId")]
        public virtual TShirt TShirt { get; set; }
    }
}
