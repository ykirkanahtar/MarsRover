namespace Hepsiburada.MarsRover.Utils
{
    public static class ArrayHelper
    {
        public static void CheckArraySize(this string[] array, int size, string exception = null)
        {
            if (array.Length != size)
                throw new HandledException(exception ?? Constants.ARRAY_SIZE_ERROR);
        }

        public static int[] ConvertToIntArray(this string[] array)
        {
            var intArray = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                var intValue = array[i].ConvertToInt();               
                intArray[i] = intValue;
            }

            return intArray;
        }
    }
}
