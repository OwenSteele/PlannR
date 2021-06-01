using Microsoft.AspNetCore.Components;

namespace PlannR.App.Shared
{
    public partial class RedirectTo
    {
        [Parameter]
        public string Page { get; set; }
        [Parameter]
        public string Message { get; set; } = "Please log in to view this page";
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override void OnInitialized()
        {
            NavigationManager.NavigateTo($"{Page}/{Message}");
        }
    }
}

