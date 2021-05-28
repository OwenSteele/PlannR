using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.ViewModels.Accomodation;
using PlannR.App.Pages.Modals;
using PlannR.ComponentLibrary.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Accomodation
{
    public partial class AccomodationDetail
    {
        private Guid _AccomodationId;
        [Parameter]
        public string AccomodationId { get; set; }

        [CascadingParameter]
        public IModalService Modal { get; set; }
        [Inject]
        public IAccomodationDataService AccomodationDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public AccomodationDetailViewModel Accomodation { get; set; }
        public List<Marker> MapPoints { get; set; }
        protected async override Task OnInitializedAsync()
        {
            if (Guid.TryParse(AccomodationId, out _AccomodationId))
            {
                Accomodation = await AccomodationDataService.GetAccomodationByIdAsync(_AccomodationId);

                SetMapPoints();
            }
        }
        protected void NavigateToTrip()
        {
            NavigationManager.NavigateTo($"trips/{Accomodation.Trip.TripId}");
        }
        protected void NavigateTo(string uri)
        {
            NavigationManager.NavigateTo($"{uri}");
        }
        private async Task ShowEditAccomodationModal()
        {
            var editModel = new EditAccomodationViewModel
            {
                AccomodationId = Accomodation.AccomodationId,
                Name = Accomodation.Name,
                TripId = Accomodation.Trip.TripId,
                AccomodationTypeId = Accomodation.AccomodationType.AccomodationTypeId,
                StartDateTime = Accomodation.StartDateTime,
                EndDateTime = Accomodation.EndDateTime,
                LocationId = Accomodation.Location?.LocationId,
                CostPerNight = Accomodation.CostPerNight,
                Nights = Accomodation.Nights,
                Description = Accomodation.Description
            };

            var parameters = new ModalParameters();

            parameters.Add("EditAccomodationViewModel", editModel);

            parameters.Add("StartTime", Accomodation.StartDateTime);
            parameters.Add("EndTime", Accomodation.EndDateTime);

            var modal = Modal.Show<CreateAccomodationModal>($"Edit: '{Accomodation.Name}'", parameters);

            var result = await modal.Result;

            if (result.Data != null)
            {
                Accomodation = await AccomodationDataService.GetAccomodationByIdAsync(_AccomodationId);

                StateHasChanged();
            }
        }
        private void SetMapPoints()
        {
            MapPoints = new List<Marker>();

            if (Accomodation.Location != null)
            {
                MapPoints.Add(new Marker
                {
                    Description = Accomodation.Name,
                    ShowPopup = true,
                    Y = (Accomodation.Location?.Latitude ?? 0),
                    X = (Accomodation.Location?.Longitude ?? 0)
                });
            }
        }
        private async Task ShowEditAccomodationBookingModal()
        {
            var title = string.Empty;

            var parameters = new ModalParameters();
            parameters.Add("OwnerId", Accomodation.AccomodationId);

            if (Accomodation.Booking != null)
            {
                parameters.Add("BookingId", Accomodation.Booking.BookingId);
                title = "Edit";
            }
            else
            {
                title = "Create";
            }

            var modal = Modal.Show<CreateAccomodationBookingModal>($"{title}: '{Accomodation.Name}' booking", parameters);

            var result = await modal.Result;

            if (result.Data != null)
            {
                Accomodation = await AccomodationDataService.GetAccomodationByIdAsync(_AccomodationId);

                StateHasChanged();
            }
        }
    }
}
