using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.ConsoleApp;
using Hepsiburada.MarsRover.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Hepsiburada.MarsRover.Tests
{

    [TestClass]
    public class CreateRoverTest
    {
        private Plateau _plateau;

        [TestInitialize]
        public void Setup()
        {
            _plateau = PlateauHelper.CreatePlateau("5 5");
        }

        [TestMethod]
        public void Rover_Successfull()
        {
            var rover = new RoverHelper(_plateau).CreateRover("1 3 N");

            Assert.AreEqual(rover.Point.PositionX, 1);
            Assert.AreEqual(rover.Point.PositionY, 3);
        }

        [TestMethod]
        public void Rover_Lower_Case()
        {
            var rover = new RoverHelper(_plateau).CreateRover("1 3 N");

            Assert.AreEqual(rover.Point.PositionX, 1);
            Assert.AreEqual(rover.Point.PositionY, 3);
        }

        [TestMethod]
        public void Rover_Invalid_Array_Size()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                new RoverHelper(_plateau).CreateRover("1 3");
            });

            Assert.AreEqual(
                string.Format(string.Format(ConsoleConstants.ARRAY_SIZE_ERROR, ConsoleConstants.ROVER_ARRAY_SIZE))
                , ex.Message);
        }

        [TestMethod]
        public void Rover_Invalid_Input_Value1()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                new RoverHelper(_plateau).CreateRover("A 3 N");
            });

            Assert.AreEqual(Constants.NUMERIC_VALUR_ERROR, ex.Message);
        }

        [TestMethod]
        public void Rover_Invalid_Input_Value2()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                new RoverHelper(_plateau).CreateRover("1 A N");
            });

            Assert.AreEqual(Constants.NUMERIC_VALUR_ERROR, ex.Message);
        }

        [TestMethod]
        public void Rover_Invalid_Input_Value3()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                new RoverHelper(_plateau).CreateRover("1 3 1");
            });

            Assert.AreEqual(ConsoleConstants.ROVER_INVALID_DIRECTION, ex.Message);
        }

        [TestMethod]
        public void Rover_Invalid_Input_Value4()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                new RoverHelper(_plateau).CreateRover("1 3 C");
            });

            Assert.AreEqual(ConsoleConstants.ROVER_INVALID_DIRECTION, ex.Message);
        }

        [TestMethod]
        public void Rover_Negative_Input_Value1()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                new RoverHelper(_plateau).CreateRover("-1 3 N");
            });

            Assert.AreEqual(Constants.NEGATIVE_VALUE_ERROR, ex.Message);
        }

        [TestMethod]
        public void Rover_Negative_Input_Value2()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                new RoverHelper(_plateau).CreateRover("1 -3 N");
            });

            Assert.AreEqual(Constants.NEGATIVE_VALUE_ERROR, ex.Message);
        }
    }
}
