using AutoMapper;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Accomodation;
using PlannR.App.Infrastructure.ViewModels.Accomodation.Bookings;
using PlannR.App.Infrastructure.ViewModels.Accomodation.Types;
using PlannR.App.Infrastructure.ViewModels.Account;
using PlannR.App.Infrastructure.ViewModels.Event;
using PlannR.App.Infrastructure.ViewModels.Event.Bookings;
using PlannR.App.Infrastructure.ViewModels.Event.Types;
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
            CreateMap<AccomodationBookingDetailViewModel, UpdateAccomodationBookingCommand>().ReverseMap();
            CreateMap<AccomodationBookingDetailViewModel, CreateAccomodationBookingCommand>().ReverseMap();
            CreateMap<AccomodationBookingDetailDataModel, AccomodationBookingDetailViewModel>().ReverseMap();
            CreateMap<AccomodationBookingListByTripIdDataModel, AccomodationBookingOfTripListViewModel>().ReverseMap();
            CreateMap<AccomodationBookingListDataModel, AccomodationBookingListViewModel>().ReverseMap();

            CreateMap<EventBookingDetailViewModel, UpdateEventBookingCommand>().ReverseMap();
            CreateMap<EventBookingDetailViewModel, CreateEventBookingCommand>().ReverseMap();
            CreateMap<EventBookingDetailDataModel, EventBookingDetailViewModel>().ReverseMap();
            CreateMap<EventBookingListByTripIdDataModel, EventBookingOfTripListViewModel>().ReverseMap();
            CreateMap<EventBookingListDataModel, EventBookingListViewModel>().ReverseMap();

            CreateMap<TransportBookingDetailViewModel, UpdateTransportBookingCommand>().ReverseMap();
            CreateMap<TransportBookingDetailViewModel, CreateTransportBookingCommand>().ReverseMap();
            CreateMap<TransportBookingDetailDataModel, TransportBookingDetailViewModel>().ReverseMap();
            CreateMap<TransportBookingListByTripIdDataModel, TransportBookingOfTripListViewModel>().ReverseMap();
            CreateMap<TransportBookingListDataModel, TransportBookingListViewModel>().ReverseMap();

            CreateMap<AccomodationTypeOfNameViewModel, CreateAccomodationTypeCommand>().ReverseMap();
            CreateMap<AccomodationTypeListDataModel, AccomodationTypeListViewModel>().ReverseMap();
            CreateMap<AccomodationTypeByNameDataModel, AccomodationTypeOfNameViewModel>().ReverseMap();

            CreateMap<EventTypeOfNameViewModel, CreateEventTypeCommand>().ReverseMap();
            CreateMap<EventTypeListDataModel, EventTypeListViewModel>().ReverseMap();
            CreateMap<EventTypeByNameDataModel, EventTypeOfNameViewModel>().ReverseMap();

            CreateMap<TransportTypeOfNameViewModel, CreateTransportTypeCommand>().ReverseMap();
            CreateMap<TransportTypeListDataModel, TransportTypeListViewModel>().ReverseMap();
            CreateMap<TransportTypeByNameDataModel, TransportTypeOfNameViewModel>().ReverseMap();

            CreateMap<AccomodationDetailViewModel, CreateAccomodationCommand>().ReverseMap();
            CreateMap<AccomodationDetailViewModel, UpdateAccomodationCommand>().ReverseMap();
            CreateMap<AccomodationDetailDataModel, AccomodationDetailViewModel>().ReverseMap();
            CreateMap<AccomodationListByTripIdDataModel, AccomodationListOfTripViewModel>().ReverseMap();
            CreateMap<AccomodationListDataModel, AccomodationListViewModel>().ReverseMap();
            CreateMap<AccomodationListByTripIdWithBookingsDataModel, AccomodationListWithBookingsViewModel>().ReverseMap();
            CreateMap<AccomodationListOnDateDataModel, AccomodationListOnDateViewModel>().ReverseMap();

            CreateMap<EventDetailViewModel, CreateEventCommand>().ReverseMap();
            CreateMap<EventDetailViewModel, UpdateEventCommand>().ReverseMap();
            CreateMap<EventDetailDataModel, EventDetailViewModel>().ReverseMap();
            CreateMap<EventListByTripIdDataModel, EventListOfTripViewModel>().ReverseMap();
            CreateMap<EventListDataModel, EventListViewModel>().ReverseMap();
            CreateMap<EventListByTripIdWithBookingsDataModel, EventListWithBookingsViewModel>().ReverseMap();
            CreateMap<EventListOnDateDataModel, EventListOnDateViewModel>().ReverseMap();

            CreateMap<TransportDetailDataModel, CreateTransportCommand>().ReverseMap();
            CreateMap<TransportDetailDataModel, UpdateTransportCommand>().ReverseMap();
            CreateMap<TransportDetailDataModel, TransportDetailViewModel>().ReverseMap();
            CreateMap<TransportListByTripIdDataModel, TransportListOfTripViewModel>().ReverseMap();
            CreateMap<TransportListDataModel, TransportListViewModel>().ReverseMap();
            CreateMap<TransportListByTripIdWithBookingsDataModel, TransportListWithBookingsViewModel>().ReverseMap();
            CreateMap<TransportListOnDateDataModel, TransportListOnDateViewModel>().ReverseMap();

            CreateMap<RouteDetailDataModel, RouteDetailViewModel>().ReverseMap();
            CreateMap<RouteDetailViewModel, UpdateRouteCommand>().ReverseMap();
            CreateMap<RouteDetailDataModel, RouteDetailViewModel>().ReverseMap();
            CreateMap<RouteListByTripIdDataModel, RouteListOfTripViewModel>().ReverseMap();
            CreateMap<RouteListDataModel, RouteListViewModel>().ReverseMap();
            CreateMap<RouteListOnDateDataModel, RouteListOnDateViewModel>().ReverseMap();

            CreateMap<EditTripViewModel, CreateTripCommand>().ReverseMap();
            CreateMap<EditTripViewModel, UpdateTripCommand>().ReverseMap();
            CreateMap<TripDetailDataModel, TripDetailViewModel>().ReverseMap();
            CreateMap<TripListDataModel, TripListViewModel>().ReverseMap();
            CreateMap<TripListOnDateDataModel, TripListOnDateViewModel>().ReverseMap();
            CreateMap<TripListBetweenDatesDataModel, TripListBetweenDatesViewModel>().ReverseMap();

            CreateMap<EditLocationViewModel, CreateLocationCommand>().ReverseMap();
            CreateMap<EditLocationViewModel, UpdateLocationCommand>().ReverseMap();
            CreateMap<LocationDetailDataModel, LocationDetailViewModel>().ReverseMap();
            CreateMap<LocationListDataModel, LocationListViewModel>().ReverseMap();
            CreateMap<LocationNestedViewModel, EditLocationViewModel>().ReverseMap();

            CreateMap<RegisterViewModel, RegistrationRequest>().ReverseMap();
            CreateMap<AuthenticateViewModel, AuthenticationRequest>().ReverseMap();
        }
    }
}
