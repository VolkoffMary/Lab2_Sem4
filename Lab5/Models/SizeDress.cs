using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5.Models
{
    public class SizeDress
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("SizeId")]
        public virtual Size Size { get; set; }
        [Required]
        [ForeignKey("DressId")]
        public virtual Dress Dress { get; set; }
    }
}
