namespace Hepsiburada.MarsRover.Utils
{
    public static class Functions
    {
        public static void CheckNegative(this int value)
        {
            if (value < 0)
                throw new HandledException(Constants.NEGATIVE_VALUE_ERROR);
        }
    }
}
