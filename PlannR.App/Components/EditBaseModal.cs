using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Pages.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Components
{
    public partial class EditBaseModal: ComponentBase
    {
        [CascadingParameter]
        protected IModalService Modal { get; set; }
        [CascadingParameter]
        public ModalParameters Parameters { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public bool Submitted { get; set; } = false;

        public string Message { get; set; }

        protected async Task<Guid?> ShowDeleteModal(string title, string name, Guid id)
        {
            var parameters = new ModalParameters();

            parameters.Add("ItemName", name);
            parameters.Add("ItemId", id);

            var locationModal = Modal.Show<DeleteItemModal>($"Edit {title}", parameters);
            var result = await locationModal.Result;

            return (result.Data == null) ? null : (Guid)result.Data;
        }
    }
}
