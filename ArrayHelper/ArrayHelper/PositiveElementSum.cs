using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayHelper
{
    public class PositiveElementSum
    {
        public static int DoubleArrayPositSum(int[,] array)
        {
            // null value and propper length of array validation
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException($"Error: {nameof(array)} is null");
            }
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > 0)
                    {
                        sum += array[i, j];
                    }
                }
            }
            return sum;
        }
    }
}
