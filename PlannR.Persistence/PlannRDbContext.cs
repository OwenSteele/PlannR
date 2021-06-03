using Microsoft.EntityFrameworkCore;
using PlannR.Application.Contracts.Identity;
using PlannR.Domain.Common;
using PlannR.Domain.Entities;
using PlannR.Domain.EntityTypes;
using PlannR.Domain.Shared;
using PlannR.Persistence.Seed;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlannR.Persistence
{
    public class PlannrDbContext : DbContext
    {
        private readonly ILoggedInService _loggedInService;

        public PlannrDbContext(DbContextOptions<PlannrDbContext> options)
              : base(options)
        {
        }
        public PlannrDbContext(DbContextOptions<PlannrDbContext> options,
            ILoggedInService loggedInService)
              : base(options)
        {
            _loggedInService = loggedInService;
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Accomodation>()
                .HasOne(x => x.Booking).WithOne(x => x.Accomodation)
                .HasForeignKey<AccomodationBooking>(x => x.AccomodationId);
            modelBuilder.Entity<Transport>()
                .HasOne(x => x.Booking).WithOne(x => x.Transport)
                .HasForeignKey<TransportBooking>(x => x.TransportId);
            modelBuilder.Entity<Event>()
                .HasOne(x => x.Booking).WithOne(x => x.Event)
                .HasForeignKey<EventBooking>(x => x.EventId);

            modelBuilder.Entity<Booking>().Property(x => x.Cost)
                .HasColumnType<decimal>("decimal(18,2)");
            modelBuilder.Entity<Accomodation>().Property(x => x.CostPerNight)
                .HasColumnType<decimal?>("decimal(18,2)");

            modelBuilder.Entity<Trip>()
                .HasOne(x => x.StartLocation).WithOne()
                .HasForeignKey<Trip>(x => x.StartLocationId)
                .IsRequired(false);
            modelBuilder.Entity<Trip>()
                .HasOne(x => x.EndLocation).WithOne()
                .HasForeignKey<Trip>(x => x.EndLocationId)
                .IsRequired(false);
            modelBuilder.Entity<Transport>()
                .HasOne(x => x.StartLocation).WithOne()
                .HasForeignKey<Transport>(x => x.StartLocationId)
                .IsRequired(false);
            modelBuilder.Entity<Transport>()
                .HasOne(x => x.EndLocation).WithOne()
                .HasForeignKey<Transport>(x => x.EndLocationId)
                .IsRequired(false);
            modelBuilder.Entity<Accomodation>()
                .HasOne(x => x.Location).WithOne()
                .HasForeignKey<Accomodation>(x => x.LocationId)
                .IsRequired(false);
            modelBuilder.Entity<RoutePoint>()
                .HasOne(x => x.Location).WithOne()
                .HasForeignKey<RoutePoint>(x => x.LocationId)
                .IsRequired(false);
            modelBuilder.Entity<Event>()
                .HasOne(x => x.Location).WithOne()
                .HasForeignKey<Event>(x => x.LocationId)
                .IsRequired(false);

            modelBuilder.Entity<RoutePoint>()
                .HasOne(x => x.AssociatedEvent).WithOne()
                .HasForeignKey<RoutePoint>(x => x.EventId)
                .IsRequired(false);

            modelBuilder.Entity<Trip>().Navigation(x => x.StartLocation).AutoInclude();
            modelBuilder.Entity<Trip>().Navigation(x => x.EndLocation).AutoInclude();
            modelBuilder.Entity<Transport>().Navigation(x => x.StartLocation).AutoInclude();
            modelBuilder.Entity<Transport>().Navigation(x => x.EndLocation).AutoInclude();
            modelBuilder.Entity<Transport>().Navigation(x => x.TransportType).AutoInclude();
            modelBuilder.Entity<Transport>().Navigation(x => x.Booking).AutoInclude();
            modelBuilder.Entity<RoutePoint>().Navigation(x => x.Location).AutoInclude();
            modelBuilder.Entity<Accomodation>().Navigation(x => x.Location).AutoInclude();
            modelBuilder.Entity<Accomodation>().Navigation(x => x.AccomodationType).AutoInclude();
            modelBuilder.Entity<Accomodation>().Navigation(x => x.Booking).AutoInclude();
            modelBuilder.Entity<Event>().Navigation(x => x.Location).AutoInclude();
            modelBuilder.Entity<Event>().Navigation(x => x.EventType).AutoInclude();
            modelBuilder.Entity<Event>().Navigation(x => x.Booking).AutoInclude();
            modelBuilder.Entity<Route>().Navigation(x => x.Points).AutoInclude();

            modelBuilder.Entity<AccomodationType>().HasData(DataSeeder.SeedAccomodationTypes());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreationDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}