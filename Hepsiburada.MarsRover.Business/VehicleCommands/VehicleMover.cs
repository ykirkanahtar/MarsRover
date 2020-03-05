using Hepsiburada.MarsRover.Business.Factories;
using Hepsiburada.MarsRover.Business.Functions;
using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.Utils.Enums;
using System.Collections.Generic;

namespace Hepsiburada.MarsRover.Business.VehicleCommands
{
    public class VehicleMover : IVehicleMover
    {
        public void MoveVehicle(Plateau plateau, ExplorationVehicle vehicle, IList<Rotation> rotations, IList<IPoint> busyPoints)
        {
            var vehiclePoint = new Point(vehicle.Point.PositionX, vehicle.Point.PositionY);
            var direction = vehicle.GetDirection();

            var virtualVehicle = ExplorationVehicles.Rover.Factory(vehiclePoint, direction);
            var destinationPoint = VehicleHelperFunctions.CheckBusyPointsRoute(virtualVehicle, rotations, busyPoints);
            VehicleHelperFunctions.CheckBorderLimits(plateau, destinationPoint);

            var vehicleCommandInvoker = new VehicleCommandInvoker();

            foreach (var rotation in rotations)
            {
                var vehicleCommand = VehicleCommandFactory.GetVehicleCommand(rotation, vehicle);
                vehicleCommandInvoker.Execute(vehicleCommand);
            }
        }

    }
}
