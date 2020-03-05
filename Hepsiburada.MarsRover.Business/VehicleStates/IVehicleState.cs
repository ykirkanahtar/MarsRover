using Hepsiburada.MarsRover.Business.Models;
using Hepsiburada.MarsRover.Utils.Enums;

namespace Hepsiburada.MarsRover.Business.VehicleStates
{
    public interface IVehicleState
    {
        IVehicleState TurnLeft();
        IVehicleState TurnRight();
        void Move(IPoint point);
        Direction GetDirection();
    }

}
