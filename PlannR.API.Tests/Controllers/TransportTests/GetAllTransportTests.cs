//using Newtonsoft.Json;
//using PlannR.API.Tests.Controllers;
//using PlannR.Application.Features.Transports.Queries.GetTransportsList;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Xunit;

//namespace PlannR.API.Tests.TransportTests.Controllers
//{
//    public class GetAllTransportTests : ControllerTestsBase
//    {
//        public GetAllTransportTests(WebHostBaseFactory<Startup> factory) : base(factory)
//        {
//        }

//        [Fact]
//        public async Task WHEN_api_transport_is_queried_THEN_Success_StatusCode_returned()
//        {
//            var client = _factory.CreateNewClient();

//            var response = await client.GetAsync("/api/Transport");

//            response.EnsureSuccessStatusCode();

//            var message = await response.Content.ReadAsStringAsync();

//            var model = JsonConvert.DeserializeObject<ICollection<TransportListDataModel>>(message);

//            Assert.IsType<List<TransportListDataModel>>(model);
//        }
//    }
//}
