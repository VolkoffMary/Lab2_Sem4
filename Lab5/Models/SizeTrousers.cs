using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5.Models
{
    public class SizeTrousers
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("SizeId")]
        public virtual Size Size { get; set; }
        [Required]
        [ForeignKey("TrousersId")]
        public virtual Trousers Trousers { get; set; }
    }
}
