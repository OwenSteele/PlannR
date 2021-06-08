using PlannR.App.Infrastructure.Contracts.View;
using System.Globalization;

namespace PlannR.App.Services
{
    public class MapService : IMapService
    {
        public (double, double) ParseCoordinates(string coordValue)
        {
            var strValue = coordValue.Replace(',', '.');
            var coords = strValue.Split(' ');

            _ = double.TryParse(coords[0],
                NumberStyles.Any, CultureInfo.InvariantCulture, out double latValue);

            _ = double.TryParse((coords.Length > 1) ? coords[1] : "0",
                NumberStyles.Any, CultureInfo.InvariantCulture, out double longValue);

            return (longValue, latValue);
        }
    }
}
