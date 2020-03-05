using Hepsiburada.MarsRover.Business.Functions;
using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.Business.VehicleCommands;
using System;
using System.Collections.Generic;

namespace Hepsiburada.MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var plateau = DefineSurface();
            var rovers = OperateRovers(plateau);

            foreach (var rover in rovers)
            {
                Console.WriteLine(string.Format(ConsoleConstants.RESULT_MESSAGE, rover.GetLastPosition()));
            }

            Console.Read();
        }

        public static Plateau DefineSurface()
        {
            Plateau plateau = null;
            bool exception;
            do
            {
                exception = false;

                try
                {
                    Console.WriteLine(ConsoleConstants.ENTER_PLATEAU_COORDINATES);
                    plateau = PlateauHelper.CreatePlateau(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ConsoleConstants.ERROR_MESSAGE} {ex.Message}");
                    exception = true;
                }

            } while (exception);

            return plateau;
        }

        public static List<ExplorationVehicle> OperateRovers(Plateau plateau)
        {
            var rovers = new List<ExplorationVehicle>();
            var busyPoints = new List<IPoint>();
            bool exception;

            do
            {

                do
                {
                    exception = false;

                    try
                    {
                        Console.WriteLine(ConsoleConstants.ENTER_ROVER_COORDINATES);

                        IRoverHelper roverHelper = new RoverHelper(plateau);
                        IVehicleMover vehicleMover = new VehicleMover();

                        var rover = roverHelper.CreateRover(Console.ReadLine());

                        Console.WriteLine(ConsoleConstants.ENTER_MOTION_SETS);

                        roverHelper.ProcessMovements(vehicleMover, busyPoints, Console.ReadLine());

                        busyPoints.Add(rover.Point);

                        rovers.AddToVehicles(rover, plateau);

                        Console.WriteLine(ConsoleConstants.PRESS_CHAR_FOR_ADD_NEW_ROVER);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ConsoleConstants.ERROR_MESSAGE} {ex.Message}");
                        exception = true;
                    }
                }
                while (exception);
            } while (Console.ReadLine().ToUpper() == ConsoleConstants.CONTINUE_CHAR.ToUpper());

            return rovers;
        }
    }
}
