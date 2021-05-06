using PlannR.Application.Exceptions;
using PlannR.Application.Features.Routes.Commands.UpdateRoute;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.BaseRoute.Commands
{
    public class UpdateRouteTests : RouteTestsBase
    {
        [Fact]
        public async Task WHEN_acommodation_is_updated_with_handler_THEN_acommodation_is_updated_in_repository()
        {
            var handler = new UpdateRouteCommandHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var existing = (await _mockRepository.Object.ListAllAsync()).FirstOrDefault();

            var newName = "updated accom 1";

            existing.Name = newName;

            var command = _mapper.Map<UpdateRouteCommand>(existing);

            await handler.Handle(command, CancellationToken.None);

            var result = await _mockRepository.Object.ListAllAsync();

            result.Count.ShouldBe(2);
            result.FirstOrDefault().Name.ShouldBeEquivalentTo(newName);
        }

        [Fact]
        public async Task WHEN_acommodation_is_updated_without_RouteId_THEN_validationException_is_thrown()
        {
            var handler = new UpdateRouteCommandHandler(_mockAuthorisationService.Object, _mapper, _mockRepository.Object);

            var existing = (await _mockRepository.Object.ListAllAsync()).FirstOrDefault();

            existing.RouteId = new Guid();

            var command = _mapper.Map<UpdateRouteCommand>(existing);

            await Should.ThrowAsync<ValidationException>(async () => await handler.Handle(command, CancellationToken.None));
        }
    }
}
