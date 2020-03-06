namespace Hepsiburada.MarsRover.Utils
{
    public static class ArrayHelper
    {
        public static bool IsSameSize(this string[] array, int size)
        {
            return (array.Length == size);
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
