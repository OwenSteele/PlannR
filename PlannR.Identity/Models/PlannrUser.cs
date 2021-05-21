using Microsoft.AspNetCore.Identity;

namespace PlannR.Identity.Models
{
    public class PlannrUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
