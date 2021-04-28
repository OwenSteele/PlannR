using PlannR.Domain.EntityTypes;

namespace PlannR.Application.Contracts.Persistence
{
    public interface IEventTypeRepository : IAsyncRepository<EventType>, IEntityTypeRepository<EventType>
    {
    }
}
