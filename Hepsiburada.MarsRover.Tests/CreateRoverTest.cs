using Hepsiburada.MarsRover.Business.Constants;
using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.ConsoleApp.Constants;
using Hepsiburada.MarsRover.ConsoleApp.Processes;
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
            _plateau = new PlateauProcess().CreatePlateau("5 5");
        }

        private RoverProcess GetRoverHelper(string inputValue)
        {
            var roverHelper = new RoverProcess();
            _ = roverHelper.CreateRover(_plateau, inputValue) as Rover;
            return roverHelper;
        }

        [TestMethod]
        public void Rover_Successfull()
        {
            var roverHelper = GetRoverHelper("1 3 N");

            Assert.AreEqual(roverHelper.GetRover().Point.PositionX, 1);
            Assert.AreEqual(roverHelper.GetRover().Point.PositionY, 3);
        }

        [TestMethod]
        public void Rover_Lower_Case()
        {
            var roverHelper = GetRoverHelper("1 3 n");

            Assert.AreEqual(roverHelper.GetRover().Point.PositionX, 1);
            Assert.AreEqual(roverHelper.GetRover().Point.PositionY, 3);
        }

        [TestMethod]
        public void Rover_Invalid_Array_Size()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                var roverHelper = GetRoverHelper("1 3");
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
                var roverHelper = GetRoverHelper("A 3 N");
            });

            Assert.AreEqual(Constants.NUMERIC_VALUR_ERROR, ex.Message);
        }

        [TestMethod]
        public void Rover_Invalid_Input_Value2()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                var roverHelper = GetRoverHelper("1 A N");
            });

            Assert.AreEqual(Constants.NUMERIC_VALUR_ERROR, ex.Message);
        }

        [TestMethod]
        public void Rover_Invalid_Input_Value3()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                var roverHelper = GetRoverHelper("1 3 1");
            });

            Assert.AreEqual(ConsoleConstants.ROVER_INVALID_DIRECTION, ex.Message);
        }

        [TestMethod]
        public void Rover_Invalid_Input_Value4()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                var roverHelper = GetRoverHelper("1 3 C");
            });

            Assert.AreEqual(ConsoleConstants.ROVER_INVALID_DIRECTION, ex.Message);
        }

        [TestMethod]
        public void Rover_Negative_Input_Value1()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                var roverHelper = GetRoverHelper("-1 3 N");
            });

            Assert.AreEqual(Constants.NEGATIVE_VALUE_ERROR, ex.Message);
        }

        [TestMethod]
        public void Rover_Negative_Input_Value2()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                var roverHelper = GetRoverHelper("1 -3 N");
            });

            Assert.AreEqual(Constants.NEGATIVE_VALUE_ERROR, ex.Message);
        }

        [TestMethod]
        public void Rover_Cross_Border1()
        {
            
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                var roverHelper = GetRoverHelper($"{(_plateau.UpperRightCoordinates.PositionX + 1).ToString()} 3 N");
            });

            Assert.AreEqual(BusinessConstants.BORDER_ERROR, ex.Message);
        }

        [TestMethod]
        public void Rover_Cross_Border2()
        {

            var ex = Assert.ThrowsException<Exception>(() =>
            {
                var roverHelper = GetRoverHelper($"1 {(_plateau.UpperRightCoordinates.PositionY + 1).ToString()} N");
            });

            Assert.AreEqual(BusinessConstants.BORDER_ERROR, ex.Message);
        }
    }
}
