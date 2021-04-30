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
    public class PlannrDbContext : DbContext
    {
        public PlannrDbContext(DbContextOptions<PlannrDbContext> options)
              : base(options)
        {
        }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<Transport> Transports { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlannrDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Trip>().HasMany<Accomodation>().WithOne(x => x.Trip)
            //    .HasForeignKey(x => x.TripId);
            //modelBuilder.Entity<Trip>().HasMany<Route>().WithOne(x => x.Trip)
            //    .HasForeignKey(x => x.TripId);
            //modelBuilder.Entity<Trip>().HasMany<Event>().WithOne(x => x.Trip)
            //    .HasForeignKey(x => x.TripId);
            //modelBuilder.Entity<Trip>().HasMany<Transport>().WithOne(x => x.Trip)
            //    .HasForeignKey(x => x.TripId);

            //modelBuilder.Entity<Accomodation>().HasOne<AccomodationBooking>().WithOne(x => x.Accomodation)
            //    .HasForeignKey(x => x.);
            //modelBuilder.Entity<Accomodation>().HasOne<AccomodationType>().WithMany(x => x.Accomodations);
            //modelBuilder.Entity<Transport>().HasOne<TransportBooking>().WithOne(x => x.Transport);
            //modelBuilder.Entity<Transport>().HasOne<TransportType>().WithMany(x => x.Transports);
            //modelBuilder.Entity<Event>().HasOne<EventBooking>().WithOne(x => x.Event);
            //modelBuilder.Entity<Event>().HasOne<EventType>().WithMany(x => x.Events);

            //modelBuilder.Entity<Route>().HasMany<RoutePoint>();



            modelBuilder.Entity<Booking>().Property(x => x.Cost)
                .HasColumnType<decimal>("decimal(18,2)");
            modelBuilder.Entity<Accomodation>().Property(x => x.CostPerNight)
                .HasColumnType<decimal?>("decimal(18,2)");
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