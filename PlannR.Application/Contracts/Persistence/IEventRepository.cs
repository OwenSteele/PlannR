using PlannR.Domain.Entities;

namespace PlannR.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>, ISharedRepository<Event>
    {
    }
}
