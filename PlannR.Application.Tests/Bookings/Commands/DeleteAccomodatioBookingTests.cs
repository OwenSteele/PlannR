using PlannR.Application.Features.Accomodations.Bookings.Commands.DeleteAccomodationBooking;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.Bookings.Commands
{
    // As the three booking derived types are Identical, only testing one as all have same functionality
    public class DeleteAccomodationBookingTests : BookingTestsBase
    {
        [Fact]
        public async Task WHEN_acommodationBooking_is_deleted_with_handler_THEN_acommodationBooking_is_missing_in_repository()
        {
            var handler = new DeleteAccomodationBookingCommandHandler(_mapper, _mockRepository.Object);

            var existing = (await _mockRepository.Object.ListAllAsync()).FirstOrDefault();

            var command = new DeleteAccomodationBookingCommand() { BookingId = existing.BookingId };

            await handler.Handle(command, CancellationToken.None);

            var result = await _mockRepository.Object.ListAllAsync();

            //result.Count.ShouldBe(3);
            result.FirstOrDefault(Xunit => Xunit.Name == existing.Name).ShouldBeNull();
        }
    }
}
