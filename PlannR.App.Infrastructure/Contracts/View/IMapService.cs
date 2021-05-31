using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Contracts.View
{
    public interface IMapService
    {
        (double, double) ParseCoordinates(string coordValue);
    }
}
