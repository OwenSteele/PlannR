using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;

namespace PlannR.App.Pages
{
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IAuthenticationDataService AuthenticationDataService { get; set; }

        protected void NavigateToRegister()
        {
            NavigationManager.NavigateTo("account/signup");
        }
        protected void NavigateToAccount()
        {
            NavigationManager.NavigateTo("account/index");
        }
    }
}
