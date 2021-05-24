using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Locations;
using PlannR.ComponentLibrary.Map;
using System;
using System.Collections.Generic;
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
        [Inject]
        IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public EditLocationViewModel EditLocationViewModel { get; set; }
        [Parameter]
        public ICollection<LocationListViewModel> ExistingLocations { get; set; }
        [Parameter]
        public Guid ExistingLocationId { get; set; }
        [Parameter]
        public Guid? EditLocationId { get; set; }
        public List<Marker> StartingPoint { get; set; }
        public bool UseExistingLocation { get; set; } = false;
        public bool Submitted { get; set; } = false;

        public string Message { get; set; }

        private LocationDetailViewModel existingLocationModel;

        protected async override Task OnInitializedAsync()
        {
            Marker marker;

            if (EditLocationId.HasValue)
            {
                existingLocationModel = await LocationDataService.GetLocationByIdAsync(EditLocationId.Value);
                EditLocationViewModel = new EditLocationViewModel
                {
                    LocationId = existingLocationModel.LocationId,
                    Name = existingLocationModel.Name,
                    Latitude = existingLocationModel.Latitude,
                    Longitude = existingLocationModel.Longitude,
                    AltitudeInMetres = existingLocationModel.AltitudeInMetres,
                    Address = existingLocationModel.Address
                };
                marker = new Marker
                {
                    Description = existingLocationModel.Name,
                    ShowPopup = true,
                    Y = existingLocationModel.Latitude,
                    X = existingLocationModel.Longitude
                };
            }
            else
            {
                EditLocationViewModel = new();
                marker = new Marker
                {
                    Description = "Select a location",
                    ShowPopup = true,
                    Y = 51.50694390856035,
                    X = -0.12153785423606735
                };
            }

            ExistingLocations = await LocationDataService.GetAllLocationsAsync();

            StartingPoint = new List<Marker>();
            StartingPoint.Add(marker);
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

        protected async Task HandleExistingSubmit()
        {
            if (ExistingLocationId == Guid.Empty) return;

            await ModalInstance.CloseAsync(ModalResult.Ok(ExistingLocationId));
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

            return response.Data;
        }

        protected void HandleInvalidSubmit()
        {
            Message = "There are some validation errors. Please try again.";
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Success)
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

        [JSInvokable]
        public async Task SetMarker()
        {
            double latValue;
            double longValue;
            var result = await JSRuntime.InvokeAsync<string>("deliveryMap.getCurrentMarkerLocation");
            var coords = result.Split(' ');

            if (!double.TryParse(coords[0], out latValue))
            {
                latValue = 0;
            }
            EditLocationViewModel.Latitude = latValue;

            if (!double.TryParse(coords[1], out longValue))
            {
                longValue = 0;
            }
            EditLocationViewModel.Longitude = longValue;
        }
    }
}
