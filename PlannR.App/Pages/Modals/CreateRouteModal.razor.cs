using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
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
    public partial class CreateRouteModal
    {
        [CascadingParameter]
        IModalService Modal { get; set; }
        [CascadingParameter]
        BlazoredModalInstance ModalInstance { get; set; }
        [CascadingParameter]
        public ModalParameters Parameters { get; set; }

        [Inject]
        public ITripDataService TripDataService { get; set; }
        [Inject]
        public IRouteDataService RouteDataService { get; set; }
        [Inject]
        public IRoutePointDataService RoutePointDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public EditRouteViewModel EditRouteViewModel { get; set; }
        public ICollection<TripNestedViewModel> UserTrips { get; set; }
        [Parameter]
        public List<RoutePointNestedViewModel> RoutePoints { get; set; }
        [Parameter]
        public List<EditRoutePointViewModel> EditableRoutePoints { get; set; }

        [Parameter]
        public DateTime StartTime { get; set; }
        [Parameter]
        public DateTime EndTime { get; set; }

        public bool Submitted { get; set; } = false;

        [Parameter]
        public string Message { get; set; }
        protected async override Task OnInitializedAsync()
        {
            EditRouteViewModel = new EditRouteViewModel
            {
                StartDateTime = DateTime.Today,
                EndDateTime = DateTime.Today,
                Points = new List<Guid>()
            };

            EditableRoutePoints = new();
            foreach(var point in RoutePoints) 
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
                await UpdatePointsAsync();

                var result = await CreateRouteAsync();

                await ModalInstance.CloseAsync(ModalResult.Ok(result));
            }
            else
            {
                await EditRouteAsync();

                await ModalInstance.CloseAsync();
            }
        }

        private async Task UpdatePointsAsync()
        {
            await RoutePointDataService.AddPointRangeAsync(EditableRoutePoints);
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
        private void AddTimesToDates()
        {
            EditRouteViewModel.StartDateTime = EditRouteViewModel.StartDateTime.Date + (StartTime.TimeOfDay- EditRouteViewModel.StartDateTime.TimeOfDay);
            EditRouteViewModel.EndDateTime = EditRouteViewModel.EndDateTime.Date + (EndTime.TimeOfDay- EditRouteViewModel.EndDateTime.TimeOfDay);
        }
    }
}
