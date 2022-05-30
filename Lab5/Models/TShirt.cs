using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lab5.Models
{
    public class TShirt
    {
        public TShirt()
        {
            Colors = new List<ColorTShirt>();
            Sizes = new List<SizeTShirt>();
            Photos = new List<PhotoTShirt>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        public int BrandId { get; set; }
        public string Materials { get; set; }
        public string Neckline { get; set; }
        public string SleeveLength { get; set; }
        public int CountryId { get; set; }
        //===================================
        //[JsonIgnore]
        public virtual Brand Brand { get; set; }
        //[JsonIgnore]
        public virtual Country Country { get; set; }
        public virtual ICollection<ColorTShirt> Colors { get; set; }
        public virtual ICollection<SizeTShirt> Sizes { get; set; }
        public virtual ICollection<PhotoTShirt> Photos { get; set; }
    }
}
