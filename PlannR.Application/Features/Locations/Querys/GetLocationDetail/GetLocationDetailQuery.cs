using MediatR;
using System;

namespace PlannR.Application.Features.Locations.Queries.GetLocationsDetail
{
    public class GetLocationDetailQuery : IRequest<LocationDetailDataModel>
    {
        public Guid LocationId { get; set; }
    }
}
