namespace Hepsiburada.MarsRover.ConsoleApp.Constants
{
    public static class ConsoleConstants
    {
        public const int PLATEAU_ARRAY_SIZE = 2;
        public const int ROVER_ARRAY_SIZE = 3;

        public const string ENTER_PLATEAU_COORDINATES = "Please enter the upper right coordinates of the plateau:";
        public const string ENTER_ROVER_COORDINATES = "Please enter the coordinates of the rover:";
        public const string ENTER_MOTION_SETS = "Please enter the motion sets";
        public const string PRESS_CHAR_FOR_ADD_NEW_ROVER = "For add a new rover please press " + CONTINUE_CHAR;
        public const string CONTINUE_CHAR = "Y";
        public const string RESULT_MESSAGE = "The last position of the rover is {0}";
        public const string SEPARATOR = " ";

        public const string ARRAY_SIZE_ERROR = "Input value must have {0} items.";

        public const string ROVER_INVALID_DIRECTION = "Rover coordinates must be numeric value.";
        public const string ROVER_ROUTE_HAS_BUSY_POINTS = "There is another rover(s) in this route.";
        public const string ROVER_ROUTE_BORDER_LIMIT_ERROR = "Rover can not cross the borders.";

        public const string ROTATION_ENUM_VALUE_ERROR = "Rover rotation must be one of these values => {0}";

        public const string ERROR_MESSAGE = "An error has occurred!!!";

        public const string UNKNOWN_ERROR = "Unknown error has occured";
    }
}
