using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Contracts.View;
using PlannR.App.Infrastructure.ViewModels.Locations;
using PlannR.App.Infrastructure.ViewModels.Trips;
using PlannR.App.Infrastructure.ViewModels.UI;
using PlannR.App.Pages.Modals;
using PlannR.ComponentLibrary.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Trip
{
    public partial class TripDetail
    {
        private Guid _tripId;
        [Parameter]
        public string TripId { get; set; }

        [CascadingParameter]
        public IModalService Modal { get; set; }
        [Inject]
        public ITripDataService TripDataService { get; set; }
        [Inject]
        public ITripOrderingService TripOrderingService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public TripDetailViewModel Trip { get; set; }
        public OrderTripPartNestedViewModel[] OrderedTripParts { get; set; }

        public List<Marker> MapPoints { get; set; }
        protected async override Task OnInitializedAsync()
        {
            if (Guid.TryParse(TripId, out _tripId))
            {
                Trip = await TripDataService.GetTripByIdAsync(_tripId);

                OrderedTripParts = TripOrderingService.OrderTripParts(Trip);

                SetMapPoints();
            }
        }
        protected void NavigateToAccomodation(string uri)
        {
            NavigationManager.NavigateTo($"accomodations/{uri}");
        }
        protected void NavigateToTransport(string uri)
        {
            NavigationManager.NavigateTo($"transports/{uri}");
        }
        protected void NavigateToEvents(string uri)
        {
            NavigationManager.NavigateTo($"events/{uri}");
        }
        protected void NavigateToRoutes(string uri)
        {
            NavigationManager.NavigateTo($"routes/{uri}");
        }
        protected void NavigateTo(string uri)
        {
            NavigationManager.NavigateTo($"{uri}");
        }
        private async Task ShowEditTripModal()
        {
            var editModel = new EditTripViewModel
            {
                TripId = Trip.TripId,
                Name = Trip.Name,
                StartDateTime = Trip.StartDateTime,
                EndDateTime = Trip.EndDateTime,
                StartLocationId = Trip.StartLocation?.LocationId,
                EndLocationId = Trip.EndLocation?.LocationId
            };

            var parameters = new ModalParameters();

            parameters.Add("EditTripViewModel", editModel);

            parameters.Add("StartTime", Trip.StartDateTime);
            parameters.Add("EndTime", Trip.EndDateTime);

            var modal = Modal.Show<CreateEditTripModal>($"Edit: '{Trip.Name}'", parameters);

            var result = await modal.Result;

            if (result.Cancelled)
            {
                Trip = await TripDataService.GetTripByIdAsync(_tripId);

                SetMapPoints();
                StateHasChanged();
            }
        }
        private async Task CreateAccomodationModal()
        {
            var modal = Modal.Show<CreateAccomodationModal>("New Accomodation");

            var result = await modal.Result;

            if (!result.Cancelled)
            {
                Trip = await TripDataService.GetTripByIdAsync(_tripId);
            }
            StateHasChanged();
        }
        private async Task CreateTransportModal()
        {
            var modal = Modal.Show<CreateTransportModal>("New Transport");

            var result = await modal.Result;

            if (!result.Cancelled)
            {
                Trip = await TripDataService.GetTripByIdAsync(_tripId);
            }
            StateHasChanged();
        }
        private async Task CreateEventModal()
        {
            var modal = Modal.Show<CreateEventModal>("New Event");

            var result = await modal.Result;

            if (!result.Cancelled)
            {
                Trip = await TripDataService.GetTripByIdAsync(_tripId);
            }
            StateHasChanged();
        }
        private async Task CreateRouteModal()
        {
            var modal = Modal.Show<CreateRouteModal>("New Route");

            var result = await modal.Result;

            if (!result.Cancelled)
            {
                Trip = await TripDataService.GetTripByIdAsync(_tripId);
            }
            StateHasChanged();
        }
        private async Task ShowFullMapModal()
        {
            var parameters = new ModalParameters();

            var fullMapPoints = new List<Marker>();

            var position = 1;

            foreach(var part in OrderedTripParts)
            {
                if (!string.IsNullOrWhiteSpace(part.StartLocationName))
                {
                    fullMapPoints.Add(new Marker
                    {
                        Description = $"{position}. {part.Name} ({part.Type}",
                        X = part.StartCoordinates.Item1.Value,
                        Y = part.StartCoordinates.Item2.Value,
                    });
                    position++;
                }
                if (!string.IsNullOrWhiteSpace(part.EndLocationName))
                {
                    fullMapPoints.Add(new Marker
                    {
                        Description = $"{position}. {part.Name} ({part.Type}",
                        X = part.EndCoordinates.Item1.Value,
                        Y = part.EndCoordinates.Item2.Value,
                    });
                    position++;
                }
            }

            if (!fullMapPoints.Any()) 
            {
                if (Trip.StartLocation == null || Trip.EndLocation == null) return;

                fullMapPoints.Add(new Marker
                {
                    Description = $"{position}. {Trip.StartLocation.Name} (start of trip)",
                    X = Trip.StartLocation.Longitude,
                    Y = Trip.StartLocation.Latitude,
                });
                position++;
                fullMapPoints.Add(new Marker
                {
                    Description = $"{position}. {Trip.EndLocation.Name} (end of trip)",
                    X = Trip.EndLocation.Longitude,
                    Y = Trip.EndLocation.Latitude,
                });
                position++;
            };

            parameters.Add("MapPoints", fullMapPoints);

            var modal = Modal.Show<FullMapModal>($"Map of {Trip.Name}", parameters);

            var result = await modal.Result;

            if (!result.Cancelled)
            {
                Trip = await TripDataService.GetTripByIdAsync(_tripId);
            }
            StateHasChanged();
        }
        private void SetMapPoints()
        {
            MapPoints = new List<Marker>();

            if (Trip.StartLocation != null)
            {
                MapPoints.Add(new Marker
                {
                    Description = "Start of Trip",
                    ShowPopup = true,
                    Y = (Trip.StartLocation?.Latitude ?? 0),
                    X = (Trip.StartLocation?.Longitude ?? 0)
                });
            }
            if (Trip.EndLocation != null)
            {
                MapPoints.Add(new Marker
                {
                    Description = "End of Trip",
                    ShowPopup = false,
                    Y = (Trip.EndLocation?.Latitude ?? 0),
                    X = (Trip.EndLocation?.Longitude ?? 0)
                });
            }
        }
    }
}
