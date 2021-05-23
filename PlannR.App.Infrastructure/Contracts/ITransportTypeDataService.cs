using PlannR.App.Infrastructure.Contracts.Base;
using PlannR.App.Infrastructure.ViewModels.Transport;
using PlannR.App.Infrastructure.ViewModels.Transport.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Contracts
{
    public interface ITransportTypeDataService : ICreateBaseDataService<TransportTypeOfNameViewModel, Guid>
    {
        Task<ICollection<TransportTypeListViewModel>> GetAllTypesAsync();
        Task<TransportTypeOfNameViewModel> GetTypeByNameAsync(string name);
        Task<ICollection<TransportTypeNestedViewModel>> GetAllTypeNamesAsync();
    }
}
