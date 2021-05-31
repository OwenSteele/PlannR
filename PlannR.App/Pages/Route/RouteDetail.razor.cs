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
                Points = points,

            };

            var parameters = new ModalParameters();

            parameters.Add("EditRouteViewModel", editModel);

            parameters.Add("StartTime", Route.StartDateTime);
            parameters.Add("EndTime", Route.EndDateTime);

            var modal = Modal.Show<CreateRouteModal>($"Edit: '{Route.Name}'", parameters);

            var result = await modal.Result;

            if (result.Data != null)
            {
                Route = await RouteDataService.GetRouteByIdAsync(_RouteId);

                StateHasChanged();
            }
        }
        private void SetMapPoints()
        {
            MapPoints = new List<Marker>();

            //foreach (var point in Route.Points)
            //{
            //    MapPoints.Add(new Marker
            //    {
            //        Description = $"{Route.Name} (start of trip)",
            //        ShowPopup = true,
            //        Y = (point.?.Latitude ?? 0),
            //        X = (Route.StartLocation?.Longitude ?? 0)
            //    });
            //}
        }
        //private async Task ShowEditRouteBookingModal()
        //{
        //    var title = string.Empty;

        //    var parameters = new ModalParameters();
        //    parameters.Add("OwnerId", Route.RouteId);

        //    if (Route.Booking != null)
        //    {
        //        parameters.Add("BookingId", Route.Booking.BookingId);
        //        title = "Edit";
        //    }
        //    else
        //    {
        //        title = "Create";
        //    }

        //    var modal = Modal.Show<CreateRouteBookingModal>($"{title}: '{Route.Name}' booking", parameters);

        //    var result = await modal.Result;

        //    if (result.Data != null)
        //    {
        //        Route = await RouteDataService.GetRouteByIdAsync(_RouteId);

        //        StateHasChanged();
        //    }
        //}
        //private async Task ShowFullMapModal()
        //{
        //    if (Route.StartLocation == null && Route.EndLocation == null) return;

        //    var parameters = new ModalParameters();

        //    var markers = new List<Marker>();

        //    if (Route.StartLocation != null)
        //    {
        //        markers.Add(new Marker
        //        {
        //            Description = $"{Route.Name} - ({Route.RouteType.Name})",
        //            X = Route.StartLocation.Longitude,
        //            Y = Route.StartLocation.Latitude,
        //            ShowPopup = true
        //        });
        //    }
        //    if (Route.EndLocation != null)
        //    {
        //        markers.Add(new Marker
        //        {
        //            Description = $"{Route.Name} - ({Route.RouteType.Name})",
        //            X = Route.EndLocation.Longitude,
        //            Y = Route.EndLocation.Latitude,
        //            ShowPopup = (Route.StartLocation == null)
        //        });
        //    }

        //    parameters.Add("MapPoints", markers);

        //    var modal = Modal.Show<FullMapModal>($"Location of {Route.Name}", parameters);

        //    await modal.Result;
        //}
    }
}
