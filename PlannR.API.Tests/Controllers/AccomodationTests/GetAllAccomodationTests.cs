using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PlannR.API.Tests.Controllers;
using PlannR.Application.Features.Transports.Queries.GetTransportsList;
using PlannR.Application.Features.Trips.Queries.GetTripsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PlannR.API.Tests.AccomodationTests.Controllers
{
    public class GetAllAccomodationTests : ControllerTestsBase
    {
        public GetAllAccomodationTests(WebHostBaseFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task WHEN_api_accomodation_is_queried_THEN_Success_StatusCode_returned()
        {
            var client = _factory.CreateNewClient();

            var response = await client.GetAsync("/api/Accomodation");

            response.EnsureSuccessStatusCode();

            var message = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<ICollection<TransportListViewModel>>(message);

            Assert.IsType<List<TransportListViewModel>>(model);
        }
    }
}
