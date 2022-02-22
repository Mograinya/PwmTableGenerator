using System;

namespace pwmTableGenerator
{
    public static class ValueTableCalculator
    {
        public static int[] GetLogarithmicTable(int max, int count)
        {
            const double countSub = 2;

            if (count <= countSub) /* Исключим деление на ноль и некорректное количество. */
            {
                return new int[1] { max };
            }

            int[] result = new int[count];
            double temp;

            result[0] = 0;

            for (int i = 1; i < count; i++)
            {
                temp = Math.Pow(10, 3 * (i - 1) / ((double)count - countSub) - 1) / 100;
                temp = Math.Round(temp * max);
                result[i] = (int)temp;
            }

            return result;
        }

        public static int[] GetLinearTable(int max, int count)
        {
            const int countSub = 1;

            if (count <= countSub) /* Исключим деление на ноль и некорректное количество. */
            {
                return new int[1] { max };
            }

            int[] result = new int[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = i * max / (count - countSub); ;
            }

            return result;
        }
    }
}
