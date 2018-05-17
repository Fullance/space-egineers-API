namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct Vector4D : IEquatable<Vector4>
    {
        public static Vector4D Zero;
        public static Vector4D One;
        public static Vector4D UnitX;
        public static Vector4D UnitY;
        public static Vector4D UnitZ;
        public static Vector4D UnitW;
        [ProtoMember(0x15)]
        public double X;
        [ProtoMember(0x1a)]
        public double Y;
        [ProtoMember(0x1f)]
        public double Z;
        [ProtoMember(0x24)]
        public double W;
        static Vector4D()
        {
            Zero = new Vector4D();
            One = new Vector4D(1.0, 1.0, 1.0, 1.0);
            UnitX = new Vector4D(1.0, 0.0, 0.0, 0.0);
            UnitY = new Vector4D(0.0, 1.0, 0.0, 0.0);
            UnitZ = new Vector4D(0.0, 0.0, 1.0, 0.0);
            UnitW = new Vector4D(0.0, 0.0, 0.0, 1.0);
        }

        public Vector4D(double x, double y, double z, double w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public Vector4D(Vector2 value, double z, double w)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = z;
            this.W = w;
        }

        public Vector4D(Vector3D value, double w)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = value.Z;
            this.W = w;
        }

        public Vector4D(double value)
        {
            this.X = this.Y = this.Z = this.W = value;
        }

        public static Vector4D operator -(Vector4D value)
        {
            Vector4D vectord;
            vectord.X = -value.X;
            vectord.Y = -value.Y;
            vectord.Z = -value.Z;
            vectord.W = -value.W;
            return vectord;
        }

        public static bool operator ==(Vector4D value1, Vector4D value2) => 
            ((((value1.X == value2.X) && (value1.Y == value2.Y)) && (value1.Z == value2.Z)) && (value1.W == value2.W));

        public static bool operator !=(Vector4D value1, Vector4D value2)
        {
            if (((value1.X == value2.X) && (value1.Y == value2.Y)) && (value1.Z == value2.Z))
            {
                return !(value1.W == value2.W);
            }
            return true;
        }

        public static Vector4D operator +(Vector4D value1, Vector4D value2)
        {
            Vector4D vectord;
            vectord.X = value1.X + value2.X;
            vectord.Y = value1.Y + value2.Y;
            vectord.Z = value1.Z + value2.Z;
            vectord.W = value1.W + value2.W;
            return vectord;
        }

        public static Vector4D operator -(Vector4D value1, Vector4D value2)
        {
            Vector4D vectord;
            vectord.X = value1.X - value2.X;
            vectord.Y = value1.Y - value2.Y;
            vectord.Z = value1.Z - value2.Z;
            vectord.W = value1.W - value2.W;
            return vectord;
        }

        public static Vector4D operator *(Vector4D value1, Vector4D value2)
        {
            Vector4D vectord;
            vectord.X = value1.X * value2.X;
            vectord.Y = value1.Y * value2.Y;
            vectord.Z = value1.Z * value2.Z;
            vectord.W = value1.W * value2.W;
            return vectord;
        }

        public static Vector4D operator *(Vector4D value1, double scaleFactor)
        {
            Vector4D vectord;
            vectord.X = value1.X * scaleFactor;
            vectord.Y = value1.Y * scaleFactor;
            vectord.Z = value1.Z * scaleFactor;
            vectord.W = value1.W * scaleFactor;
            return vectord;
        }

        public static Vector4D operator *(double scaleFactor, Vector4D value1)
        {
            Vector4D vectord;
            vectord.X = value1.X * scaleFactor;
            vectord.Y = value1.Y * scaleFactor;
            vectord.Z = value1.Z * scaleFactor;
            vectord.W = value1.W * scaleFactor;
            return vectord;
        }

        public static Vector4D operator /(Vector4D value1, Vector4D value2)
        {
            Vector4D vectord;
            vectord.X = value1.X / value2.X;
            vectord.Y = value1.Y / value2.Y;
            vectord.Z = value1.Z / value2.Z;
            vectord.W = value1.W / value2.W;
            return vectord;
        }

        public static Vector4D operator /(Vector4D value1, double divider)
        {
            Vector4D vectord;
            double num = 1.0 / divider;
            vectord.X = value1.X * num;
            vectord.Y = value1.Y * num;
            vectord.Z = value1.Z * num;
            vectord.W = value1.W * num;
            return vectord;
        }

        public static Vector4D operator /(double lhs, Vector4D rhs)
        {
            Vector4D vectord;
            vectord.X = lhs / rhs.X;
            vectord.Y = lhs / rhs.Y;
            vectord.Z = lhs / rhs.Z;
            vectord.W = lhs / rhs.W;
            return vectord;
        }

        public static Vector4D PackOrthoMatrix(Vector3D position, Vector3D forward, Vector3D up)
        {
            int direction = (int) Base6Directions.GetDirection((Vector3) forward);
            int num2 = (int) Base6Directions.GetDirection((Vector3) up);
            return new Vector4D(position, (double) ((direction * 6) + num2));
        }

        public static Vector4D PackOrthoMatrix(ref MatrixD matrix)
        {
            int direction = (int) Base6Directions.GetDirection((Vector3) matrix.Forward);
            int num2 = (int) Base6Directions.GetDirection((Vector3) matrix.Up);
            return new Vector4D(matrix.Translation, (double) ((direction * 6) + num2));
        }

        public static MatrixD UnpackOrthoMatrix(ref Vector4D packed)
        {
            int w = (int) packed.W;
            return MatrixD.CreateWorld(new Vector3((Vector4) packed), Base6Directions.GetVector((int) (w / 6)), Base6Directions.GetVector((int) (w % 6)));
        }

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format(currentCulture, "{{X:{0} Y:{1} Z:{2} W:{3}}}", new object[] { this.X.ToString(currentCulture), this.Y.ToString(currentCulture), this.Z.ToString(currentCulture), this.W.ToString(currentCulture) });
        }

        public bool Equals(Vector4 other) => 
            ((((this.X == other.X) && (this.Y == other.Y)) && (this.Z == other.Z)) && (this.W == other.W));

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is Vector4)
            {
                flag = this.Equals((Vector4) obj);
            }
            return flag;
        }

        public override int GetHashCode() => 
            (((this.X.GetHashCode() + this.Y.GetHashCode()) + this.Z.GetHashCode()) + this.W.GetHashCode());

        public double Length() => 
            Math.Sqrt((((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z)) + (this.W * this.W));

        public double LengthSquared() => 
            ((((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z)) + (this.W * this.W));

        public static double Distance(Vector4 value1, Vector4 value2)
        {
            double num = value1.X - value2.X;
            double num2 = value1.Y - value2.Y;
            double num3 = value1.Z - value2.Z;
            double num4 = value1.W - value2.W;
            return Math.Sqrt((((num * num) + (num2 * num2)) + (num3 * num3)) + (num4 * num4));
        }

        public static void Distance(ref Vector4 value1, ref Vector4 value2, out double result)
        {
            double num = value1.X - value2.X;
            double num2 = value1.Y - value2.Y;
            double num3 = value1.Z - value2.Z;
            double num4 = value1.W - value2.W;
            double d = (((num * num) + (num2 * num2)) + (num3 * num3)) + (num4 * num4);
            result = Math.Sqrt(d);
        }

        public static double DistanceSquared(Vector4 value1, Vector4 value2)
        {
            double num = value1.X - value2.X;
            double num2 = value1.Y - value2.Y;
            double num3 = value1.Z - value2.Z;
            double num4 = value1.W - value2.W;
            return ((((num * num) + (num2 * num2)) + (num3 * num3)) + (num4 * num4));
        }

        public static void DistanceSquared(ref Vector4 value1, ref Vector4 value2, out double result)
        {
            double num = value1.X - value2.X;
            double num2 = value1.Y - value2.Y;
            double num3 = value1.Z - value2.Z;
            double num4 = value1.W - value2.W;
            result = (((num * num) + (num2 * num2)) + (num3 * num3)) + (num4 * num4);
        }

        public static double Dot(Vector4 vector1, Vector4 vector2) => 
            ((((vector1.X * vector2.X) + (vector1.Y * vector2.Y)) + (vector1.Z * vector2.Z)) + (vector1.W * vector2.W));

        public static void Dot(ref Vector4 vector1, ref Vector4 vector2, out double result)
        {
            result = (((vector1.X * vector2.X) + (vector1.Y * vector2.Y)) + (vector1.Z * vector2.Z)) + (vector1.W * vector2.W);
        }

        public void Normalize()
        {
            double num = 1.0 / Math.Sqrt((((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z)) + (this.W * this.W));
            this.X *= num;
            this.Y *= num;
            this.Z *= num;
            this.W *= num;
        }

        public static Vector4D Normalize(Vector4D vector)
        {
            Vector4D vectord;
            double num = 1.0 / Math.Sqrt((((vector.X * vector.X) + (vector.Y * vector.Y)) + (vector.Z * vector.Z)) + (vector.W * vector.W));
            vectord.X = vector.X * num;
            vectord.Y = vector.Y * num;
            vectord.Z = vector.Z * num;
            vectord.W = vector.W * num;
            return vectord;
        }

        public static void Normalize(ref Vector4D vector, out Vector4D result)
        {
            double num = 1.0 / Math.Sqrt((((vector.X * vector.X) + (vector.Y * vector.Y)) + (vector.Z * vector.Z)) + (vector.W * vector.W));
            result.X = vector.X * num;
            result.Y = vector.Y * num;
            result.Z = vector.Z * num;
            result.W = vector.W * num;
        }

        public static Vector4 Min(Vector4 value1, Vector4 value2)
        {
            Vector4 vector;
            vector.X = (value1.X < value2.X) ? value1.X : value2.X;
            vector.Y = (value1.Y < value2.Y) ? value1.Y : value2.Y;
            vector.Z = (value1.Z < value2.Z) ? value1.Z : value2.Z;
            vector.W = (value1.W < value2.W) ? value1.W : value2.W;
            return vector;
        }

        public static void Min(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            result.X = (value1.X < value2.X) ? value1.X : value2.X;
            result.Y = (value1.Y < value2.Y) ? value1.Y : value2.Y;
            result.Z = (value1.Z < value2.Z) ? value1.Z : value2.Z;
            result.W = (value1.W < value2.W) ? value1.W : value2.W;
        }

        public static Vector4 Max(Vector4 value1, Vector4 value2)
        {
            Vector4 vector;
            vector.X = (value1.X > value2.X) ? value1.X : value2.X;
            vector.Y = (value1.Y > value2.Y) ? value1.Y : value2.Y;
            vector.Z = (value1.Z > value2.Z) ? value1.Z : value2.Z;
            vector.W = (value1.W > value2.W) ? value1.W : value2.W;
            return vector;
        }

        public static void Max(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            result.X = (value1.X > value2.X) ? value1.X : value2.X;
            result.Y = (value1.Y > value2.Y) ? value1.Y : value2.Y;
            result.Z = (value1.Z > value2.Z) ? value1.Z : value2.Z;
            result.W = (value1.W > value2.W) ? value1.W : value2.W;
        }

        public static Vector4D Clamp(Vector4D value1, Vector4D min, Vector4D max)
        {
            Vector4D vectord;
            double x = value1.X;
            double num2 = (x > max.X) ? max.X : x;
            double num3 = (num2 < min.X) ? min.X : num2;
            double y = value1.Y;
            double num5 = (y > max.Y) ? max.Y : y;
            double num6 = (num5 < min.Y) ? min.Y : num5;
            double z = value1.Z;
            double num8 = (z > max.Z) ? max.Z : z;
            double num9 = (num8 < min.Z) ? min.Z : num8;
            double w = value1.W;
            double num11 = (w > max.W) ? max.W : w;
            double num12 = (num11 < min.W) ? min.W : num11;
            vectord.X = num3;
            vectord.Y = num6;
            vectord.Z = num9;
            vectord.W = num12;
            return vectord;
        }

        public static void Clamp(ref Vector4D value1, ref Vector4D min, ref Vector4D max, out Vector4D result)
        {
            double x = value1.X;
            double num2 = (x > max.X) ? max.X : x;
            double num3 = (num2 < min.X) ? min.X : num2;
            double y = value1.Y;
            double num5 = (y > max.Y) ? max.Y : y;
            double num6 = (num5 < min.Y) ? min.Y : num5;
            double z = value1.Z;
            double num8 = (z > max.Z) ? max.Z : z;
            double num9 = (num8 < min.Z) ? min.Z : num8;
            double w = value1.W;
            double num11 = (w > max.W) ? max.W : w;
            double num12 = (num11 < min.W) ? min.W : num11;
            result.X = num3;
            result.Y = num6;
            result.Z = num9;
            result.W = num12;
        }

        public static Vector4D Lerp(Vector4D value1, Vector4D value2, double amount)
        {
            Vector4D vectord;
            vectord.X = value1.X + ((value2.X - value1.X) * amount);
            vectord.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            vectord.Z = value1.Z + ((value2.Z - value1.Z) * amount);
            vectord.W = value1.W + ((value2.W - value1.W) * amount);
            return vectord;
        }

        public static void Lerp(ref Vector4D value1, ref Vector4D value2, double amount, out Vector4D result)
        {
            result.X = value1.X + ((value2.X - value1.X) * amount);
            result.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            result.Z = value1.Z + ((value2.Z - value1.Z) * amount);
            result.W = value1.W + ((value2.W - value1.W) * amount);
        }

        public static Vector4D Barycentric(Vector4D value1, Vector4D value2, Vector4D value3, double amount1, double amount2)
        {
            Vector4D vectord;
            vectord.X = (value1.X + (amount1 * (value2.X - value1.X))) + (amount2 * (value3.X - value1.X));
            vectord.Y = (value1.Y + (amount1 * (value2.Y - value1.Y))) + (amount2 * (value3.Y - value1.Y));
            vectord.Z = (value1.Z + (amount1 * (value2.Z - value1.Z))) + (amount2 * (value3.Z - value1.Z));
            vectord.W = (value1.W + (amount1 * (value2.W - value1.W))) + (amount2 * (value3.W - value1.W));
            return vectord;
        }

        public static void Barycentric(ref Vector4D value1, ref Vector4D value2, ref Vector4D value3, double amount1, double amount2, out Vector4D result)
        {
            result.X = (value1.X + (amount1 * (value2.X - value1.X))) + (amount2 * (value3.X - value1.X));
            result.Y = (value1.Y + (amount1 * (value2.Y - value1.Y))) + (amount2 * (value3.Y - value1.Y));
            result.Z = (value1.Z + (amount1 * (value2.Z - value1.Z))) + (amount2 * (value3.Z - value1.Z));
            result.W = (value1.W + (amount1 * (value2.W - value1.W))) + (amount2 * (value3.W - value1.W));
        }

        public static Vector4D SmoothStep(Vector4D value1, Vector4D value2, double amount)
        {
            Vector4D vectord;
            amount = (amount > 1.0) ? 1.0 : ((amount < 0.0) ? 0.0 : amount);
            amount = (amount * amount) * (3.0 - (2.0 * amount));
            vectord.X = value1.X + ((value2.X - value1.X) * amount);
            vectord.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            vectord.Z = value1.Z + ((value2.Z - value1.Z) * amount);
            vectord.W = value1.W + ((value2.W - value1.W) * amount);
            return vectord;
        }

        public static void SmoothStep(ref Vector4D value1, ref Vector4D value2, double amount, out Vector4D result)
        {
            amount = (amount > 1.0) ? 1.0 : ((amount < 0.0) ? 0.0 : amount);
            amount = (amount * amount) * (3.0 - (2.0 * amount));
            result.X = value1.X + ((value2.X - value1.X) * amount);
            result.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            result.Z = value1.Z + ((value2.Z - value1.Z) * amount);
            result.W = value1.W + ((value2.W - value1.W) * amount);
        }

        public static Vector4D CatmullRom(Vector4D value1, Vector4D value2, Vector4D value3, Vector4D value4, double amount)
        {
            Vector4D vectord;
            double num = amount * amount;
            double num2 = amount * num;
            vectord.X = 0.5 * ((((2.0 * value2.X) + ((-value1.X + value3.X) * amount)) + (((((2.0 * value1.X) - (5.0 * value2.X)) + (4.0 * value3.X)) - value4.X) * num)) + ((((-value1.X + (3.0 * value2.X)) - (3.0 * value3.X)) + value4.X) * num2));
            vectord.Y = 0.5 * ((((2.0 * value2.Y) + ((-value1.Y + value3.Y) * amount)) + (((((2.0 * value1.Y) - (5.0 * value2.Y)) + (4.0 * value3.Y)) - value4.Y) * num)) + ((((-value1.Y + (3.0 * value2.Y)) - (3.0 * value3.Y)) + value4.Y) * num2));
            vectord.Z = 0.5 * ((((2.0 * value2.Z) + ((-value1.Z + value3.Z) * amount)) + (((((2.0 * value1.Z) - (5.0 * value2.Z)) + (4.0 * value3.Z)) - value4.Z) * num)) + ((((-value1.Z + (3.0 * value2.Z)) - (3.0 * value3.Z)) + value4.Z) * num2));
            vectord.W = 0.5 * ((((2.0 * value2.W) + ((-value1.W + value3.W) * amount)) + (((((2.0 * value1.W) - (5.0 * value2.W)) + (4.0 * value3.W)) - value4.W) * num)) + ((((-value1.W + (3.0 * value2.W)) - (3.0 * value3.W)) + value4.W) * num2));
            return vectord;
        }

        public static void CatmullRom(ref Vector4D value1, ref Vector4D value2, ref Vector4D value3, ref Vector4D value4, double amount, out Vector4D result)
        {
            double num = amount * amount;
            double num2 = amount * num;
            result.X = 0.5 * ((((2.0 * value2.X) + ((-value1.X + value3.X) * amount)) + (((((2.0 * value1.X) - (5.0 * value2.X)) + (4.0 * value3.X)) - value4.X) * num)) + ((((-value1.X + (3.0 * value2.X)) - (3.0 * value3.X)) + value4.X) * num2));
            result.Y = 0.5 * ((((2.0 * value2.Y) + ((-value1.Y + value3.Y) * amount)) + (((((2.0 * value1.Y) - (5.0 * value2.Y)) + (4.0 * value3.Y)) - value4.Y) * num)) + ((((-value1.Y + (3.0 * value2.Y)) - (3.0 * value3.Y)) + value4.Y) * num2));
            result.Z = 0.5 * ((((2.0 * value2.Z) + ((-value1.Z + value3.Z) * amount)) + (((((2.0 * value1.Z) - (5.0 * value2.Z)) + (4.0 * value3.Z)) - value4.Z) * num)) + ((((-value1.Z + (3.0 * value2.Z)) - (3.0 * value3.Z)) + value4.Z) * num2));
            result.W = 0.5 * ((((2.0 * value2.W) + ((-value1.W + value3.W) * amount)) + (((((2.0 * value1.W) - (5.0 * value2.W)) + (4.0 * value3.W)) - value4.W) * num)) + ((((-value1.W + (3.0 * value2.W)) - (3.0 * value3.W)) + value4.W) * num2));
        }

        public static Vector4D Hermite(Vector4D value1, Vector4D tangent1, Vector4D value2, Vector4D tangent2, double amount)
        {
            Vector4D vectord;
            double num = amount * amount;
            double num2 = amount * num;
            double num3 = ((2.0 * num2) - (3.0 * num)) + 1.0;
            double num4 = (-2.0 * num2) + (3.0 * num);
            double num5 = (num2 - (2.0 * num)) + amount;
            double num6 = num2 - num;
            vectord.X = (((value1.X * num3) + (value2.X * num4)) + (tangent1.X * num5)) + (tangent2.X * num6);
            vectord.Y = (((value1.Y * num3) + (value2.Y * num4)) + (tangent1.Y * num5)) + (tangent2.Y * num6);
            vectord.Z = (((value1.Z * num3) + (value2.Z * num4)) + (tangent1.Z * num5)) + (tangent2.Z * num6);
            vectord.W = (((value1.W * num3) + (value2.W * num4)) + (tangent1.W * num5)) + (tangent2.W * num6);
            return vectord;
        }

        public static void Hermite(ref Vector4D value1, ref Vector4D tangent1, ref Vector4D value2, ref Vector4D tangent2, double amount, out Vector4D result)
        {
            double num = amount * amount;
            double num2 = amount * num;
            double num3 = ((2.0 * num2) - (3.0 * num)) + 1.0;
            double num4 = (-2.0 * num2) + (3.0 * num);
            double num5 = (num2 - (2.0 * num)) + amount;
            double num6 = num2 - num;
            result.X = (((value1.X * num3) + (value2.X * num4)) + (tangent1.X * num5)) + (tangent2.X * num6);
            result.Y = (((value1.Y * num3) + (value2.Y * num4)) + (tangent1.Y * num5)) + (tangent2.Y * num6);
            result.Z = (((value1.Z * num3) + (value2.Z * num4)) + (tangent1.Z * num5)) + (tangent2.Z * num6);
            result.W = (((value1.W * num3) + (value2.W * num4)) + (tangent1.W * num5)) + (tangent2.W * num6);
        }

        public static Vector4D Transform(Vector2 position, MatrixD matrix)
        {
            Vector4D vectord;
            double num = ((position.X * matrix.M11) + (position.Y * matrix.M21)) + matrix.M41;
            double num2 = ((position.X * matrix.M12) + (position.Y * matrix.M22)) + matrix.M42;
            double num3 = ((position.X * matrix.M13) + (position.Y * matrix.M23)) + matrix.M43;
            double num4 = ((position.X * matrix.M14) + (position.Y * matrix.M24)) + matrix.M44;
            vectord.X = num;
            vectord.Y = num2;
            vectord.Z = num3;
            vectord.W = num4;
            return vectord;
        }

        public static void Transform(ref Vector2 position, ref MatrixD matrix, out Vector4D result)
        {
            double num = ((position.X * matrix.M11) + (position.Y * matrix.M21)) + matrix.M41;
            double num2 = ((position.X * matrix.M12) + (position.Y * matrix.M22)) + matrix.M42;
            double num3 = ((position.X * matrix.M13) + (position.Y * matrix.M23)) + matrix.M43;
            double num4 = ((position.X * matrix.M14) + (position.Y * matrix.M24)) + matrix.M44;
            result.X = num;
            result.Y = num2;
            result.Z = num3;
            result.W = num4;
        }

        public static Vector4D Transform(Vector3D position, MatrixD matrix)
        {
            Vector4D vectord;
            double num = (((position.X * matrix.M11) + (position.Y * matrix.M21)) + (position.Z * matrix.M31)) + matrix.M41;
            double num2 = (((position.X * matrix.M12) + (position.Y * matrix.M22)) + (position.Z * matrix.M32)) + matrix.M42;
            double num3 = (((position.X * matrix.M13) + (position.Y * matrix.M23)) + (position.Z * matrix.M33)) + matrix.M43;
            double num4 = (((position.X * matrix.M14) + (position.Y * matrix.M24)) + (position.Z * matrix.M34)) + matrix.M44;
            vectord.X = num;
            vectord.Y = num2;
            vectord.Z = num3;
            vectord.W = num4;
            return vectord;
        }

        public static void Transform(ref Vector3D position, ref MatrixD matrix, out Vector4D result)
        {
            double num = (((position.X * matrix.M11) + (position.Y * matrix.M21)) + (position.Z * matrix.M31)) + matrix.M41;
            double num2 = (((position.X * matrix.M12) + (position.Y * matrix.M22)) + (position.Z * matrix.M32)) + matrix.M42;
            double num3 = (((position.X * matrix.M13) + (position.Y * matrix.M23)) + (position.Z * matrix.M33)) + matrix.M43;
            double num4 = (((position.X * matrix.M14) + (position.Y * matrix.M24)) + (position.Z * matrix.M34)) + matrix.M44;
            result.X = num;
            result.Y = num2;
            result.Z = num3;
            result.W = num4;
        }

        public static Vector4D Transform(Vector4D vector, MatrixD matrix)
        {
            Vector4D vectord;
            double num = (((vector.X * matrix.M11) + (vector.Y * matrix.M21)) + (vector.Z * matrix.M31)) + (vector.W * matrix.M41);
            double num2 = (((vector.X * matrix.M12) + (vector.Y * matrix.M22)) + (vector.Z * matrix.M32)) + (vector.W * matrix.M42);
            double num3 = (((vector.X * matrix.M13) + (vector.Y * matrix.M23)) + (vector.Z * matrix.M33)) + (vector.W * matrix.M43);
            double num4 = (((vector.X * matrix.M14) + (vector.Y * matrix.M24)) + (vector.Z * matrix.M34)) + (vector.W * matrix.M44);
            vectord.X = num;
            vectord.Y = num2;
            vectord.Z = num3;
            vectord.W = num4;
            return vectord;
        }

        public static void Transform(ref Vector4D vector, ref MatrixD matrix, out Vector4D result)
        {
            double num = (((vector.X * matrix.M11) + (vector.Y * matrix.M21)) + (vector.Z * matrix.M31)) + (vector.W * matrix.M41);
            double num2 = (((vector.X * matrix.M12) + (vector.Y * matrix.M22)) + (vector.Z * matrix.M32)) + (vector.W * matrix.M42);
            double num3 = (((vector.X * matrix.M13) + (vector.Y * matrix.M23)) + (vector.Z * matrix.M33)) + (vector.W * matrix.M43);
            double num4 = (((vector.X * matrix.M14) + (vector.Y * matrix.M24)) + (vector.Z * matrix.M34)) + (vector.W * matrix.M44);
            result.X = num;
            result.Y = num2;
            result.Z = num3;
            result.W = num4;
        }

        public static Vector4D Transform(Vector2 value, Quaternion rotation)
        {
            Vector4D vectord;
            double num = rotation.X + rotation.X;
            double num2 = rotation.Y + rotation.Y;
            double num3 = rotation.Z + rotation.Z;
            double num4 = rotation.W * num;
            double num5 = rotation.W * num2;
            double num6 = rotation.W * num3;
            double num7 = rotation.X * num;
            double num8 = rotation.X * num2;
            double num9 = rotation.X * num3;
            double num10 = rotation.Y * num2;
            double num11 = rotation.Y * num3;
            double num12 = rotation.Z * num3;
            double num13 = (value.X * ((1.0 - num10) - num12)) + (value.Y * (num8 - num6));
            double num14 = (value.X * (num8 + num6)) + (value.Y * ((1.0 - num7) - num12));
            double num15 = (value.X * (num9 - num5)) + (value.Y * (num11 + num4));
            vectord.X = num13;
            vectord.Y = num14;
            vectord.Z = num15;
            vectord.W = 1.0;
            return vectord;
        }

        public static void Transform(ref Vector2 value, ref Quaternion rotation, out Vector4D result)
        {
            double num = rotation.X + rotation.X;
            double num2 = rotation.Y + rotation.Y;
            double num3 = rotation.Z + rotation.Z;
            double num4 = rotation.W * num;
            double num5 = rotation.W * num2;
            double num6 = rotation.W * num3;
            double num7 = rotation.X * num;
            double num8 = rotation.X * num2;
            double num9 = rotation.X * num3;
            double num10 = rotation.Y * num2;
            double num11 = rotation.Y * num3;
            double num12 = rotation.Z * num3;
            double num13 = (value.X * ((1.0 - num10) - num12)) + (value.Y * (num8 - num6));
            double num14 = (value.X * (num8 + num6)) + (value.Y * ((1.0 - num7) - num12));
            double num15 = (value.X * (num9 - num5)) + (value.Y * (num11 + num4));
            result.X = num13;
            result.Y = num14;
            result.Z = num15;
            result.W = 1.0;
        }

        public static Vector4D Transform(Vector3D value, Quaternion rotation)
        {
            Vector4D vectord;
            double num = rotation.X + rotation.X;
            double num2 = rotation.Y + rotation.Y;
            double num3 = rotation.Z + rotation.Z;
            double num4 = rotation.W * num;
            double num5 = rotation.W * num2;
            double num6 = rotation.W * num3;
            double num7 = rotation.X * num;
            double num8 = rotation.X * num2;
            double num9 = rotation.X * num3;
            double num10 = rotation.Y * num2;
            double num11 = rotation.Y * num3;
            double num12 = rotation.Z * num3;
            double num13 = ((value.X * ((1.0 - num10) - num12)) + (value.Y * (num8 - num6))) + (value.Z * (num9 + num5));
            double num14 = ((value.X * (num8 + num6)) + (value.Y * ((1.0 - num7) - num12))) + (value.Z * (num11 - num4));
            double num15 = ((value.X * (num9 - num5)) + (value.Y * (num11 + num4))) + (value.Z * ((1.0 - num7) - num10));
            vectord.X = num13;
            vectord.Y = num14;
            vectord.Z = num15;
            vectord.W = 1.0;
            return vectord;
        }

        public static void Transform(ref Vector3D value, ref Quaternion rotation, out Vector4D result)
        {
            double num = rotation.X + rotation.X;
            double num2 = rotation.Y + rotation.Y;
            double num3 = rotation.Z + rotation.Z;
            double num4 = rotation.W * num;
            double num5 = rotation.W * num2;
            double num6 = rotation.W * num3;
            double num7 = rotation.X * num;
            double num8 = rotation.X * num2;
            double num9 = rotation.X * num3;
            double num10 = rotation.Y * num2;
            double num11 = rotation.Y * num3;
            double num12 = rotation.Z * num3;
            double num13 = ((value.X * ((1.0 - num10) - num12)) + (value.Y * (num8 - num6))) + (value.Z * (num9 + num5));
            double num14 = ((value.X * (num8 + num6)) + (value.Y * ((1.0 - num7) - num12))) + (value.Z * (num11 - num4));
            double num15 = ((value.X * (num9 - num5)) + (value.Y * (num11 + num4))) + (value.Z * ((1.0 - num7) - num10));
            result.X = num13;
            result.Y = num14;
            result.Z = num15;
            result.W = 1.0;
        }

        public static Vector4D Transform(Vector4D value, Quaternion rotation)
        {
            Vector4D vectord;
            double num = rotation.X + rotation.X;
            double num2 = rotation.Y + rotation.Y;
            double num3 = rotation.Z + rotation.Z;
            double num4 = rotation.W * num;
            double num5 = rotation.W * num2;
            double num6 = rotation.W * num3;
            double num7 = rotation.X * num;
            double num8 = rotation.X * num2;
            double num9 = rotation.X * num3;
            double num10 = rotation.Y * num2;
            double num11 = rotation.Y * num3;
            double num12 = rotation.Z * num3;
            double num13 = ((value.X * ((1.0 - num10) - num12)) + (value.Y * (num8 - num6))) + (value.Z * (num9 + num5));
            double num14 = ((value.X * (num8 + num6)) + (value.Y * ((1.0 - num7) - num12))) + (value.Z * (num11 - num4));
            double num15 = ((value.X * (num9 - num5)) + (value.Y * (num11 + num4))) + (value.Z * ((1.0 - num7) - num10));
            vectord.X = num13;
            vectord.Y = num14;
            vectord.Z = num15;
            vectord.W = value.W;
            return vectord;
        }

        public static void Transform(ref Vector4D value, ref Quaternion rotation, out Vector4D result)
        {
            double num = rotation.X + rotation.X;
            double num2 = rotation.Y + rotation.Y;
            double num3 = rotation.Z + rotation.Z;
            double num4 = rotation.W * num;
            double num5 = rotation.W * num2;
            double num6 = rotation.W * num3;
            double num7 = rotation.X * num;
            double num8 = rotation.X * num2;
            double num9 = rotation.X * num3;
            double num10 = rotation.Y * num2;
            double num11 = rotation.Y * num3;
            double num12 = rotation.Z * num3;
            double num13 = ((value.X * ((1.0 - num10) - num12)) + (value.Y * (num8 - num6))) + (value.Z * (num9 + num5));
            double num14 = ((value.X * (num8 + num6)) + (value.Y * ((1.0 - num7) - num12))) + (value.Z * (num11 - num4));
            double num15 = ((value.X * (num9 - num5)) + (value.Y * (num11 + num4))) + (value.Z * ((1.0 - num7) - num10));
            result.X = num13;
            result.Y = num14;
            result.Z = num15;
            result.W = value.W;
        }

        public static void Transform(Vector4D[] sourceArray, ref MatrixD matrix, Vector4D[] destinationArray)
        {
            for (int i = 0; i < sourceArray.Length; i++)
            {
                double x = sourceArray[i].X;
                double y = sourceArray[i].Y;
                double z = sourceArray[i].Z;
                double w = sourceArray[i].W;
                destinationArray[i].X = (((x * matrix.M11) + (y * matrix.M21)) + (z * matrix.M31)) + (w * matrix.M41);
                destinationArray[i].Y = (((x * matrix.M12) + (y * matrix.M22)) + (z * matrix.M32)) + (w * matrix.M42);
                destinationArray[i].Z = (((x * matrix.M13) + (y * matrix.M23)) + (z * matrix.M33)) + (w * matrix.M43);
                destinationArray[i].W = (((x * matrix.M14) + (y * matrix.M24)) + (z * matrix.M34)) + (w * matrix.M44);
            }
        }

        public static void Transform(Vector4D[] sourceArray, int sourceIndex, ref MatrixD matrix, Vector4D[] destinationArray, int destinationIndex, int length)
        {
            while (length > 0)
            {
                double x = sourceArray[sourceIndex].X;
                double y = sourceArray[sourceIndex].Y;
                double z = sourceArray[sourceIndex].Z;
                double w = sourceArray[sourceIndex].W;
                destinationArray[destinationIndex].X = (((x * matrix.M11) + (y * matrix.M21)) + (z * matrix.M31)) + (w * matrix.M41);
                destinationArray[destinationIndex].Y = (((x * matrix.M12) + (y * matrix.M22)) + (z * matrix.M32)) + (w * matrix.M42);
                destinationArray[destinationIndex].Z = (((x * matrix.M13) + (y * matrix.M23)) + (z * matrix.M33)) + (w * matrix.M43);
                destinationArray[destinationIndex].W = (((x * matrix.M14) + (y * matrix.M24)) + (z * matrix.M34)) + (w * matrix.M44);
                sourceIndex++;
                destinationIndex++;
                length--;
            }
        }

        public static void Transform(Vector4D[] sourceArray, ref Quaternion rotation, Vector4D[] destinationArray)
        {
            double num = rotation.X + rotation.X;
            double num2 = rotation.Y + rotation.Y;
            double num3 = rotation.Z + rotation.Z;
            double num4 = rotation.W * num;
            double num5 = rotation.W * num2;
            double num6 = rotation.W * num3;
            double num7 = rotation.X * num;
            double num8 = rotation.X * num2;
            double num9 = rotation.X * num3;
            double num10 = rotation.Y * num2;
            double num11 = rotation.Y * num3;
            double num12 = rotation.Z * num3;
            double num13 = (1.0 - num10) - num12;
            double num14 = num8 - num6;
            double num15 = num9 + num5;
            double num16 = num8 + num6;
            double num17 = (1.0 - num7) - num12;
            double num18 = num11 - num4;
            double num19 = num9 - num5;
            double num20 = num11 + num4;
            double num21 = (1.0 - num7) - num10;
            for (int i = 0; i < sourceArray.Length; i++)
            {
                double x = sourceArray[i].X;
                double y = sourceArray[i].Y;
                double z = sourceArray[i].Z;
                destinationArray[i].X = ((x * num13) + (y * num14)) + (z * num15);
                destinationArray[i].Y = ((x * num16) + (y * num17)) + (z * num18);
                destinationArray[i].Z = ((x * num19) + (y * num20)) + (z * num21);
                destinationArray[i].W = sourceArray[i].W;
            }
        }

        public static void Transform(Vector4D[] sourceArray, int sourceIndex, ref Quaternion rotation, Vector4D[] destinationArray, int destinationIndex, int length)
        {
            double num = rotation.X + rotation.X;
            double num2 = rotation.Y + rotation.Y;
            double num3 = rotation.Z + rotation.Z;
            double num4 = rotation.W * num;
            double num5 = rotation.W * num2;
            double num6 = rotation.W * num3;
            double num7 = rotation.X * num;
            double num8 = rotation.X * num2;
            double num9 = rotation.X * num3;
            double num10 = rotation.Y * num2;
            double num11 = rotation.Y * num3;
            double num12 = rotation.Z * num3;
            double num13 = (1.0 - num10) - num12;
            double num14 = num8 - num6;
            double num15 = num9 + num5;
            double num16 = num8 + num6;
            double num17 = (1.0 - num7) - num12;
            double num18 = num11 - num4;
            double num19 = num9 - num5;
            double num20 = num11 + num4;
            double num21 = (1.0 - num7) - num10;
            while (length > 0)
            {
                double x = sourceArray[sourceIndex].X;
                double y = sourceArray[sourceIndex].Y;
                double z = sourceArray[sourceIndex].Z;
                double w = sourceArray[sourceIndex].W;
                destinationArray[destinationIndex].X = ((x * num13) + (y * num14)) + (z * num15);
                destinationArray[destinationIndex].Y = ((x * num16) + (y * num17)) + (z * num18);
                destinationArray[destinationIndex].Z = ((x * num19) + (y * num20)) + (z * num21);
                destinationArray[destinationIndex].W = w;
                sourceIndex++;
                destinationIndex++;
                length--;
            }
        }

        public static Vector4D Negate(Vector4D value)
        {
            Vector4D vectord;
            vectord.X = -value.X;
            vectord.Y = -value.Y;
            vectord.Z = -value.Z;
            vectord.W = -value.W;
            return vectord;
        }

        public static void Negate(ref Vector4D value, out Vector4D result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
            result.Z = -value.Z;
            result.W = -value.W;
        }

        public static Vector4D Add(Vector4D value1, Vector4D value2)
        {
            Vector4D vectord;
            vectord.X = value1.X + value2.X;
            vectord.Y = value1.Y + value2.Y;
            vectord.Z = value1.Z + value2.Z;
            vectord.W = value1.W + value2.W;
            return vectord;
        }

        public static void Add(ref Vector4D value1, ref Vector4D value2, out Vector4D result)
        {
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
            result.Z = value1.Z + value2.Z;
            result.W = value1.W + value2.W;
        }

        public static Vector4 Subtract(Vector4 value1, Vector4 value2)
        {
            Vector4 vector;
            vector.X = value1.X - value2.X;
            vector.Y = value1.Y - value2.Y;
            vector.Z = value1.Z - value2.Z;
            vector.W = value1.W - value2.W;
            return vector;
        }

        public static void Subtract(ref Vector4D value1, ref Vector4D value2, out Vector4D result)
        {
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
            result.Z = value1.Z - value2.Z;
            result.W = value1.W - value2.W;
        }

        public static Vector4D Multiply(Vector4D value1, Vector4D value2)
        {
            Vector4D vectord;
            vectord.X = value1.X * value2.X;
            vectord.Y = value1.Y * value2.Y;
            vectord.Z = value1.Z * value2.Z;
            vectord.W = value1.W * value2.W;
            return vectord;
        }

        public static void Multiply(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
            result.Z = value1.Z * value2.Z;
            result.W = value1.W * value2.W;
        }

        public static Vector4D Multiply(Vector4D value1, double scaleFactor)
        {
            Vector4D vectord;
            vectord.X = value1.X * scaleFactor;
            vectord.Y = value1.Y * scaleFactor;
            vectord.Z = value1.Z * scaleFactor;
            vectord.W = value1.W * scaleFactor;
            return vectord;
        }

        public static void Multiply(ref Vector4D value1, double scaleFactor, out Vector4D result)
        {
            result.X = value1.X * scaleFactor;
            result.Y = value1.Y * scaleFactor;
            result.Z = value1.Z * scaleFactor;
            result.W = value1.W * scaleFactor;
        }

        public static Vector4D Divide(Vector4D value1, Vector4D value2)
        {
            Vector4D vectord;
            vectord.X = value1.X / value2.X;
            vectord.Y = value1.Y / value2.Y;
            vectord.Z = value1.Z / value2.Z;
            vectord.W = value1.W / value2.W;
            return vectord;
        }

        public static void Divide(ref Vector4D value1, ref Vector4D value2, out Vector4D result)
        {
            result.X = value1.X / value2.X;
            result.Y = value1.Y / value2.Y;
            result.Z = value1.Z / value2.Z;
            result.W = value1.W / value2.W;
        }

        public static Vector4D Divide(Vector4D value1, double divider)
        {
            Vector4D vectord;
            double num = 1.0 / divider;
            vectord.X = value1.X * num;
            vectord.Y = value1.Y * num;
            vectord.Z = value1.Z * num;
            vectord.W = value1.W * num;
            return vectord;
        }

        public static void Divide(ref Vector4D value1, double divider, out Vector4D result)
        {
            double num = 1.0 / divider;
            result.X = value1.X * num;
            result.Y = value1.Y * num;
            result.Z = value1.Z * num;
            result.W = value1.W * num;
        }

        public static implicit operator Vector4(Vector4D v) => 
            new Vector4((float) v.X, (float) v.Y, (float) v.Z, (float) v.W);

        public static implicit operator Vector4D(Vector4 v) => 
            new Vector4D((double) v.X, (double) v.Y, (double) v.Z, (double) v.W);
    }
}

