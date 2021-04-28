using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Persistence.Repositories
{
    public class TransportTypeRepository : TypeBaseRepository<TransportType>, ITransportTypeRepository
    {
        public TransportTypeRepository(PlannRDbContext dbContext) : base(dbContext)
        {
        }

        public Task<ICollection<TransportType>> GetAllPublicTransportTypes()
        {
            throw new NotImplementedException();
        }
        public Task<ICollection<TransportType>> GetAllNonPublicTransportTypes()
        {
            throw new NotImplementedException();
        }
        public Task<ICollection<TransportType>> GetAllTransportTypesWithFixedRoute()
        {
            throw new NotImplementedException();
        }
        public Task<ICollection<TransportType>> GetAllTransportTypesWithNonFixedRoute()
        {
            throw new NotImplementedException();
        }
    }
}
