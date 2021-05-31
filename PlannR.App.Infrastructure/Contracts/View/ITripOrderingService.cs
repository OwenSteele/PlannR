using PlannR.App.Infrastructure.ViewModels.Nested;
using PlannR.App.Infrastructure.ViewModels.Trips;
using PlannR.App.Infrastructure.ViewModels.UI;
using PlannR.ComponentLibrary.Map;
using System.Collections.Generic;

namespace PlannR.App.Infrastructure.Contracts.View
{
    public interface ITripOrderingService
    {
        OrderTripPartNestedViewModel[] OrderTripParts(TripDetailViewModel tripModel);
        List<Marker> GetMarkerList(OrderTripPartNestedViewModel[] orderedTripParts, LocationNestedViewModel startLocation = null, LocationNestedViewModel endLocation = null);
    }
}
