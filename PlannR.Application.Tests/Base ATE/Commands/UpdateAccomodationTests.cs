using PlannR.Application.Exceptions;
using PlannR.Application.Features.Accomodations.Commands.UpdateAccomodation;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.BaseATE.Commands
{
    // As the three booking derived types are Identical, only testing one as all have same functionality
    public class UpdateAccomodationTests : ATETestsBase
    {
        [Fact]
        public async Task WHEN_acommodation_is_updated_with_handler_THEN_acommodation_is_updated_in_repository()
        {
            var handler = new UpdateAccomodationCommandHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var existing = (await _mockRepository.Object.ListAllAsync()).FirstOrDefault();

            var newName = "updated accom 1";

            existing.Name = newName;

            var command = _mapper.Map<UpdateAccomodationCommand>(existing);

            await handler.Handle(command, CancellationToken.None);

            var result = await _mockRepository.Object.ListAllAsync();

            result.Count.ShouldBe(2);
            result.FirstOrDefault().Name.ShouldBeEquivalentTo(newName);
        }

        [Fact]
        public async Task WHEN_acommodation_is_updated_without_AccomodationId_THEN_validationException_is_thrown()
        {
            var handler = new UpdateAccomodationCommandHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var existing = (await _mockRepository.Object.ListAllAsync()).FirstOrDefault();

            existing.AccomodationId = new Guid();

            var command = _mapper.Map<UpdateAccomodationCommand>(existing);

            await Should.ThrowAsync<ValidationException>(async () => await handler.Handle(command, CancellationToken.None));
        }
    }
}
