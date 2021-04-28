using PlannR.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Persistence.Repositories
{
    public class TypeBaseRepository<T> : BaseRepository<T>, IEntityTypeRepository<T> where T : class
    {
        public TypeBaseRepository(PlannRDbContext dbContext) : base(dbContext) { }
        
        public Task<T> GetEntityTypeByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> GetAllEntityTypesWithEntitiesFromTripById(Guid tripId)
        {
            throw new NotImplementedException();
        }
    }
}