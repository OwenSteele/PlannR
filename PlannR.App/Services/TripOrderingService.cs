﻿using PlannR.App.Infrastructure.Contracts.View;
using PlannR.App.Infrastructure.ViewModels.Trips;
using PlannR.App.Infrastructure.ViewModels.UI;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannR.App.Services
{
    public class TripOrderingService : ITripOrderingService
    {
        public OrderTripPartNestedViewModel[] OrderTripParts(TripDetailViewModel tripModel)
        {
            var orderedParts = new List<OrderTripPartNestedViewModel>();

            foreach(var accom in tripModel.Accomodations)
            {
                orderedParts.Add(new OrderTripPartNestedViewModel {
                    Name = accom.Name,
                    Type = "Accomodation",
                    StartDateTime = accom.StartDateTime,
                    EndDateTime = accom.EndDateTime,
                    StartLocationName = accom.Location?.Name,
                    StartCoordinates = (accom.Location?.Longitude,accom.Location?.Latitude),
                    Uri = $"/accomodations/{accom.AccomodationId}",
                    CssClass = "accom"
                });
            }
            foreach (var transport in tripModel.Transports)
            {
                orderedParts.Add(new OrderTripPartNestedViewModel
                {
                    Name = transport.Name,
                    Type = "Transport",
                    StartDateTime = transport.StartDateTime,
                    EndDateTime = transport.EndDateTime,
                    StartLocationName = transport.StartLocation?.Name,
                    StartCoordinates = (transport.StartLocation?.Longitude, transport.StartLocation?.Latitude),
                    EndLocationName = transport.EndLocation?.Name,
                    EndCoordinates = (transport.EndLocation?.Longitude, transport.EndLocation?.Latitude),
                    Uri = $"/transports/{transport.TransportId}",
                    CssClass = "transport"
                });
            }
            foreach (var ev in tripModel.Events)
            {
                orderedParts.Add(new OrderTripPartNestedViewModel
                {
                    Name = ev.Name,
                    Type = "Event",
                    StartDateTime = ev.StartDateTime,
                    EndDateTime = ev.EndDateTime,
                    StartLocationName = ev.CompanyName,
                    StartCoordinates = (ev.Location?.Longitude, ev.Location?.Latitude),
                    Uri = $"/events/{ev.EventId}",
                    CssClass = "events"
                });
            }
            foreach (var route in tripModel.Routes)
            {
                orderedParts.Add(new OrderTripPartNestedViewModel
                {
                    Name = route.Name,
                    Type = "Route",
                    StartDateTime = route.StartDateTime,
                    EndDateTime = route.EndDateTime,
                    Uri = $"/routes/{route.RouteId}",
                    CssClass = "routes"
                });
            }

            return orderedParts.OrderBy(x => x.StartDateTime).ToArray();
        }
    }
}
