using PlannR.Application.Features.Routes.Queries.GetRouteDetail;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.BaseRoute.Queries
{// As the three booking derived types are Identical, only testing one as all have same functionality

    public class GetRouteDetailTests : RouteTestsBase
    {
        [Fact]
        public async Task WHEN_repository_is_queried_with_routeId_THEN_matching_entity_is_returned()
        {
            var handler = new GetRouteDetailQueryHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var existing = (await _mockRepository.Object.ListAllAsync()).FirstOrDefault();
            var query = new GetRouteDetailQuery() { RouteId = existing.RouteId };

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<RouteDetailDataModel>();
            result.RouteId.ShouldBeEquivalentTo(existing.RouteId);

            result.Trip.ShouldNotBeNull();
        }

        [Fact]
        public async Task WHEN_repository_is_queried_with_InvalidRouteId_THEN_null_is_returned()
        {
            var handler = new GetRouteDetailQueryHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var query = new GetRouteDetailQuery() { RouteId = new Guid() };

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeNull();
        }
    }
}
