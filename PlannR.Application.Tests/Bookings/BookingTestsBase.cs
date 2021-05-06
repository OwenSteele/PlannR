using AutoMapper;
using Moq;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Profiles;
using PlannR.Application.Tests.Bookings.Mocks;
using PlannR.Domain.Entities;

namespace PlannR.Application.Tests.Bookings
{
    public class BookingTestsBase : HandlerTestsBase<AccomodationBooking>
    {
        protected readonly Mock<IAsyncRepository<AccomodationBooking>> _mockRepository;
        protected readonly IMapper _mapper;

        public BookingTestsBase()
        {
            _mockRepository = AccomodationBookingRepositoryMocks.GetAccomodationBookingRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }
    }
}
