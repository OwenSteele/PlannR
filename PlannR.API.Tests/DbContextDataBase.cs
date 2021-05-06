using PlannR.Domain.Entities;
using PlannR.Persistence;
using System;
using System.Threading.Tasks;

namespace PlannR.API.Tests
{
    public class DbContextDataBase
    {
        public static async Task SeedMockDbContext(PlannrDbContext dbContext)
        {
            var t1 = Guid.Parse("{154c1810-047a-4552-b7d2-69b5cb25f1fa}");
            var t2 = Guid.Parse("{440d2c00-9c13-4215-9cbe-49bffaf0789d}");
            await dbContext.AddAsync(new Trip
            {
                TripId = t1,
                Name = "trip 1",
                StartDateTime = DateTime.Parse("2022-12-01T12:00:00.000Z"),
                EndDateTime = DateTime.Parse("2022-12-30T12:00:00.000Z"),

            });
            await dbContext.AddAsync(new Trip
            {
                TripId = t2,
                Name = "trip 2",
                StartDateTime = DateTime.Parse("2023-12-01T12:00:00.000Z"),
                EndDateTime = DateTime.Parse("2023-12-30T12:00:00.000Z")
            });

            var r1 = Guid.Parse("{da87a094-f692-42f1-97d2-b8a614c66f38}");
            var r2 = Guid.Parse("{94a31503-e3b6-4022-8676-8ccede00b48f}");

            await dbContext.AddAsync(new Route
            {
                RouteId = r1,
                Name = "route 1",
                TripId = Guid.Parse("{154c1810-047a-4552-b7d2-69b5cb25f1fa}"),
                StartDateTime = DateTime.Parse("2022-12-13T12:00:00.000Z"),
                EndDateTime = DateTime.Parse("2022-12-13T18:00:00.000Z")
            });

            await dbContext.AddAsync(new Route
            {
                RouteId = r2,
                Name = "route 2",
                TripId = Guid.Parse("{440d2c00-9c13-4215-9cbe-49bffaf0789d}"),
                StartDateTime = DateTime.Parse("2023-12-13T12:00:00.000Z"),
                EndDateTime = DateTime.Parse("2023-12-13T18:00:00.000Z")
            });

            var a1 = Guid.Parse("{236bd69e-f312-44be-b272-4da1edb404f1}");
            var a2 = Guid.Parse("{3017eaf2-7b9a-4cab-bc8c-1bf2d84b4d24}");
            await dbContext.AddAsync(new Accomodation
            {
                AccomodationId = a1,
                Name = "accom 1",
                TripId = Guid.Parse("{154c1810-047a-4552-b7d2-69b5cb25f1fa}"),
                StartDateTime = DateTime.Parse("2022-12-01T12:00:00.000Z"),
                EndDateTime = DateTime.Parse("2022-12-12T12:00:00.000Z")
            });
            await dbContext.AddAsync(new Accomodation
            {
                AccomodationId = a2,
                Name = "accom 2",
                TripId = Guid.Parse("{440d2c00-9c13-4215-9cbe-49bffaf0789d}"),
                StartDateTime = DateTime.Parse("2023-12-01T12:00:00.000Z"),
                EndDateTime = DateTime.Parse("2023-12-12T12:00:00.000Z")
            });

            var e1 = Guid.Parse("{0b2bcb2a-c231-433b-95de-a3ed85e315f7}");
            var e2 = Guid.Parse("{fe87fcdd-8e02-41c8-a87e-6ec9f8e3d9c5}");
            await dbContext.AddAsync(new Event
            {
                EventId = e1,
                Name = "event 1",
                TripId = Guid.Parse("{154c1810-047a-4552-b7d2-69b5cb25f1fa}"),
                StartDateTime = DateTime.Parse("2022-12-20T12:00:00.000Z"),
                EndDateTime = DateTime.Parse("2022-12-20T15:00:00.000Z")
            });
            await dbContext.AddAsync(new Event
            {
                EventId = e2,
                Name = "event 2",
                TripId = Guid.Parse("{440d2c00-9c13-4215-9cbe-49bffaf0789d}"),
                StartDateTime = DateTime.Parse("2023-12-20T12:00:00.000Z"),
                EndDateTime = DateTime.Parse("2023-12-20T15:00:00.000Z")
            });

            var tr1 = Guid.Parse("{94474c88-0ef0-4a43-908d-9de487016b49}");
            var tr2 = Guid.Parse("{2728888a-ab29-4f89-a31b-962bcb97f335}");
            await dbContext.AddAsync(new Transport
            {
                TransportId = tr1,
                Name = "transport 1",
                TripId = Guid.Parse("{154c1810-047a-4552-b7d2-69b5cb25f1fa}"),
                StartDateTime = DateTime.Parse("2022-12-25T12:00:00.000Z"),
                EndDateTime = DateTime.Parse("2022-12-27T12:00:00.000Z")
            });
            await dbContext.AddAsync(new Transport
            {
                TransportId = tr2,
                Name = "transport 2",
                TripId = Guid.Parse("{440d2c00-9c13-4215-9cbe-49bffaf0789d}"),
                StartDateTime = DateTime.Parse("2023-12-25T12:00:00.000Z"),
                EndDateTime = DateTime.Parse("2023-12-27T12:00:00.000Z")
            });
        }
    }
}
