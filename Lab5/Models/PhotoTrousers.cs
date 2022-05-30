using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5.Models
{
    public class PhotoTrousers
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("PhotoId")]
        public virtual Photo Photo { get; set; }
        [Required]
        [ForeignKey("TrousersId")]
        public virtual Trousers Trousers { get; set; }
    }
}
