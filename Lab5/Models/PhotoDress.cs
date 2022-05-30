using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5.Models
{
    public class PhotoDress
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("PhotoId")]
        public virtual Photo Photo { get; set; }
        [Required]
        [ForeignKey("DressId")]
        public virtual Dress Dress { get; set; }
    }
}
