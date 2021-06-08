using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.ViewModels.Account;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Account
{
    public partial class Login
    {
        [Inject]
        public IAuthenticationDataService AuthenticationDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public string Redirected { get; set; } = null;
        public AuthenticateViewModel LoginViewModel { get; set; }
        public string LoginButtonCssClass { get; set; } = "";

        public bool Submitted { get; set; } = false;

        public string Message { get; set; }
        protected override void OnInitialized()
        {
            if (!string.IsNullOrWhiteSpace(Redirected)) Message = Redirected;

            LoginViewModel = new();
        }

        protected async Task HandleValidSubmit()
        {
            Submitted = true;

            LoginButtonCssClass = "loader";

            var response = await AuthenticationDataService.Authenticate(LoginViewModel);

            if (response) NavigationManager.NavigateTo("account");
            else
            {
                Submitted = false;
                Message = "Error on log in - Please ensure details are correct";
            }
        }
        protected void HandleInvalidSubmit()
        {
            Message = "Invalid Email or Password.";
        }
    }
}
