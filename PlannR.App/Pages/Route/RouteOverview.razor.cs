using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.ViewModels.Routes;
using PlannR.App.Pages.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Route
{
    public partial class RouteOverview
    {
        [CascadingParameter]
        public IModalService Modal { get; set; }
        [Inject]
        public IRouteDataService RouteDataService { get; set; }
        public ICollection<RouteListViewModel> Routes { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Routes = await RouteDataService.GetAllRoutesAsync();
        }
        private async Task ShowCreateRouteModal()
        {
            var modal = Modal.Show<CreateRouteModal>("Add a new Route");

            var result = await modal.Result;

            if (!result.Cancelled)
            {
                Routes = await RouteDataService.GetAllRoutesAsync();
                StateHasChanged();
            }
        }
    }
}
