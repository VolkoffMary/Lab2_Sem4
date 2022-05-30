using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class Brand
    {
        public Brand()
        {
            TShorts = new List<TShirt>();
            Dresses = new List<Dress>();
            Skirts = new List<Skirt>();
            TrousersColl = new List<Trousers>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Назва бренду")]
        public string Name { get; set; }
        [Display(Name = "Рік заснування бренду")]
        public int Year { get; set; }
        public string PhotoUrl { get; set; }
        public virtual ICollection<TShirt> TShorts { get; set; }
        public virtual ICollection<Dress> Dresses { get; set; }
        public virtual ICollection<Skirt> Skirts { get; set; }
        public virtual ICollection<Trousers> TrousersColl { get; set; }
    }
}
