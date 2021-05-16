using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PlannR.App.Infrastructure.Contracts;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Account
{
    public partial class Index
    {

        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAuthenticationDataService AuthenticationService { get; set; }

        public string Username { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Username = await AuthenticationService.GetUsernameAsync();
        }
    }
}
