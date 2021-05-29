using AutoMapper;
using Moq;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Features.Trips.Queries.GetTripsDetail;
using PlannR.Application.Profiles;
using PlannR.Application.Tests.BaseTrip.Mocks;
using PlannR.Domain.Entities;
using System;

namespace PlannR.Application.Tests.BaseTrip
{
    public class TripTestsBase : HandlerTestsBase<Trip>
    {
        protected readonly Mock<ITripRepository> _mockRepository;
        protected readonly IMapper _mapper;

        public TripTestsBase()
        {
            _mockRepository = TripRespositoryMocks.GetTripRepository();
            _mockRepository.Setup(x => x.GetByIdWithChildrenAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid tripId) =>
                {
                    var trip = new Trip { TripId = Guid.Parse("098952e3-7cb8-4cdb-9f54-e129cab91909") };
                    return (tripId == trip.TripId) ? trip : null;
                });

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }
    }
}
