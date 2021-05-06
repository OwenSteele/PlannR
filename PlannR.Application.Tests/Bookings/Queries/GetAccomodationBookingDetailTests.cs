using PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingDetail;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.Bookings.Queries
{// As the three booking derived types are Identical, only testing one as all have same functionality

    public class GetAccomodationBookingDetailTests : BookingTestsBase
    {
        [Fact]
        public async Task WHEN_repository_is_queried_with_accomodationBookingId_THEN_matching_entity_is_returned()
        {
            var handler = new GetAccomodationBookingDetailQueryHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var existing = (await _mockRepository.Object.ListAllAsync()).FirstOrDefault();

            var query = new GetAccomodationBookingDetailQuery() { Id = existing.BookingId };

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<AccomodationBookingDetailViewModel>();
            result.BookingId.ShouldBeEquivalentTo(existing.BookingId);
        }

        [Fact]
        public async Task WHEN_repository_is_queried_with_InvalidAccomodationBookingId_THEN_null_is_returned()
        {
            var handler = new GetAccomodationBookingDetailQueryHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var query = new GetAccomodationBookingDetailQuery() { Id = new Guid() };

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeNull();
        }
    }
}
