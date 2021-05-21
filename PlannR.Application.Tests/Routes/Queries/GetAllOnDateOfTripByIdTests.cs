using PlannR.Application.Features.Routes.Queries.GetRouteListOnDate;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.BaseRoute.Queries
{
    public class GetAllOnDateOfTripByIdTests : RouteTestsBase
    {
        [InlineData("{14b31a2f-5b5d-4ac3-85e2-28ad5cba8165}", "2022-12-05T12:00:00.000Z", 1)]
        [InlineData("{180167ab-cf2c-4000-ac6e-633bd8ffb069}", "2023-12-05T12:00:00.000Z", 1)]
        [InlineData("{14b31a2f-5b5d-4ac3-85e2-28ad5cba8165}", "2023-12-05T12:00:00.000Z", 0)]
        [InlineData("{14b31a2f-5b5d-4ac3-85e2-28ad5cba8164}", "2022-12-05T12:00:00.000Z", 0)]
        [Theory]
        public async Task WHEN_repository_is_queried_with_tripId_and_date_included_THEN_matching_entity_with_tripId_and_date_are_returned(
            string guidString, string dateString, int expectedResults)
        {
            var guid = Guid.Parse(guidString);
            var date = DateTime.Parse(dateString);

            var handler = new GetRouteListOnDateQueryHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var query = new GetRouteListOnDateQuery() { TripId = guid, Date = date };

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.Equal(expectedResults, result?.Count ?? 0);
        }
    }
}
