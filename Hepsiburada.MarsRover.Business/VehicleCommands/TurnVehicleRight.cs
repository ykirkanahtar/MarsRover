using Hepsiburada.MarsRover.Business.Models;

namespace Hepsiburada.MarsRover.Business.VehicleCommands
{
    internal class TurnVehicleRight : IVehicleCommand
    {
        private readonly ExplorationVehicle _vehicle = null;

        internal TurnVehicleRight(ExplorationVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public void Execute()
        {
            _vehicle.TurnRight();
        }

    }
}
