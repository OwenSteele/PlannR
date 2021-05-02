using PlannR.Application.Features.Accomodations.Queries.GetAccomodationListByTripIdWithBookings;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.BaseATE.Queries
{
    public class GetAllOfTripByIdWithBookingsTests : ATETestsBase
    {
        [InlineData("{14b31a2f-5b5d-4ac3-85e2-28ad5cba8165}", 1, true)]
        [InlineData("{180167ab-cf2c-4000-ac6e-633bd8ffb069}", 1, false)]
        [InlineData("{14b31a2f-5b5d-4ac3-85e2-28ad5cba8164}", 0, false)]
        [Theory]
        public async Task WHEN_repository_is_queried_with_tripId_included_THEN_matching_entity_with_tripId_are_returned_with_bookings(
            string guidString, int expectedResults, bool expectBookings)
        {
            var guid = Guid.Parse(guidString);

            var handler = new GetAccomodationListByTripIdWithBookingsQueryHandler(_mapper, _mockRepository.Object);

            var query = new GetAccomodationListByTripIdWithBookingsQuery() { TripId = guid };

            var result = await handler.Handle(query, CancellationToken.None);

            var notNull = result?.FirstOrDefault()?.Booking != null ? true : false;

            Assert.Equal(expectedResults, result?.Count ?? 0);
            Assert.Equal(expectBookings, notNull);
        }
    }
}
