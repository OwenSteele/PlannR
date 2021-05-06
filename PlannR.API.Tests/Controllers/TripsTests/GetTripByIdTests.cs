//using System.Threading.Tasks;
//using Xunit;

//namespace PlannR.API.Tests.Controllers.Trips
//{
//    public class GetTripByIdTests : ControllerTestsBase
//    {
//        public GetTripByIdTests(WebHostBaseFactory<Startup> factory) : base(factory)
//        {
//        }

//        [Fact]
//        public async Task WHEN_api_trips_by_id_is_queried_without_authentication_THEN_the_request_is_denied()
//        {
//            var client = _factory.CreateNewClient();

//            var response = await client.GetAsync($"/api/Trips/x");

//            Assert.False(response.IsSuccessStatusCode);
//            Assert.Equal(404, (int)response.StatusCode);
//        }
//    }
//}
