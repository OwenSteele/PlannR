using PlannR.App.Infrastructure.ViewModels.Trips;
using PlannR.App.Infrastructure.ViewModels.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Contracts.View
{
    public interface ITripOrderingService
    {
        OrderTripPartNestedViewModel[] OrderTripParts(TripDetailViewModel tripModel);
    }
}
