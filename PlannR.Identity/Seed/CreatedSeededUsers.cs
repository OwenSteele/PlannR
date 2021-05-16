using Microsoft.AspNetCore.Identity;
using PlannR.Identity.Models;
using System.Threading.Tasks;

namespace PlannR.Identity.Seed
{
    public class CreatedSeededUsers
    {
        public static async Task SeedAsync(UserManager<PlannrUser> userManager)
        {
            var user = new PlannrUser
            {
                FirstName = "Owen",
                LastName = "Steele",
                UserName = "OwenSteele",
                Email = "owen@owensteele.co.uk",
                EmailConfirmed = true
            };

            var result = await userManager.FindByEmailAsync(user.Email);
            if (result == null)
            {
                await userManager.CreateAsync(user, "Test1234!");
            }
        }
    }
}
