using PlannR.App.Infrastructure.Contracts.View;
using System.Globalization;

namespace PlannR.App.Services
{
    public class MapService : IMapService
    {

        public (double, double) ParseCoordinates(string coordValue)
        {
            var coords = coordValue.Split(' ');

            _ = double.TryParse(coords[0],
                NumberStyles.Any, CultureInfo.InvariantCulture, out double latValue);
            _ = double.TryParse(coords[1],
                NumberStyles.Any, CultureInfo.InvariantCulture, out double longValue);

            return (longValue, latValue);
        }
    }
}
