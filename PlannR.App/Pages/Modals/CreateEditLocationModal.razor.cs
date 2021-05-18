using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Modals
{
    public partial class CreateEditLocationModal
    {
        [CascadingParameter]
        public ModalParameters Parameters { get; set; }

        [Parameter]
        public EventCallback OnComplete { get; set; }

        [Inject]
        public ILocationDataService TripDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public EditLocationViewModel EditLocationViewModel { get; set; }
        public bool Submitted { get; set; } = false;

        public string Message { get; set; }

        protected override void OnInitialized()
        {
            if (Parameters == null) 
                EditLocationViewModel = new EditLocationViewModel();
            else 
                EditLocationViewModel = Parameters.Get<EditLocationViewModel>("EditLocationViewModel");
        }

        protected async Task HandleValidSubmit()
        {
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
                Message = "Location added successfully!";

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
