using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.ViewModels.Transport;
using PlannR.App.Pages.Modals;
using PlannR.ComponentLibrary.Map;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Transport
{
    public partial class TransportDetail
    {
        private Guid _TransportId;
        [Parameter]
        public string TransportId { get; set; }

        [CascadingParameter]
        public IModalService Modal { get; set; }
        [Inject]
        public ITransportDataService TransportDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public TransportDetailViewModel Transport { get; set; }
        public List<Marker> MapPoints { get; set; }
        protected async override Task OnInitializedAsync()
        {
            if (Guid.TryParse(TransportId, out _TransportId))
            {
                Transport = await TransportDataService.GetTransportByIdAsync(_TransportId);

                SetMapPoints();
            }
        }
        protected void NavigateToTrip()
        {
            NavigationManager.NavigateTo($"trips/{Transport.Trip.TripId}");
        }
        protected void NavigateTo(string uri)
        {
            NavigationManager.NavigateTo($"{uri}");
        }
        private async Task ShowEditTransportModal()
        {
            var editModel = new EditTransportViewModel
            {
                TransportId = Transport.TransportId,
                Name = Transport.Name,
                TripId = Transport.Trip.TripId,
                TransportTypeId = Transport.TransportType.TransportTypeId,
                StartDateTime = Transport.StartDateTime,
                EndDateTime = Transport.EndDateTime,
                StartLocationId = Transport.StartLocation?.LocationId,
                EndLocationId = Transport.EndLocation?.LocationId,
                Description = Transport.Description
            };

            var parameters = new ModalParameters();

            parameters.Add("EditTransportViewModel", editModel);

            parameters.Add("StartTime", Transport.StartDateTime);
            parameters.Add("EndTime", Transport.EndDateTime);

            var modal = Modal.Show<CreateTransportModal>($"Edit: '{Transport.Name}'", parameters);

            var result = await modal.Result;

            if (result.Data != null)
            {
                Transport = await TransportDataService.GetTransportByIdAsync(_TransportId);

                StateHasChanged();
            }
        }
        private void SetMapPoints()
        {
            MapPoints = new List<Marker>();

            if (Transport.StartLocation != null)
            {
                MapPoints.Add(new Marker
                {
                    Description = $"{Transport.Name} (start of trip)",
                    ShowPopup = true,
                    Y = (Transport.StartLocation?.Latitude ?? 0),
                    X = (Transport.StartLocation?.Longitude ?? 0)
                });
            }

            if (Transport.EndLocation != null)
            {
                MapPoints.Add(new Marker
                {
                    Description = $"{Transport.Name} (end of trip)",
                    ShowPopup = (Transport.StartLocation == null),
                    Y = (Transport.EndLocation?.Latitude ?? 0),
                    X = (Transport.EndLocation?.Longitude ?? 0)
                });
            }
        }
        private async Task ShowEditTransportBookingModal()
        {
            var title = string.Empty;

            var parameters = new ModalParameters();
            parameters.Add("OwnerId", Transport.TransportId);

            if (Transport.Booking != null)
            {
                parameters.Add("BookingId", Transport.Booking.BookingId);
                title = "Edit";
            }
            else
            {
                title = "Create";
            }

            var modal = Modal.Show<CreateTransportBookingModal>($"{title}: '{Transport.Name}' booking", parameters);

            var result = await modal.Result;

            if (result.Data != null)
            {
                Transport = await TransportDataService.GetTransportByIdAsync(_TransportId);

                StateHasChanged();
            }
        }
        private async Task ShowFullMapModal()
        {
            if (Transport.StartLocation == null && Transport.EndLocation == null) return;

            var parameters = new ModalParameters();

            var markers = new List<Marker>();

            if (Transport.StartLocation != null)
            {
                markers.Add(new Marker
                {
                    Description = $"{Transport.Name} - ({Transport.TransportType.Name})",
                    X = Transport.StartLocation.Longitude,
                    Y = Transport.StartLocation.Latitude,
                    ShowPopup = true
                });
            }
            if (Transport.EndLocation != null)
            {
                markers.Add(new Marker
                {
                    Description = $"{Transport.Name} - ({Transport.TransportType.Name})",
                    X = Transport.EndLocation.Longitude,
                    Y = Transport.EndLocation.Latitude,
                    ShowPopup = (Transport.StartLocation == null)
                });
            }

            parameters.Add("MapPoints", markers);

            var modal = Modal.Show<FullMapModal>($"Location of {Transport.Name}", parameters);

            await modal.Result;
        }
    }
}
