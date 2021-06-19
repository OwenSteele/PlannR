using PlannR.App.Infrastructure.Validation;
using System.ComponentModel.DataAnnotations;

namespace PlannR.App.Infrastructure.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [StringLength(30, ErrorMessage = "This must be between 2 and 30 characters long.", MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(30, ErrorMessage = "This must be between 2 and 30 characters long.", MinimumLength = 2)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(20, ErrorMessage = "This must be between 3 and 20 characters long.", MinimumLength = 3)]
        public string Username { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Password]
        public string Password { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [MustMatch("Password", ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm { get; set; }
    }
}
