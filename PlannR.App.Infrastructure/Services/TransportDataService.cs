using Blazored.LocalStorage;
using Plannr.App.Infrastructure.Contracts;
using Plannr.App.Infrastructure.Services.Base;

namespace Plannr.App.Infrastructure.Services
{
    public class TransportDataService : BaseDataService, ITransportDataService
    {
        private readonly IMapper _mapper;
        public TransportDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }
    }
}
