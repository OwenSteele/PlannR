//using Newtonsoft.Json;
//using PlannR.API.Tests.Controllers;
//using PlannR.Application.Features.Locations.Queries.GetLocationsList;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Xunit;

//namespace PlannR.API.Tests.Locations.Controllers
//{
//    public class GetAllLocationsTests : ControllerTestsBase
//    {
//        public GetAllLocationsTests(WebHostBaseFactory<Startup> factory) : base(factory)
//        {
//        }

//        [Fact]
//        public async Task WHEN_api_Locations_is_queried_THEN_Success_StatusCode_returned()
//        {
//            var client = _factory.CreateNewClient();

//            var response = await client.GetAsync("/api/Locations");

//            response.EnsureSuccessStatusCode();

//            var message = await response.Content.ReadAsStringAsync();

//            var model = JsonConvert.DeserializeObject<ICollection<LocationListDataModel>>(message);

//            Assert.IsType<List<LocationListDataModel>>(model);
//            Assert.NotEmpty(model);
//        }
//    }
//}
