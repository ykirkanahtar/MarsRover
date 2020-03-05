using Hepsiburada.MarsRover.Business.Factories;
using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.Business.VehicleCommands;
using Hepsiburada.MarsRover.ConsoleApp.Constants;
using Hepsiburada.MarsRover.Utils;
using Hepsiburada.MarsRover.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hepsiburada.MarsRover.ConsoleApp.Processes
{
    public class RoverProcess : IRoverProcess
    {
        private Rover _rover;

        public Rover CreateRover(string inputValue)
        {
            try
            {
                var roverPositions = inputValue.ToUpper().Split(ConsoleConstants.SEPARATOR);

                roverPositions.CheckArraySize(ConsoleConstants.ROVER_ARRAY_SIZE, string.Format(ConsoleConstants.ARRAY_SIZE_ERROR, ConsoleConstants.ROVER_ARRAY_SIZE));

                var xValue = roverPositions[0].ConvertToInt();
                var yValue = roverPositions[1].ConvertToInt();

                var point = new Point(xValue, yValue);
                var direction = roverPositions[2].ParseEnum<Direction>(ConsoleConstants.ROVER_INVALID_DIRECTION);

                _rover = ExplorationVehicles.Rover.Factory(point, direction) as Rover;
                return _rover;
            }
            catch (Exception ex)
            {
                if (ex is HandledException)
                    throw new Exception(ex.Message);
                else
                    throw new Exception(ConsoleConstants.UNKNOWN_ERROR);
            }
        }

        public void ProcessMovements(Plateau plateau, IVehicleMover vehicleMover, IList<IPoint> busyPoints, string inputMovement)
        {
            try
            {
                var movements = new List<char>();
                movements.AddRange(inputMovement.ToUpper());

                var rotationValues = Enum.GetValues(typeof(Rotation)).Cast<Rotation>().ToList();
                var rotations = movements.ConvertToRotations(string.Format(ConsoleConstants.ROTATION_ENUM_VALUE_ERROR, string.Join(", ", rotationValues)));

                vehicleMover.MoveVehicle(plateau, _rover, rotations, busyPoints);
            }
            catch (Exception ex)
            {
                if (ex is HandledException)
                    throw new Exception(ex.Message);
                else
                    throw new Exception(ConsoleConstants.UNKNOWN_ERROR);
            }
        }

        public Rover GetRover()
        {
            return _rover;
        }
    }
}
