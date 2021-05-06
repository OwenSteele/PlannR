using PlannR.Application.Exceptions;
using PlannR.Application.Features.Accomodations.Bookings.Commands.UpdateAccomodationBooking;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.Bookings.Commands
{
    // As the three booking derived types are Identical, only testing one as all have same functionality
    public class UpdateAccomodationBookingTests : BookingTestsBase
    {
        [Fact]
        public async Task WHEN_acommodationBooking_is_updated_with_handler_THEN_acommodationBooking_is_updated_in_repository()
        {
            var handler = new UpdateAccomodationBookingCommandHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var existing = (await _mockRepository.Object.ListAllAsync()).FirstOrDefault();

            var newName = "updated booking 1";

            existing.Name = newName;

            var command = _mapper.Map<UpdateAccomodationBookingCommand>(existing);

            await handler.Handle(command, CancellationToken.None);

            var result = await _mockRepository.Object.ListAllAsync();

            result.Count.ShouldBe(4);
            result.FirstOrDefault().Name.ShouldBeEquivalentTo(newName);
        }

        [Fact]
        public async Task WHEN_acommodationBooking_is_updated_without_BookingId_THEN_validationException_is_thrown()
        {
            var handler = new UpdateAccomodationBookingCommandHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var existing = (await _mockRepository.Object.ListAllAsync()).FirstOrDefault();

            existing.BookingId = new Guid();

            var command = _mapper.Map<UpdateAccomodationBookingCommand>(existing);

            await Should.ThrowAsync<ValidationException>(async () => await handler.Handle(command, CancellationToken.None));
        }
    }
}
