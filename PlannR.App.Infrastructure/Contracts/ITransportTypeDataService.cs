using Plannr.App.Infrastructure.Contracts.Base;
using Plannr.App.Infrastructure.Services.Base;
using Plannr.App.Infrastructure.ViewModels.Transport.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Contracts
{
    public interface ITransportTypeDataService : ICreateBaseDataService<TransportTypeOfNameViewModel>
    {
        Task<ICollection<TransportTypeListViewModel>> GetAllBookingsAsync();
        Task<TransportTypeOfNameViewModel> GetBookingByNameAsync(string name);
    }
}
