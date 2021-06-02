using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.ViewModels.Routes;
using PlannR.App.Pages.Modals;
using PlannR.ComponentLibrary.Map;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace PlannR.App.Pages.Route
{
    public partial class RouteDetail
    {
        private Guid _RouteId;
        [Parameter]
        public string RouteId { get; set; }

        [CascadingParameter]
        public IModalService Modal { get; set; }
        [Inject]
        public IRouteDataService RouteDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public RouteDetailViewModel Route { get; set; }
        public List<Marker> MapPoints { get; set; }
        protected async override Task OnInitializedAsync()
        {
            if (Guid.TryParse(RouteId, out _RouteId))
            {
                Route = await RouteDataService.GetRouteByIdAsync(_RouteId);

                SetMapPoints();
            }
        }
        protected void NavigateToTrip()
        {
            NavigationManager.NavigateTo($"trips/{Route.Trip.TripId}");
        }
        protected void NavigateTo(string uri)
        {
            NavigationManager.NavigateTo($"{uri}");
        }
        private async Task ShowEditRouteModal()
        {
            var points = new List<Guid>();
            foreach (var point in Route.Points) points.Add(point.Id);

            var editModel = new EditRouteViewModel
            {
                RouteId = Route.RouteId,
                Name = Route.Name,
                TripId = Route.Trip.TripId,
                StartDateTime = Route.StartDateTime,
                EndDateTime = Route.EndDateTime,
                Points = points
            };

            var parameters = new ModalParameters();

            parameters.Add("EditRouteViewModel", editModel);
            parameters.Add("RoutePoints", Route.Points);

            parameters.Add("StartTime", Route.StartDateTime);
            parameters.Add("EndTime", Route.EndDateTime);

            var modal = Modal.Show<CreateRouteModal>($"Edit: '{Route.Name}'", parameters);

            var result = await modal.Result;

            if (result.Data != null)
            {
                Route = await RouteDataService.GetRouteByIdAsync(_RouteId);

                StateHasChanged();
            }
            SetMapPoints();
        }
        private void SetMapPoints()
        {
            MapPoints = new List<Marker>();

            var pos = 1;
            foreach (var point in Route.Points)
            {
                MapPoints.Add(new Marker
                {
                    Description = $"{pos}. {point.Location.Name} ({point.StartDateTime.ToString("dd MMMMM HH:mm")})",
                    ShowPopup = (pos==1),
                    Y = (point.Location?.Latitude ?? 0),
                    X = (point.Location?.Longitude ?? 0)
                }); ;
                pos++;
            }
        }
        private async Task ShowFullMapModal()
        {
            var parameters = new ModalParameters();

            parameters.Add("MapPoints", MapPoints);

            var modal = Modal.Show<FullMapModal>($"Map of route: '{Route.Name}", parameters);

            await modal.Result;
        }
    }
}
