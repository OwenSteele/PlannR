using Microsoft.EntityFrameworkCore;
using PlannR.Domain.Common;
using PlannR.Domain.Entities;
using PlannR.Domain.EntityTypes;
using PlannR.Domain.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Persistence
{
    public class PlannRDbContext : DbContext
    {
        public DbSet<Trip> Trips {get;set;}
        public DbSet<Transport> Transports { get;set; }
        public DbSet<TransportBooking> TransportBookings { get; set; }
        public DbSet<TransportType> TransportTypes { get; set; }
        public DbSet<Accomodation> Accomodations { get; set; }
        public DbSet<AccomodationBooking> AccomodationBookings { get; set; }
        public DbSet<AccomodationType> AccomodationTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventBooking> EventBookings { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RoutePoint> RoutePoints { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public PlannRDbContext(DbContextOptions<PlannRDbContext> options)
              : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlannRDbContext).Assembly);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreationDate = DateTime.Now;
                        entry.Entity.CreatedBy = string.Empty;  // Update
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = string.Empty;  // Update
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}