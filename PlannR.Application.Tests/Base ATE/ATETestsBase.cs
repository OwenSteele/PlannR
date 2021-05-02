using AutoMapper;
using Moq;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Profiles;
using PlannR.Application.Tests.BaseATE.Mocks;

namespace PlannR.Application.Tests.BaseATE
{
    public class ATETestsBase
    {
        protected readonly Mock<IAccomodationRepository> _mockRepository;
        protected readonly IMapper _mapper;

        public ATETestsBase()
        {
            _mockRepository = ATERespositoryMocks.GetAccomodationRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }
    }
}
