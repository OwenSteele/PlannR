using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Application.Contracts.Persistence
{
    public interface IEntityTypeRepository<T> where T : class
    {
        Task<T> GetEntityTypeByName(string name);
        Task<ICollection<T>> GetAllEntityTypesWithEntitiesFromTripById(Guid tripId);
    }
}