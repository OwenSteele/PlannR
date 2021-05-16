using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Trips;
using System;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Trip
{
    public partial class CreateEditTripModal
    {
        [Parameter]
        public EventCallback OnComplete { get; set; }

        [Inject]
        public ITripDataService TripDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public EditTripViewModel EditTripViewModel { get; set; }
        public bool Submitted { get; set; } = false;

        public string Message { get; set; }

        protected override void OnInitialized()
        {
            EditTripViewModel = new EditTripViewModel
            {
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now
            };
        }

        protected async Task HandleValidSubmit()
        {
            if (EditTripViewModel.EndDateTime <= EditTripViewModel.StartDateTime)
            {
                Message = "End date and time must be after the starting date and time.";
                return;
            }

            var response = await TripDataService.CreateAsync(EditTripViewModel);
            HandleResponse(response);

            await OnComplete.InvokeAsync();
        }
        protected void HandleInvalidSubmit()
        {
            Message = "There are some validation errors. Please try again.";
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Successful)
            {
                Message = "Trip added successfully!";

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
