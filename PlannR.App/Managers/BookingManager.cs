//using PlannR.App.Infrastructure.Contracts;
//using PlannR.App.Infrastructure.Contracts.Managers;
//using PlannR.App.Infrastructure.CustomTypes;
//using PlannR.App.Infrastructure.Services.Base;
//using PlannR.App.Infrastructure.ViewModels.Booking;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PlannR.App.Managers
//{
//    public class BookingManager : IBookingManager
//    {
//        private readonly IAccomodationBookingDataService _accomodationBookingDataService;
//        private readonly ITransportBookingDataService _transportBookingDataService;
//        private readonly IEventBookingDataService _eventBookingDataService;

//        public BookingManager(
//            IAccomodationBookingDataService accomodationBookingDataService,
//            ITransportBookingDataService transportBookingDataService,
//            IEventBookingDataService eventBookingDataService)
//        {
//            _accomodationBookingDataService = accomodationBookingDataService;
//            _transportBookingDataService = transportBookingDataService;
//            _eventBookingDataService = eventBookingDataService;
//        }
//        public Task<EditBookingViewModel> GetBookingModelAsync(Guid? bookingId)
//        {
//            var result = 
//        }

//        public Task<ApiResponse<Guid>> SubmitBookingModelAsync(EditBookingViewModel editBookingViewModel)
//        {
//            if(editBookingViewModel.BookingId == Guid.Empty) 
//        }

//        private async Task EditAsync(EditBookingViewModel editBookingViewModel)
//        {
//            switch (editBookingViewModel.OwnerType)
//            {
//                case BookingEnum.Accomodation:
//                    await _accomodationBookingDataService.UpdateAsync(editBookingViewModel);
//                    break;
//                case BookingEnum.Transport:
//                    await _transportBookingDataService.UpdateAsync(editBookingViewModel);
//                    break;
//                case BookingEnum.Event:
//                    await _eventBookingDataService.UpdateAsync(editBookingViewModel);
//                    break;
//            }
//        }

//        private async Task<Guid> CreateAsync(EditBookingViewModel editBookingViewModel)
//        {
//            var response = await BookingDataService.CreateAsync(EditBookingViewModel);

//            HandleResponse(response);

//            return response.Data;
//        }
//    }
//}
