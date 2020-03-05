using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.Utils.Enums;

namespace Hepsiburada.MarsRover.Business.VehicleStates
{
    public class NorthState : IVehicleState
    {
        public Direction GetDirection()
        {
            return Direction.N;
        }

        public void Move(IPoint point)
        {
            point.SetPositionY(point.PositionY + 1);
        }

        public IVehicleState TurnLeft()
        {
            return new WestState();
        }

        public IVehicleState TurnRight()
        {
            return new EastState();
        }
    }

}
