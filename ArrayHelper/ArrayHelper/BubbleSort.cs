using System;


namespace ArrayHelper
{     
    public class BubbleSort
    {
       public enum Direction
        {
            Asc,
            Desc
        }

        public static void BubbleSortBy(int[] array, Direction direction = Direction.Asc)
        {
            // null value and propper length of array validation
            if (array == null || array.Length == 0) return;

            for (int i = 0; i < array.Length; ++i)
            {
                int max = 0;

                for (int j = 0; j < array.Length - i; ++j)
                {
                    if (direction == Direction.Asc)
                    {
                        if (array[max] < array[j])
                            max = j;
                    }
                    else
                    {
                        if (array[max] > array[j])
                            max = j;
                    }
                }
                int temp = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = array[max];
                array[max] = temp;
            }
        }  
    }
}
