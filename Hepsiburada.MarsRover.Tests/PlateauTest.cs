using Hepsiburada.MarsRover.Business.Constants;
using Hepsiburada.MarsRover.ConsoleApp;
using Hepsiburada.MarsRover.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Hepsiburada.MarsRover.Tests
{
    [TestClass]
    public class PlateauTest
    {
        [TestMethod]
        public void Plateau_Successfull()
        {
            var plateau = PlateauHelper.CreatePlateau("5 5");

            Assert.AreEqual(plateau.UpperRightCoordinates.PositionX, 5);
            Assert.AreEqual(plateau.UpperRightCoordinates.PositionY, 5);

        }

        [TestMethod]
        public void Plateau_Invalid_Array_Size()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                PlateauHelper.CreatePlateau("A");
            });

            Assert.AreEqual(
                string.Format(ConsoleConstants.ARRAY_SIZE_ERROR, ConsoleConstants.PLATEAU_ARRAY_SIZE)
                , ex.Message);
        }

        [TestMethod]
        public void Plateau_Invalid_Input_Value()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                PlateauHelper.CreatePlateau("A B");
            });

            Assert.AreEqual(Constants.NUMERIC_VALUR_ERROR, ex.Message);
        }

        [TestMethod]
        public void Plateau_Size_Limit_Error1()
        {
            var plateauSize = Convert.ToInt32(BusinessConstants.PLATEAU_SIZE_LIMIT);
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                PlateauHelper.CreatePlateau($"{(plateauSize + 1).ToString()} 1");
            });

            Assert.AreEqual(BusinessConstants.INVALID_PLATEAU_SIZE, ex.Message);
        }

        [TestMethod]
        public void Plateau_Size_Limit_Error2()
        {
            var plateauSize = Convert.ToInt32(BusinessConstants.PLATEAU_SIZE_LIMIT);
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                PlateauHelper.CreatePlateau($"1 {(plateauSize + 1).ToString()}");
            });

            Assert.AreEqual(BusinessConstants.INVALID_PLATEAU_SIZE, ex.Message);
        }

        [TestMethod]
        public void Plateau_Negative_Input_Value1()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                PlateauHelper.CreatePlateau("1 -1");
            });

            Assert.AreEqual(Constants.NEGATIVE_VALUE_ERROR, ex.Message);
        }

        [TestMethod]
        public void Plateau_Negative_Input_Value2()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                PlateauHelper.CreatePlateau("-1 1");
            });

            Assert.AreEqual(Constants.NEGATIVE_VALUE_ERROR, ex.Message);
        }

        [TestMethod]
        public void Plateau_Zero_Input_Value1()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                PlateauHelper.CreatePlateau("0 1");
            });

            Assert.AreEqual(BusinessConstants.INVALID_PLATEAU_UPPER_RIGHT_COORDINATE, ex.Message);
        }

        [TestMethod]
        public void Plateau_Zero_Input_Value2()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
                PlateauHelper.CreatePlateau("1 0");
            });

            Assert.AreEqual(BusinessConstants.INVALID_PLATEAU_UPPER_RIGHT_COORDINATE, ex.Message);
        }
    }
}
