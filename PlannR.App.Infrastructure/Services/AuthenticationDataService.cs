using Blazored.LocalStorage;
using Plannr.App.Infrastructure.Contracts;
using Plannr.App.Infrastructure.Services.Base;
using Plannr.App.Infrastructure.ViewModels.Account;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Services
{
    public class AuthenticationDataService : BaseDataService, IAuthenticationDataService
    {
        public AuthenticationDataService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }

        public Task<bool> Authenticate(AuthenticateViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task Logout()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Register(RegisterViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
