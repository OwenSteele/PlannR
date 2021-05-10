using AutoMapper;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Accomodation;
using PlannR.App.Infrastructure.ViewModels.Accomodation.Bookings;
using PlannR.App.Infrastructure.ViewModels.Accomodation.Types;
using PlannR.App.Infrastructure.ViewModels.Event;
using PlannR.App.Infrastructure.ViewModels.Event.Bookings;
using PlannR.App.Infrastructure.ViewModels.Event.Types;
using PlannR.App.Infrastructure.ViewModels.Transport;
using PlannR.App.Infrastructure.ViewModels.Transport.Bookings;
using PlannR.App.Infrastructure.ViewModels.Transport.Types;
using System.Collections.Generic;

namespace PlannR.App.Infrastructure.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccomodationBookingDetailViewModel, UpdateAccomodationBookingCommand>().ReverseMap();
            CreateMap<AccomodationBookingDetailViewModel, CreateAccomodationBookingCommand>().ReverseMap();
            CreateMap<AccomodationBookingDetailDataModel, AccomodationBookingDetailViewModel>().ReverseMap();
            CreateMap<ICollection<AccomodationBookingListByTripIdDataModel>, ICollection<AccomodationBookingOfTripListViewModel>>().ReverseMap();
            CreateMap<ICollection<AccomodationBookingListDataModel>, ICollection<AccomodationBookingListViewModel>>().ReverseMap();

            CreateMap<EventBookingDetailViewModel, UpdateEventBookingCommand>().ReverseMap();
            CreateMap<EventBookingDetailViewModel, CreateEventBookingCommand>().ReverseMap();
            CreateMap<EventBookingDetailDataModel, EventBookingDetailViewModel>().ReverseMap();
            CreateMap<ICollection<EventBookingListByTripIdDataModel>, ICollection<EventBookingOfTripListViewModel>>().ReverseMap();
            CreateMap<ICollection<EventBookingListDataModel>, ICollection<EventBookingListViewModel>>().ReverseMap();

            CreateMap<TransportBookingDetailViewModel, UpdateTransportBookingCommand>().ReverseMap();
            CreateMap<TransportBookingDetailViewModel, CreateTransportBookingCommand>().ReverseMap();
            CreateMap<TransportBookingDetailDataModel, TransportBookingDetailViewModel>().ReverseMap();
            CreateMap<ICollection<TransportBookingListByTripIdDataModel>, ICollection<TransportBookingOfTripListViewModel>>().ReverseMap();
            CreateMap<ICollection<TransportBookingListDataModel>, ICollection<TransportBookingListViewModel>>().ReverseMap();

            CreateMap<AccomodationTypeOfNameViewModel, CreateAccomodationTypeCommand>().ReverseMap();
            CreateMap<ICollection<AccomodationTypeListDataModel>, ICollection<AccomodationTypeListViewModel>>().ReverseMap();
            CreateMap<AccomodationTypeByNameDataModel, AccomodationTypeOfNameViewModel>().ReverseMap();

            CreateMap<EventTypeOfNameViewModel, CreateEventTypeCommand>().ReverseMap();
            CreateMap<ICollection<EventTypeListDataModel>, ICollection<EventTypeListViewModel>>().ReverseMap();
            CreateMap<EventTypeByNameDataModel, EventTypeOfNameViewModel>().ReverseMap();

            CreateMap<TransportTypeOfNameViewModel, CreateTransportTypeCommand>().ReverseMap();
            CreateMap<ICollection<TransportTypeListDataModel>, ICollection<TransportTypeListViewModel>>().ReverseMap();
            CreateMap<TransportTypeByNameDataModel, TransportTypeOfNameViewModel>().ReverseMap();

            CreateMap<AccomodationDetailViewModel, CreateAccomodationCommand>().ReverseMap();
            CreateMap<AccomodationDetailViewModel, UpdateAccomodationCommand>().ReverseMap();
            CreateMap<AccomodationDetailDataModel, AccomodationDetailViewModel>().ReverseMap();
            CreateMap<ICollection<AccomodationListByTripIdDataModel>, ICollection<AccomodationListOfTripViewModel>>().ReverseMap();
            CreateMap<ICollection<AccomodationListDataModel>, ICollection<AccomodationListViewModel>>().ReverseMap();
            CreateMap<ICollection<AccomodationListByTripIdWithBookingsDataModel>, ICollection<AccomodationListWithBookingsViewModel>>().ReverseMap();
            CreateMap<ICollection<AccomodationListOnDateDataModel>, ICollection<AccomodationListOnDateViewModel>>().ReverseMap();

            CreateMap<EventDetailViewModel, CreateEventCommand>().ReverseMap();
            CreateMap<EventDetailViewModel, UpdateEventCommand>().ReverseMap();
            CreateMap<EventDetailDataModel, EventDetailViewModel>().ReverseMap();
            CreateMap<ICollection<EventListByTripIdDataModel>, ICollection<EventListOfTripViewModel>>().ReverseMap();
            CreateMap<ICollection<EventListDataModel>, ICollection<EventListViewModel>>().ReverseMap();
            CreateMap<ICollection<EventListByTripIdWithBookingsDataModel>, ICollection<EventListWithBookingsViewModel>>().ReverseMap();
            CreateMap<ICollection<EventListOnDateDataModel>, ICollection<EventListOnDateViewModel>>().ReverseMap();

            CreateMap<TransportDetailViewModel, CreateTransportCommand>().ReverseMap();
            CreateMap<TransportDetailViewModel, UpdateTransportCommand>().ReverseMap();
            CreateMap<TransportDetailDataModel, TransportDetailViewModel>().ReverseMap();
            CreateMap<ICollection<TransportListByTripIdDataModel>, ICollection<TransportListOfTripViewModel>>().ReverseMap();
            CreateMap<ICollection<TransportListDataModel>, ICollection<TransportListViewModel>>().ReverseMap();
            CreateMap<ICollection<TransportListByTripIdWithBookingsDataModel>, ICollection<TransportListWithBookingsViewModel>>().ReverseMap();
            CreateMap<ICollection<TransportListOnDateDataModel>, ICollection<TransportListOnDateViewModel>>().ReverseMap();
        }
    }
}
