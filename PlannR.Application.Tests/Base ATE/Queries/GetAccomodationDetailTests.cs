using PlannR.Application.Features.Accomodations.Queries.GetAccomodationsDetail;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.BaseATE.Queries
{// As the three booking derived types are Identical, only testing one as all have same functionality

    public class GetAccomodationDetailTests : ATETestsBase
    {
        [Fact]
        public async Task WHEN_repository_is_queried_with_tripId_THEN_matching_entity_is_returned()
        {
            var handler = new GetAccomodationDetailQueryHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var existing = (await _mockRepository.Object.ListAllAsync()).FirstOrDefault();
            var query = new GetAccomodationDetailQuery() { Id = existing.AccomodationId };

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<AccomodationDetailDataModel>();
            result.AccomodationId.ShouldBeEquivalentTo(existing.AccomodationId);

            result.Location.ShouldNotBeNull();
            result.AccomodationType.ShouldNotBeNull();
            result.Trip.ShouldNotBeNull();
        }

        [Fact]
        public async Task WHEN_repository_is_queried_with_InvalidAccomodationId_THEN_null_is_returned()
        {
            var handler = new GetAccomodationDetailQueryHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var query = new GetAccomodationDetailQuery() { Id = new Guid() };

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeNull();
        }
    }
}
