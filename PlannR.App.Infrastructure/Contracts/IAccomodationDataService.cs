using PlannR.App.Infrastructure.Contracts.Base;
using PlannR.App.Infrastructure.ViewModels.Accomodation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Contracts
{
    public interface IAccomodationDataService : IBaseDataService<EditAccomodationViewModel, Guid>
    {
        Task<ICollection<AccomodationListViewModel>> GetAllAccomodationAsync();
        Task<ICollection<AccomodationListOfTripViewModel>> GetAllAccomodationOfTripIdAsync(Guid tripId);
        Task<ICollection<AccomodationListOnDateViewModel>> GetAllAccomodationOnDateAsync(DateTime date);
        Task<ICollection<AccomodationListWithBookingsViewModel>> GetAllAccomodationOfTripWithBookingsAsync(Guid tripId);
        Task<AccomodationDetailViewModel> GetAccomodationByIdAsync(Guid id);
    }
}
