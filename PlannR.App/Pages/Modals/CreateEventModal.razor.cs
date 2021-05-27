using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Event;
using PlannR.App.Infrastructure.ViewModels.Events;
using PlannR.App.Infrastructure.ViewModels.Nested;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Modals
{
    public partial class CreateEventModal
    {
        [CascadingParameter]
        IModalService Modal { get; set; }
        [CascadingParameter]
        BlazoredModalInstance ModalInstance { get; set; }
        [CascadingParameter]
        public ModalParameters Parameters { get; set; }

        [Inject]
        public ITripDataService TripDataService { get; set; }
        [Inject]
        public IEventDataService EventDataService { get; set; }
        [Inject]
        public IEventTypeDataService EventTypeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public EditEventViewModel EditEventViewModel { get; set; }
        public ICollection<TripNestedViewModel> UserTrips { get; set; }
        public ICollection<EventTypeNestedViewModel> EventTypes { get; set; }

        [Parameter]
        public DateTime StartTime { get; set; }
        [Parameter]
        public DateTime EndTime { get; set; }
        public bool Submitted { get; set; } = false;

        public string Message { get; set; }
        protected async override Task OnInitializedAsync()
        {
            EditEventViewModel = new EditEventViewModel
            {
                StartDateTime = DateTime.Today,
                EndDateTime = DateTime.Today
            };
            UserTrips = await TripDataService.GetTripNamesAsync();
            EventTypes = await EventTypeService.GetAllTypeNamesAsync();
        }

        protected async Task HandleValidSubmit()
        {
            AddTimesToDates();

            if (EditEventViewModel.EventId == Guid.Empty)
            {
                var result = await CreateEventAsync();

                await ModalInstance.CloseAsync(ModalResult.Ok(result));
            }
            else
            {
                await EditEventAsync();

                await ModalInstance.CloseAsync();
            }
        }

        private async Task EditEventAsync()
        {
            var response = await EventDataService.UpdateAsync(EditEventViewModel);

            HandleResponse(response);
        }

        private async Task<Guid> CreateEventAsync()
        {
            var response = await EventDataService.CreateAsync(EditEventViewModel);

            HandleResponse(response);

            return response.Data;
        }

        protected void HandleInvalidSubmit()
        {
            Message = "There are some validation errors. Please try again.";
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Success)
            {
                Message = "Event added successfully!";

                Submitted = true;
            }
            else
            {
                Message = response.Message;

                if (!string.IsNullOrEmpty(response.Errors)) Message += response.Errors;
            }
        }
        public async Task CreateTypeModal()
        {
            var typeModal = Modal.Show<CreateEventTypeModal>("");
            var result = await typeModal.Result;

            if (result.Cancelled) return;

            EventTypes = await EventTypeService.GetAllTypeNamesAsync();

            EditEventViewModel.EventTypeId = (Guid)result.Data;
        }
        public async Task LocationModal()
        {
            var parameters = new ModalParameters();

            if (EditEventViewModel.LocationId.HasValue)
            {
                parameters.Add("EditLocationId", EditEventViewModel.LocationId);
            }

            var locationModal = Modal.Show<CreateEditLocationModal>("Edit Location", parameters);
            var result = await locationModal.Result;

            if (result.Cancelled) return;

            if (EditEventViewModel.LocationId == null)
                EditEventViewModel.LocationId = (Guid)result.Data;
        }
        private void AddTimesToDates()
        {
            EditEventViewModel.StartDateTime = EditEventViewModel.StartDateTime.Date + (StartTime.TimeOfDay- EditEventViewModel.StartDateTime.TimeOfDay);
            EditEventViewModel.EndDateTime = EditEventViewModel.EndDateTime.Date + (EndTime.TimeOfDay- EditEventViewModel.EndDateTime.TimeOfDay);
        }
    }
}
