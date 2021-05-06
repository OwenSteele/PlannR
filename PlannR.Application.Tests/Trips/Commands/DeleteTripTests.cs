using PlannR.Application.Features.Trips.Commands.DeleteTrip;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.BaseTrip.Commands
{
    public class DeleteTripTests : TripTestsBase
    {
        [Fact]
        public async Task WHEN_acommodation_is_deleted_with_handler_THEN_acommodation_is_missing_in_repository()
        {
            var handler = new DeleteTripCommandHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var existing = (await _mockRepository.Object.ListAllAsync()).FirstOrDefault();

            var command = new DeleteTripCommand() { TripId = existing.TripId };

            await handler.Handle(command, CancellationToken.None);

            var result = await _mockRepository.Object.ListAllAsync();

            result.Count.ShouldBe(1);
            result.FirstOrDefault(Xunit => Xunit.Name == existing.Name).ShouldBeNull();
        }
    }
}
