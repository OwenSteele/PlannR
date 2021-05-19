using AutoMapper;
using PlannR.Application.Features.Accomodations.Bookings.Commands.CreateAccomodationBooking;
using PlannR.Application.Features.Accomodations.Bookings.Commands.UpdateAccomodationBooking;
using PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingDetail;
using PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingList;
using PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingListByTripId;
using PlannR.Application.Features.Accomodations.Commands.CreateAccomodation;
using PlannR.Application.Features.Accomodations.Commands.UpdateAccomodation;
using PlannR.Application.Features.Accomodations.Dtos.GetAccomodationsList;
using PlannR.Application.Features.Accomodations.Queries.GetAccomodationListByTripId;
using PlannR.Application.Features.Accomodations.Queries.GetAccomodationListByTripIdWithBookings;
using PlannR.Application.Features.Accomodations.Queries.GetAccomodationListOnDate;
using PlannR.Application.Features.Accomodations.Queries.GetAccomodationsDetail;
using PlannR.Application.Features.Accomodations.Queries.GetAccomodationsList;
using PlannR.Application.Features.Accomodations.Types.Commands.CreateAccomodationType;
using PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeByName;
using PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeList;
using PlannR.Application.Features.Events.Bookings.Commands.CreateEventBooking;
using PlannR.Application.Features.Events.Bookings.Commands.UpdateEventBooking;
using PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingDetail;
using PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingList;
using PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingListByTripId;
using PlannR.Application.Features.Events.Commands.CreateEvent;
using PlannR.Application.Features.Events.Commands.UpdateEvent;
using PlannR.Application.Features.Events.Dtos.GetEventsList;
using PlannR.Application.Features.Events.Queries.GetEventListByTripId;
using PlannR.Application.Features.Events.Queries.GetEventListByTripIdWithBookings;
using PlannR.Application.Features.Events.Queries.GetEventListOnDate;
using PlannR.Application.Features.Events.Queries.GetEventsDetail;
using PlannR.Application.Features.Events.Queries.GetEventsList;
using PlannR.Application.Features.Events.Types.Commands.CreateEventType;
using PlannR.Application.Features.Events.Types.Queries.GetEventTypeByName;
using PlannR.Application.Features.Events.Types.Queries.GetEventTypeList;
using PlannR.Application.Features.Locations.Commands.CreateLocation;
using PlannR.Application.Features.Locations.Commands.UpdateLocation;
using PlannR.Application.Features.Locations.Queries.GetLocationsDetail;
using PlannR.Application.Features.Locations.Queries.GetLocationsList;
using PlannR.Application.Features.Routes.Commands.CreateRoute;
using PlannR.Application.Features.Routes.Commands.UpdateRoute;
using PlannR.Application.Features.Routes.Queries.GetRouteDetail;
using PlannR.Application.Features.Routes.Queries.GetRouteListByTripId;
using PlannR.Application.Features.Routes.Queries.GetRouteListOnDate;
using PlannR.Application.Features.Routes.Queries.GetRoutesList;
using PlannR.Application.Features.Transports.Bookings.Commands.CreateTransportBooking;
using PlannR.Application.Features.Transports.Bookings.Commands.UpdateTransportBooking;
using PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingDetail;
using PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingList;
using PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingListByTripId;
using PlannR.Application.Features.Transports.Commands.CreateTransport;
using PlannR.Application.Features.Transports.Commands.UpdateTransport;
using PlannR.Application.Features.Transports.Dtos.GetTransportsList;
using PlannR.Application.Features.Transports.Queries.GetTransportListByTripId;
using PlannR.Application.Features.Transports.Queries.GetTransportListByTripIdWithBookings;
using PlannR.Application.Features.Transports.Queries.GetTransportListOnDate;
using PlannR.Application.Features.Transports.Queries.GetTransportsDetail;
using PlannR.Application.Features.Transports.Queries.GetTransportsList;
using PlannR.Application.Features.Transports.Types.Commands.CreateTransportType;
using PlannR.Application.Features.Transports.Types.Queries.GetTransportTypeByName;
using PlannR.Application.Features.Transports.Types.Queries.GetTransportTypeList;
using PlannR.Application.Features.Trips.Commands.CreateTrip;
using PlannR.Application.Features.Trips.Commands.UpdateTrip;
using PlannR.Application.Features.Trips.Queries.GetTripListBetweenDates;
using PlannR.Application.Features.Trips.Queries.GetTripListOnDate;
using PlannR.Application.Features.Trips.Queries.GetTripsDetail;
using PlannR.Application.Features.Trips.Queries.GetTripsList;
using PlannR.Domain.Entities;
using PlannR.Domain.EntityTypes;
using PlannR.Domain.Shared;

