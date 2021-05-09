using Plannr.App.Infrastructure.ViewModels.Account;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Contracts
{
    public interface IAuthenticationDataService
    {
        Task<bool> Authenticate(AuthenticateViewModel viewModel);
        Task<bool> Register(RegisterViewModel viewModel);
        Task Logout();
    }
}
