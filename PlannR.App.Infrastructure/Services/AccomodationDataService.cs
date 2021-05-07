using AutoMapper;
using Blazored.LocalStorage;
using Plannr.App.Infrastructure.Contracts;
using Plannr.App.Infrastructure.Services.Base;

namespace Plannr.App.Infrastructure.Services
{
    public class AccomodationDataService : BaseDataService, IAccomodationDataService
    {
        private readonly IMapper _mapper;
        public AccomodationDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }
    }
}
