using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.ViewModels.Locations;
using PlannR.App.Infrastructure.ViewModels.Nested;
using PlannR.App.Infrastructure.ViewModels.Trips;
using PlannR.App.Pages.Modals;
using System;
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
        public NavigationManager NavigationManager { get; set; }
        public TripDetailViewModel Trip { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Guid.TryParse(TripId, out _tripId);

            Trip = await TripDataService.GetTripByIdAsync(_tripId);
        }
        protected void NavigateToAccomodation(string uri)
        {
            NavigationManager.NavigateTo($"accomodation/{uri}");
        }
        protected void NavigateToTransport(string uri)
        {
            NavigationManager.NavigateTo($"transport/{uri}");
        }
        protected void NavigateToEvents(string uri)
        {
            NavigationManager.NavigateTo($"events/{uri}");
        }
        protected void NavigateToRoutes(string uri)
        {
            NavigationManager.NavigateTo($"routes/{uri}");
        }
        private async Task ShowEditTripModal()
        {
            var editModel = new EditTripViewModel
            {
                TripId = Trip.TripId,
                Name = Trip.Name,
                StartDateTime = Trip.StartDateTime,
                EndDateTime = Trip.EndDateTime
            };

            var parameters = new ModalParameters();

            parameters.Add("EditTripViewModel", editModel);

            var modal = Modal.Show<CreateEditTripModal>($"Edit: '{Trip.Name}'", parameters);

            var result = await modal.Result;

            if (result.Cancelled)
                Trip = await TripDataService.GetTripByIdAsync(_tripId);
        }
        private async Task ShowEditLocationModal(bool IsStartLocation)
        {
            var model = IsStartLocation ? Trip.StartLocation : Trip.EndLocation;

            if(model == null)
            {
                var modal = Modal.Show<CreateEditLocationModal>("New Location");

                var result = await modal.Result;

                if (!result.Cancelled)
                {
                    var id = (Guid)result.Data;

                    Trip = await TripDataService.GetTripByIdAsync(_tripId);
                }                
            }
            else
            {
                var editModel = new EditLocationViewModel
                {
                    Name = model.Name,
                    Address = model.Address,
                    AltitudeInMetres = model.AltitudeInMetres,
                    Latitude = model.Latitude,
                    LocationId = model.LocationId,
                    Longitude = model.Longitude
                };
                var parameters = new ModalParameters();

                parameters.Add("CreateEditLocationModal", editModel);

                var modal = Modal.Show<CreateEditLocationModal>(
                    $"Edit {Trip.StartLocation.Name}", parameters);

                var result = await modal.Result;

                if (!result.Cancelled)
                    Trip = await TripDataService.GetTripByIdAsync(_tripId);
            }
        }
    }
}
