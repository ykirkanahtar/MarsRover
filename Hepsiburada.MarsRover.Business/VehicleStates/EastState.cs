using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.Utils.Enums;

namespace Hepsiburada.MarsRover.Business.VehicleStates
{
    public class EastState : IVehicleState
    {
        public Direction GetDirection()
        {
            return Direction.E;
        }

        public void Move(IPoint point)
        {
            point.SetPositionX(point.PositionX + 1);
        }

        public IVehicleState TurnLeft()
        {
            return new NorthState();
        }

        public IVehicleState TurnRight()
        {
            return new SudState();
        }
    }

}
