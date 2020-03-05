using Hepsiburada.MarsRover.Business.Models;

namespace Hepsiburada.MarsRover.Business.VehicleCommands
{
    internal class MoveVehicle : IVehicleCommand
    {
        private readonly ExplorationVehicle _vehicle = null;

        internal MoveVehicle(ExplorationVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public void Execute()
        {
            _vehicle.Move();
        }
    }
}
