using PlannR.App.Infrastructure.Contracts.Base;
using PlannR.App.Infrastructure.ViewModels.Accomodation;
using PlannR.App.Infrastructure.ViewModels.Accomodation.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Contracts
{
    public interface IAccomodationTypeDataService : ICreateBaseDataService<AccomodationTypeOfNameViewModel, Guid>
    {
        Task<ICollection<AccomodationTypeListViewModel>> GetAllTypesAsync();
        Task<AccomodationTypeOfNameViewModel> GetTypeByNameAsync(string name);
        Task<ICollection<AccomodationTypeNestedViewModel>> GetAllTypeNamesAsync();
    }
}
