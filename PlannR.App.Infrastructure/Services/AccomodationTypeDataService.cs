using AutoMapper;
using Blazored.LocalStorage;
using Plannr.App.Infrastructure.Contracts;
using Plannr.App.Infrastructure.Services.Base;

namespace Plannr.App.Infrastructure.Services
{
    public class AccomodationTypeDataService : BaseDataService, IAccomodationTypeDataService
    {
        private readonly IMapper _mapper;
        public AccomodationTypeDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }
    }
}
