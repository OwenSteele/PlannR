using AutoMapper;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PlannR.App.Infrastructure.Authentication;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Account;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Services
{
    public class AuthenticationDataService : BaseDataService, IAuthenticationDataService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IMapper _mapper;

        public AuthenticationDataService(IClient client, ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider, IMapper mapper) : base(client, localStorage)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _mapper = mapper;
        }

        public async Task<bool> IsLoggedInAsync()
        {
            return (await _authenticationStateProvider.GetAuthenticationStateAsync()).User == null;
        }

        public async Task<bool> Authenticate(AuthenticateViewModel viewModel)
        {
            try
            {
                var request = _mapper.Map<AuthenticationRequest>(viewModel);
                var response = await _client.AuthenticateAsync(request);

                if (response.Token == string.Empty) return false;

                await _localStorage.SetItemAsync("token", response.Token);

                var plannrAuthenticationStateProvider = (PlannrAuthenticationStateProvider)_authenticationStateProvider;
                plannrAuthenticationStateProvider.SetUserAuthenticated(viewModel.Email);

                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", response.Token);

                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");

            var plannrAuthenticationStateProvider = (PlannrAuthenticationStateProvider)_authenticationStateProvider;

            plannrAuthenticationStateProvider.SetUserLoggedOut();

            _client.HttpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<bool> Register(RegisterViewModel viewModel)
        {
            var request = _mapper.Map<RegistrationRequest>(viewModel);
            var response = await _client.RegisterAsync(request);

            return string.IsNullOrEmpty(response.UserId);
        }
    }
}
