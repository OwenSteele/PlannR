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
        private readonly IMapper _mapper;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationDataService(IClient client, ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider, IMapper mapper) : base(client, authenticationStateProvider)
        {
            _localStorage = localStorage;
            _mapper = mapper;
        }

        public async Task<string> GetUsernameAsync()
        {
            return await _localStorage.GetItemAsync<string>("username");
        }

        public async Task<bool> Authenticate(AuthenticateViewModel viewModel)
        {
            try
            {
                var request = _mapper.Map<AuthenticationRequest>(viewModel);
                var response = await _client.AuthenticateAsync(request);

                if (response.Token == string.Empty) return false;
                                
                var plannrAuthenticationStateProvider = (PlannrAuthenticationStateProvider)_authenticationStateProvider;

                await plannrAuthenticationStateProvider.SetTokenAsync(response.Token, response.UserName, response.TokenExpiry);

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
            var plannrAuthenticationStateProvider = (PlannrAuthenticationStateProvider)_authenticationStateProvider;

            await plannrAuthenticationStateProvider.SetTokenAsync(null);

            plannrAuthenticationStateProvider.SetUserLoggedOut();

            _client.HttpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<bool> Register(RegisterViewModel viewModel)
        {
            try
            {
                var request = _mapper.Map<RegistrationRequest>(viewModel);
                var response = await _client.RegisterAsync(request);

                return !string.IsNullOrWhiteSpace(response.UserId);
            }
            catch
            {
                return false;
            }
        }
    }
}
