using PlannR.Application.Features.Routes.Commands.DeleteRoute;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.Application.Tests.BaseRoute.Commands
{
    public class DeleteRouteTests : RouteTestsBase
    {
        [Fact]
        public async Task WHEN_acommodation_is_deleted_with_handler_THEN_acommodation_is_missing_in_repository()
        {
            var handler = new DeleteRouteCommandHandler(_mapper, _mockRepository.Object);

            var existing = (await _mockRepository.Object.ListAllAsync()).FirstOrDefault();

            var command = new DeleteRouteCommand() { RouteId = existing.RouteId };

            await handler.Handle(command, CancellationToken.None);

            var result = await _mockRepository.Object.ListAllAsync();

            result.Count.ShouldBe(1);
            result.FirstOrDefault(Xunit => Xunit.Name == existing.Name).ShouldBeNull();
        }
    }
}
