using PlannR.Application.Features.Accomodations.Queries.GetAccomodationListByTripId;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.BaseATE.Queries
{
    public class GetAllOfTripByIdTests : ATETestsBase
    {
        [InlineData("{14b31a2f-5b5d-4ac3-85e2-28ad5cba8165}", 1)]
        [InlineData("{180167ab-cf2c-4000-ac6e-633bd8ffb069}", 1)]
        [InlineData("{14b31a2f-5b5d-4ac3-85e2-28ad5cba8164}", 0)]
        [Theory]
        public async Task WHEN_repository_is_queried_with_tripId_included_THEN_matching_entity_with_tripId_are_returned(
            string guidString, int expectedResults)
        {
            var guid = Guid.Parse(guidString);

            var handler = new GetAccomodationListByTripIdQueryHandler(_mapper, _mockRepository.Object);

            var query = new GetAccomodationListByTripIdQuery() { TripId = guid };

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.Equal(expectedResults, result?.Count ?? 0);
        }

        [Fact]
        public async Task WHEN_repository_is_queried_with_InvalidTripId_THEN_null_is_returned()
        {
            var handler = new GetAccomodationListByTripIdQueryHandler(_mapper, _mockRepository.Object);

            var query = new GetAccomodationListByTripIdQuery() { TripId = new Guid() };

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeEmpty();
        }
    }
}
