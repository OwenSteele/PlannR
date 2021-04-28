using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Persistence.Repositories
{
    public class AccomodationTypeRepository : BaseRepository<AccomodationType>, IAccomodationTypeRepository
    {
        public AccomodationTypeRepository(PlannRDbContext dbContext) : base(dbContext)
        {
        }

        public Task<ICollection<AccomodationType>> GetAllAccomodationTypesWithAccomodationsFromTripById(Guid tripId)
        {
            throw new NotImplementedException();
        }

        public Task<AccomodationType> GetByName(string name)
        {
            throw new NotImplementedException();
        }

    }
}
}
