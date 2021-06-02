using PlannR.Application.Features.Accomodations.Types.Commands.CreateAccomodationType;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.ATETypes.Commands
{

    public class CreateAccomodationTypeTests : ATETypeTestsBase
    {
        // As the three booking derived types are Identical, only testing one as all have same functionality

        [Fact]
        public async Task WHEN_acommodation_is_added_with_handler_THEN_new_acommodation_is_in_repository()
        {
            var handler = new CreateAccomodationTypeCommandHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var command = new CreateAccomodationTypeCommand()
            {
                Name = "create accomType 1"
            };

            await handler.Handle(command, CancellationToken.None);

            var result = await _mockRepository.Object.ListAllAsync();

            result.Count.ShouldBe(3);
            result.FirstOrDefault(x => x.Name == command.Name).ShouldNotBeNull();
        }
    }
}
