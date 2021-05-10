using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
