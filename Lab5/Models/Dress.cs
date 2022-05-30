using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class Dress
    {
        public Dress()
        {
            Colors = new List<ColorDress>();
            Sizes = new List<SizeDress>();
            Photos = new List<PhotoDress>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        public int BrandId { get; set; }
        public string Materials { get; set; }
        public int Length { get; set; }
        public string Neckline { get; set; }
        public string SleeveLength { get; set; }
        public int CountryId { get; set; }
        //===================================
        public virtual Country Country { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<ColorDress> Colors { get; set; }
        public virtual ICollection<SizeDress> Sizes { get; set; }
        public virtual ICollection<PhotoDress> Photos { get; set; }
    }
}