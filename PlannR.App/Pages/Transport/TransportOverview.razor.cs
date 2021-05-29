using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.ViewModels.Transport;
using PlannR.App.Pages.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Transport
{
    public partial class TransportOverview
    {
        [CascadingParameter]
        public IModalService Modal { get; set; }
        [Inject]
        public ITransportDataService TransportDataService { get; set; }
        public ICollection<TransportListViewModel> Transports { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Transports = await TransportDataService.GetAllTransportAsync();
        }
        private async Task ShowCreateTransportModal()
        {
            var modal = Modal.Show<CreateTransportModal>("Add a new Transport");

            var result = await modal.Result;

            if (!result.Cancelled)
            {
                Transports = await TransportDataService.GetAllTransportAsync();
                StateHasChanged();
            }
        }
    }
}
