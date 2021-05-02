using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PlannR.API.Tests.Controllers;
using PlannR.Application.Features.Events.Queries.GetEventsList;
using PlannR.Application.Features.Transports.Queries.GetTransportsList;
using PlannR.Application.Features.Trips.Queries.GetTripsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.API.Tests.EventsTests.Controllers
{
    public class GetAllEventsTests : ControllerTestsBase
    {
        public GetAllEventsTests(WebHostBaseFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task WHEN_api_events_is_queried_THEN_Success_StatusCode_returned()
        {
            var client = _factory.CreateNewClient();

            var response = await client.GetAsync("/api/Events");

            response.EnsureSuccessStatusCode();

            var message = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<ICollection<EventListViewModel>>(message);

            Assert.IsType<List<EventListViewModel>>(model);
        }
    }
}
