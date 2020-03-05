using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.Utils.Enums;
using System.Collections.Generic;

namespace Hepsiburada.MarsRover.Business.VehicleCommands
{
    public interface IVehicleMover
    {
        void MoveVehicle(Plateau plateau, ExplorationVehicle vehicle, IList<Rotation> rotations, IList<IPoint> busyPoints);
    }
}
