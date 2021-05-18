using PlannR.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.Persistence.Repositories
{
    public class LocationRepository :BaseRepository<Location>
    {
        public LocationRepository(PlannrDbContext dbContext) : base(dbContext)
        {
        }
    }
}
