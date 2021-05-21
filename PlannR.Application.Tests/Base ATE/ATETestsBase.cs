using AutoMapper;
using Moq;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Profiles;
using PlannR.Application.Tests.BaseATE.Mocks;
using PlannR.Domain.Entities;

namespace PlannR.Application.Tests.BaseATE
{
    public class ATETestsBase : HandlerTestsBase<Accomodation>
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
