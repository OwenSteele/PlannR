using PlannR.Application.Contracts.Persistence;
using PlannR.Domain.EntityTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Persistence.Repositories
{
        public class AccomodationTypeRepository : TypeBaseRepository<AccomodationType>, IAccomodationTypeRepository
        {
            public AccomodationTypeRepository(PlannRDbContext dbContext) : base(dbContext)
            {
            }
        }
    }
