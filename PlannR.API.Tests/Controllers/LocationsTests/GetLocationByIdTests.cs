//using System.Threading.Tasks;
//using Xunit;

//namespace PlannR.API.Tests.Controllers.Locations
//{
//    public class GetLocationByIdTests : ControllerTestsBase
//    {
//        public GetLocationByIdTests(WebHostBaseFactory<Startup> factory) : base(factory)
//        {
//        }

//        [Fact]
//        public async Task WHEN_api_Locations_by_id_is_queried_without_authentication_THEN_the_request_is_denied()
//        {
//            var client = _factory.CreateNewClient();

//            var response = await client.GetAsync($"/api/Locations/x");

//            Assert.False(response.IsSuccessStatusCode);
//            Assert.Equal(404, (int)response.StatusCode);
//        }
//    }
//}
