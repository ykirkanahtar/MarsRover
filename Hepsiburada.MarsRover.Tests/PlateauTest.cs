using Hepsiburada.MarsRover.Business.Constants;
using Hepsiburada.MarsRover.ConsoleApp.Constants;
using Hepsiburada.MarsRover.ConsoleApp.Processes;
using Hepsiburada.MarsRover.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Hepsiburada.MarsRover.Tests
{
    [TestClass]
    public class PlateauTest
    {
        private PlateauProcess GetNewPlateauHelper()
        {
            return new PlateauProcess();
        }


        [TestMethod]
        public void Plateau_Successfull()
        {
            var plateau = GetNewPlateauHelper().CreatePlateau("5 5");

            Assert.AreEqual(plateau.UpperRightCoordinates.PositionX, 5);
            Assert.AreEqual(plateau.UpperRightCoordinates.PositionY, 5);

        }

        [TestMethod]
        public void Plateau_Invalid_Array_Size()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
               GetNewPlateauHelper().CreatePlateau("A");
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
               GetNewPlateauHelper().CreatePlateau("A B");
            });

            Assert.AreEqual(UtilsConstants.NUMERIC_VALUR_ERROR, ex.Message);
        }

        [TestMethod]
        public void Plateau_Size_Limit_Error1()
        {
            var plateauSize = Convert.ToInt32(BusinessConstants.PLATEAU_SIZE_LIMIT);
            var ex = Assert.ThrowsException<Exception>(() =>
            {
               GetNewPlateauHelper().CreatePlateau($"{(plateauSize + 1).ToString()} 1");
            });

            Assert.AreEqual(BusinessConstants.INVALID_PLATEAU_SIZE, ex.Message);
        }

        [TestMethod]
        public void Plateau_Size_Limit_Error2()
        {
            var plateauSize = Convert.ToInt32(BusinessConstants.PLATEAU_SIZE_LIMIT);
            var ex = Assert.ThrowsException<Exception>(() =>
            {
               GetNewPlateauHelper().CreatePlateau($"1 {(plateauSize + 1).ToString()}");
            });

            Assert.AreEqual(BusinessConstants.INVALID_PLATEAU_SIZE, ex.Message);
        }

        [TestMethod]
        public void Plateau_Negative_Input_Value1()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
               GetNewPlateauHelper().CreatePlateau("1 -1");
            });

            Assert.AreEqual(UtilsConstants.NEGATIVE_VALUE_ERROR, ex.Message);
        }

        [TestMethod]
        public void Plateau_Negative_Input_Value2()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
               GetNewPlateauHelper().CreatePlateau("-1 1");
            });

            Assert.AreEqual(UtilsConstants.NEGATIVE_VALUE_ERROR, ex.Message);
        }

        [TestMethod]
        public void Plateau_Zero_Input_Value1()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
               GetNewPlateauHelper().CreatePlateau("0 1");
            });

            Assert.AreEqual(BusinessConstants.INVALID_PLATEAU_UPPER_RIGHT_COORDINATE, ex.Message);
        }

        [TestMethod]
        public void Plateau_Zero_Input_Value2()
        {
            var ex = Assert.ThrowsException<Exception>(() =>
            {
               GetNewPlateauHelper().CreatePlateau("1 0");
            });

            Assert.AreEqual(BusinessConstants.INVALID_PLATEAU_UPPER_RIGHT_COORDINATE, ex.Message);
        }
    }
}
