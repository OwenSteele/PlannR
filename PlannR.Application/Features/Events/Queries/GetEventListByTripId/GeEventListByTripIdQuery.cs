using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Events.Queries.GetEventListByTripId
{
    public class GetEventListByTripIdQuery : IRequest<ICollection<EventListByTripIdDataModel>>
    {
        public Guid TripId { get; set; }
    }
}
