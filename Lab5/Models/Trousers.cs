using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class Trousers
    {
        public Trousers()
        {
            Colors = new List<ColorTrousers>();
            Sizes = new List<SizeTrousers>();
            Photos = new List<PhotoTrousers>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        public int BrandId { get; set; }
        public string Materials { get; set; }
        public int Length { get; set; }
        public int CountryId { get; set; }
        //===================================
        public virtual Country Country { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<ColorTrousers> Colors { get; set; }
        public virtual ICollection<SizeTrousers> Sizes { get; set; }
        public virtual ICollection<PhotoTrousers> Photos { get; set; }
    }
}