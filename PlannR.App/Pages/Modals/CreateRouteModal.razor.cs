using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Nested;
using PlannR.App.Infrastructure.ViewModels.Routes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Modals
{
    public partial class CreateRouteModal: EditBaseModal
    {
        [CascadingParameter]
        BlazoredModalInstance ModalInstance { get; set; }

        [Inject]
        public ITripDataService TripDataService { get; set; }
        [Inject]
        public IRouteDataService RouteDataService { get; set; }
        [Inject]
        public IRoutePointDataService RoutePointDataService { get; set; }
        [Parameter]
        public EditRouteViewModel EditRouteViewModel { get; set; }
        public ICollection<TripNestedViewModel> UserTrips { get; set; }
        [Parameter]
        public List<RoutePointNestedViewModel> RoutePoints { get; set; }
        [Parameter]
        public List<EditRoutePointViewModel> EditableRoutePoints { get; set; }
        [Parameter]
        public List<Guid> PointsToDelete { get; set; } = new();
        [Parameter]
        public List<EditRoutePointViewModel> PointsToAdd { get; set; } = new();

        [Parameter]
        public DateTime StartTime { get; set; }
        [Parameter]
        public DateTime EndTime { get; set; }
        protected async override Task OnInitializedAsync()
        {
            EditRouteViewModel = new EditRouteViewModel
            {
                StartDateTime = DateTime.Today,
                EndDateTime = DateTime.Today,
                Points = new List<Guid>()
            };

            EditableRoutePoints = new();
            if(RoutePoints == null) RoutePoints = new();

            foreach (var point in RoutePoints) 
            {
                EditableRoutePoints.Add(new EditRoutePointViewModel
                {
                    Id = point.Id,
                    LocationId = point.Location.LocationId,
                    StartDateTime = point.StartDateTime,
                    EndDateTime = point.EndDateTime
                });
            }

            UserTrips = await TripDataService.GetTripNamesAsync();
        }

        protected async Task HandleValidSubmit()
        {
            AddTimesToDates();

            if (EditRouteViewModel.RouteId == Guid.Empty)
            {
                var result = await CreateRouteAsync();

                EditRouteViewModel.RouteId = result;

                await UpdatePointsAsync();

                await ModalInstance.CloseAsync(ModalResult.Ok(result));
            }
            else
            {
                await EditRouteAsync();

                await UpdatePointsAsync();

                await ModalInstance.CloseAsync();
            }
        }

        private async Task UpdatePointsAsync()
        {
            if(PointsToDelete.Any()) await RoutePointDataService.DeletePointRangeAsync(PointsToDelete);

            if (PointsToAdd.Any())
            {
                foreach(var point in PointsToAdd)
                    point.RouteId = EditRouteViewModel.RouteId;

                await RoutePointDataService.AddPointRangeAsync(PointsToAdd);
            }
        }

        protected void HandleInvalidSubmit()
        {
            Message = "There are some validation errors. Please try again.";
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Success)
            {
                Message = "Route added successfully!";

                Submitted = true;
            }
            else
            {
                Message = response.Message;

                if (!string.IsNullOrEmpty(response.Errors)) Message += response.Errors;
            }
        }
        private async Task EditRouteAsync()
        {
            var response = await RouteDataService.UpdateAsync(EditRouteViewModel);

            HandleResponse(response);
        }

        private async Task<Guid> CreateRouteAsync()
        {
            var response = await RouteDataService.CreateAsync(EditRouteViewModel);

            HandleResponse(response);

            return response.Data;
        }
        private async Task DeleteItem()
        {
            var result = await ShowDeleteModal($"{EditRouteViewModel.Name} Route",
                EditRouteViewModel.Name,
                EditRouteViewModel.RouteId);

            if (result.HasValue)
            {
                await RouteDataService.DeleteAsync(result.Value);

                await ModalInstance.CloseAsync();

                NavigationManager.NavigateTo("routes");
            }
        }
        private void AddTimesToDates()
        {
            EditRouteViewModel.StartDateTime = EditRouteViewModel.StartDateTime.Date + (StartTime.TimeOfDay- EditRouteViewModel.StartDateTime.TimeOfDay);
            EditRouteViewModel.EndDateTime = EditRouteViewModel.EndDateTime.Date + (EndTime.TimeOfDay- EditRouteViewModel.EndDateTime.TimeOfDay);
        }
    }
}
