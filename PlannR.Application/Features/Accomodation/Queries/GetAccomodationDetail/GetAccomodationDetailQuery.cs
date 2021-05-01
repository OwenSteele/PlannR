using MediatR;
using System;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationsDetail
{
    public class GetAccomodationDetailQuery : IRequest<AccomodationDetailViewModel>
    {
        public Guid Id { get; set; }
    }
}
