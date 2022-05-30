using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class Photo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Посилання на фото")]
        public string Url { get; set; }
    }
}