using PlannR.Application.Features.Trips.Commands.CreateTrip;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.BaseTrip.Commands
{

    public class CreateTripTests : TripTestsBase
    {

        [Fact]
        public async Task WHEN_acommodation_is_added_with_handler_THEN_new_acommodation_is_in_repository()
        {
            var handler = new CreateTripCommandHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var command = new CreateTripCommand()
            {
                Name = "create trip 1"
            };

            await handler.Handle(command, CancellationToken.None);

            var result = await _mockRepository.Object.ListAllAsync();

            result.Count.ShouldBe(3);
            result.FirstOrDefault(x => x.Name == command.Name).ShouldNotBeNull();
        }
    }
}
