using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Threading.Tasks;

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
        private string NavMenuCssClass { get; set; } = "sidebar-collapsed";
        private string ToggleNavMenuClass { get; set; } = "main-focused";
        protected void ToggleNavMenu()
        {
            NavMenuCssClass = (NavMenuCssClass == "sidebar") ?
                "sidebar-collapsed" : "sidebar";

            ToggleNavMenuClass = (ToggleNavMenuClass == "main") ?
                "main-focused" : "main";
        }

        protected void CollapseNavMenu()
        {
            NavMenuCssClass = "sidebar-collapsed";

            ToggleNavMenuClass = "main-focused";
        }

        protected async Task<bool> EnableUserNavMenu()
        {
            return (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User != null;
        }
    }
}
