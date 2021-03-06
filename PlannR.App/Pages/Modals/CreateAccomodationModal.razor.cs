using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Accomodation;
using PlannR.App.Infrastructure.ViewModels.Nested;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Modals
{
    public partial class CreateAccomodationModal : EditBaseModal
    {
        [CascadingParameter]
        BlazoredModalInstance ModalInstance { get; set; }

        [Inject]
        public ITripDataService TripDataService { get; set; }
        [Inject]
        public IAccomodationDataService AccomodationDataService { get; set; }
        [Inject]
        public IAccomodationTypeDataService AccomodationTypeService { get; set; }

        [Parameter]
        public EditAccomodationViewModel EditAccomodationViewModel { get; set; }
        public ICollection<TripNestedViewModel> UserTrips { get; set; }
        public ICollection<AccomodationTypeNestedViewModel> AccomodationTypes { get; set; }

        [Parameter]
        public DateTime StartTime { get; set; }
        [Parameter]
        public DateTime EndTime { get; set; }
        protected async override Task OnInitializedAsync()
        {
            EditAccomodationViewModel = new EditAccomodationViewModel
            {
                StartDateTime = DateTime.Today.AddDays(1)
            };
            UserTrips = await TripDataService.GetTripNamesAsync();
            AccomodationTypes = await AccomodationTypeService.GetAllTypeNamesAsync();
        }

        protected async Task HandleValidSubmit()
        {
            AddTimesToDates();

            if (EditAccomodationViewModel.AccomodationId == Guid.Empty)
            {
                var result = await CreateAccomodationAsync();

                await ModalInstance.CloseAsync(ModalResult.Ok(result));
            }
            else
            {
                await EditAccomodationAsync();

                await ModalInstance.CloseAsync();
            }
        }

        private async Task EditAccomodationAsync()
        {
            var response = await AccomodationDataService.UpdateAsync(EditAccomodationViewModel);

            HandleResponse(response);
        }

        private async Task<Guid> CreateAccomodationAsync()
        {
            var response = await AccomodationDataService.CreateAsync(EditAccomodationViewModel);

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
                Message = "Accomodation added successfully!";

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
            var typeModal = Modal.Show<CreateAccomodationTypeModal>("");
            var result = await typeModal.Result;

            if (result.Cancelled) return;

            AccomodationTypes = await AccomodationTypeService.GetAllTypeNamesAsync();

            EditAccomodationViewModel.AccomodationTypeId = (Guid)result.Data;
        }
        public async Task LocationModal()
        {
            var parameters = new ModalParameters();

            if (EditAccomodationViewModel.LocationId.HasValue)
            {
                parameters.Add("EditLocationId", EditAccomodationViewModel.LocationId);
            }

            var locationModal = Modal.Show<CreateEditLocationModal>("Edit Location", parameters);
            var result = await locationModal.Result;

            if (result.Cancelled) return;

            if (EditAccomodationViewModel.LocationId == null)
                EditAccomodationViewModel.LocationId = (Guid)result.Data;
        }
        private async Task DeleteItem()
        {
            var result = await ShowDeleteModal($"{EditAccomodationViewModel.Name} Accomodation",
                EditAccomodationViewModel.Name,
                EditAccomodationViewModel.AccomodationId);

            if (result.HasValue)
            {
                await AccomodationDataService.DeleteAsync(result.Value);

                await ModalInstance.CloseAsync();

                NavigationManager.NavigateTo("accomodations");
            }
        }
        private void AddTimesToDates()
        {
            EditAccomodationViewModel.EndDateTime = EditAccomodationViewModel.StartDateTime.AddDays(EditAccomodationViewModel.Nights);
            EditAccomodationViewModel.StartDateTime = EditAccomodationViewModel.StartDateTime.Date + (StartTime.TimeOfDay - EditAccomodationViewModel.StartDateTime.TimeOfDay);
            EditAccomodationViewModel.EndDateTime = EditAccomodationViewModel.EndDateTime.Date + (EndTime.TimeOfDay - EndTime.TimeOfDay);
        }
    }
}
