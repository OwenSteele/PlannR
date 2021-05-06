using Blazored.LocalStorage;
using Plannr.App.Infrastructure.Contracts;
using Plannr.App.Infrastructure.Services.Base;

namespace Plannr.App.Infrastructure.Services
{
    public class AccomodationDataService : BaseDataService, IAccomodationDataService
    {
        public AccomodationDataService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }
    }
}
