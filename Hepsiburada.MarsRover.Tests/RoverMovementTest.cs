using Hepsiburada.MarsRover.Business.Constants;
using Hepsiburada.MarsRover.Business.Functions;
using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.Business.VehicleCommands;
using Hepsiburada.MarsRover.ConsoleApp;
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
            _plateau = PlateauHelper.CreatePlateau("5 5");
        }

        private RoverHelper GetRoverHelper()
        {
            var roverHelper = new RoverHelper(_plateau);
            var rover = roverHelper.CreateRover("1 2 N") as Rover;
            return roverHelper;
        }

        private Rover GetRover(string inputValue)
        {
            var roverHelper = new RoverHelper(_plateau);
            return roverHelper.CreateRover(inputValue) as Rover;
        }

        [TestMethod]
        public void RoverMovement_Successfull()
        {
            var roverHelper = GetRoverHelper();
            var rover = roverHelper.GetRover();

            roverHelper.ProcessMovements(_vehicleMover, new List<IPoint>(), "LMLMLMLMM");

            Assert.AreEqual(rover.Point.PositionX, 1);
            Assert.AreEqual(rover.Point.PositionY, 3);
            Assert.AreEqual(rover.GetDirection(), Direction.N);
        }

        [TestMethod]
        public void Rover_Invalid_Rotation_Value()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                GetRoverHelper().ProcessMovements(_vehicleMover, new List<IPoint>(), "BMLMLMLMM");
            });

            var rotationValues = Enum.GetValues(typeof(Rotation)).Cast<Rotation>().ToList();

            Assert.AreEqual(
                string.Format(ConsoleConstants.ROTATION_ENUM_VALUE_ERROR, string.Join(", ", rotationValues))
                , ex.Message);
        }

        [TestMethod]
        public void Rover_Busy_Point_Error()
        {
            var busyPoint = new List<IPoint>() { new Point(1, 3) };
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                GetRoverHelper().ProcessMovements(_vehicleMover, busyPoint, "LMLMLMLMM");
            });

            Assert.AreEqual(
                BusinessConstants.BUSY_POINT
                , ex.Message);
        }

        [TestMethod]
        public void Rover_Border_Error1()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                GetRoverHelper().ProcessMovements(_vehicleMover, new List<IPoint>(), "MMMM");
            });

            Assert.AreEqual(
                BusinessConstants.BORDER_ERROR
                , ex.Message);
        }

        [TestMethod]
        public void Rover_Border_Error2()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                GetRoverHelper().ProcessMovements(_vehicleMover, new List<IPoint>(), "RMMMMM");
            });

            Assert.AreEqual(
                BusinessConstants.BORDER_ERROR
                , ex.Message);
        }

        [TestMethod]
        public void Rover_Border_Negative_Error1()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                GetRoverHelper().ProcessMovements(_vehicleMover, new List<IPoint>(), "LMM");
            });

            Assert.AreEqual(
                Constants.NEGATIVE_VALUE_ERROR
                , ex.Message);
        }

        [TestMethod]
        public void Rover_Border_Negative_Error2()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                GetRoverHelper().ProcessMovements(_vehicleMover, new List<IPoint>(), "LLMMM");
            });

            Assert.AreEqual(
                Constants.NEGATIVE_VALUE_ERROR
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
