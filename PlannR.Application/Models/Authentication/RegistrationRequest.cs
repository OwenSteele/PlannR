using System.ComponentModel.DataAnnotations;

namespace PlannR.Application.Models.Authentication
{
    public class RegistrationRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        public string UserName { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

    }
}
