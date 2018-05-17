namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;
    using VRage;

    public static class MathHelper
    {
        public const float E = 2.718282f;
        public const float EPSILON = 1E-05f;
        public const float EPSILON10 = 1E-06f;
        public const float FourPi = 12.56637f;
        private static readonly int[] lof2floor_lut = new int[] { 
            0, 9, 1, 10, 13, 0x15, 2, 0x1d, 11, 14, 0x10, 0x12, 0x16, 0x19, 3, 30,
            8, 12, 20, 0x1c, 15, 0x11, 0x18, 7, 0x13, 0x1b, 0x17, 6, 0x1a, 5, 4, 0x1f
        };
        public const float Log10E = 0.4342945f;
        public const float Log2E = 1.442695f;
        public const float Pi = 3.141593f;
        public const float PiOver2 = 1.570796f;
        public const float PiOver4 = 0.7853982f;
        public const float RadiansPerSecondToRPM = 9.549296f;
        public const float RPMToRadiansPerMillisec = 0.0001047198f;
        public const float RPMToRadiansPerSecond = 0.1047198f;
        public const float Sqrt2 = 1.414214f;
        public const float Sqrt3 = 1.732051f;
        public const float TwoPi = 6.283185f;

        public static double Atan(double x) => 
            ((0.785375 * x) - ((x * (Math.Abs(x) - 1.0)) * (0.2447 + (0.0663 * Math.Abs(x)))));

        public static float Atan(float x) => 
            ((0.785375f * x) - ((x * (Math.Abs(x) - 1f)) * (0.2447f + (0.0663f * Math.Abs(x)))));

        public static float Barycentric(float value1, float value2, float value3, float amount1, float amount2) => 
            ((value1 + (amount1 * (value2 - value1))) + (amount2 * (value3 - value1)));

        public static Vector3D CalculateBezierPoint(double t, Vector3D p0, Vector3D p1, Vector3D p2, Vector3D p3)
        {
            double num = 1.0 - t;
            double num2 = t * t;
            double num3 = num * num;
            double num4 = num3 * num;
            double num5 = num2 * t;
            Vector3D vectord = (Vector3D) (num4 * p0);
            vectord += (Vector3D) (((3.0 * num3) * t) * p1);
            vectord += (Vector3D) (((3.0 * num) * num2) * p2);
            return (vectord + ((Vector3D) (num5 * p3)));
        }

        public static Vector3 CalculateVectorOnSphere(Vector3 northPoleDir, float phi, float theta)
        {
            double num = Math.Sin((double) theta);
            return Vector3.TransformNormal(new Vector3(Math.Cos((double) phi) * num, Math.Sin((double) phi) * num, Math.Cos((double) theta)), Matrix.CreateFromDir(northPoleDir));
        }

        public static float CatmullRom(float value1, float value2, float value3, float value4, float amount)
        {
            float num = amount * amount;
            float num2 = amount * num;
            return (float) (0.5 * ((((2.0 * value2) + ((-((double) value1) + value3) * amount)) + (((((2.0 * value1) - (5.0 * value2)) + (4.0 * value3)) - value4) * num)) + ((((-((double) value1) + (3.0 * value2)) - (3.0 * value3)) + value4) * num2)));
        }

        public static double Clamp(double value, double min, double max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }

        public static int Clamp(int value, int min, int max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }

        public static float Clamp(float value, float min, float max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }

        public static MyFixedPoint Clamp(MyFixedPoint value, MyFixedPoint min, MyFixedPoint max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }

        public static unsafe int ComputeHashFromBytes(byte[] bytes)
        {
            int num4;
            int length = bytes.Length;
            length -= length % 4;
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            int num2 = 0;
            try
            {
                int* numPtr = (int*) handle.AddrOfPinnedObject().ToPointer();
                int num3 = 0;
                while (num3 < length)
                {
                    num2 ^= numPtr[0];
                    num3 += 4;
                    numPtr++;
                }
                num4 = num2;
            }
            finally
            {
                handle.Free();
            }
            return num4;
        }

        public static double CubicInterp(double p0, double p1, double p2, double p3, double t)
        {
            double num = (p3 - p2) - (p0 - p1);
            double num2 = (p0 - p1) - num;
            double num3 = t * t;
            return (((((num * num3) * t) + (num2 * num3)) + ((p2 - p0) * t)) + p1);
        }

        public static float Distance(float value1, float value2) => 
            Math.Abs((float) (value1 - value2));

        public static int Floor(double n)
        {
            if (n >= 0.0)
            {
                return (int) n;
            }
            return (((int) n) - 1);
        }

        public static int Floor(float n)
        {
            if (n >= 0f)
            {
                return (int) n;
            }
            return (((int) n) - 1);
        }

        public static int GetNearestBiggerPowerOfTwo(double f)
        {
            int num = 1;
            while (num < f)
            {
                num = num << 1;
            }
            return num;
        }

        public static int GetNearestBiggerPowerOfTwo(int v)
        {
            v--;
            v |= v >> 1;
            v |= v >> 2;
            v |= v >> 4;
            v |= v >> 8;
            v |= v >> 0x10;
            v++;
            return v;
        }

        public static int GetNearestBiggerPowerOfTwo(float f)
        {
            int num = 1;
            while (num < f)
            {
                num = num << 1;
            }
            return num;
        }

        public static uint GetNearestBiggerPowerOfTwo(uint v)
        {
            v--;
            v |= v >> 1;
            v |= v >> 2;
            v |= v >> 4;
            v |= v >> 8;
            v |= v >> 0x10;
            v++;
            return v;
        }

        public static int GetNumberOfMipmaps(int v)
        {
            int num = 0;
            while (v > 0)
            {
                v = v >> 1;
                num++;
            }
            return num;
        }

        public static float Hermite(float value1, float tangent1, float value2, float tangent2, float amount)
        {
            float num = amount;
            float num2 = num * num;
            float num3 = num * num2;
            float num4 = (float) (((2.0 * num3) - (3.0 * num2)) + 1.0);
            float num5 = (float) ((-2.0 * num3) + (3.0 * num2));
            float num6 = (num3 - (2f * num2)) + num;
            float num7 = num3 - num2;
            return ((((value1 * num4) + (value2 * num5)) + (tangent1 * num6)) + (tangent2 * num7));
        }

        public static float InterpLog(float value, float amount1, float amount2) => 
            ((float) (Math.Pow((double) amount1, 1.0 - value) * Math.Pow((double) amount2, (double) value)));

        public static float InterpLogInv(float value, float amount1, float amount2) => 
            ((float) Math.Log((double) (value / amount1), (double) (amount2 / amount1)));

        public static bool IsEqual(float value1, float value2) => 
            IsZero((float) (value1 - value2), 1E-05f);

        public static bool IsEqual(Matrix value1, Matrix value2) => 
            (((IsZero(value1.Left - value2.Left, 1E-05f) && IsZero(value1.Up - value2.Up, 1E-05f)) && IsZero(value1.Forward - value2.Forward, 1E-05f)) && IsZero(value1.Translation - value2.Translation, 1E-05f));

        public static bool IsEqual(Quaternion value1, Quaternion value2) => 
            (((IsZero((float) (value1.X - value2.X), 1E-05f) && IsZero((float) (value1.Y - value2.Y), 1E-05f)) && IsZero((float) (value1.Z - value2.Z), 1E-05f)) && IsZero((float) (value1.W - value2.W), 1E-05f));

        public static bool IsEqual(QuaternionD value1, QuaternionD value2) => 
            (((IsZero((double) (value1.X - value2.X), 1E-05f) && IsZero((double) (value1.Y - value2.Y), 1E-05f)) && IsZero((double) (value1.Z - value2.Z), 1E-05f)) && IsZero((double) (value1.W - value2.W), 1E-05f));

        public static bool IsEqual(Vector2 value1, Vector2 value2) => 
            (IsZero((float) (value1.X - value2.X), 1E-05f) && IsZero((float) (value1.Y - value2.Y), 1E-05f));

        public static bool IsEqual(Vector3 value1, Vector3 value2) => 
            ((IsZero((float) (value1.X - value2.X), 1E-05f) && IsZero((float) (value1.Y - value2.Y), 1E-05f)) && IsZero((float) (value1.Z - value2.Z), 1E-05f));

        public static bool IsPowerOfTwo(int x) => 
            ((x > 0) && ((x & (x - 1)) == 0));

        public static bool IsValid(double f) => 
            (!double.IsNaN(f) && !double.IsInfinity(f));

        public static bool IsValid(Vector3? vec) => 
            (!vec.HasValue || ((IsValid(vec.Value.X) && IsValid(vec.Value.Y)) && IsValid(vec.Value.Z)));

        public static bool IsValid(float f) => 
            (!float.IsNaN(f) && !float.IsInfinity(f));

        public static bool IsValid(Matrix matrix) => 
            (((matrix.Up.IsValid() && matrix.Left.IsValid()) && (matrix.Forward.IsValid() && matrix.Translation.IsValid())) && (matrix != Matrix.Zero));

        public static bool IsValid(MatrixD matrix) => 
            (((matrix.Up.IsValid() && matrix.Left.IsValid()) && (matrix.Forward.IsValid() && matrix.Translation.IsValid())) && (matrix != MatrixD.Zero));

        public static bool IsValid(Quaternion q) => 
            (((IsValid(q.X) && IsValid(q.Y)) && (IsValid(q.Z) && IsValid(q.W))) && !IsZero(q, 1E-05f));

        public static bool IsValid(Vector2 vec) => 
            (IsValid(vec.X) && IsValid(vec.Y));

        public static bool IsValid(Vector3 vec) => 
            ((IsValid(vec.X) && IsValid(vec.Y)) && IsValid(vec.Z));

        public static bool IsValid(Vector3D vec) => 
            ((IsValid(vec.X) && IsValid(vec.Y)) && IsValid(vec.Z));

        public static bool IsValidNormal(Vector3 vec)
        {
            float num = vec.LengthSquared();
            return ((vec.IsValid() && (num > 0.999f)) && (num < 1.001f));
        }

        public static bool IsValidOrZero(Matrix matrix) => 
            (((IsValid(matrix.Up) && IsValid(matrix.Left)) && IsValid(matrix.Forward)) && IsValid(matrix.Translation));

        public static bool IsZero(Vector4 value) => 
            (((IsZero(value.X, 1E-05f) && IsZero(value.Y, 1E-05f)) && IsZero(value.Z, 1E-05f)) && IsZero(value.W, 1E-05f));

        public static bool IsZero(double value, float epsilon = 1E-05f) => 
            ((value > -epsilon) && (value < epsilon));

        public static bool IsZero(float value, float epsilon = 1E-05f) => 
            ((value > -epsilon) && (value < epsilon));

        public static bool IsZero(Quaternion value, float epsilon = 1E-05f) => 
            (((IsZero(value.X, epsilon) && IsZero(value.Y, epsilon)) && IsZero(value.Z, epsilon)) && IsZero(value.W, epsilon));

        public static bool IsZero(Vector3 value, float epsilon = 1E-05f) => 
            ((IsZero(value.X, epsilon) && IsZero(value.Y, epsilon)) && IsZero(value.Z, epsilon));

        public static bool IsZero(Vector3D value, float epsilon = 1E-05f) => 
            ((IsZero(value.X, epsilon) && IsZero(value.Y, epsilon)) && IsZero(value.Z, epsilon));

        public static double Lerp(double value1, double value2, double amount) => 
            (value1 + ((value2 - value1) * amount));

        public static float Lerp(float value1, float value2, float amount) => 
            (value1 + ((value2 - value1) * amount));

        public static void LimitRadians(ref float angle)
        {
            if (angle > 6.283185f)
            {
                angle = angle % 6.283185f;
            }
            else if (angle < 0f)
            {
                angle = (angle % 6.283185f) + 6.283185f;
            }
        }

        public static void LimitRadians2PI(ref double angle)
        {
            if (angle > 6.2831854820251465)
            {
                angle = angle % 6.2831854820251465;
            }
            else if (angle < 0.0)
            {
                angle = (angle % 6.2831854820251465) + 6.2831854820251465;
            }
        }

        public static void LimitRadiansPI(ref double angle)
        {
            if (angle > 3.1415929794311523)
            {
                angle = (angle % 3.1415929794311523) - 3.1415929794311523;
            }
            else if (angle < -3.1415929794311523)
            {
                angle = (angle % 3.1415929794311523) + 3.1415929794311523;
            }
        }

        public static void LimitRadiansPI(ref float angle)
        {
            if (angle > 3.141593f)
            {
                angle = (angle % 3.141593f) - 3.141593f;
            }
            else if (angle < 3.141593f)
            {
                angle = (angle % 3.141593f) + 3.141593f;
            }
        }

        public static int Log2(int n)
        {
            int num = 0;
            while ((n = n >> 1) > 0)
            {
                num++;
            }
            return num;
        }

        public static int Log2(uint n)
        {
            int num = 0;
            while ((n = n >> 1) > 0)
            {
                num++;
            }
            return num;
        }

        public static int Log2Ceiling(int value)
        {
            value |= value >> 1;
            value |= value >> 2;
            value |= value >> 4;
            value |= value >> 8;
            value |= value >> 0x10;
            value = lof2floor_lut[(value * 0x7c4acdd) >> 0x1b];
            if ((value & (value - 1)) == 0)
            {
                return value;
            }
            return (value + 1);
        }

        public static int Log2Floor(int value)
        {
            value |= value >> 1;
            value |= value >> 2;
            value |= value >> 4;
            value |= value >> 8;
            value |= value >> 0x10;
            return lof2floor_lut[(value * 0x7c4acdd) >> 0x1b];
        }

        public static double Max(double value1, double value2) => 
            Math.Max(value1, value2);

        public static float Max(float value1, float value2) => 
            Math.Max(value1, value2);

        public static double Max(double a, double b, double c)
        {
            double num = (a > b) ? a : b;
            if (num <= c)
            {
                return c;
            }
            return num;
        }

        public static int Max(int a, int b, int c)
        {
            int num = (a > b) ? a : b;
            if (num <= c)
            {
                return c;
            }
            return num;
        }

        public static float Max(float a, float b, float c)
        {
            float num = (a > b) ? a : b;
            if (num <= c)
            {
                return c;
            }
            return num;
        }

        public static double Min(double value1, double value2) => 
            Math.Min(value1, value2);

        public static float Min(float value1, float value2) => 
            Math.Min(value1, value2);

        public static double Min(double a, double b, double c)
        {
            double num = (a < b) ? a : b;
            if (num >= c)
            {
                return c;
            }
            return num;
        }

        public static float Min(float a, float b, float c)
        {
            float num = (a < b) ? a : b;
            if (num >= c)
            {
                return c;
            }
            return num;
        }

        public static float MonotonicAcos(float cos)
        {
            if (cos > 1f)
            {
                return (float) Math.Acos((double) (2f - cos));
            }
            return (float) -Math.Acos((double) cos);
        }

        public static float MonotonicCosine(float radians)
        {
            if (radians > 0f)
            {
                return (2f - ((float) Math.Cos((double) radians)));
            }
            return (float) Math.Cos((double) radians);
        }

        public static int Pow2(int n) => 
            (((int) 1) << n);

        public static float RoundOn2(float x) => 
            (((float) ((int) (x * 100f))) / 100f);

        public static double Saturate(double n)
        {
            if (n < 0.0)
            {
                return 0.0;
            }
            if (n <= 1.0)
            {
                return n;
            }
            return 1.0;
        }

        public static float Saturate(float n)
        {
            if (n < 0f)
            {
                return 0f;
            }
            if (n <= 1f)
            {
                return n;
            }
            return 1f;
        }

        public static double SCurve3(double t) => 
            ((t * t) * (3.0 - (2.0 * t)));

        public static float SCurve3(float t) => 
            ((t * t) * (3f - (2f * t)));

        public static double SCurve5(double t) => 
            (((t * t) * t) * ((t * ((t * 6.0) - 15.0)) + 10.0));

        public static float SCurve5(float t) => 
            (((t * t) * t) * ((t * ((t * 6f) - 15f)) + 10f));

        public static double SmoothStep(double value1, double value2, double amount) => 
            Lerp(value1, value2, SCurve3(amount));

        public static float SmoothStep(float value1, float value2, float amount) => 
            Lerp(value1, value2, SCurve3(amount));

        public static double SmoothStepStable(double amount)
        {
            double num = 1.0 - amount;
            double num2 = amount;
            double num3 = num2 * amount;
            double num4 = (num2 * num) + amount;
            return ((num3 * num) + (num4 * amount));
        }

        public static float SmoothStepStable(float amount)
        {
            float num = 1f - amount;
            float num2 = amount;
            float num3 = num2 * amount;
            float num4 = (num2 * num) + amount;
            return ((num3 * num) + (num4 * amount));
        }

        public static double ToDegrees(double radians) => 
            (radians * 57.295779513082323);

        public static float ToDegrees(float radians) => 
            (radians * 57.29578f);

        public static double ToRadians(double degrees) => 
            (degrees * 0.017453292519943295);

        public static float ToRadians(float degrees) => 
            (degrees * 0.01745329f);

        public static float WrapAngle(float angle)
        {
            angle = (float) Math.IEEERemainder((double) angle, 6.28318548202515);
            if (angle <= -3.14159274101257)
            {
                angle += 6.283185f;
                return angle;
            }
            if (angle > 3.14159274101257)
            {
                angle -= 6.283185f;
            }
            return angle;
        }
    }
}

