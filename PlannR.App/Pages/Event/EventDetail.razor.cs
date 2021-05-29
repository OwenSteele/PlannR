using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.ViewModels.Event;
using PlannR.App.Infrastructure.ViewModels.Events;
using PlannR.App.Pages.Modals;
using PlannR.ComponentLibrary.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Event
{
    public partial class EventDetail
    {
        private Guid _EventId;
        [Parameter]
        public string EventId { get; set; }

        [CascadingParameter]
        public IModalService Modal { get; set; }
        [Inject]
        public IEventDataService EventDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public EventDetailViewModel Event { get; set; }
        public List<Marker> MapPoints { get; set; }
        protected async override Task OnInitializedAsync()
        {
            if (Guid.TryParse(EventId, out _EventId))
            {
                Event = await EventDataService.GetEventByIdAsync(_EventId);

                SetMapPoints();
            }
        }
        protected void NavigateToTrip()
        {
            NavigationManager.NavigateTo($"trips/{Event.Trip.TripId}");
        }
        protected void NavigateTo(string uri)
        {
            NavigationManager.NavigateTo($"{uri}");
        }
        private async Task ShowEditEventModal()
        {
            var editModel = new EditEventViewModel
            {
                EventId = Event.EventId,
                Name = Event.Name,
                TripId = Event.Trip.TripId,
                EventTypeId = Event.EventType.EventTypeId,
                StartDateTime = Event.StartDateTime,
                EndDateTime = Event.EndDateTime,
                LocationId = Event.Location?.LocationId,
                CompanyName = Event.CompanyName,
                Description = Event.Description
            };

            var parameters = new ModalParameters();

            parameters.Add("EditEventViewModel", editModel);

            parameters.Add("StartTime", Event.StartDateTime);
            parameters.Add("EndTime", Event.EndDateTime);

            var modal = Modal.Show<CreateEventModal>($"Edit: '{Event.Name}'", parameters);

            var result = await modal.Result;

            if (result.Data != null)
            {
                Event = await EventDataService.GetEventByIdAsync(_EventId);

                StateHasChanged();
            }
        }
        private void SetMapPoints()
        {
            MapPoints = new List<Marker>();

            if (Event.Location != null)
            {
                MapPoints.Add(new Marker
                {
                    Description = Event.Name,
                    ShowPopup = true,
                    Y = (Event.Location?.Latitude ?? 0),
                    X = (Event.Location?.Longitude ?? 0)
                });
            }
        }
        private async Task ShowEditEventBookingModal()
        {
            var title = string.Empty;

            var parameters = new ModalParameters();
            parameters.Add("OwnerId", Event.EventId);

            if (Event.Booking != null)
            {
                parameters.Add("BookingId", Event.Booking.BookingId);
                title = "Edit";
            }
            else
            {
                title = "Create";
            }

            var modal = Modal.Show<CreateEventBookingModal>($"{title}: '{Event.Name}' booking", parameters);

            var result = await modal.Result;

            if (result.Data != null)
            {
                Event = await EventDataService.GetEventByIdAsync(_EventId);

                StateHasChanged();
            }
        }
    }
}
