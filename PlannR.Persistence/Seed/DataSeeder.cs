using Microsoft.EntityFrameworkCore;
using PlannR.Application.Contracts.Persistence.Seed;
using PlannR.Domain.Entities;
using PlannR.Domain.EntityTypes;
using PlannR.Persistence.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Persistence.Seed
{
    public static class DataSeeder
    {
        public static ICollection<AccomodationType>  SeedAccomodationTypes() =>
            SeedHelper.SeedData<AccomodationType>("accomodationTypeData.json");
        //public static ICollection<EventType> SeedEventTypes() =>
        //    SeedHelper.SeedData<EventType>("eventTypeData.json");
        //public static ICollection<AccomodationType> SeedAccomodationTypes() =>
        //    SeedHelper.SeedData<AccomodationType>("accomodationTypeData.json");
    }
}
