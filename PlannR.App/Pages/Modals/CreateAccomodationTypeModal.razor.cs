using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Accomodation.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Modals
{
    public partial class CreateAccomodationTypeModal
    {
        [CascadingParameter]
        BlazoredModalInstance ModalInstance { get; set; }
        [CascadingParameter]
        public ModalParameters Parameters { get; set; }

        [Inject]
        public IAccomodationTypeDataService AccomodationTypeDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public AccomodationTypeOfNameViewModel AccomodationTypeOfNameViewModel { get; set; }
        public bool Submitted { get; set; } = false;

        public string Message { get; set; }

        protected override void OnInitialized()
        {
            AccomodationTypeOfNameViewModel = new AccomodationTypeOfNameViewModel();
        }

        protected async Task HandleValidSubmit()
        {
            var response = await AccomodationTypeDataService.CreateAsync(AccomodationTypeOfNameViewModel);

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
                Message = "Accomodation Type added successfully!";

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
