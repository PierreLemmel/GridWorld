using System;

namespace Troikatorz.GridWorld
{
    internal static class Check
    {
        public static void NotNull(object param, string paramName = null)
        {
            if (param is null)
                throw new ArgumentNullException(paramName);
        }

        public static void IsPositive(int value)
        {
            if (value < 0)
                throw new ArgumentException("The value must be greater than or equal to 0");
        }

        public static void IsStrictlyPositive(int value)
        {
            if (value <= 0)
                throw new ArgumentException("The value must be greater than 0");
        }

        public static void IsInInterval(int value, int min, int max)
        {
            if (value < min || value > max)
                throw new ArgumentOutOfRangeException($"The value must be in the interval [{min}, {max}]");
        }
    }
}
