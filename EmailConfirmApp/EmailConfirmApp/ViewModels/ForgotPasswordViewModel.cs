using System.ComponentModel.DataAnnotations;

namespace EmailConfirmApp.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
