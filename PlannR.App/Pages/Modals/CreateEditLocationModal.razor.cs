using Blazored.Modal;
using Blazored.Modal.Services;
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
        BlazoredModalInstance ModalInstance { get; set; }
        [CascadingParameter]
        public ModalParameters Parameters { get; set; }

        [Inject]
        public ILocationDataService LocationDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public EditLocationViewModel EditLocationViewModel { get; set; }
        public bool Submitted { get; set; } = false;

        public string Message { get; set; }

        protected override void OnInitialized()
        {
            EditLocationViewModel = new EditLocationViewModel();
        }

        protected async Task HandleValidSubmit()
        {
            if (EditLocationViewModel.LocationId == Guid.Empty)
            {
                var result = await CreateLocationAsync();

                await ModalInstance.CloseAsync(ModalResult.Ok(result));
            }
            else
            {
                await EditLocationAsync();

                await ModalInstance.CloseAsync();
            }  
        }

        private async Task EditLocationAsync()
        {
            var response = await LocationDataService.UpdateAsync(EditLocationViewModel);

            HandleResponse(response);
        }

        private async Task<Guid> CreateLocationAsync()
        {
            var response = await LocationDataService.CreateAsync(EditLocationViewModel);

            HandleResponse(response);

            return response.Context;
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
