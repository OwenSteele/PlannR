﻿using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Locations;
using PlannR.App.Infrastructure.ViewModels.Trips;
using PlannR.App.Pages.Modals;
using System;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Trip
{
    public partial class CreateEditTripModal
    {
        [CascadingParameter]
        IModalService Modal { get; set; }

        [CascadingParameter]
        public ModalParameters Parameters { get; set; }

        [Parameter]
        public EventCallback OnComplete { get; set; }

        [Inject]
        public ITripDataService TripDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public EditTripViewModel EditTripViewModel { get; set; }

        [Parameter]
        public DateTime StartTime { get; set; }
        [Parameter]
        public DateTime EndTime { get; set; }
        public bool Submitted { get; set; } = false;

        public string Message { get; set; }

        protected override void OnInitialized()
        {
            EditTripViewModel = new EditTripViewModel
            {
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now
            };
        }

        protected async Task HandleValidSubmit()
        {

            if (EditTripViewModel.EndDateTime < EditTripViewModel.StartDateTime)
            {
                Message = "End date and time must be after the starting date and time.";
                return;
            }

            AddTimesToDates();

            if (EditTripViewModel.TripId == Guid.Empty)
            {
                var response = await TripDataService.CreateAsync(EditTripViewModel);
                HandleResponse(response, "added");
            }
            else
            {
                var response = await TripDataService.UpdateAsync(EditTripViewModel);
                HandleResponse(response, "changed");
            }

            await OnComplete.InvokeAsync();
        }

        private void AddTimesToDates()
        {
            EditTripViewModel.StartDateTime = EditTripViewModel.StartDateTime.Date + StartTime.TimeOfDay;
            EditTripViewModel.EndDateTime = EditTripViewModel.EndDateTime.Date + EndTime.TimeOfDay;
        }

        protected void HandleInvalidSubmit()
        {
            Message = "There are some validation errors. Please try again.";
        }

        private void HandleResponse(ApiResponse<Guid> response, string message)
        {
            if (response.Success)
            {
                Message = $"Trip {message} successfully!";

                Submitted = true;
            }
            else
            {
                Message = response.Message;

                if (!string.IsNullOrEmpty(response.Errors)) Message += response.Errors;
            }
        }

        public async Task StartLocationModal()
        {
            var parameters = new ModalParameters();

            if(EditTripViewModel.StartLocationId.HasValue)
            {
                parameters.Add("EditLocationId", EditTripViewModel.StartLocationId);
            }            

            var locationModal = Modal.Show<CreateEditLocationModal>("Edit Start Location", parameters);
            var result = await locationModal.Result;

            if (result.Cancelled) return;

            if (EditTripViewModel.StartLocationId == null)
                EditTripViewModel.StartLocationId = (Guid)result.Data;
        }
        public async Task EndLocationModal()
        {
            var parameters = new ModalParameters();

            if (EditTripViewModel.EndLocationId.HasValue)
            {
                parameters.Add("EditLocationId", EditTripViewModel.EndLocationId);
            }
            var locationModal = Modal.Show<CreateEditLocationModal>("Edit End Location", parameters);
            var result = await locationModal.Result;

            if (result.Cancelled) return;

            if (EditTripViewModel.EndLocationId == null)
                EditTripViewModel.EndLocationId = (Guid)result.Data;
        }
    }
}
