﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlannR.Persistence;

namespace PlannR.Persistence.Migrations
{
    [DbContext(typeof(PlannrDbContext))]
    [Migration("20210501171957_EntityTypeRelationshipFix3")]
    partial class EntityTypeRelationshipFix3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.3.21201.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PlannR.Domain.Entities.Accomodation", b =>
                {
                    b.Property<Guid>("AccomodationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccomodationTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("CostPerNight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nights")
                        .HasColumnType("int");

                    b.Property<int>("Rooms")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TripId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AccomodationId");

                    b.HasIndex("AccomodationTypeId");

                    b.HasIndex("LocationId");

                    b.HasIndex("TripId");

                    b.ToTable("Accomodations");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailReminderEnabled")
                        .HasColumnType("bit");

                    b.Property<TimeSpan?>("EmailReminderTimer")
                        .HasColumnType("time");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EventTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TripId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EventId");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("LocationId");

                    b.HasIndex("TripId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.Route", b =>
                {
                    b.Property<Guid>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TripId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RouteId");

                    b.HasIndex("TripId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.RoutePoint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RouteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("LocationId");

                    b.HasIndex("RouteId");

                    b.ToTable("RoutePoints");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.Transport", b =>
                {
                    b.Property<Guid>("TransportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("EndLocationLocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("StartLocationLocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TransportTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TripId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TransportId");

                    b.HasIndex("EndLocationLocationId");

                    b.HasIndex("StartLocationLocationId");

                    b.HasIndex("TransportTypeId");

                    b.HasIndex("TripId");

                    b.ToTable("Transports");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.Trip", b =>
                {
                    b.Property<Guid>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("EndLocationLocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("StartLocationLocationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TripId");

                    b.HasIndex("EndLocationLocationId");

                    b.HasIndex("StartLocationLocationId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("PlannR.Domain.EntityTypes.AccomodationType", b =>
                {
                    b.Property<Guid>("AccomodationTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccomodationTypeId");

                    b.ToTable("AccomodationTypes");
                });

            modelBuilder.Entity("PlannR.Domain.EntityTypes.EventType", b =>
                {
                    b.Property<Guid>("EventTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventTypeId");

                    b.ToTable("EventTypes");
                });

            modelBuilder.Entity("PlannR.Domain.EntityTypes.TransportType", b =>
                {
                    b.Property<Guid>("TransportTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HasFixedRoute")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransportTypeId");

                    b.ToTable("TransportTypes");
                });

            modelBuilder.Entity("PlannR.Domain.Shared.Booking", b =>
                {
                    b.Property<Guid>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingId");

                    b.ToTable("Bookings");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Booking");
                });

            modelBuilder.Entity("PlannR.Domain.Shared.BookingFile", b =>
                {
                    b.Property<Guid>("BookingFileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("FileBytes")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("BookingFileId");

                    b.HasIndex("BookingId");

                    b.ToTable("BookingFile");
                });

            modelBuilder.Entity("PlannR.Domain.Shared.Location", b =>
                {
                    b.Property<Guid>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("AltitudeInMetres")
                        .HasColumnType("float");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.AccomodationBooking", b =>
                {
                    b.HasBaseType("PlannR.Domain.Shared.Booking");

                    b.Property<Guid>("AccomodationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("AccomodationId")
                        .IsUnique()
                        .HasFilter("[AccomodationId] IS NOT NULL");

                    b.HasDiscriminator().HasValue("AccomodationBooking");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.EventBooking", b =>
                {
                    b.HasBaseType("PlannR.Domain.Shared.Booking");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("EventId")
                        .IsUnique()
                        .HasFilter("[EventId] IS NOT NULL");

                    b.HasDiscriminator().HasValue("EventBooking");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.TransportBooking", b =>
                {
                    b.HasBaseType("PlannR.Domain.Shared.Booking");

                    b.Property<Guid>("TransportId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("TransportId")
                        .IsUnique()
                        .HasFilter("[TransportId] IS NOT NULL");

                    b.HasDiscriminator().HasValue("TransportBooking");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.Accomodation", b =>
                {
                    b.HasOne("PlannR.Domain.EntityTypes.AccomodationType", "AccomodationType")
                        .WithMany("Accomodations")
                        .HasForeignKey("AccomodationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlannR.Domain.Shared.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("PlannR.Domain.Entities.Trip", "Trip")
                        .WithMany("Accomodations")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccomodationType");

                    b.Navigation("Location");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.Event", b =>
                {
                    b.HasOne("PlannR.Domain.EntityTypes.EventType", "EventType")
                        .WithMany("Events")
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlannR.Domain.Shared.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("PlannR.Domain.Entities.Trip", "Trip")
                        .WithMany("Events")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventType");

                    b.Navigation("Location");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.Route", b =>
                {
                    b.HasOne("PlannR.Domain.Entities.Trip", "Trip")
                        .WithMany("Routes")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.RoutePoint", b =>
                {
                    b.HasOne("PlannR.Domain.Entities.Event", "AssociatedEvent")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlannR.Domain.Shared.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("PlannR.Domain.Entities.Route", null)
                        .WithMany("Points")
                        .HasForeignKey("RouteId");

                    b.Navigation("AssociatedEvent");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.Transport", b =>
                {
                    b.HasOne("PlannR.Domain.Shared.Location", "EndLocation")
                        .WithMany()
                        .HasForeignKey("EndLocationLocationId");

                    b.HasOne("PlannR.Domain.Shared.Location", "StartLocation")
                        .WithMany()
                        .HasForeignKey("StartLocationLocationId");

                    b.HasOne("PlannR.Domain.EntityTypes.TransportType", "TransportType")
                        .WithMany("Transports")
                        .HasForeignKey("TransportTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlannR.Domain.Entities.Trip", "Trip")
                        .WithMany("Transports")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EndLocation");

                    b.Navigation("StartLocation");

                    b.Navigation("TransportType");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.Trip", b =>
                {
                    b.HasOne("PlannR.Domain.Shared.Location", "EndLocation")
                        .WithMany()
                        .HasForeignKey("EndLocationLocationId");

                    b.HasOne("PlannR.Domain.Shared.Location", "StartLocation")
                        .WithMany()
                        .HasForeignKey("StartLocationLocationId");

                    b.Navigation("EndLocation");

                    b.Navigation("StartLocation");
                });

            modelBuilder.Entity("PlannR.Domain.Shared.BookingFile", b =>
                {
                    b.HasOne("PlannR.Domain.Shared.Booking", null)
                        .WithMany("Reservations")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlannR.Domain.Entities.AccomodationBooking", b =>
                {
                    b.HasOne("PlannR.Domain.Entities.Accomodation", "Accomodation")
                        .WithOne("Booking")
                        .HasForeignKey("PlannR.Domain.Entities.AccomodationBooking", "AccomodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accomodation");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.EventBooking", b =>
                {
                    b.HasOne("PlannR.Domain.Entities.Event", "Event")
                        .WithOne("Booking")
                        .HasForeignKey("PlannR.Domain.Entities.EventBooking", "EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.TransportBooking", b =>
                {
                    b.HasOne("PlannR.Domain.Entities.Transport", "Transport")
                        .WithOne("Booking")
                        .HasForeignKey("PlannR.Domain.Entities.TransportBooking", "TransportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.Accomodation", b =>
                {
                    b.Navigation("Booking");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.Event", b =>
                {
                    b.Navigation("Booking");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.Route", b =>
                {
                    b.Navigation("Points");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.Transport", b =>
                {
                    b.Navigation("Booking");
                });

            modelBuilder.Entity("PlannR.Domain.Entities.Trip", b =>
                {
                    b.Navigation("Accomodations");

                    b.Navigation("Events");

                    b.Navigation("Routes");

                    b.Navigation("Transports");
                });

            modelBuilder.Entity("PlannR.Domain.EntityTypes.AccomodationType", b =>
                {
                    b.Navigation("Accomodations");
                });

            modelBuilder.Entity("PlannR.Domain.EntityTypes.EventType", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("PlannR.Domain.EntityTypes.TransportType", b =>
                {
                    b.Navigation("Transports");
                });

            modelBuilder.Entity("PlannR.Domain.Shared.Booking", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
