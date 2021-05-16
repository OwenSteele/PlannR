using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Shared
{
    public partial class RedirectToLogin
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override void OnInitialized()
        {
            NavigationManager.NavigateTo("login");
        }
    }
}
