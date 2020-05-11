using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ValidationApp.Models
{
    public class Person
    {
        [Required(ErrorMessage ="LALAALLLALA")]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Remote(controller:"Home", action:"CheckAge", ErrorMessage = "Вы должны быть старше 18")]
        public int Age { get; set; }
    }
}
