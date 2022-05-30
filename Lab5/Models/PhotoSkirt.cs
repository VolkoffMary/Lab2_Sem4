using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5.Models
{
    public class PhotoSkirt
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("PhotoId")]
        public virtual Photo Photo { get; set; }
        [Required]
        [ForeignKey("SkirtId")]
        public virtual Skirt Skirt { get; set; }
    }
}
