using PlannR.Application.Features.Accomodations.Commands.DeleteAccomodation;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.BaseATE.Commands
{
    // As the three booking derived types are Identical, only testing one as all have same functionality
    public class DeleteAccomodationTests : ATETestsBase
    {
        [Fact]
        public async Task WHEN_acommodation_is_deleted_with_handler_THEN_acommodation_is_missing_in_repository()
        {
            var handler = new DeleteAccomodationCommandHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var existing = (await _mockRepository.Object.ListAllAsync()).FirstOrDefault();

            var command = new DeleteAccomodationCommand() { AccomodationId = existing.AccomodationId };

            await handler.Handle(command, CancellationToken.None);

            var result = await _mockRepository.Object.ListAllAsync();

            result.Count.ShouldBe(1);
            result.FirstOrDefault(Xunit => Xunit.Name == existing.Name).ShouldBeNull();
        }
    }
}
