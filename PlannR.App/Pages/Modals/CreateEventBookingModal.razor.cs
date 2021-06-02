using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Event.Bookings;
using PlannR.App.Infrastructure.ViewModels.Events.Bookings;
using System;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Modals
{
    public partial class CreateEventBookingModal
    {
        [CascadingParameter]
        BlazoredModalInstance ModalInstance { get; set; }
        [Inject]
        public IEventBookingDataService EventBookingDataService { get; set; }
        [Parameter]
        public EditEventBookingViewModel EditEventBookingViewModel { get; set; }
        protected async override Task OnInitializedAsync()
        {
            if (BookingId.HasValue)
            {
                EditEventBookingViewModel = await EventBookingDataService.GetBookingByIdAsync(BookingId.Value);
            }
            else
            {
                EditEventBookingViewModel = new EditEventBookingViewModel
                {
                    EventId = OwnerId
                };
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (EditEventBookingViewModel.BookingId == Guid.Empty)
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
            var response = await EventBookingDataService.UpdateAsync(EditEventBookingViewModel);

            HandleResponse(response);
        }

        private async Task<Guid> CreateEventAsync()
        {
            var response = await EventBookingDataService.CreateAsync(EditEventBookingViewModel);

            HandleResponse(response);

            return response.Data;
        }
        private async Task DeleteItem()
        {
            var result = await ShowDeleteModal($"Booking for {EditEventBookingViewModel.Name}",
                EditEventBookingViewModel.Name,
                EditEventBookingViewModel.BookingId);

            if (result.HasValue)
            {
                await EventBookingDataService.DeleteAsync(result.Value);

                await ModalInstance.CloseAsync();
            }
        }
    }
}
