using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PlannR.App.Infrastructure.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Shared
{
    public partial class MainLayout
    {
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
