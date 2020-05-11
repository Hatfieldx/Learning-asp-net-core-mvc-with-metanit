using System.ComponentModel.DataAnnotations;

namespace EFDataApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Имя пользователя")]
        [StringLength(10, MinimumLength = 1)]
        public string Name { get; set; } // имя пользователя
        [Required][Range(18, 90)]
        [Display(Name = "Возраст")]
        public int Age { get; set; } // возраст пользователя
    }
}
