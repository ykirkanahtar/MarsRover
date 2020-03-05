using Hepsiburada.MarsRover.Business.Factories;
using Hepsiburada.MarsRover.Business.VehicleStates;
using Hepsiburada.MarsRover.Utils.Enums;

namespace Hepsiburada.MarsRover.Business.Models
{
    public abstract class ExplorationVehicle
    {
        protected ExplorationVehicle(IPoint point, Direction direction)
        {
            Point = point;
            VehicleState = direction.SetInitial();
        }

        public IPoint Point {  get;  set; }
        public IVehicleState VehicleState { get; set; }

        public void TurnLeft()
        {
            VehicleState = VehicleState.TurnLeft();
        }

        public void TurnRight()
        {
            VehicleState = VehicleState.TurnRight();
        }

        public void Move()
        {
            VehicleState.Move(Point);
        }

        public Direction GetDirection()
        {
            return VehicleState.GetDirection();
        }

        public string GetLastPosition()
        {
            return $"{Point.PositionX} {Point.PositionY} {GetDirection()}";
        }
    }
}
