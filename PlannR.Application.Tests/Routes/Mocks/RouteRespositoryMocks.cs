using Moq;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlannR.Application.Tests.BaseRoute.Mocks
{
    public class RouteRespositoryMocks
    {
        // As the three Route types are Identical in CQ, only testing one as all have same functionality
        //Route == Route, Transport, Event
        public static Mock<IRouteRepository> GetRouteRepository()
        {

            var r1 = Guid.Parse("{0c135c86-f44c-47e9-9305-15527126c239}");
            var r2 = Guid.Parse("{2545332f-3f7d-4f99-bfa9-ae5ec3cc7e0d}");

            var routes = new List<Route>
            {
                new Route
                {
                    RouteId = r1,
                    Name = "route 1",
                    TripId = Guid.Parse("{14b31a2f-5b5d-4ac3-85e2-28ad5cba8165}"),
                    Trip = new(),
                    StartDateTime = DateTime.Parse("2022-12-01T12:00:00.000Z"),
                    EndDateTime = DateTime.Parse("2022-12-12T12:00:00.000Z")
                },
                new Route
                {
                    RouteId = r2,
                    Name = "route 2",
                    TripId = Guid.Parse("{180167ab-cf2c-4000-ac6e-633bd8ffb069}"),
                    Trip = new(),
                    StartDateTime = DateTime.Parse("2023-12-01T12:00:00.000Z"),
                    EndDateTime = DateTime.Parse("2023-12-12T12:00:00.000Z")
                }
            };

            var mockRepository = new Mock<IRouteRepository>();

            mockRepository.Setup(x => x.ListAllAsync()).ReturnsAsync(routes);

            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid guid) =>
                {
                    return routes.FirstOrDefault(x => x.RouteId == guid);
                });

            mockRepository.Setup(x => x.AddAsync(It.IsAny<Route>()))
                .ReturnsAsync((Route route) =>
                {
                    routes.Add(route);
                    return route;
                }
                );

            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<Route>()))
                .Callback((Route route) =>
                {
                    var index = routes.IndexOf(route);
                    if (index > -1)
                    {
                        routes[index] = route;
                    }
                });

            mockRepository.Setup(x => x.DeleteAsync(It.IsAny<Route>()))
                .Callback((Route route) =>
                {
                    routes.Remove(route);
                });

            mockRepository.Setup(x => x.GetWithRelated(It.IsAny<Guid>()))
                .ReturnsAsync((Guid guid) =>
                {
                    return routes.FirstOrDefault(x => x.RouteId == guid);
                });

            mockRepository.Setup(x => x.GetAllRoutesOfTripById(It.IsAny<Guid>()))
                .ReturnsAsync((Guid guid) =>
                {
                    return routes.Where(x => x.TripId == guid).ToArray();
                });

            mockRepository.Setup(x => x.GetAllRoutesOnDate(It.IsAny<DateTime>()))
                .ReturnsAsync((DateTime date) =>
                {
                    return routes.Where(x =>
                        x.StartDateTime <= date && x.EndDateTime >= date).ToArray();
                });

            mockRepository.Setup(x => x.IsRouteReservedOnTheseDateTimes(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync((DateTime start, DateTime end) =>
                {
                    return routes.Any(x => (x.EndDateTime <= start && x.StartDateTime >= end));
                });

            return mockRepository;
        }
    }
}
