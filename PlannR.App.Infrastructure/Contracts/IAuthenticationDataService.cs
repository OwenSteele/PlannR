using PlannR.App.Infrastructure.ViewModels.Account;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Contracts
{
    public interface IAuthenticationDataService
    {
        Task<bool> IsLoggedInAsync();
        Task<bool> Authenticate(AuthenticateViewModel viewModel);
        Task<bool> Register(RegisterViewModel viewModel);
        Task Logout();
    }
}
