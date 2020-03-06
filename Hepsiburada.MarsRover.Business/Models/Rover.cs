using Hepsiburada.MarsRover.Utils.Enums;

namespace Hepsiburada.MarsRover.Business.Models
{
    public class Rover : ExplorationVehicle
    {
        internal Rover(IPoint point, Direction direction, Plateau plateau)
            : base(point, direction, plateau)
        {

        }
    }
}
