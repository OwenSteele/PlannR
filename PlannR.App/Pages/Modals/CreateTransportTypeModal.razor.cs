using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Transport.Types;
using System;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Modals
{
    public partial class CreateTransportTypeModal
    {
        [CascadingParameter]
        BlazoredModalInstance ModalInstance { get; set; }
        [CascadingParameter]
        public ModalParameters Parameters { get; set; }

        [Inject]
        public ITransportTypeDataService TransportTypeDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public TransportTypeOfNameViewModel TransportTypeOfNameViewModel { get; set; }
        public bool Submitted { get; set; } = false;

        public string Message { get; set; }

        protected override void OnInitialized()
        {
            TransportTypeOfNameViewModel = new TransportTypeOfNameViewModel();
        }

        protected async Task HandleValidSubmit()
        {
            var response = await TransportTypeDataService.CreateAsync(TransportTypeOfNameViewModel);

            HandleResponse(response);
            
            if(response.Success)
            await ModalInstance.CloseAsync(ModalResult.Ok(response.Data));
        }

        protected void HandleInvalidSubmit()
        {
            Message = "There are some validation errors. Please try again.";
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Success)
            {
                Message = "Transport Type added successfully!";

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
