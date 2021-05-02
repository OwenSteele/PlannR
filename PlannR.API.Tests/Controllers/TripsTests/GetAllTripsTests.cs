using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PlannR.API.Tests.Controllers;
using PlannR.Application.Features.Trips.Queries.GetTripsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.API.Tests.Trips.Controllers
{
    public class GetAllTripsTests : ControllerTestsBase
    {
        public GetAllTripsTests(WebHostBaseFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task WHEN_api_trips_is_queried_THEN_Success_StatusCode_returned()
        {
            var client = _factory.CreateNewClient();

            var response = await client.GetAsync("/api/Trips");

            response.EnsureSuccessStatusCode();

            var message = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<ICollection<TripListViewModel>>(message);

            Assert.IsType<List<TripListViewModel>>(model);
            Assert.NotEmpty(model);
        }
    }
}
