using FluentValidation;
using System.Collections.Generic;

namespace PlannR.Application.Features.RoutePoints.Commands.CreateRoutePointRange
{ 
    public class CreateRoutePointRangeCommandValidator : AbstractValidator<ICollection<CreateRoutePointRangeCommand>>
    {
        public CreateRoutePointRangeCommandValidator()
        {
        }
    }
}