namespace PlannR.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Transport, CreateTransportCommand>().ReverseMap();
            CreateMap<Transport, UpdateTransportCommand>().ReverseMap();
            CreateMap<Transport, TransportDetailDataModel>().ReverseMap();
            CreateMap<Transport, TransportListDataModel>().ReverseMap();
            CreateMap<Transport, TransportListByTripIdWithBookingsDataModel>().ReverseMap();
            CreateMap<Transport, TransportListByTripIdDataModel>().ReverseMap();
            CreateMap<Transport, TransportListOnDateDataModel>().ReverseMap();

            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailDataModel>().ReverseMap();
            CreateMap<Event, EventListDataModel>().ReverseMap();
            CreateMap<Event, EventListByTripIdWithBookingsDataModel>().ReverseMap();
            CreateMap<Event, EventListByTripIdDataModel>().ReverseMap();
            CreateMap<Event, EventListOnDateDataModel>().ReverseMap();

            CreateMap<Accomodation, CreateAccomodationCommand>().ReverseMap();
            CreateMap<Accomodation, UpdateAccomodationCommand>().ReverseMap();
            CreateMap<Accomodation, AccomodationDetailDataModel>().ReverseMap();
            CreateMap<Accomodation, AccomodationListDataModel>().ReverseMap();
            CreateMap<Accomodation, AccomodationListByTripIdWithBookingsDataModel>().ReverseMap();
            CreateMap<Accomodation, AccomodationListByTripIdDataModel>().ReverseMap();
            CreateMap<Accomodation, AccomodationListOnDateDataModel>().ReverseMap();

            CreateMap<Trip, CreateTripCommand>().ReverseMap();
            CreateMap<Trip, UpdateTripCommand>().ReverseMap();
            CreateMap<Trip, TripDetailDataModel>().ReverseMap();
            CreateMap<Trip, TripListDataModel>().ReverseMap();
            CreateMap<Trip, TripListBetweenDatesDataModel>().ReverseMap();
            CreateMap<Trip, TripListOnDateDataModel>().ReverseMap();

            CreateMap<Location, CreateLocationCommand>().ReverseMap();
            CreateMap<Location, UpdateLocationCommand>().ReverseMap();
            CreateMap<Location, LocationDetailDataModel>().ReverseMap();
            CreateMap<Location, LocationListDataModel>().ReverseMap();

            CreateMap<Route, CreateRouteCommand>().ReverseMap();
            CreateMap<Route, UpdateRouteCommand>().ReverseMap();
            CreateMap<Route, RouteDetailDataModel>().ReverseMap();
            CreateMap<Route, RouteListDataModel>().ReverseMap();
            CreateMap<Route, RouteListByTripIdDataModel>().ReverseMap();
            CreateMap<Route, RouteListOnDateDataModel>().ReverseMap();

            CreateMap<TransportType, CreateTransportTypeCommand>().ReverseMap();
            CreateMap<TransportType, TransportTypeListDataModel>().ReverseMap();
            CreateMap<TransportType, TransportTypeByNameDataModel>().ReverseMap();

            CreateMap<EventType, CreateEventTypeCommand>().ReverseMap();
            CreateMap<EventType, EventTypeListDataModel>().ReverseMap();
            CreateMap<EventType, EventTypeByNameDataModel>().ReverseMap();

            CreateMap<AccomodationType, CreateAccomodationTypeCommand>().ReverseMap();
            CreateMap<AccomodationType, AccomodationTypeListDataModel>().ReverseMap();
            CreateMap<AccomodationType, AccomodationTypeByNameDataModel>().ReverseMap();

            CreateMap<TransportBooking, CreateTransportBookingCommand>().ReverseMap();
            CreateMap<TransportBooking, UpdateTransportBookingCommand>().ReverseMap();
            CreateMap<TransportBooking, TransportBookingListDataModel>().ReverseMap();
            CreateMap<TransportBooking, TransportBookingDetailDataModel>().ReverseMap();
            CreateMap<TransportBooking, TransportBookingListByTripIdDataModel>().ReverseMap();

            CreateMap<EventBooking, CreateEventBookingCommand>().ReverseMap();
            CreateMap<EventBooking, UpdateEventBookingCommand>().ReverseMap();
            CreateMap<EventBooking, EventBookingListDataModel>().ReverseMap();
            CreateMap<EventBooking, EventBookingDetailDataModel>().ReverseMap();
            CreateMap<EventBooking, EventBookingListByTripIdDataModel>().ReverseMap();

            CreateMap<AccomodationBooking, CreateAccomodationBookingCommand>().ReverseMap();
            CreateMap<AccomodationBooking, UpdateAccomodationBookingCommand>().ReverseMap();
            CreateMap<AccomodationBooking, AccomodationBookingListDataModel>().ReverseMap();
            CreateMap<AccomodationBooking, AccomodationBookingDetailDataModel>().ReverseMap();
            CreateMap<AccomodationBooking, AccomodationBookingListByTripIdDataModel>().ReverseMap();

            CreateMap<TransportBooking, TransportBookingDto>().ReverseMap();
            CreateMap<EventBooking, EventBookingDto>().ReverseMap();
            CreateMap<AccomodationBooking, AccomodationBookingDto>().ReverseMap();

            CreateMap<TransportType, TransportTypeDto>();
            CreateMap<EventType, EventTypeDto>();
            CreateMap<AccomodationType, AccomodationTypeDto>();
            CreateMap<RoutePoint, RoutePointDto>();
            CreateMap<Location, AccomodationLocationDto>();
            CreateMap<Location, EventLocationDto>();
            CreateMap<Location, RouteLocationDto>();
            CreateMap<Location, TransportLocationDto>();
            CreateMap<Trip, AccomodationTripDto>();
            CreateMap<Trip, EventTripDto>();
            CreateMap<Trip, TransportTripDto>();
            CreateMap<Trip, RouteTripDto>();
        }
    }
}
