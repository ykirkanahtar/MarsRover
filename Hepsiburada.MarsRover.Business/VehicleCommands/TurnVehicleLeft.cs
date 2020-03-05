using Hepsiburada.MarsRover.Business.Models;

namespace Hepsiburada.MarsRover.Business.VehicleCommands
{
    internal class TurnVehicleLeft : IVehicleCommand
    {
        private readonly ExplorationVehicle _vehicle = null;

        internal TurnVehicleLeft(ExplorationVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public void Execute()
        {
            _vehicle.TurnLeft();
        }
    }
}
