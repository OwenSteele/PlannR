using PlannR.Application.Exceptions;
using PlannR.Application.Features.Accomodations.Commands.CreateAccomodation;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.BaseATE.Commands
{

    public class CreateAccomodationTests : ATETestsBase
    {
        // As the three booking derived types are Identical, only testing one as all have same functionality

        [Fact]
        public async Task WHEN_acommodation_is_added_with_handler_THEN_new_acommodation_is_in_repository()
        {
            var handler = new CreateAccomodationCommandHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var command = new CreateAccomodationCommand()
            {
                Name = "create accom 1",
                TripId = Guid.Parse("{b793c915-cb6c-4eca-9541-03e1713e82d5}")
            };

            await handler.Handle(command, CancellationToken.None);

            var result = await _mockRepository.Object.ListAllAsync();

            result.Count.ShouldBe(3);
            result.FirstOrDefault(x => x.Name == command.Name).ShouldNotBeNull();
        }

        [Fact]
        public async Task WHEN_acommodation_is_added_without_TripId_THEN_validationException_is_thrown()
        {
            var handler = new CreateAccomodationCommandHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var command = new CreateAccomodationCommand()
            {
                Name = "create accom 1"
            };

            await Should.ThrowAsync<ValidationException>(async () => await handler.Handle(command, CancellationToken.None));
        }
    }
}
