using Hepsiburada.MarsRover.Utils.Enums;

namespace Hepsiburada.MarsRover.Business.Models
{
    public class Rover : ExplorationVehicle
    {
        internal Rover(IPoint point, Direction direction)
            : base(point, direction)
        {

        }
    }
}
