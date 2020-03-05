using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.Business.VehicleCommands;
using System.Collections.Generic;

namespace Hepsiburada.MarsRover.ConsoleApp
{
    public interface IRoverHelper
    {
        Rover CreateRover(string inputValue);
        void ProcessMovements(IVehicleMover vehicleMover, IList<IPoint> busyPoints, string inputMovement);
    }
}