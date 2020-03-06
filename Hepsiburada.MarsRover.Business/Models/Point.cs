using Hepsiburada.MarsRover.Utils;

namespace Hepsiburada.MarsRover.Business.Models
{
    public class Point : IPoint
    {
        public Point(int positionX, int positionY)
        {
            SetPositionX(positionX);
            SetPositionY(positionY);
        }

        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        public void SetPositionX(int value)
        {
            if (!value.IsPositive())
                throw new HandledException(UtilsConstants.NEGATIVE_VALUE_ERROR);

            PositionX = value;
        }

        public void SetPositionY(int value)
        {
            if (!value.IsPositive())
                throw new HandledException(UtilsConstants.NEGATIVE_VALUE_ERROR);

            PositionY = value;
        }
    }
}
