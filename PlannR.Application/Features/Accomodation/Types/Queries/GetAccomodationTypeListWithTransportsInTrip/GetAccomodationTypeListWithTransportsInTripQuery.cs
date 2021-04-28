using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeListWithAccomodationsInTrip
{
    public class GetAccomodationTypeListWithAccomodationsInTripQuery : IRequest<ICollection<AccomodationTypeListWithAccomodationsInTripViewModel>>
    {
        public Guid TripId { get; set; }
    }
}

