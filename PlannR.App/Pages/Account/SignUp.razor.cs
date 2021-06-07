using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.ViewModels.Account;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Account
{

    public partial class SignUp
    {
        [Inject]
        public IAuthenticationDataService AuthenticationDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }

        public string InputCssClass { get; } = "input-field";

        public string Message { get; set; }
        protected override void OnInitialized()
        {
            RegisterViewModel = new();
        }

        protected async Task HandleValidSubmit()
        {
            var response = await AuthenticationDataService.Register(RegisterViewModel);

            if (response) NavigationManager.NavigateTo("account");
            else Message = "Error on trying to register.";
        }
        protected void HandleInvalidSubmit()
        {
            Message = "Invalid Details.";
        }
    }
}
