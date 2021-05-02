using PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingList;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.Bookings.Queries
{
    // As the three booking derived types are Identical, only testing one as all have same functionality
    public class ListAllAccomodationBookingTests : BookingTestsBase
    {
        [Fact]
        public async Task WHEN_repository_is_queried_ListAllAsync_THEN_all_entities_are_returned()
        {
            var handler = new GetAccomodationBookingListQueryHandler(_mapper, _mockRepository.Object);

            var query = new GetAccomodationBookingListQuery();

            await handler.Handle(query, CancellationToken.None);

            var result = await _mockRepository.Object.ListAllAsync();
            result.Count.ShouldBe(4);
        }
    }
}
