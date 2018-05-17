namespace VRageMath
{
    using System;

    public static class MathHelperD
    {
        public const double E = 2.7182818284590451;
        public const double FourPi = 12.566370614359172;
        public const double Pi = 3.1415926535897931;
        public const double PiOver2 = 1.5707963267948966;
        public const double PiOver4 = 0.78539816339744828;
        public const double TwoPi = 6.2831853071795862;

        public static double Clamp(double value, double min, double max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }

        public static double Distance(double value1, double value2) => 
            Math.Abs((double) (value1 - value2));

        public static double Max(double value1, double value2) => 
            Math.Max(value1, value2);

        public static double Min(double value1, double value2) => 
            Math.Min(value1, value2);

        public static float MonotonicAcos(float cos)
        {
            if (cos > 1f)
            {
                return (float) Math.Acos((double) (2f - cos));
            }
            return (float) -Math.Acos((double) cos);
        }

        public static double ToDegrees(double radians) => 
            ((radians * 180.0) / 3.1415926535897931);

        public static double ToRadians(double degrees) => 
            ((degrees / 180.0) * 3.1415926535897931);
    }
}

