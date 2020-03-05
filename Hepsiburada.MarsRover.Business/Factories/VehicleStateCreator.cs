using Hepsiburada.MarsRover.Business.Constants;
using Hepsiburada.MarsRover.Business.VehicleStates;
using Hepsiburada.MarsRover.Utils.Enums;
using System;

namespace Hepsiburada.MarsRover.Business.Factories
{
    public static class VehicleStateCreator
    {
        public static IVehicleState SetInitial(this Direction direction)
        {
            switch (direction)
            {
                case Direction.N:
                    return new NorthState();
                case Direction.S:
                    return new SudState();
                case Direction.W:
                    return new WestState();
                case Direction.E:
                    return new EastState();
                default:
                    throw new Exception(BusinessConstants.INVALID_DIRECTION_VALUE);
            }

        }
    }

}
