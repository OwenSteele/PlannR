//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;

//namespace PlannR.Persistence
//{
//    public class PlannrDbContextFactory : IDesignTimeDbContextFactory<PlannrDbContext>
//    {
//        public PlannrDbContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<PlannrDbContext>();
//            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PlannrDb;Integrated Security=True;Connect Timeout=30;");

//            return new PlannrDbContext(optionsBuilder.Options);
//        }
//    }
//}