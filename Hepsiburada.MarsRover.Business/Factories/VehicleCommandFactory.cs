using Hepsiburada.MarsRover.Business.Constants;
using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.Business.VehicleCommands;
using Hepsiburada.MarsRover.Utils.Enums;
using System;

namespace Hepsiburada.MarsRover.Business.Factories
{
    internal static class VehicleCommandFactory
    {
        public static IVehicleCommand GetVehicleCommand(Rotation rotation, ExplorationVehicle vehicle)
        {
            return rotation switch
            {
                Rotation.L => new TurnVehicleLeft(vehicle),
                Rotation.R => new TurnVehicleRight(vehicle),
                Rotation.M => new MoveVehicle(vehicle),
                _ => throw new Exception(BusinessConstants.INVALID_ROTATION_VALUE),
            };
        }
    }
}