using AutoMapper;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Accomodation;
using PlannR.App.Infrastructure.ViewModels.Accomodation.Bookings;
using PlannR.App.Infrastructure.ViewModels.Accomodation.Types;
using PlannR.App.Infrastructure.ViewModels.Account;
using PlannR.App.Infrastructure.ViewModels.Event;
using PlannR.App.Infrastructure.ViewModels.Event.Bookings;
using PlannR.App.Infrastructure.ViewModels.Event.Types;
using PlannR.App.Infrastructure.ViewModels.Events;
using PlannR.App.Infrastructure.ViewModels.Locations;
using PlannR.App.Infrastructure.ViewModels.Nested;
using PlannR.App.Infrastructure.ViewModels.Routes;
using PlannR.App.Infrastructure.ViewModels.Transport;
using PlannR.App.Infrastructure.ViewModels.Transport.Bookings;
using PlannR.App.Infrastructure.ViewModels.Transport.Types;
using PlannR.App.Infrastructure.ViewModels.Trips;

namespace PlannR.App.Infrastructure.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EditAccomodationBookingViewModel, UpdateAccomodationBookingCommand>().ReverseMap();
            CreateMap<EditAccomodationBookingViewModel, CreateAccomodationBookingCommand>().ReverseMap();
            CreateMap<AccomodationBookingDetailDataModel, AccomodationBookingDetailViewModel>().ReverseMap();
            CreateMap<AccomodationBookingListByTripIdDataModel, AccomodationBookingOfTripListViewModel>().ReverseMap();
            CreateMap<AccomodationBookingListDataModel, AccomodationBookingListViewModel>().ReverseMap();
            CreateMap<AccomodationBookingDetailDataModel, EditAccomodationBookingViewModel>().ReverseMap();
            CreateMap<AccomodationBookingDto, AccomodationBookingNestedViewModel>().ReverseMap();

            //CreateMap<EditEventBookingViewModel, UpdateEventBookingCommand>().ReverseMap();
            //CreateMap<EditEventBookingViewModel, CreateEventBookingCommand>().ReverseMap();
            CreateMap<EventBookingDetailDataModel, EventBookingDetailViewModel>().ReverseMap();
            CreateMap<EventBookingListByTripIdDataModel, EventBookingOfTripListViewModel>().ReverseMap();
            CreateMap<EventBookingListDataModel, EventBookingListViewModel>().ReverseMap();
            CreateMap<EventBookingDto, EventBookingNestedViewModel>().ReverseMap();

            CreateMap<TransportBookingDetailViewModel, UpdateTransportBookingCommand>().ReverseMap();
            CreateMap<TransportBookingDetailViewModel, CreateTransportBookingCommand>().ReverseMap();
            CreateMap<TransportBookingDetailDataModel, TransportBookingDetailViewModel>().ReverseMap();
            CreateMap<TransportBookingListByTripIdDataModel, TransportBookingOfTripListViewModel>().ReverseMap();
            CreateMap<TransportBookingListDataModel, TransportBookingListViewModel>().ReverseMap();
            CreateMap<TransportBookingDto, TransportBookingNestedViewModel>().ReverseMap();

            CreateMap<AccomodationTypeOfNameViewModel, CreateAccomodationTypeCommand>().ReverseMap();
            CreateMap<AccomodationTypeListDataModel, AccomodationTypeListViewModel>().ReverseMap();
            CreateMap<AccomodationTypeListViewModel, AccomodationTypeNestedViewModel>().ReverseMap();
            CreateMap<AccomodationTypeByNameDataModel, AccomodationTypeOfNameViewModel>().ReverseMap();
            CreateMap<AccomodationTypeListDataModel, AccomodationTypeNestedViewModel>().ReverseMap();
            CreateMap<AccomodationTypeDto, AccomodationTypeNestedViewModel>().ReverseMap();

            CreateMap<EventTypeOfNameViewModel, CreateEventTypeCommand>().ReverseMap();
            CreateMap<EventTypeListDataModel, EventTypeListViewModel>().ReverseMap();
            CreateMap<EventTypeByNameDataModel, EventTypeOfNameViewModel>().ReverseMap();
            CreateMap<EventTypeListViewModel, EventTypeNestedViewModel>().ReverseMap();
            CreateMap<EventTypeListDataModel, EventTypeNestedViewModel>().ReverseMap();
            CreateMap<EventTypeDto, AccomodationTypeNestedViewModel>().ReverseMap();

            CreateMap<TransportTypeOfNameViewModel, CreateTransportTypeCommand>().ReverseMap();
            CreateMap<TransportTypeListDataModel, TransportTypeListViewModel>().ReverseMap();
            CreateMap<TransportTypeByNameDataModel, TransportTypeOfNameViewModel>().ReverseMap();
            CreateMap<TransportTypeListViewModel, TransportTypeNestedViewModel>().ReverseMap();
            CreateMap<TransportTypeListDataModel, TransportTypeNestedViewModel>().ReverseMap();
            CreateMap<TransportTypeDto, AccomodationTypeNestedViewModel>().ReverseMap();

            CreateMap<EditAccomodationViewModel, CreateAccomodationCommand>().ReverseMap();
            CreateMap<EditAccomodationViewModel, UpdateAccomodationCommand>().ReverseMap();
            CreateMap<AccomodationDetailDataModel, AccomodationDetailViewModel>().ReverseMap();
            CreateMap<AccomodationListByTripIdDataModel, AccomodationListOfTripViewModel>().ReverseMap();
            CreateMap<AccomodationListDataModel, AccomodationListViewModel>().ReverseMap();
            CreateMap<AccomodationListByTripIdWithBookingsDataModel, AccomodationListWithBookingsViewModel>().ReverseMap();
            CreateMap<AccomodationListOnDateDataModel, AccomodationListOnDateViewModel>().ReverseMap();
            CreateMap<AccomodationTripDto, TripNestedViewModel>().ReverseMap();

            CreateMap<EditEventViewModel, CreateEventCommand>().ReverseMap();
            CreateMap<EditEventViewModel, UpdateEventCommand>().ReverseMap();
            CreateMap<EventDetailDataModel, EventDetailViewModel>().ReverseMap();
            CreateMap<EventListByTripIdDataModel, EventListOfTripViewModel>().ReverseMap();
            CreateMap<EventListDataModel, EventListViewModel>().ReverseMap();
            CreateMap<EventListByTripIdWithBookingsDataModel, EventListWithBookingsViewModel>().ReverseMap();
            CreateMap<EventListOnDateDataModel, EventListOnDateViewModel>().ReverseMap();
            CreateMap<EventTripDto, TripNestedViewModel>().ReverseMap();

            CreateMap<EditTransportViewModel, CreateTransportCommand>().ReverseMap();
            CreateMap<EditTransportViewModel, UpdateTransportCommand>().ReverseMap();
            CreateMap<TransportDetailDataModel, TransportDetailViewModel>().ReverseMap();
            CreateMap<TransportListByTripIdDataModel, TransportListOfTripViewModel>().ReverseMap();
            CreateMap<TransportListDataModel, TransportListViewModel>().ReverseMap();
            CreateMap<TransportListByTripIdWithBookingsDataModel, TransportListWithBookingsViewModel>().ReverseMap();
            CreateMap<TransportListOnDateDataModel, TransportListOnDateViewModel>().ReverseMap();
            CreateMap<TransportTripDto, TripNestedViewModel>().ReverseMap();

            CreateMap<EditRouteViewModel, CreateRouteCommand>().ReverseMap();
            CreateMap<EditRouteViewModel, UpdateRouteCommand>().ReverseMap();
            CreateMap<RouteDetailDataModel, RouteDetailViewModel>().ReverseMap();
            CreateMap<RouteDetailDataModel, RouteDetailViewModel>().ReverseMap();
            CreateMap<RouteListByTripIdDataModel, RouteListOfTripViewModel>().ReverseMap();
            CreateMap<RouteListDataModel, RouteListViewModel>().ReverseMap();
            CreateMap<RouteListOnDateDataModel, RouteListOnDateViewModel>().ReverseMap();
            CreateMap<RouteTripDto, TripNestedViewModel>().ReverseMap();

            CreateMap<RoutePointNestedViewModel, CreateRoutePointCommand>().ReverseMap();
            CreateMap<RoutePointNestedViewModel, RoutePointNestedViewModel>().ReverseMap();

            CreateMap<EditTripViewModel, CreateTripCommand>().ReverseMap();
            CreateMap<EditTripViewModel, UpdateTripCommand>().ReverseMap();
            CreateMap<TripDetailDataModel, TripDetailViewModel>().ReverseMap();
            CreateMap<TripListDataModel, TripListViewModel>().ReverseMap();
            CreateMap<TripListOnDateDataModel, TripListOnDateViewModel>().ReverseMap();
            CreateMap<TripListBetweenDatesDataModel, TripListBetweenDatesViewModel>().ReverseMap();
            CreateMap<TripNameListDataModel, TripNestedViewModel>().ReverseMap();

            CreateMap<EditLocationViewModel, CreateLocationCommand>().ReverseMap();
            CreateMap<EditLocationViewModel, UpdateLocationCommand>().ReverseMap();
            CreateMap<LocationDetailDataModel, LocationDetailViewModel>().ReverseMap();
            CreateMap<LocationListDataModel, LocationListViewModel>().ReverseMap();
            CreateMap<LocationNestedViewModel, EditLocationViewModel>().ReverseMap();

            CreateMap<AccomodationDto, AccomodationNestedViewModel>().ReverseMap();
            CreateMap<EventDto, EventNestedViewModel>().ReverseMap();
            CreateMap<RouteDto, RouteNestedViewModel>().ReverseMap();
            CreateMap<TransportDto, TransportNestedViewModel>().ReverseMap();
            CreateMap<LocationDto, LocationNestedViewModel>().ReverseMap();

            CreateMap<AccomodationLocationDto, LocationNestedViewModel>().ReverseMap();
            CreateMap<EventLocationDto, LocationNestedViewModel>().ReverseMap();
            CreateMap<TransportLocationDto, LocationNestedViewModel>().ReverseMap();
            CreateMap<RouteLocationDto, LocationNestedViewModel>().ReverseMap();
            CreateMap<LocationDto, LocationNestedViewModel>().ReverseMap();

            CreateMap<RegisterViewModel, RegistrationRequest>().ReverseMap();
            CreateMap<AuthenticateViewModel, AuthenticationRequest>().ReverseMap();
        }
    }
}
