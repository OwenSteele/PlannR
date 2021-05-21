using PlannR.Application.Contracts.Persistence.Seed;
using PlannR.Domain.Entities;
using System.Threading.Tasks;

namespace PlannR.Persistence.Seed
{
    public class CreateSeededData
    {
        private readonly PlannrDbContext _dbContext;
        private readonly IFileReaderService _service;

        public CreateSeededData(PlannrDbContext dbContext, IFileReaderService service)
        {
            _dbContext = dbContext;
            _service = service;

        }
        public async Task SeedAsync()
        {
            _dbContext.Database.EnsureCreated();

            var accomodations = await _service.GetJsonData<Accomodation>("accomodationData.json");

            await _dbContext.Accomodations.AddRangeAsync(accomodations);
            await _dbContext.SaveChangesAsync();
        }
    }
}
