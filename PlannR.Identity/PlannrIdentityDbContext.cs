using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlannR.Identity.Models;

namespace PlannR.Identity
{
    public class PlannrIdentityDbContext : IdentityDbContext<PlannrUser>
    {
        public PlannrIdentityDbContext(DbContextOptions<PlannrIdentityDbContext> options) : base(options)
        {
        }
    }
}