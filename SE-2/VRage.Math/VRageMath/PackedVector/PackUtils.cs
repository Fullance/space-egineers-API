namespace VRageMath.PackedVector
{
    using System;

    internal static class PackUtils
    {
        private static double ClampAndRound(float value, float min, float max)
        {
            if (float.IsNaN(value))
            {
                return 0.0;
            }
            if (float.IsInfinity(value))
            {
                if (!float.IsNegativeInfinity(value))
                {
                    return (double) max;
                }
                return (double) min;
            }
            if (value < min)
            {
                return (double) min;
            }
            if (value > max)
            {
                return (double) max;
            }
            return Math.Round((double) value);
        }

        public static uint PackSigned(uint bitmask, float value)
        {
            float max = bitmask >> 1;
            float min = (float) (-((double) max) - 1.0);
            return (((uint) ((int) ClampAndRound(value, min, max))) & bitmask);
        }

        public static uint PackSNorm(uint bitmask, float value)
        {
            float max = bitmask >> 1;
            value *= max;
            return (((uint) ((int) ClampAndRound(value, -max, max))) & bitmask);
        }

        public static uint PackUNorm(float bitmask, float value)
        {
            value *= bitmask;
            return (uint) ClampAndRound(value, 0f, bitmask);
        }

        public static uint PackUnsigned(float bitmask, float value) => 
            ((uint) ClampAndRound(value, 0f, bitmask));

        public static float UnpackSNorm(uint bitmask, uint value)
        {
            uint num = (uint) ((bitmask + 1) >> 1);
            if ((value & num) != 0)
            {
                if ((value & bitmask) == num)
                {
                    return -1f;
                }
                value |= ~bitmask;
            }
            else
            {
                value &= bitmask;
            }
            float num2 = bitmask >> 1;
            return (((float) value) / num2);
        }

        public static float UnpackUNorm(uint bitmask, uint value)
        {
            value &= bitmask;
            return (((float) value) / ((float) bitmask));
        }
    }
}

