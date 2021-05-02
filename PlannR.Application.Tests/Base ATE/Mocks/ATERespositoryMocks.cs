using Moq;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlannR.Application.Tests.BaseATE.Mocks
{
    public class ATERespositoryMocks
    {
        // As the three ATE types are Identical in CQ, only testing one as all have same functionality
        //ATE == Accomodation, Transport, Event
        public static Mock<IAccomodationRepository> GetAccomodationRepository()
        {

            var a1 = Guid.Parse("{0c135c86-f44c-47e9-9305-15527126c239}");
            var a2 = Guid.Parse("{2545332f-3f7d-4f99-bfa9-ae5ec3cc7e0d}");

            var accoms = new List<Accomodation>
            {
                new Accomodation
                {
                    AccomodationId = a1,
                    Name = "accom 1",
                    TripId = Guid.Parse("{14b31a2f-5b5d-4ac3-85e2-28ad5cba8165}"),
                    Trip = new(),
                    Location = new(),
                    AccomodationType = new(),
                    Booking = new(),  // only this has a booking - *withBooking query tests
                    StartDateTime = DateTime.Parse("2022-12-01T12:00:00.000Z"),
                    EndDateTime = DateTime.Parse("2022-12-12T12:00:00.000Z")
                },
                new Accomodation
                {
                    AccomodationId = a2,
                    Name = "accom 2",
                    TripId = Guid.Parse("{180167ab-cf2c-4000-ac6e-633bd8ffb069}"),
                    Trip = new(),
                    Location = new(),
                    AccomodationType = new(),
                    StartDateTime = DateTime.Parse("2023-12-01T12:00:00.000Z"),
                    EndDateTime = DateTime.Parse("2023-12-12T12:00:00.000Z")
                }
            };

            var mockRepository = new Mock<IAccomodationRepository>();

            mockRepository.Setup(x => x.ListAllAsync()).ReturnsAsync(accoms);

            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid guid) =>
                {
                    return accoms.FirstOrDefault(x => x.AccomodationId == guid);
                });

            mockRepository.Setup(x => x.AddAsync(It.IsAny<Accomodation>()))
                .ReturnsAsync((Accomodation accomodation) =>
                {
                    accoms.Add(accomodation);
                    return accomodation;
                }
                );

            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<Accomodation>()))
                .Callback((Accomodation accomodation) =>
                {
                    var index = accoms.IndexOf(accomodation);
                    if (index > -1)
                    {
                        accoms[index] = accomodation;
                    }
                });

            mockRepository.Setup(x => x.DeleteAsync(It.IsAny<Accomodation>()))
                .Callback((Accomodation accomodation) =>
                {
                    accoms.Remove(accomodation);
                });

            mockRepository.Setup(x => x.GetWithRelated(It.IsAny<Guid>()))
                .ReturnsAsync((Guid guid) =>
                {
                    return accoms.FirstOrDefault(x => x.AccomodationId == guid);
                });

            mockRepository.Setup(x => x.GetAllOfTripById(It.IsAny<Guid>()))
                .ReturnsAsync((Guid guid) =>
                {
                    return accoms.Where(x => x.TripId == guid).ToArray();
                });

            mockRepository.Setup(x => x.GetAllOfTripByIdWithBookings(It.IsAny<Guid>()))
                .ReturnsAsync((Guid guid) =>
                {
                    return accoms.Where(x => x.TripId == guid).ToArray();
                });

            mockRepository.Setup(x => x.GetAllOnDateOfTripById(It.IsAny<Guid>(), It.IsAny<DateTime>()))
                .ReturnsAsync((Guid guid, DateTime date) =>
                {
                    return accoms.Where(x => x.TripId == guid &&
                        x.StartDateTime <= date && x.EndDateTime >= date).ToArray();
                });

            mockRepository.Setup(x => x.IsBookedOnTheseDateTimes(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync((DateTime start, DateTime end) =>
                {
                    return accoms.Any(x => (x.EndDateTime <= start && x.StartDateTime >= end));
                });

            return mockRepository;
        }
    }
}
