using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Accomodation.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Modals
{
    public partial class CreateAccomodationBookingModal
    {
        [CascadingParameter]
        IModalService Modal { get; set; }
        [CascadingParameter]
        BlazoredModalInstance ModalInstance { get; set; }
        [CascadingParameter]
        public ModalParameters Parameters { get; set; }
        [Inject]
        public IAccomodationBookingDataService AccomodationBookingDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public Guid? BookingId { get; set; }
        [Parameter]
        public Guid OwnerId { get; set; }

        public EditAccomodationBookingViewModel EditAccomodationBookingViewModel { get; set; }
        public bool Submitted { get; set; } = false;

        public string Message { get; set; }
        protected async override Task OnInitializedAsync()
        {
            if (BookingId.HasValue)
            {
                EditAccomodationBookingViewModel = await AccomodationBookingDataService.GetBookingByIdAsync(BookingId.Value);
            }
            else
            {
                EditAccomodationBookingViewModel = new EditAccomodationBookingViewModel {
                    AccomodationId = OwnerId
                };
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (EditAccomodationBookingViewModel.BookingId == Guid.Empty)
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
            var response = await AccomodationBookingDataService.UpdateAsync(EditAccomodationBookingViewModel);

            HandleResponse(response);
        }

        private async Task<Guid> CreateAccomodationAsync()
        {
            var response = await AccomodationBookingDataService.CreateAsync(EditAccomodationBookingViewModel);

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
    }
}
