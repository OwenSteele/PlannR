using PlannR.Application.Features.Trips.Queries.GetTripsDetail;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.BaseTrip.Queries
{// As the three booking derived types are Identical, only testing one as all have same functionality

    public class GetTripDetailTests : TripTestsBase
    {
        [Fact]
        public async Task WHEN_repository_is_queried_with_tripId_THEN_matching_entity_is_returned()
        {
            var handler = new GetTripDetailQueryHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var existing = (await _mockRepository.Object.ListAllAsync()).FirstOrDefault();
            var query = new GetTripDetailQuery() { TripId = existing.TripId };

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<TripDetailViewModel>();
            result.TripId.ShouldBeEquivalentTo(existing.TripId);
        }

        [Fact]
        public async Task WHEN_repository_is_queried_with_InvalidTripId_THEN_null_is_returned()
        {
            var handler = new GetTripDetailQueryHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var query = new GetTripDetailQuery() { TripId = new Guid() };

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeNull();
        }
    }
}
