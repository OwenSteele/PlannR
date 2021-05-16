using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace PlannR.App.Shared
{
    public partial class MainLayout
    {

        [CascadingParameter]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        public IJSRuntime IJSRuntime { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private string NavMenuCssClass { get; set; } = "sidebar";
        private string ToggleNavMenuClass { get; set; } = "main";
        protected void ToggleNavMenu()
        {
            NavMenuCssClass = (NavMenuCssClass == "sidebar") ?
                "sidebar-collapsed" : "sidebar";

            ToggleNavMenuClass = (ToggleNavMenuClass == "main") ?
                "main-focused" : "main";
        }
    }
}
