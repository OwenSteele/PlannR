//using Blazored.Modal;
//using Blazored.Modal.Services;
//using Microsoft.AspNetCore.Components;
//using PlannR.App.Infrastructure.Contracts.Managers;
//using PlannR.App.Infrastructure.Services.Base;
//using PlannR.App.Infrastructure.ViewModels.Booking;
//using System;
//using System.Threading.Tasks;

//namespace PlannR.App.Pages.Modals
//{
//    public partial class CreateBookingModal
//    {
//        [CascadingParameter]
//        IModalService Modal { get; set; }
//        [CascadingParameter]
//        BlazoredModalInstance ModalInstance { get; set; }
//        [CascadingParameter]
//        public ModalParameters Parameters { get; set; }
//        [Inject]
//        public IBookingManager BookingManager { get; set; }

//        [Inject]
//        public NavigationManager NavigationManager { get; set; }

//        [Parameter]
//        public Guid? BookingId { get; set; }
//        [Parameter]
//        public Guid OwnerId { get; set; }

//        public EditBookingViewModel EditBookingViewModel { get; set; }
//        public bool Submitted { get; set; } = false;

//        public string Message { get; set; }
//        protected async override Task OnInitializedAsync()
//        {
//            EditBookingViewModel = await BookingManager.GetBookingModelAsync(BookingId);
//        }

//        protected async Task HandleValidSubmit()
//        {
//            var response = await BookingManager.SubmitBookingModelAsync(EditBookingViewModel);

//            HandleResponse(response);

//            if(Submitted) await ModalInstance.CloseAsync(ModalResult.Ok(response?.Data));
//        }

//        protected void HandleInvalidSubmit()
//        {
//            Message = "There are some validation errors. Please try again.";
//        }

//        private void HandleResponse(ApiResponse<Guid> response)
//        {
//            if (response.Success)
//            {
//                Message = " added successfully!";

//                Submitted = true;
//            }
//            else
//            {
//                Message = response.Message;

//                if (!string.IsNullOrEmpty(response.Errors)) Message += response.Errors;
//            }
//        }
//    }
//}
