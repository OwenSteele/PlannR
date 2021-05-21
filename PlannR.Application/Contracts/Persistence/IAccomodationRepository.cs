using PlannR.Domain.Entities;

namespace PlannR.Application.Contracts.Persistence
{
    public interface IAccomodationRepository : IAsyncRepository<Accomodation>, ISharedRepository<Accomodation>
    {
    }
}
