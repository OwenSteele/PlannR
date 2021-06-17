using Microsoft.AspNetCore.Components;
using PlannR.App.Contracts.Guest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Home
{
    public partial class GuestLogin
    {
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        IGuestService GuestService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await GuestService.SetGuestLoginAsync();

            NavigationManager.NavigateTo("account");
        }
    }
}
