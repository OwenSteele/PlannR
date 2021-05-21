using AutoMapper;
using Moq;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Profiles;
using PlannR.Application.Tests.BaseTrip.Mocks;
using PlannR.Domain.Entities;

namespace PlannR.Application.Tests.BaseTrip
{
    public class TripTestsBase : HandlerTestsBase<Trip>
    {
        protected readonly Mock<ITripRepository> _mockRepository;
        protected readonly IMapper _mapper;

        public TripTestsBase()
        {
            _mockRepository = TripRespositoryMocks.GetTripRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }
    }
}
