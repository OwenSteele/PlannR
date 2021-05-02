using PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeList;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.ATETypes.Queries
{
    public class GetAccomodationTypeListTests : ATETypeTestsBase
    {
        [Fact]
        public async Task WHEN_repository_is_queried_ListAllAsync_THEN_all_entities_are_returned()
        {
            var handler = new GetAccomodationTypeListQueryHandler(_mapper, _mockRepository.Object);

            var query = new GetAccomodationTypeListQuery();

            await handler.Handle(query, CancellationToken.None);

            var result = await _mockRepository.Object.ListAllAsync();
            result.Count.ShouldBe(2);
        }
    }
}
