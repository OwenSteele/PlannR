using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Application.Contracts.Persistence
{
    public interface ISharedRepository<T>
    {
        Task<ICollection<T>> GetAllOfTripById(Guid tripId);
    }
}
