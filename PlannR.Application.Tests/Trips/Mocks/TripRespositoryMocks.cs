using Moq;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlannR.Application.Tests.BaseTrip.Mocks
{
    public class TripRespositoryMocks
    {
        public static Mock<ITripRepository> GetTripRepository()
        {
            var t1 = Guid.Parse("{0c135c86-f44c-47e9-9305-15527126c239}");
            var t2 = Guid.Parse("{2545332f-3f7d-4f99-bfa9-ae5ec3cc7e0d}");

            var trips = new List<Trip>
            {
                new Trip
                {
                    TripId = t1,
                    Name = "trip 1",
                    StartDateTime = DateTime.Parse("2022-12-01T12:00:00.000Z"),
                    EndDateTime = DateTime.Parse("2022-12-12T12:00:00.000Z"),

                },
                new Trip
                {
                    TripId = t2,
                    Name = "trip 2",
                    StartDateTime = DateTime.Parse("2023-12-01T12:00:00.000Z"),
                    EndDateTime = DateTime.Parse("2023-12-12T12:00:00.000Z")
                }
            };

            var mockRepository = new Mock<ITripRepository>();

            mockRepository.Setup(x => x.ListAllAsync()).ReturnsAsync(trips);

            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid guid) =>
                {
                    return trips.FirstOrDefault(x => x.TripId == guid);
                });

            mockRepository.Setup(x => x.AddAsync(It.IsAny<Trip>()))
                .ReturnsAsync((Trip trip) =>
                {
                    trips.Add(trip);
                    return trip;
                }
                );

            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<Trip>()))
                .Callback((Trip trip) =>
                {
                    var index = trips.IndexOf(trip);
                    if (index > -1)
                    {
                        trips[index] = trip;
                    }
                });

            mockRepository.Setup(x => x.DeleteAsync(It.IsAny<Trip>()))
                .Callback((Trip trip) =>
                {
                    trips.Remove(trip);
                });

            mockRepository.Setup(x => x.GetAllTripsOnTheseDateTimes(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync((DateTime start, DateTime end) =>
                {
                    return trips.Where(x => x.StartDateTime <= end && x.EndDateTime >= start).ToArray();
                });

            return mockRepository;
        }
    }
}
