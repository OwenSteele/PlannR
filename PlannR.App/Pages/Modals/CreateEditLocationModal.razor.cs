using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PlannR.App.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Contracts.View;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Locations;
using PlannR.ComponentLibrary.Map;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Modals
{
    public partial class CreateEditLocationModal: EditBaseModal
    {
        [CascadingParameter]
        BlazoredModalInstance ModalInstance { get; set; }

        [Inject]
        public ILocationDataService LocationDataService { get; set; }
        [Inject]
        IJSRuntime JSRuntime { get; set; }
        [Inject]
        IMapService MapService { get; set; }

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

            StartingPoint = new List<Marker>
            {
                marker
            };
        }

        protected async Task HandleValidSubmit()
        {
            Guid? data = null;

            if (EditLocationViewModel.LocationId == Guid.Empty)
            {
                var result = await CreateLocationAsync();

                data = result;
            }
            else
            {
                await EditLocationAsync();
            }

            if (Submitted)
            {
                if (data.HasValue)
                    await ModalInstance.CloseAsync(ModalResult.Ok(data.Value));

                else await ModalInstance.CloseAsync();
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
            var result = await JSRuntime.InvokeAsync<string>("deliveryMap.getCurrentMarkerLocation");

            var coords = MapService.ParseCoordinates(result);
            
            EditLocationViewModel.Longitude = coords.Item1;
            EditLocationViewModel.Latitude = coords.Item2;
        }
        private async Task DeleteItem(Guid? otherLocationId = null)
        {
            var result = await ShowDeleteModal($"{EditLocationViewModel.Name} Location",
                EditLocationViewModel.Name,
                otherLocationId ?? EditLocationViewModel.LocationId);
            
            if (result.HasValue)
            {
                await LocationDataService.DeleteAsync(result.Value);

                await ModalInstance.CloseAsync();
            }
        }
    }
}
