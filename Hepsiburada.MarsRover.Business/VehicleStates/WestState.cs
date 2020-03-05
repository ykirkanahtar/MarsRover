using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.Utils.Enums;

namespace Hepsiburada.MarsRover.Business.VehicleStates
{
    public class WestState : IVehicleState
    {
        public Direction GetDirection()
        {
            return Direction.W;
        }

        public void Move(IPoint point)
        {
            point.SetPositionX(point.PositionX - 1);
        }

        public IVehicleState TurnLeft()
        {
            return new SudState();
        }

        public IVehicleState TurnRight()
        {
            return new NorthState();
        }
    }

}
