using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.ViewModels.Accomodation;
using PlannR.App.Pages.Modals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Accomodation
{
    public partial class AccomodationOverview
    {
        [CascadingParameter]
        public IModalService Modal { get; set; }
        [Inject]
        public IAccomodationDataService AccomodationDataService { get; set; }
        public ICollection<AccomodationListViewModel> Accomodations { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Accomodations = await AccomodationDataService.GetAllAccomodationAsync();
        }
        private async Task ShowCreateAccomodationModal()
        {
            var modal = Modal.Show<CreateAccomodationModal>("Add a new Accomodation");

            var result = await modal.Result;

            if (!result.Cancelled)
            {
                Accomodations = await AccomodationDataService.GetAllAccomodationAsync();
                StateHasChanged();
            }
        }
    }
}
