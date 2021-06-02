using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Transport.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Modals
{
    public partial class CreateTransportBookingModal
    {
        [CascadingParameter]
        BlazoredModalInstance ModalInstance { get; set; }
        [Inject]
        public ITransportBookingDataService TransportBookingDataService { get; set; }

        public EditTransportBookingViewModel EditTransportBookingViewModel { get; set; }
        protected async override Task OnInitializedAsync()
        {
            if (BookingId.HasValue)
            {
                EditTransportBookingViewModel = await TransportBookingDataService.GetBookingByIdAsync(BookingId.Value);
            }
            else
            {
                EditTransportBookingViewModel = new EditTransportBookingViewModel
                {
                    TransportId = OwnerId
                };
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (EditTransportBookingViewModel.BookingId == Guid.Empty)
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
            var response = await TransportBookingDataService.UpdateAsync(EditTransportBookingViewModel);

            HandleResponse(response);
        }

        private async Task<Guid> CreateTransportAsync()
        {
            var response = await TransportBookingDataService.CreateAsync(EditTransportBookingViewModel);

            HandleResponse(response);

            return response.Data;
        }
        private async Task DeleteItem()
        {
            var result = await ShowDeleteModal($"Booking for {EditTransportBookingViewModel.Name}",
                EditTransportBookingViewModel.Name,
                EditTransportBookingViewModel.BookingId);

            if (result.HasValue)
            {
                await TransportBookingDataService.DeleteAsync(result.Value);

                await ModalInstance.CloseAsync();
            }
        }
    }
}
