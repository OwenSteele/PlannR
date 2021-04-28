using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeListWithAccomodationsInTrip
{
    public class AccomodationTypeListWithAccomodationsInTripViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Guid> AccomodationIds { get; set; }
    }
}
