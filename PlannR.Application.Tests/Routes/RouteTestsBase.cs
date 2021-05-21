using AutoMapper;
using Moq;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Profiles;
using PlannR.Application.Tests.BaseRoute.Mocks;
using PlannR.Domain.Entities;

namespace PlannR.Application.Tests.BaseRoute
{
    public class RouteTestsBase : HandlerTestsBase<Route>
    {
        protected readonly Mock<IRouteRepository> _mockRepository;
        protected readonly IMapper _mapper;

        public RouteTestsBase()
        {
            _mockRepository = RouteRespositoryMocks.GetRouteRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }
    }
}
