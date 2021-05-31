using PlannR.App.Infrastructure.Contracts.View;
using PlannR.App.Infrastructure.ViewModels.Nested;
using PlannR.App.Infrastructure.ViewModels.Trips;
using PlannR.App.Infrastructure.ViewModels.UI;
using PlannR.ComponentLibrary.Map;
using System.Collections.Generic;
using System.Linq;

namespace PlannR.App.Services
{
    public class TripOrderingService : ITripOrderingService
    {
        public OrderTripPartNestedViewModel[] OrderTripParts(TripDetailViewModel tripModel)
        {
            var orderedParts = new List<OrderTripPartNestedViewModel>();

            foreach (var accom in tripModel.Accomodations)
            {
                orderedParts.Add(new OrderTripPartNestedViewModel
                {
                    Name = accom.Name,
                    Type = "Accomodation",
                    StartDateTime = accom.StartDateTime,
                    EndDateTime = accom.EndDateTime,
                    StartLocationName = accom.Location?.Name,
                    StartCoordinates = (accom.Location?.Longitude, accom.Location?.Latitude),
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

        public List<Marker> GetMarkerList(OrderTripPartNestedViewModel[] orderedTripParts,
            LocationNestedViewModel startLocation = null,
            LocationNestedViewModel endLocation = null)
        {
            var fullMapPoints = new List<Marker>();

            var position = 0;

            if (startLocation != null)
            {
                position++;
                fullMapPoints.Add(new Marker
                {
                    Description = $"{position}. {startLocation.Name} (start of trip)",
                    ShowPopup = true,
                    X = startLocation.Longitude,
                    Y = startLocation.Latitude,
                });
            }

            foreach (var part in orderedTripParts)
            {
                if (!string.IsNullOrWhiteSpace(part.StartLocationName))
                {
                    position++;
                    fullMapPoints.Add(new Marker
                    {
                        Description = $"{position}. {part.Name} ({part.Type})",
                        X = part.StartCoordinates.Item1.Value,
                        Y = part.StartCoordinates.Item2.Value,
                    });
                }
                if (!string.IsNullOrWhiteSpace(part.EndLocationName))
                {
                    fullMapPoints.Add(new Marker
                    {
                        Description = $"{position}. end of: {part.Name} ({part.Type})",
                        X = part.EndCoordinates.Item1.Value,
                        Y = part.EndCoordinates.Item2.Value,
                    });
                }
            }
            if (endLocation != null)
            {
                position++;
                fullMapPoints.Add(new Marker
                {
                    Description = $"{position}. {endLocation.Name} (end of trip)",
                    X = endLocation.Longitude,
                    Y = endLocation.Latitude,
                });
            }

            return fullMapPoints;
        }
    }
}
