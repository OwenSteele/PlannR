using PlannR.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Persistence.Repositories
{
    public class ATEBaseRepository<T> : BaseRepository<T>, ISharedRepository<T> where T : class
    {
        public ATEBaseRepository(PlannRDbContext dbContext) : base(dbContext)
        {
        }

        public Task<ICollection<T>> GetAllOfTripById(Guid tripId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> GetAllOfTripByIdWithBookings(Guid tripId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> GetAllOnDateOfTripById(Guid tripId, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
