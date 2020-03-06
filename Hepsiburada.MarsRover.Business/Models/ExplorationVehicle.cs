using Hepsiburada.MarsRover.Business.Constants;
using Hepsiburada.MarsRover.Business.Factories;
using Hepsiburada.MarsRover.Business.VehicleStates;
using Hepsiburada.MarsRover.Utils;
using Hepsiburada.MarsRover.Utils.Enums;

namespace Hepsiburada.MarsRover.Business.Models
{
    public abstract class ExplorationVehicle
    {
        protected readonly Plateau Plateau;
        protected ExplorationVehicle(IPoint point, Direction direction, Plateau plateau)
        {
            Plateau = plateau;
            CheckPlateauBorder(point);

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

        private void CheckPlateauBorder(IPoint point)
        {
            if (point.PositionX > Plateau.UpperRightCoordinates.PositionX
                ||
                point.PositionY > Plateau.UpperRightCoordinates.PositionY)
                throw new HandledException(BusinessConstants.BORDER_ERROR);
        }

    }
}
