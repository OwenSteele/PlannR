using Moq;
using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlannR.Application.Tests.Bookings.Mocks
{
    public class AccomodationBookingRepositoryMocks
    {
        public static Mock<IAsyncRepository<AccomodationBooking>> GetAccomodationBookingRepository()
        {
            // As the three booking derived types are Identical, only testing one as all have same functionality

            var b1 = Guid.Parse("{e573a76d-88dc-4048-8980-5dd8bc322e6d}");
            var b2 = Guid.Parse("{864190a3-62d1-4dd1-a185-fe3b94d17f5b}");
            var b3 = Guid.Parse("{54c05a1f-ce4a-4a2e-bd8e-e93d4f73a24d}");
            var b4 = Guid.Parse("{e0bfd106-36c9-440b-86a8-01d29f58ce16}");

            var bookings = new List<AccomodationBooking>
            {
                new AccomodationBooking
                {
                    BookingId = b1,
                    AccomodationId = Guid.Parse("{14b31a2f-5b5d-4ac3-85e2-28ad5cba8165}"),
                    Name = "booking 1",
                    Link = "https://b1.co.uk",
                    Email = "x@x.x",
                    Comments = "b1",
                    Cost = 100.00m
                },
                new AccomodationBooking
                {
                    BookingId = b2,
                    AccomodationId = Guid.Parse("{180167ab-cf2c-4000-ac6e-633bd8ffb069}"),
                    Name = "booking 2",
                    Link = "https://b2.co.uk",
                    Email = "x@x.x",
                    Comments = "b2",
                    Cost = 200.00m
                },
                new AccomodationBooking
                {
                    BookingId = b3,
                    AccomodationId = Guid.Parse("{660f5869-aa0d-4e9b-a8ed-2fea7e44f772}"),
                    Name = "booking 3",
                    Link = "https://b3.co.uk",
                    Email = "x@x.x",
                    Comments = "b3",
                    Cost = 300.00m
                },
                new AccomodationBooking
                {
                    BookingId = b4,
                    AccomodationId = Guid.Parse("{519b7d30-4213-47c7-8de5-b6e659ad2292}"),
                    Name = "booking 4",
                    Link = "https://b4.co.uk",
                    Email = "x@x.x",
                    Comments = "b4",
                    Cost = 400.00m
                }
            };

            var mockRepository = new Mock<IAsyncRepository<AccomodationBooking>>();

            mockRepository.Setup(x => x.ListAllAsync()).ReturnsAsync(bookings);

            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid guid) =>
                {
                    return bookings.FirstOrDefault(x => x.BookingId == guid);
                });

            mockRepository.Setup(x => x.AddAsync(It.IsAny<AccomodationBooking>()))
                .ReturnsAsync((AccomodationBooking accomodationBooking) =>
                {
                    bookings.Add(accomodationBooking);
                    return accomodationBooking;
                }
                );

            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<AccomodationBooking>()))
                .Callback((AccomodationBooking accomodationBooking) =>
                {
                    var index = bookings.IndexOf(accomodationBooking);
                    if (index > -1)
                    {
                        bookings[index] = accomodationBooking;
                    }
                });

            mockRepository.Setup(x => x.DeleteAsync(It.IsAny<AccomodationBooking>()))
                .Callback((AccomodationBooking accomodationBooking) =>
                {
                    bookings.Remove(accomodationBooking);
                });


            return mockRepository;
        }
    }
}
