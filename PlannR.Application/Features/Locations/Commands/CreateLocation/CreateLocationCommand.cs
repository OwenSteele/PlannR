using MediatR;

namespace PlannR.Application.Features.Locations.Commands.CreateLocation
{
    public class CreateLocationCommand : IRequest<CreateLocationCommandResponse>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double AltitudeInMetres { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
