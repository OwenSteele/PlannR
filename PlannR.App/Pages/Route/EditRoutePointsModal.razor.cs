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
        [CascadingParameter]
        public List<RoutePointNestedViewModel> RoutePoints { get; set; }
        [CascadingParameter]
        public string Message { get; set; }

        [Parameter]
        public RoutePointNestedViewModel CurrentPoint { get; set; }

        protected override void OnInitialized()
        {
            CurrentPoint = new RoutePointNestedViewModel
            {
                StartDateTime = DateTime.Today,
                EndDateTime = DateTime.Today
            };
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

            RoutePoints.Add(CurrentPoint);

            CurrentPoint = new RoutePointNestedViewModel
            {
                StartDateTime = DateTime.Today,
                EndDateTime = DateTime.Today
            };
        }
        public void RemoveRoutePoint(RoutePointNestedViewModel point)
        {
            RoutePoints.Remove(point);
        }
    }
}
