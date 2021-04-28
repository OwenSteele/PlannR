using PlannR.Domain.Entities;

namespace PlannR.Application.Contracts.Persistence
{
    public interface ITransportRepository : IAsyncRepository<Transport>, ISharedRepository<Transport>
    {
    }
}
