using Microsoft.EntityFrameworkCore;
using Moq;
using PlannR.Application.Contracts.Identity;
using PlannR.Domain.EntityTypes;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Persistence.Tests.IntegrationTests
{
    public class PlannrDbContextTests
    {
        private readonly string _userId;
        private readonly Mock<ILoggedInService> _mockLoggedInService;
        private readonly PlannrDbContext _dbContext;

        public PlannrDbContextTests()
        {
            var options = new DbContextOptionsBuilder<PlannrDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _userId = new Guid().ToString();

            _mockLoggedInService = new Mock<ILoggedInService>();
            _mockLoggedInService.Setup(x => x.UserId).Returns(_userId);

            _dbContext = new PlannrDbContext(options, _mockLoggedInService.Object);
        }

        [Fact]
        public async Task WHEN_SaveChangesAsync_is_called_THEN_auditable_properties_are_set_as_UserId()
        {
            var accomodationType = new AccomodationType()
            {
                AccomodationTypeId = Guid.NewGuid(),
                Name = "ContextTestAccomType"
            };

            _dbContext.AccomodationTypes.Add(accomodationType);

            var result = await _dbContext.SaveChangesAsync();

            accomodationType.CreatedBy.ShouldBeEquivalentTo(_userId);
            result.ShouldBeGreaterThan(0);
        }
    }
}
