using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Accomodation.Bookings;
using System;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Modals
{
    public partial class CreateAccomodationBookingModal : EditBookingBaseModal
    {
        [CascadingParameter]
        BlazoredModalInstance ModalInstance { get; set; }
        [Inject]
        public IAccomodationBookingDataService AccomodationBookingDataService { get; set; }

        public EditAccomodationBookingViewModel EditAccomodationBookingViewModel { get; set; }
        protected async override Task OnInitializedAsync()
        {
            if (BookingId.HasValue)
            {
                EditAccomodationBookingViewModel = await AccomodationBookingDataService.GetBookingByIdAsync(BookingId.Value);
            }
            else
            {
                EditAccomodationBookingViewModel = new EditAccomodationBookingViewModel
                {
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
    }
}
