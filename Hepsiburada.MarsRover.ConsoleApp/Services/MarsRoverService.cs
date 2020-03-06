using Hepsiburada.MarsRover.Business.Functions;
using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.Business.VehicleCommands;
using Hepsiburada.MarsRover.ConsoleApp.Constants;
using Hepsiburada.MarsRover.ConsoleApp.Processes;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hepsiburada.MarsRover.ConsoleApp.Services
{
    public class MarsRoverService : BackgroundService
    {
        private readonly IPlateauProcess _plateauHelper;
        private readonly IRoverProcess _roverHelper;
        private readonly IVehicleMover _vehicleMover;

        public MarsRoverService(IPlateauProcess plateauHelper, IRoverProcess roverHelper, IVehicleMover vehicleMover)
        {
            _plateauHelper = plateauHelper;
            _roverHelper = roverHelper;
            _vehicleMover = vehicleMover;
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var plateau = DefineSurface();
            var rovers = OperateRovers(plateau);

            foreach (var rover in rovers)
            {
                Console.WriteLine(string.Format(ConsoleConstants.RESULT_MESSAGE, rover.GetLastPosition()));
            }

            Console.Read();

            return Task.CompletedTask;
        }

        public Plateau DefineSurface()
        {
            Plateau plateau = null;
            bool exception;
            do
            {
                exception = false;

                try
                {
                    Console.WriteLine(ConsoleConstants.ENTER_PLATEAU_COORDINATES);
                    plateau = _plateauHelper.CreatePlateau(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ConsoleConstants.ERROR_MESSAGE} {ex.Message}");
                    exception = true;
                }

            } while (exception);

            return plateau;
        }

        public List<ExplorationVehicle> OperateRovers(Plateau plateau)
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

                        var rover = _roverHelper.CreateRover(plateau, Console.ReadLine());

                        Console.WriteLine(ConsoleConstants.ENTER_MOTION_SETS);

                        _roverHelper.ProcessMovements(plateau, _vehicleMover, busyPoints, Console.ReadLine());

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

        public void StopApplication()
        {
            throw new NotImplementedException();
        }
    }
}
