using PlannR.Application.Features.Trips.Queries.GetTripListOnDate;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.BaseTrip.Queries
{
    public class GetAllOnDateByTripIdTests : TripTestsBase
    {
        [InlineData("2022-12-05T12:00:00.000Z", 1)]
        [InlineData("2023-12-05T12:00:00.000Z", 1)]
        [InlineData("2024-12-05T12:00:00.000Z", 0)]
        [Theory]
        public async Task WHEN_repository_is_queried_with_tripId_and_date_included_THEN_matching_entity_with_tripId_and_date_are_returned(
            string dateString, int expectedResults)
        {
            var date = DateTime.Parse(dateString);

            var handler = new GetTripListOnDateQueryHandler(_mapper, _mockRepository.Object);

            var query = new GetTripListOnDateQuery() { DateTime = date };

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.Equal(expectedResults, result?.Count ?? 0);
        }
    }
}
