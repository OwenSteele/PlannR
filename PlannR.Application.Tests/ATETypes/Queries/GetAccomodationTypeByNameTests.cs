using PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeByName;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.ATETypes.Queries
{
    public class GetAccomodationTypeByNameTests : ATETypeTestsBase
    {
        [Fact]
        public async Task WHEN_repository_is_queried_with_typeName_THEN_matching_entity_is_returned()
        {
            var handler = new GetAccomodationTypeByNameQueryHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var existing = (await _mockRepository.Object.ListAllAsync()).FirstOrDefault();
            var query = new GetAccomodationTypeByNameQuery() { Name = existing.Name };

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<AccomodationTypeByNameDataModel>();
            result.Name.ShouldBeEquivalentTo(existing.Name);
            result.AccomodationTypeId.ShouldBeEquivalentTo(existing.AccomodationTypeId);
        }

        [Fact]
        public async Task WHEN_repository_is_queried_with_InvalidAccomodationId_THEN_null_is_returned()
        {
            var handler = new GetAccomodationTypeByNameQueryHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var query = new GetAccomodationTypeByNameQuery() { Name = string.Empty };

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeNull();
        }
    }
}
