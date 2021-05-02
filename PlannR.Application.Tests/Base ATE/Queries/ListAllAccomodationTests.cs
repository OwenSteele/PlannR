using PlannR.Application.Features.Accomodations.Queries.GetAccomodationsList;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.BaseATE.Queries
{
    // As the three booking derived types are Identical, only testing one as all have same functionality
    public class ListAllAccomodationTests : ATETestsBase
    {
        [Fact]
        public async Task WHEN_repository_is_queried_ListAllAsync_THEN_all_entities_are_returned()
        {
            var handler = new GetAccomodationListQueryHandler(_mapper, _mockRepository.Object);

            var query = new GetAccomodationListQuery();

            await handler.Handle(query, CancellationToken.None);

            var result = await _mockRepository.Object.ListAllAsync();
            result.Count.ShouldBe(2);
        }
    }
}
