using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.ViewModels.Trips;
using System;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Trip
{
    public partial class TripDetail
    {
        private Guid _tripId;
        [Parameter]
        public string TripId { get; set; }

        [CascadingParameter]
        public IModalService Modal { get; set; }
        [Inject]
        public ITripDataService TripDataService { get; set; }
        public TripDetailViewModel Trip { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Guid.TryParse(TripId, out _tripId);

            Trip = await TripDataService.GetTripByIdAsync(_tripId);
        }
        private async Task ShowEditTripModal()
        {
            var parameters = new ModalParameters();

            parameters.Add("Name", Trip.Name);
            parameters.Add("Start", Trip.StartDateTime);
            parameters.Add("End", Trip.EndDateTime);


            var modal = Modal.Show<CreateEditTripModal>($"Edit {Trip.Name}", parameters);

            var result = await modal.Result;

            if (result.Cancelled)
                Trip = await TripDataService.GetTripByIdAsync(_tripId);
        }
    }
}
