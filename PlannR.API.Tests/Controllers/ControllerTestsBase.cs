using Xunit;

namespace PlannR.API.Tests.Controllers
{
    // IClassFixture used to prevent recreation of context for every class of tests
    public class ControllerTestsBase : IClassFixture<WebHostBaseFactory<Startup>>
    {
        protected readonly WebHostBaseFactory<Startup> _factory;

        public ControllerTestsBase(WebHostBaseFactory<Startup> factory)
        {
            _factory = factory;
        }
    }
}