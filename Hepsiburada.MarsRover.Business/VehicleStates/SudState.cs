using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.Utils.Enums;

namespace Hepsiburada.MarsRover.Business.VehicleStates
{
    public class SudState : IVehicleState
    {
        public Direction GetDirection()
        {
            return Direction.S;
        }

        public void Move(IPoint point)
        {
            point.SetPositionY(point.PositionY - 1);
        }

        public IVehicleState TurnLeft()
        {
            return new EastState();
        }

        public IVehicleState TurnRight()
        {
            return new WestState();
        }
    }

}
