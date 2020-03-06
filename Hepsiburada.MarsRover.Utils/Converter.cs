using Hepsiburada.MarsRover.Utils.Enums;
using System;
using System.Collections.Generic;

namespace Hepsiburada.MarsRover.Utils
{
    public static class Converter
    {
        public static T ParseEnum<T>(this string value, string exception = null)
        {
            if (Int32.TryParse(value, out _)) //Prevent to enter numeric value
            {
                throw new HandledException(exception ?? UtilsConstants.INVALID_ENUM_VALUE_ERROR);
            }

            if (Enum.TryParse(typeof(T), value, out var enumValue))
            {
                return (T)enumValue;
            }

            throw new HandledException(exception ?? UtilsConstants.INVALID_ENUM_VALUE_ERROR);
        }

        public static int ConvertToInt(this string value)
        {

            if (int.TryParse(value, out var numericValue))
            {
                return numericValue;
            }
            else
                throw new HandledException(UtilsConstants.NUMERIC_VALUR_ERROR);
        }

        public static List<Rotation> ConvertToRotations(this IList<char> items, string exception = null)
        {
            var rotations = new List<Rotation>();
            foreach (var item in items)
            {
                var rotation = item.ToString().ParseEnum<Rotation>(exception);
                rotations.Add(rotation);
            }

            return rotations;
        }
    }
}
