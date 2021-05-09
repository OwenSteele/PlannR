using Plannr.App.Infrastructure.Contracts.Base;
using Plannr.App.Infrastructure.Services.Base;
using Plannr.App.Infrastructure.ViewModels.Accomodation.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Contracts
{
    public interface IAccomodationTypeDataService : ICreateBaseDataService<AccomodationTypeOfNameViewModel>
    {
        Task<ICollection<AccomodationTypeListViewModel>> GetAllBookingsAsync();
        Task<AccomodationTypeOfNameViewModel> GetBookingByNameAsync(string name);
    }
}
