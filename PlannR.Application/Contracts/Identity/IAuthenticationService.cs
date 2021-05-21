using PlannR.Application.Models.Authentication;
using System.Threading.Tasks;

namespace PlannR.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
    }
}
