using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PlannR.Identity
{
    public class PlannrIdentityDbContextFactory : IDesignTimeDbContextFactory<PlannrIdentityDbContext>
    {
        public PlannrIdentityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PlannrIdentityDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PlannrIdentityDb;Integrated Security=True;Connect Timeout=30;");
            return new PlannrIdentityDbContext(optionsBuilder.Options);
        }
    }
}
