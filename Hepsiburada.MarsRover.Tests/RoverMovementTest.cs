using Hepsiburada.MarsRover.Business.Constants;
using Hepsiburada.MarsRover.Business.Functions;
using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.Business.VehicleCommands;
using Hepsiburada.MarsRover.ConsoleApp.Constants;
using Hepsiburada.MarsRover.ConsoleApp.Processes;
using Hepsiburada.MarsRover.Utils;
using Hepsiburada.MarsRover.Utils.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hepsiburada.MarsRover.Tests
{
    [TestClass]
    public class RoverMovementTest
    {
        private Plateau _plateau;
        private readonly IVehicleMover _vehicleMover;

        public RoverMovementTest()
        {
            _vehicleMover = new VehicleMover();
        }

        [TestInitialize]
        public void Setup()
        {
            _plateau = new PlateauProcess().CreatePlateau("5 5");
        }

        private Rover GetRover(string inputValue)
        {
            return new RoverProcess().CreateRover(_plateau, inputValue) as Rover;
        }

        private RoverProcess GetRoverHelper(string inputValue)
        {
            var roverHelper = new RoverProcess();
            _ = roverHelper.CreateRover(_plateau, inputValue) as Rover;
            return roverHelper;
        }

        [TestMethod]
        public void RoverMovement_Successfull()
        {
            var roverHelper = GetRoverHelper("1 2 N");
            roverHelper.ProcessMovements(_plateau, _vehicleMover, new List<IPoint>(), "LMLMLMLMM");

            Assert.AreEqual(roverHelper.GetRover().Point.PositionX, 1);
            Assert.AreEqual(roverHelper.GetRover().Point.PositionY, 3);
            Assert.AreEqual(roverHelper.GetRover().GetDirection(), Direction.N);
        }

        [TestMethod]
        public void Rover_Invalid_Rotation_Value()
        {
            var roverHelper = GetRoverHelper("1 2 N");

            var ex = Assert.ThrowsException<Exception>(() =>
            {
                roverHelper.ProcessMovements(_plateau, _vehicleMover, new List<IPoint>(), "BMLMLMLMM");
            });

            var rotationValues = Enum.GetValues(typeof(Rotation)).Cast<Rotation>().ToList();

            Assert.AreEqual(
                string.Format(ConsoleConstants.ROTATION_ENUM_VALUE_ERROR, string.Join(", ", rotationValues))
                , ex.Message);
        }

        [TestMethod]
        public void Rover_Busy_Point_Error()
        {
            var roverHelper = GetRoverHelper("1 2 N");

            var busyPoint = new List<IPoint>() { new Point(1, 3) };
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                roverHelper.ProcessMovements(_plateau, _vehicleMover, busyPoint, "LMLMLMLMM");
            });

            Assert.AreEqual(
                BusinessConstants.BUSY_POINT
                , ex.Message);
        }

        [TestMethod]
        public void Rover_Border_Error1()
        {
            var roverHelper = GetRoverHelper("1 2 N");

            var ex = Assert.ThrowsException<Exception>(() =>
            {
                roverHelper.ProcessMovements(_plateau, _vehicleMover, new List<IPoint>(), "MMMM");
            });

            Assert.AreEqual(
                BusinessConstants.BORDER_ERROR
                , ex.Message);
        }

        [TestMethod]
        public void Rover_Border_Error2()
        {
            var roverHelper = GetRoverHelper("1 2 N");

            var ex = Assert.ThrowsException<Exception>(() =>
            {
                roverHelper.ProcessMovements(_plateau, _vehicleMover, new List<IPoint>(), "RMMMMM");
            });

            Assert.AreEqual(
                BusinessConstants.BORDER_ERROR
                , ex.Message);
        }

        [TestMethod]
        public void Rover_Border_Negative_Error1()
        {
            var roverHelper = GetRoverHelper("1 2 N");

            var ex = Assert.ThrowsException<Exception>(() =>
            {
                roverHelper.ProcessMovements(_plateau, _vehicleMover, new List<IPoint>(), "LMM");
            });

            Assert.AreEqual(
                UtilsConstants.NEGATIVE_VALUE_ERROR
                , ex.Message);
        }

        [TestMethod]
        public void Rover_Border_Negative_Error2()
        {
            var roverHelper = GetRoverHelper("1 2 N");

            var ex = Assert.ThrowsException<Exception>(() =>
            {
                roverHelper.ProcessMovements(_plateau, _vehicleMover, new List<IPoint>(), "LLMMM");
            });

            Assert.AreEqual(
                UtilsConstants.NEGATIVE_VALUE_ERROR
                , ex.Message);
        }

        [TestMethod]
        public void Rover_Check_Vehicle_List_Limit()
        {
            var rovers = new List<ExplorationVehicle>();

            var rover1 = GetRover("3 4 S");
            var rover2 = GetRover("0 0 E");
            var rover3 = GetRover("2 2 N");
            var rover4 = GetRover("4 0 S");
            var rover5 = GetRover("2 5 W");
            var rover6 = GetRover("5 5 S");

            var ex = Assert.ThrowsException<HandledException>(() =>
            {
                rovers.AddToVehicles(rover1, _plateau);
                rovers.AddToVehicles(rover2, _plateau);
                rovers.AddToVehicles(rover3, _plateau);
                rovers.AddToVehicles(rover4, _plateau);
                rovers.AddToVehicles(rover5, _plateau);
                rovers.AddToVehicles(rover6, _plateau);
            });

            Assert.AreEqual(
                BusinessConstants.VEHICLE_LIST_EXCEEDED
                , ex.Message);
        }
    }
}
