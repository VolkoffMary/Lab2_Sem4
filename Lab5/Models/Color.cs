using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class Color
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім, та строго має довжину в 6 символів")]
        [Display(Name = "Hex-значення кольору")]
        [MinLength(6), MaxLength(6)]
        public string Value { get; set; }
    }
}
