using MediatR;
using System;
using System.Collections.Generic;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationsDetail
{
    public class GetAccomodationDetailQuery : IRequest<ICollection<AccomodationDetailViewModel>>
    {
        public Guid Id { get; set; }
    }
}
