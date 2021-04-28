using PlannR.Domain.EntityTypes;

namespace PlannR.Application.Contracts.Persistence
{
    public interface IAccomodationTypeRepository : IAsyncRepository<AccomodationType>, IEntityTypeRepository<AccomodationType>
    {
    }
}
