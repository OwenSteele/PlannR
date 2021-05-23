using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Nested;
using PlannR.App.Infrastructure.ViewModels.Transport;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Modals
{
    public partial class CreateTransportModal
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
        public ITransportDataService TransportDataService { get; set; }
        [Inject]
        public ITransportTypeDataService TransportTypeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public EditTransportViewModel EditTransportViewModel { get; set; }
        public ICollection<TripNestedViewModel> UserTrips { get; set; }
        public ICollection<TransportTypeNestedViewModel> TransportTypes { get; set; }
        public bool Submitted { get; set; } = false;

        public string Message { get; set; }
        protected async override Task OnInitializedAsync()
        {
            EditTransportViewModel = new EditTransportViewModel
            {
                StartDateTime = DateTime.Today,
                EndDateTime = DateTime.Today
            };
            UserTrips = await TripDataService.GetTripNamesAsync();
            TransportTypes = await TransportTypeService.GetAllTypeNamesAsync();
        }

        protected async Task HandleValidSubmit()
        {
            if (EditTransportViewModel.TransportId == Guid.Empty)
            {
                var result = await CreateTransportAsync();

                await ModalInstance.CloseAsync(ModalResult.Ok(result));
            }
            else
            {
                await EditTransportAsync();

                await ModalInstance.CloseAsync();
            }
        }

        private async Task EditTransportAsync()
        {
            var response = await TransportDataService.UpdateAsync(EditTransportViewModel);

            HandleResponse(response);
        }

        private async Task<Guid> CreateTransportAsync()
        {
            var response = await TransportDataService.CreateAsync(EditTransportViewModel);

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
                Message = "Transport added successfully!";

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
            var typeModal = Modal.Show<CreateTransportTypeModal>("");
            var result = await typeModal.Result;

            if (result.Cancelled) return;

            TransportTypes = await TransportTypeService.GetAllTypeNamesAsync();
        }

        public async Task StartLocationModal()
        {
            var locationModal = Modal.Show<CreateEditLocationModal>();
            var result = await locationModal.Result;

            if (result.Cancelled) return;

            if (EditTransportViewModel.StartLocationId == null)
                EditTransportViewModel.StartLocationId = (Guid)result.Data;
        }
        public async Task EndLocationModal()
        {
            var locationModal = Modal.Show<CreateEditLocationModal>();
            var result = await locationModal.Result;

            if (result.Cancelled) return;

            if (EditTransportViewModel.EndLocationId == null)
                EditTransportViewModel.EndLocationId = (Guid)result.Data;
        }
    }
}