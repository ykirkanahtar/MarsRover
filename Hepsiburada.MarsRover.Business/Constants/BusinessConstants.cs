namespace Hepsiburada.MarsRover.Business.Constants
{
    public static class BusinessConstants
    {
        public const string PLATEAU_SIZE_LIMIT = "15";
        public const string INVALID_PLATEAU_UPPER_RIGHT_COORDINATE = "Invalid upper right coordinates values";
        public const string INVALID_PLATEAU_SIZE = "The maximum plateau size can be " + PLATEAU_SIZE_LIMIT;

        public const string INVALID_DIRECTION_VALUE = "Invalid direction value";
        public const string INVALID_ROTATION_VALUE = "Invalid rotation value";
        public const string BUSY_POINT = "There is another vehicle(s) in this route";
        public const string BORDER_ERROR = "The vehicle can not cross the borders";
        public const string VEHICLE_LIST_EXCEEDED = "More vehicles can not be added";
    }
}
