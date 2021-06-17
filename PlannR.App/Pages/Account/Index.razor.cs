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

        public string Username { get; set; } = string.Empty;

        public string Info { get; set; } = "Checkout the Navigation pane to the left, to see your trips!";
        public bool IsUser { get; set; } = false;


        protected async override Task OnInitializedAsync()
        {
            Username = await AuthenticationService.GetUsernameAsync();

            if (Username == "Guest")
            {
                Info = "Take a look at all of the features and options PlannR has to offer! Use the navigation bar to the left to see how PlannR can make trip planning stress a thing of the past.";   
            }
            else
            {
                IsUser = true;
            }
        }
    }
}
