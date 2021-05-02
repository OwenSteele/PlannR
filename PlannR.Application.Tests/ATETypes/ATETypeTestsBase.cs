using AutoMapper;
using Moq;
using PlannR.Application.Contracts.Persistence;
using PlannR.Application.Profiles;
using PlannR.Application.Tests.ATETypes.Mocks;
using PlannR.Domain.EntityTypes;

namespace PlannR.Application.Tests.ATETypes
{
    public class ATETypeTestsBase
    {
        protected readonly Mock<IAsyncRepository<AccomodationType>> _mockRepository;
        protected readonly IMapper _mapper;

        public ATETypeTestsBase()
        {
            _mockRepository = TypeRespositoryMocks.GetAccomodationTypeRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }
    }
}
