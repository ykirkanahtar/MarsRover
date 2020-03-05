namespace Hepsiburada.MarsRover.Business.Models
{
    public interface IPoint
    {
        int PositionX { get;  }
        int PositionY { get;  }

        void SetPositionX(int value);
        void SetPositionY(int value);
    }
}