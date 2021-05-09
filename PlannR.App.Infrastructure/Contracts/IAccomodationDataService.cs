using Plannr.App.Infrastructure.Contracts.Base;
using Plannr.App.Infrastructure.ViewModels.Accomodation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Contracts
{
    public interface IAccomodationDataService : IBaseDataService<AccomodationDetailViewModel>
    {
        Task<ICollection<AccomodationListViewModel>> GetAllAccomodationAsync();
        Task<ICollection<AccomodationListOfTripViewModel>> GetAllAccomodationOfTripIdAsync(Guid tripId);
        Task<ICollection<AccomodationListOnDateViewModel>> GetAllAccomodationOnDateAsync(DateTime date);
        Task<ICollection<AccomodationListWithBookingsViewModel>> GetAllAccomodationOfTripWithBookingsAsync(Guid tripId);
        Task<ICollection<AccomodationDetailViewModel>> GetAccomodationByIdAsync(Guid id);
    }
}
