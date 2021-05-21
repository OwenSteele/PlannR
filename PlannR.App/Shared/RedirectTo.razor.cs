using Microsoft.AspNetCore.Components;

namespace PlannR.App.Shared
{
    public partial class RedirectTo
    {
        [Parameter]
        public string Page { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override void OnInitialized()
        {
            NavigationManager.NavigateTo(Page);
        }
    }
}

