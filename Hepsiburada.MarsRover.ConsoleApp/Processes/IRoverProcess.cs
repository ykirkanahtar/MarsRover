using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.Business.VehicleCommands;
using System.Collections.Generic;

namespace Hepsiburada.MarsRover.ConsoleApp.Processes
{
    public interface IRoverProcess
    {
        Rover CreateRover(string inputValue);
        void ProcessMovements(Plateau plateau, IVehicleMover vehicleMover, IList<IPoint> busyPoints, string inputMovement);
    }
}