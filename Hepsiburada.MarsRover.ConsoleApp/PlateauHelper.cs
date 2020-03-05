﻿using Hepsiburada.MarsRover.Business.Factories;
using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.Utils;
using System;

namespace Hepsiburada.MarsRover.ConsoleApp
{

    public static class PlateauHelper
    {
        public static Plateau CreatePlateau(string inputValue)
        {
            try
            {
                var array = inputValue.Split(ConsoleConstants.SEPARATOR);

                array.CheckArraySize(ConsoleConstants.PLATEAU_ARRAY_SIZE, string.Format(ConsoleConstants.ARRAY_SIZE_ERROR, ConsoleConstants.PLATEAU_ARRAY_SIZE));
                var plateauCoordinates = array.ConvertToIntArray();

                return Plateau.GetInstance(new Point(plateauCoordinates[0], plateauCoordinates[1]));               
            }
            catch (Exception ex)
            {
                if (ex is HandledException)
                    throw new Exception(ex.Message);
                else
                    throw new Exception(ConsoleConstants.UNKNOWN_ERROR);
            }
        }
    }
}
