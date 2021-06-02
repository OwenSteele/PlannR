using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.ViewModels.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Modals
{
    public partial class DeleteItemModal
    {
        [CascadingParameter]
        BlazoredModalInstance ModalInstance { get; set; }
        [Parameter]
        public string ItemName { get; set; }
        [Parameter]
        public Guid ItemId { get; set; }
        public string Message { get; set; }
        public DeleteItemViewModel DeleteItemViewModel { get; set; }
        protected override void OnInitialized()
        {
            DeleteItemViewModel = new()
            {
                RequiredName = $"PlannR/{ItemName}"
            };
        }
        protected async Task HandleValidSubmit()
        {
            if (DeleteItemViewModel.RequiredName == DeleteItemViewModel.Input) 
                await ModalInstance.CloseAsync(ModalResult.Ok(ItemId));

            else HandleInvalidSubmit();
        }

        protected void HandleInvalidSubmit()
        {
            Message = "The field must match the text above exactly.";
        }
        private async Task Cancel()
        {
            await ModalInstance.CancelAsync();
        }
    }
}
