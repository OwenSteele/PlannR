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
        private string NavMenuCssClass { get; set; }
        protected void ToggleNavMenu()
        {
            if (NavMenuCssClass == "width: 300px;") NavMenuCssClass = "width: 0px;";
            else NavMenuCssClass = "width: 300px;";
        }
    }
}
