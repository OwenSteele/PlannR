using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.ViewModels.Trips;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Trip
{
    public partial class TripOverview
    {
        [CascadingParameter]
        public IModalService Modal { get; set; }
        [Inject]
        public ITripDataService TripDataService { get; set; }
        public ICollection<TripListViewModel> Trips { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Trips = await TripDataService.GetAllTripsAsync();
        }
        private void ShowCreateTripModal()
        {
            Modal.Show<CreateEditTripModal>("Add a new Trip");
        }
    }
}
