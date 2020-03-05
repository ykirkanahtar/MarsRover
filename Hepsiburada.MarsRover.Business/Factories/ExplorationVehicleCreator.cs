using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.Utils.Enums;

namespace Hepsiburada.MarsRover.Business.Factories
{
    public static class ExplorationVehicleCreator
    {
        public static ExplorationVehicle Factory(this ExplorationVehicles explorationVehicle, IPoint point, Direction direction)
        {
            switch (explorationVehicle)
            {
                case ExplorationVehicles.Rover:
                    return new Rover(point, direction);
                default:
                    return new Rover(point, direction);
            }

        }
    }
}
