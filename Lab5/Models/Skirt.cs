using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class Skirt
    {
        public Skirt()
        {
            Colors = new List<ColorSkirt>();
            Sizes = new List<SizeSkirt>();
            Photos = new List<PhotoSkirt>();
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
        public virtual ICollection<ColorSkirt> Colors { get; set; }
        public virtual ICollection<SizeSkirt> Sizes { get; set; }
        public virtual ICollection<PhotoSkirt> Photos { get; set; }
    }
}
