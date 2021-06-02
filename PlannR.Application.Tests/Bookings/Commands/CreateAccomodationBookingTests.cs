using PlannR.Application.Exceptions;
using PlannR.Application.Features.Accomodations.Bookings.Commands.CreateAccomodationBooking;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.Bookings.Commands
{

    public class CreateAccomodationBookingTests : BookingTestsBase
    {
        // As the three booking derived types are Identical, only testing one as all have same functionality
        [Fact]
        public async Task WHEN_acommodationBooking_is_added_with_handler_THEN_new_acommodationBooking_is_in_repository()
        {
            var handler = new CreateAccomodationBookingCommandHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var command = new CreateAccomodationBookingCommand()
            {
                AccomodationId = Guid.Parse("{27ff0fbc-6332-4d0c-ac6a-690097f0415f}"),
                Name = "create booking 4",
                Link = "https://cb4.co.uk",
                Email = "cx@cx.cx",
                Comments = "cb1",
                Cost = 50.00m
            };

            await handler.Handle(command, CancellationToken.None);

            var result = await _mockRepository.Object.ListAllAsync();

            result.Count.ShouldBe(5);
            result.FirstOrDefault(x => x.Name == command.Name).ShouldNotBeNull();
        }

        [Fact]
        public async Task WHEN_acommodationBooking_is_added_without_AccomodationId_THEN_validationException_is_thrown()
        {
            var handler = new CreateAccomodationBookingCommandHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var command = new CreateAccomodationBookingCommand()
            {
                Name = "create invalid booking",
                Link = "https://icb.co.uk",
                Email = "icx@icx.icx",
                Comments = "icb",
                Cost = 50.00m
            };

            await Should.ThrowAsync<ValidationException>(async () => await handler.Handle(command, CancellationToken.None));
        }
    }
}
