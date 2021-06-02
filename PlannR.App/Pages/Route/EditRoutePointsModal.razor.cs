using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.ViewModels.Routes;
using PlannR.App.Pages.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Route
{
    public partial class EditRoutePointsModal
    {
        [CascadingParameter]
        IModalService Modal { get; set; }
        [CascadingParameter(Name = "EditParam")]
        public List<EditRoutePointViewModel> EditableRoutePoints { get; set; }
        [CascadingParameter(Name = "DeleteParam")]
        public List<Guid> PointsToDelete { get; set; }
        [CascadingParameter(Name ="AddParam")]
        public List<EditRoutePointViewModel> PointsToAdd { get; set; }
        [CascadingParameter]
        public string Message { get; set; }

        [Parameter]
        public EditRoutePointViewModel CurrentPoint { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        protected override void OnInitialized()
        {
            if (EditableRoutePoints == null) EditableRoutePoints = new();

            SetCurrentPoint();
        }
        public async Task LocationModal()
        {
            var locationModal = Modal.Show<CreateEditLocationModal>("Add Location");
            var result = await locationModal.Result;

            if (result.Cancelled) return;

            CurrentPoint.LocationId = (Guid)result.Data;
        }
        public void AddRoutePoint()
        {
            var context = new ValidationContext(CurrentPoint, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(CurrentPoint, context, validationResults, true))
            {
                Message = "Point is not valid - please check required fields and location";
                return;
            }

            CurrentPoint.StartDateTime += StartTime.TimeOfDay;
            CurrentPoint.EndDateTime += EndTime.TimeOfDay;

            PointsToAdd.Add(CurrentPoint);
            EditableRoutePoints.Add(CurrentPoint);

            SetCurrentPoint();
        }
        public void RemoveRoutePoint(EditRoutePointViewModel point)
        {
            EditableRoutePoints.Remove(point);
            if (PointsToAdd.Contains(point)) PointsToAdd.Remove(point);

            else if (point.Id != Guid.Empty) PointsToDelete.Add(point.Id);
        }

        private void SetCurrentPoint()
        {
            CurrentPoint = new EditRoutePointViewModel
            {
                StartDateTime = DateTime.Today,
                EndDateTime = DateTime.Today
            };

            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
        }
    }
}
