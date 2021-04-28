using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using PlannR.Persistence;
using PlannR.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Persistence.Repositories
{
    public class EventTypeRepository : TypeBaseRepository<EventType>, IEventTypeRepository
    {
        public EventTypeRepository(PlannRDbContext dbContext) : base(dbContext)
        {
        }
    }
}
