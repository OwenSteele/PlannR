//using Newtonsoft.Json;
//using PlannR.Application.Features.Trips.Queries.GetTripListOnDate;
//using PlannR.Application.Features.Trips.Queries.GetTripsDetail;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace PlannR.API.Tests.Controllers.Trips
//{
//    public class GetTripByDatesTests : ControllerTestsBase
//    {
//        public GetTripByDatesTests(WebHostBaseFactory<Startup> factory) : base(factory)
//        {
//        }

//        [Fact]
//        public async Task WHEN_api_trips_by_onDate_is_queried_THEN_all_trips_on_date_are_in_repsonse()
//        {
//            var client = _factory.CreateNewClient();

//            var dateString = "2022-12-02T12:00:00.000Z";

//            var response = await client.GetAsync($"/api/Trips/{dateString}");

//            response.EnsureSuccessStatusCode();

//            var message = await response.Content.ReadAsStringAsync();

//            var model = JsonConvert.DeserializeObject<ICollection<TripListOnDateDataModel>>(message);

//            Assert.IsType<List<TripListOnDateDataModel>>(model);
//            Assert.NotEmpty(model);
//            Assert.InRange(DateTime.Parse(dateString),
//                model.FirstOrDefault().StartDateTime,
//                model.FirstOrDefault().StartDateTime);
//        }
//    }
//}
