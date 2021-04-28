using AutoMapper;
using PlannR.Application.Features.Transports.Commands.CreateTransport;
using PlannR.Application.Features.Transports.Commands.UpdateTransport;
using PlannR.Application.Features.Transports.Dtos.GetTransportsList;
using PlannR.Application.Features.Transports.Queries.GetTransportListByTripId;
using PlannR.Application.Features.Transports.Queries.GetTransportListByTripIdWithBookings;
using PlannR.Application.Features.Transports.Queries.GetTransportListOnDate;
using PlannR.Application.Features.Transports.Queries.GetTransportsDetail;
using PlannR.Application.Features.Transports.Queries.GetTransportsList;
using PlannR.Domain.Entities;
using PlannR.Domain.EntityTypes;
using PlannR.Domain.Shared;

namespace PlannR.Application.Profiles
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Transport, CreateTransportCommand>().ReverseMap();
            CreateMap<Transport, UpdateTransportCommand>().ReverseMap();
            CreateMap<Transport, TransportsDetailViewModel>().ReverseMap();
            CreateMap<Transport, TransportListViewModel>().ReverseMap();
            CreateMap<Transport, TransportListOnDateViewModel>().ReverseMap();
            CreateMap<Transport, TransportListByTripIdWithBookingsViewModel>().ReverseMap();
            CreateMap<Transport, TransportListByTripIdViewModel>().ReverseMap();

            CreateMap<Location, LocationDto>();
            CreateMap<TransportType, TransportTypeDto>();
            CreateMap<Trip, TripDto>();
        }
    }
}
