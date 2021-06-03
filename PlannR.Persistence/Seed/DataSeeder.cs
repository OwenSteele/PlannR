using Microsoft.EntityFrameworkCore;
using PlannR.Application.Contracts.Persistence.Seed;
using PlannR.Domain.Entities;
using PlannR.Domain.EntityTypes;
using PlannR.Domain.Shared;
using PlannR.Persistence.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Persistence.Seed
{
    public static class DataSeeder
    {
        public static ICollection<Location> SeedLocations() =>
            SeedHelper.SeedData<Location>("locationData.json");
        public static ICollection<Trip> SeedTrips() =>
            SeedHelper.SeedData<Trip>("tripData.json");
        public static ICollection<AccomodationType>  SeedAccomodationTypes() =>
            SeedHelper.SeedData<AccomodationType>("accomodationTypeData.json");
        public static ICollection<Accomodation> SeedAccomodations() =>
            SeedHelper.SeedData<Accomodation>("accomodationData.json");
        public static ICollection<AccomodationBooking> SeedAccomodationBookings() =>
            SeedHelper.SeedData<AccomodationBooking>("accomodationBookingData.json");
        public static ICollection<TransportType> SeedTransportTypes() =>
            SeedHelper.SeedData<TransportType>("transportTypeData.json");
        public static ICollection<Transport> SeedTransports() =>
            SeedHelper.SeedData<Transport>("transportData.json");
        public static ICollection<TransportBooking> SeedTransportBookings() =>
            SeedHelper.SeedData<TransportBooking>("transportBookingData.json");
        public static ICollection<EventType> SeedEventTypes() =>
            SeedHelper.SeedData<EventType>("eventTypeData.json");
        public static ICollection<Event> SeedEvents() =>
            SeedHelper.SeedData<Event>("eventData.json");
        public static ICollection<EventBooking> SeedEventBookings() =>
            SeedHelper.SeedData<EventBooking>("eventBookingData.json");
        public static ICollection<Route> SeedRoutes() =>
            SeedHelper.SeedData<Route>("routeData.json");
        public static ICollection<RoutePoint> SeedRoutePoints() =>
            SeedHelper.SeedData<RoutePoint>("routePointData.json");
    }
}
