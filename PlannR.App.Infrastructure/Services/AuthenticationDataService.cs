using Blazored.LocalStorage;
using Plannr.App.Infrastructure.Contracts;
using Plannr.App.Infrastructure.Services.Base;

namespace Plannr.App.Infrastructure.Services
{
    public class AuthenticationDataService : BaseDataService, IAuthenticationDataService
    {
        public AuthenticationDataService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }
    }
}
