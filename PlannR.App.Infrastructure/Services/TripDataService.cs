using Blazored.LocalStorage;
using Plannr.App.Infrastructure.Contracts;
using Plannr.App.Infrastructure.Services.Base;

namespace Plannr.App.Infrastructure.Services
{
    public class TripDataService : BaseDataService, ITripDataService
    {
        private readonly IMapper _mapper;
        public TripDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }
    }
}
