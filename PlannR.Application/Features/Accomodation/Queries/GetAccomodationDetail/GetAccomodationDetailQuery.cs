using MediatR;
using System;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationsDetail
{
    public class GetAccomodationDetailQuery : IRequest<AccomodationDetailDataModel>
    {
        public Guid Id { get; set; }
    }
}
