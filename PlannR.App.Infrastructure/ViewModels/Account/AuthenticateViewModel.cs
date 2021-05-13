using System.ComponentModel.DataAnnotations;

namespace PlannR.App.Infrastructure.ViewModels.Account
{
    public class AuthenticateViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
