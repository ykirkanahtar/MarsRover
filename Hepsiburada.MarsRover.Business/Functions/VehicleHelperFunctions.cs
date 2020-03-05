using Hepsiburada.MarsRover.Business.Constants;
using Hepsiburada.MarsRover.Business.Factories;
using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.Business.VehicleCommands;
using Hepsiburada.MarsRover.Utils;
using Hepsiburada.MarsRover.Utils.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Hepsiburada.MarsRover.Business.Functions
{
    public static class VehicleHelperFunctions
    {
        public static IPoint CheckBusyPointsRoute(ExplorationVehicle virtualVehicle, IList<Rotation> rotations, IList<IPoint> busyPoints)
        {
            var vehicleCommandInvoker = new VehicleCommandInvoker();

            foreach (var rotation in rotations)
            {
                var vehicleCommand = VehicleCommandFactory.GetVehicleCommand(rotation, virtualVehicle);
                vehicleCommandInvoker.Execute(vehicleCommand);

                if (busyPoints
                    .Where(x => x.PositionX == virtualVehicle.Point.PositionX)
                    .Where(x => x.PositionY == virtualVehicle.Point.PositionY)
                    .Count() > 0)
                {
                    throw new HandledException(BusinessConstants.BUSY_POINT);
                }
            }
            return virtualVehicle.Point;
        }

        public static void CheckBorderLimits(Plateau plateau, IPoint virtualVehiclePoint)
        {

            if (virtualVehiclePoint.PositionX > plateau.UpperRightCoordinates.PositionX
                || virtualVehiclePoint.PositionY > plateau.UpperRightCoordinates.PositionY
                || virtualVehiclePoint.PositionX < 0
                || virtualVehiclePoint.PositionY < 0
                )
            {
                throw new HandledException(BusinessConstants.BORDER_ERROR);
            }
        }

        public static void AddToVehicles(this IList<ExplorationVehicle> vehicles, ExplorationVehicle newVehicle, Plateau plateau)
        {
            vehicles.CheckVehiclesLimit(plateau);
            vehicles.Add(newVehicle);
        }


        //The limit of the rover count is equal to smaller coordinate of the plateau
        public static void CheckVehiclesLimit(this IList<ExplorationVehicle> vehicles, Plateau plateau)
        {
            var point = plateau.UpperRightCoordinates;
            var limitOfTheList = point.PositionX < point.PositionY ? point.PositionX : point.PositionY;

            if (!(vehicles.Count < limitOfTheList))
                throw new HandledException(BusinessConstants.VEHICLE_LIST_EXCEEDED);
        }
    }
}
