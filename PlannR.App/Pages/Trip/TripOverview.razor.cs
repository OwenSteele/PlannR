using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Trip
{
    public partial class TripOverview
    {
        [Inject]
        public ITripDataService TripDataService { get; set; }
        public ICollection<TripListViewModel> Trips { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Trips = await TripDataService.GetAllTripsAsync();
        }
    }
}
