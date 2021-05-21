//using Newtonsoft.Json;
//using PlannR.API.Tests.Controllers;
//using PlannR.Application.Features.Routes.Queries.GetRoutesList;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Xunit;

//namespace PlannR.API.Tests.RoutesTests.Controllers
//{
//    public class GetAllRoutesTests : ControllerTestsBase
//    {
//        public GetAllRoutesTests(WebHostBaseFactory<Startup> factory) : base(factory)
//        {
//        }

//        [Fact]
//        public async Task WHEN_api_routes_is_queried_THEN_Success_StatusCode_returned()
//        {
//            var client = _factory.CreateNewClient();

//            var response = await client.GetAsync("/api/routes");

//            response.EnsureSuccessStatusCode();

//            var message = await response.Content.ReadAsStringAsync();

//            var model = JsonConvert.DeserializeObject<ICollection<RouteListDataModel>>(message);

//            Assert.IsType<List<RouteListDataModel>>(model);
//        }
//    }
//}
