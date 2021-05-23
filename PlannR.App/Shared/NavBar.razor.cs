using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PlannR.App.Infrastructure.Authentication;
using PlannR.App.Infrastructure.Contracts;
using System.Threading.Tasks;

namespace PlannR.App.Shared
{
    public partial class NavBar
    {
        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAuthenticationDataService AuthenticationService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await ((PlannrAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
        }

        protected void NavigateToAccount()
        {
            StateHasChanged();
            NavigationManager.NavigateTo("account");
        }
        protected void NavigateToLogin()
        {
            NavigationManager.NavigateTo("login");
        }
        protected void NavigateToSignUp()
        {
            NavigationManager.NavigateTo("signup");
        }
        protected void Logout()
        {
            StateHasChanged();
            AuthenticationService.Logout();
            NavigationManager.NavigateTo("/");
        }
    }
}
