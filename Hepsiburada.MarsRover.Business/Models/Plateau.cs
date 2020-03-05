using Hepsiburada.MarsRover.Business.Constants;
using Hepsiburada.MarsRover.Utils;
using System;

namespace Hepsiburada.MarsRover.Business.Models
{
    public class Plateau
    {
        public static volatile Plateau plateau;
        private static object lockObject = new object();

        internal Plateau(IPoint upperRightCoordinates)
        {
            UpperRightCoordinates = upperRightCoordinates;
        }

        public IPoint UpperRightCoordinates { get; set; }

        public static Plateau GetInstance(IPoint upperRightCoordinates)
        {
            if (upperRightCoordinates.PositionX < 1
                ||
                upperRightCoordinates.PositionY < 1)
            {
                throw new HandledException(BusinessConstants.INVALID_PLATEAU_UPPER_RIGHT_COORDINATE);
            }

            if (upperRightCoordinates.PositionX > Convert.ToInt32(BusinessConstants.PLATEAU_SIZE_LIMIT)
                ||
                upperRightCoordinates.PositionY > Convert.ToInt32(BusinessConstants.PLATEAU_SIZE_LIMIT))
            {
                throw new HandledException(BusinessConstants.INVALID_PLATEAU_SIZE);
            }

            lock (lockObject)
            {
                if (plateau == null)
                {
                    plateau = new Plateau(upperRightCoordinates);
                }
                return plateau;
            }
        }

    }
}
