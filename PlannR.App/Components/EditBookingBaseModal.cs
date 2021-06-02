using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Services.Base;
using System;

namespace PlannR.App.Components
{
    public partial class EditBookingBaseModal : EditBaseModal
    {
        [CascadingParameter]
        public ModalParameters Parameters { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public Guid? BookingId { get; set; }
        [Parameter]
        public Guid OwnerId { get; set; }
        public bool Submitted { get; set; } = false;

        public string Message { get; set; }

        protected void HandleInvalidSubmit()
        {
            Message = "There are some validation errors. Please try again.";
        }

        protected void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Success)
            {
                Message = "Booking updated successfully!";

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
