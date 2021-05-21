using PlannR.Application.Features.Routes.Queries.GetRoutesList;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.BaseRoute.Queries
{
    // As the three booking derived types are Identical, only testing one as all have same functionality
    public class ListAllRouteTests : RouteTestsBase
    {
        [Fact]
        public async Task WHEN_repository_is_queried_ListAllAsync_THEN_all_entities_are_returned()
        {
            var handler = new GetRouteListQueryHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var query = new GetRouteListQuery();

            await handler.Handle(query, CancellationToken.None);

            var result = await _mockRepository.Object.ListAllAsync();
            result.Count.ShouldBe(2);
        }
    }
}
