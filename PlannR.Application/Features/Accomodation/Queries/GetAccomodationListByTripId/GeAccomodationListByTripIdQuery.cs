using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationListByTripId
{
    public class GetAccomodationListByTripIdQuery : IRequest<ICollection<AccomodationListByTripIdDataModel>>
    {
        public Guid TripId { get; set; }
    }
}
