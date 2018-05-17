namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;

    public static class HyperSphereHelpers
    {
        public static double DistanceToTangent(ref Vector2D center, ref Vector2D point, double radius)
        {
            double num;
            Vector2D.Distance(ref point, ref center, out num);
            return Math.Sqrt((num * num) - (radius * radius));
        }

        public static double DistanceToTangent(ref Vector3D center, ref Vector3D point, double radius)
        {
            double num;
            Vector3D.Distance(ref point, ref center, out num);
            return Math.Sqrt((num * num) - (radius * radius));
        }

        public static double DistanceToTangentProjected(ref Vector3D center, ref Vector3D point, double radius, out double distance)
        {
            double num;
            Vector3D.Distance(ref point, ref center, out num);
            double num2 = radius * radius;
            double num3 = num;
            double num4 = radius;
            double num5 = Math.Sqrt((num3 * num3) - num2);
            double num6 = ((num3 + num4) + num5) / 2.0;
            double d = ((num6 * (num6 - num3)) * (num6 - num4)) * (num6 - num5);
            double num8 = (2.0 * Math.Sqrt(d)) / num3;
            distance = num3 - Math.Sqrt(num2 - (num8 * num8));
            return num8;
        }
    }
}

