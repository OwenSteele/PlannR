using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PlannR.App.Contracts.Guest;
using PlannR.App.Infrastructure.Authentication;
using System;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Services.Guest
{
    public class GuestService : IGuestService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly PlannrAuthenticationStateProvider _plannrAuthenticationStateProvider;

        public GuestService(ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            _plannrAuthenticationStateProvider = (PlannrAuthenticationStateProvider)authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task SetGuestLoginAsync()
        {
            _plannrAuthenticationStateProvider.SetGuestAuthenticated();

            await _plannrAuthenticationStateProvider.SetTokenAsync(string.Empty, "Guest", DateTime.Now.AddHours(1));
        }

        public void SetGuestLogoutAsync()
        {
            _plannrAuthenticationStateProvider.SetUserLoggedOut();
        }
    }
}
