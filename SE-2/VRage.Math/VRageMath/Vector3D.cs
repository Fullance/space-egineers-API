namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using Unsharper;

    [Serializable, StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct Vector3D : IEquatable<Vector3D>
    {
        public static Vector3D Zero;
        public static Vector3D One;
        public static Vector3D Half;
        public static Vector3D PositiveInfinity;
        public static Vector3D NegativeInfinity;
        public static Vector3D UnitX;
        public static Vector3D UnitY;
        public static Vector3D UnitZ;
        public static Vector3D Up;
        public static Vector3D Down;
        public static Vector3D Right;
        public static Vector3D Left;
        public static Vector3D Forward;
        public static Vector3D Backward;
        public static Vector3D MaxValue;
        public static Vector3D MinValue;
        [ProtoMember(0x22)]
        public double X;
        [ProtoMember(0x27)]
        public double Y;
        [ProtoMember(0x2c)]
        public double Z;
        static Vector3D()
        {
            Zero = new Vector3D();
            One = new Vector3D(1.0, 1.0, 1.0);
            Half = new Vector3D(0.5, 0.5, 0.5);
            PositiveInfinity = new Vector3D(double.PositiveInfinity);
            NegativeInfinity = new Vector3D(double.NegativeInfinity);
            UnitX = new Vector3D(1.0, 0.0, 0.0);
            UnitY = new Vector3D(0.0, 1.0, 0.0);
            UnitZ = new Vector3D(0.0, 0.0, 1.0);
            Up = new Vector3D(0.0, 1.0, 0.0);
            Down = new Vector3D(0.0, -1.0, 0.0);
            Right = new Vector3D(1.0, 0.0, 0.0);
            Left = new Vector3D(-1.0, 0.0, 0.0);
            Forward = new Vector3D(0.0, 0.0, -1.0);
            Backward = new Vector3D(0.0, 0.0, 1.0);
            MaxValue = new Vector3D(double.MaxValue, double.MaxValue, double.MaxValue);
            MinValue = new Vector3D(double.MinValue, double.MinValue, double.MinValue);
        }

        public Vector3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector3D(double value)
        {
            this.X = this.Y = this.Z = value;
        }

        public Vector3D(Vector2 value, double z)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = z;
        }

        public Vector3D(Vector2D value, double z)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = z;
        }

        public Vector3D(Vector4 xyz)
        {
            this.X = xyz.X;
            this.Y = xyz.Y;
            this.Z = xyz.Z;
        }

        public Vector3D(Vector4D xyz)
        {
            this.X = xyz.X;
            this.Y = xyz.Y;
            this.Z = xyz.Z;
        }

        public Vector3D(Vector3 value)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = value.Z;
        }

        public Vector3D(ref Vector3I value)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = value.Z;
        }

        public Vector3D(Vector3I value)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = value.Z;
        }

        public static Vector3D operator -(Vector3D value)
        {
            Vector3D vectord;
            vectord.X = -value.X;
            vectord.Y = -value.Y;
            vectord.Z = -value.Z;
            return vectord;
        }

        public static bool operator ==(Vector3D value1, Vector3D value2) => 
            (((value1.X == value2.X) && (value1.Y == value2.Y)) && (value1.Z == value2.Z));

        public static bool operator ==(Vector3 value1, Vector3D value2) => 
            (((value1.X == value2.X) && (value1.Y == value2.Y)) && (value1.Z == value2.Z));

        public static bool operator ==(Vector3D value1, Vector3 value2) => 
            (((value1.X == value2.X) && (value1.Y == value2.Y)) && (value1.Z == value2.Z));

        public static bool operator !=(Vector3D value1, Vector3D value2)
        {
            if ((value1.X == value2.X) && (value1.Y == value2.Y))
            {
                return !(value1.Z == value2.Z);
            }
            return true;
        }

        public static bool operator !=(Vector3 value1, Vector3D value2)
        {
            if ((value1.X == value2.X) && (value1.Y == value2.Y))
            {
                return (value1.Z != value2.Z);
            }
            return true;
        }

        public static bool operator !=(Vector3D value1, Vector3 value2)
        {
            if ((value1.X == value2.X) && (value1.Y == value2.Y))
            {
                return (value1.Z != value2.Z);
            }
            return true;
        }

        public static Vector3D operator %(Vector3D value1, double value2)
        {
            Vector3D vectord;
            vectord.X = value1.X % value2;
            vectord.Y = value1.Y % value2;
            vectord.Z = value1.Z % value2;
            return vectord;
        }

        public static Vector3D operator %(Vector3D value1, Vector3D value2)
        {
            Vector3D vectord;
            vectord.X = value1.X % value2.X;
            vectord.Y = value1.Y % value2.Y;
            vectord.Z = value1.Z % value2.Z;
            return vectord;
        }

        public static Vector3D operator +(Vector3D value1, Vector3D value2)
        {
            Vector3D vectord;
            vectord.X = value1.X + value2.X;
            vectord.Y = value1.Y + value2.Y;
            vectord.Z = value1.Z + value2.Z;
            return vectord;
        }

        public static Vector3D operator +(Vector3D value1, Vector3 value2)
        {
            Vector3D vectord;
            vectord.X = value1.X + value2.X;
            vectord.Y = value1.Y + value2.Y;
            vectord.Z = value1.Z + value2.Z;
            return vectord;
        }

        public static Vector3D operator +(Vector3 value1, Vector3D value2)
        {
            Vector3D vectord;
            vectord.X = value1.X + value2.X;
            vectord.Y = value1.Y + value2.Y;
            vectord.Z = value1.Z + value2.Z;
            return vectord;
        }

        public static Vector3D operator +(Vector3D value1, Vector3I value2)
        {
            Vector3D vectord;
            vectord.X = value1.X + value2.X;
            vectord.Y = value1.Y + value2.Y;
            vectord.Z = value1.Z + value2.Z;
            return vectord;
        }

        public static Vector3D operator +(Vector3D value1, double value2)
        {
            Vector3D vectord;
            vectord.X = value1.X + value2;
            vectord.Y = value1.Y + value2;
            vectord.Z = value1.Z + value2;
            return vectord;
        }

        public static Vector3D operator +(Vector3D value1, float value2)
        {
            Vector3D vectord;
            vectord.X = value1.X + value2;
            vectord.Y = value1.Y + value2;
            vectord.Z = value1.Z + value2;
            return vectord;
        }

        public static Vector3D operator -(Vector3D value1, Vector3D value2)
        {
            Vector3D vectord;
            vectord.X = value1.X - value2.X;
            vectord.Y = value1.Y - value2.Y;
            vectord.Z = value1.Z - value2.Z;
            return vectord;
        }

        public static Vector3D operator -(Vector3D value1, Vector3 value2)
        {
            Vector3D vectord;
            vectord.X = value1.X - value2.X;
            vectord.Y = value1.Y - value2.Y;
            vectord.Z = value1.Z - value2.Z;
            return vectord;
        }

        public static Vector3D operator -(Vector3 value1, Vector3D value2)
        {
            Vector3D vectord;
            vectord.X = value1.X - value2.X;
            vectord.Y = value1.Y - value2.Y;
            vectord.Z = value1.Z - value2.Z;
            return vectord;
        }

        public static Vector3D operator -(Vector3D value1, double value2)
        {
            Vector3D vectord;
            vectord.X = value1.X - value2;
            vectord.Y = value1.Y - value2;
            vectord.Z = value1.Z - value2;
            return vectord;
        }

        public static Vector3D operator *(Vector3D value1, Vector3D value2)
        {
            Vector3D vectord;
            vectord.X = value1.X * value2.X;
            vectord.Y = value1.Y * value2.Y;
            vectord.Z = value1.Z * value2.Z;
            return vectord;
        }

        public static Vector3D operator *(Vector3D value1, Vector3 value2)
        {
            Vector3D vectord;
            vectord.X = value1.X * value2.X;
            vectord.Y = value1.Y * value2.Y;
            vectord.Z = value1.Z * value2.Z;
            return vectord;
        }

        public static Vector3D operator *(Vector3D value, double scaleFactor)
        {
            Vector3D vectord;
            vectord.X = value.X * scaleFactor;
            vectord.Y = value.Y * scaleFactor;
            vectord.Z = value.Z * scaleFactor;
            return vectord;
        }

        public static Vector3D operator *(double scaleFactor, Vector3D value)
        {
            Vector3D vectord;
            vectord.X = value.X * scaleFactor;
            vectord.Y = value.Y * scaleFactor;
            vectord.Z = value.Z * scaleFactor;
            return vectord;
        }

        public static Vector3D operator /(Vector3D value1, Vector3D value2)
        {
            Vector3D vectord;
            vectord.X = value1.X / value2.X;
            vectord.Y = value1.Y / value2.Y;
            vectord.Z = value1.Z / value2.Z;
            return vectord;
        }

        public static Vector3D operator /(Vector3D value, double divider)
        {
            Vector3D vectord;
            double num = 1.0 / divider;
            vectord.X = value.X * num;
            vectord.Y = value.Y * num;
            vectord.Z = value.Z * num;
            return vectord;
        }

        public static Vector3D operator /(double value, Vector3D divider)
        {
            Vector3D vectord;
            vectord.X = value / divider.X;
            vectord.Y = value / divider.Y;
            vectord.Z = value / divider.Z;
            return vectord;
        }

        public static Vector3D Abs(Vector3D value) => 
            new Vector3D((value.X < 0.0) ? -value.X : value.X, (value.Y < 0.0) ? -value.Y : value.Y, (value.Z < 0.0) ? -value.Z : value.Z);

        public static Vector3D Sign(Vector3D value) => 
            new Vector3D((double) Math.Sign(value.X), (double) Math.Sign(value.Y), (double) Math.Sign(value.Z));

        public static Vector3D SignNonZero(Vector3D value) => 
            new Vector3D((value.X < 0.0) ? ((double) (-1)) : ((double) 1), (value.Y < 0.0) ? ((double) (-1)) : ((double) 1), (value.Z < 0.0) ? ((double) (-1)) : ((double) 1));

        public void Interpolate3(Vector3D v0, Vector3D v1, double rt)
        {
            double num = 1.0 - rt;
            this.X = (num * v0.X) + (rt * v1.X);
            this.Y = (num * v0.Y) + (rt * v1.Y);
            this.Z = (num * v0.Z) + (rt * v1.Z);
        }

        public bool IsValid() => 
            ((this.X.IsValid() && this.Y.IsValid()) && this.Z.IsValid());

        [Conditional("DEBUG")]
        public void AssertIsValid()
        {
        }

        public static bool IsUnit(ref Vector3D value)
        {
            double num = value.LengthSquared();
            return ((num >= 0.99989998340606689) && (num < 1.0001));
        }

        public static bool ArePerpendicular(ref Vector3D a, ref Vector3D b)
        {
            double num = a.Dot((Vector3D) b);
            return ((num * num) < ((1E-08 * a.LengthSquared()) * b.LengthSquared()));
        }

        public static bool IsZero(Vector3D value) => 
            IsZero(value, 0.0001);

        public static bool IsZero(Vector3D value, double epsilon) => 
            (((Math.Abs(value.X) < epsilon) && (Math.Abs(value.Y) < epsilon)) && (Math.Abs(value.Z) < epsilon));

        public static Vector3D IsZeroVector(Vector3D value) => 
            new Vector3D((value.X == 0.0) ? ((double) 1) : ((double) 0), (value.Y == 0.0) ? ((double) 1) : ((double) 0), (value.Z == 0.0) ? ((double) 1) : ((double) 0));

        public static Vector3D IsZeroVector(Vector3D value, double epsilon) => 
            new Vector3D((Math.Abs(value.X) < epsilon) ? ((double) 1) : ((double) 0), (Math.Abs(value.Y) < epsilon) ? ((double) 1) : ((double) 0), (Math.Abs(value.Z) < epsilon) ? ((double) 1) : ((double) 0));

        public static Vector3D Step(Vector3D value) => 
            new Vector3D((value.X > 0.0) ? ((double) 1) : ((value.X < 0.0) ? ((double) (-1)) : ((double) 0)), (value.Y > 0.0) ? ((double) 1) : ((value.Y < 0.0) ? ((double) (-1)) : ((double) 0)), (value.Z > 0.0) ? ((double) 1) : ((value.Z < 0.0) ? ((double) (-1)) : ((double) 0)));

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format(currentCulture, "{{X:{0} Y:{1} Z:{2}}}", this.X.ToString(currentCulture), this.Y.ToString(currentCulture), this.Z.ToString(currentCulture));
        }

        public static bool TryParse(string str, out Vector3D retval)
        {
            retval = Zero;
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            int num = 0;
            int startIndex = 0;
            int num3 = 0;
            bool flag = true;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '{')
                {
                    num++;
                    continue;
                }
                if (str[i] == ':')
                {
                    if (num == 1)
                    {
                        startIndex = i + 1;
                    }
                    else
                    {
                        flag = false;
                    }
                    continue;
                }
                if (str[i] == ' ')
                {
                    if (num != 1)
                    {
                        continue;
                    }
                    int length = i - startIndex;
                    string s = str.Substring(startIndex, length);
                    double result = 0.0;
                    if (!double.TryParse(s, out result))
                    {
                        flag = false;
                    }
                    switch (num3)
                    {
                        case 0:
                            retval.X = result;
                            break;

                        case 1:
                            retval.Y = result;
                            break;

                        case 2:
                            retval.Z = result;
                            break;

                        default:
                            flag = false;
                            break;
                    }
                    num3++;
                    continue;
                }
                if (str[i] == '}')
                {
                    num--;
                    if (num != 0)
                    {
                        flag = false;
                        continue;
                    }
                    int num7 = i - startIndex;
                    string str3 = str.Substring(startIndex, num7);
                    double num8 = 0.0;
                    if (!double.TryParse(str3, out num8))
                    {
                        flag = false;
                    }
                    switch (num3)
                    {
                        case 0:
                            retval.X = num8;
                            break;

                        case 1:
                            retval.Y = num8;
                            break;

                        case 2:
                            retval.Z = num8;
                            break;

                        default:
                            flag = false;
                            break;
                    }
                    num3++;
                }
            }
            return (((num == 0) && (num3 == 3)) && flag);
        }

        public string ToString(string format)
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format(currentCulture, "{{X:{0} Y:{1} Z:{2}}}", this.X.ToString(format, currentCulture), this.Y.ToString(format, currentCulture), this.Z.ToString(format, currentCulture));
        }

        public bool Equals(Vector3D other) => 
            (((this.X == other.X) && (this.Y == other.Y)) && (this.Z == other.Z));

        public bool Equals(Vector3D other, double epsilon) => 
            (((Math.Abs((double) (this.X - other.X)) < epsilon) && (Math.Abs((double) (this.Y - other.Y)) < epsilon)) && (Math.Abs((double) (this.Z - other.Z)) < epsilon));

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is Vector3D)
            {
                flag = this.Equals((Vector3D) obj);
            }
            return flag;
        }

        public override int GetHashCode()
        {
            int num = (int) (this.X * 997.0);
            num = (num * 0x18d) ^ ((int) (this.Y * 997.0));
            return ((num * 0x18d) ^ ((int) (this.Z * 997.0)));
        }

        public long GetHash()
        {
            long num = 1L;
            int num2 = 0;
            num = (long) Math.Round(Math.Abs((double) (this.X * 1000.0)));
            num2 = 2;
            num = (num * 0x18dL) ^ ((long) Math.Round(Math.Abs((double) (this.Y * 1000.0))));
            num2 += 4;
            num = (num * 0x18dL) ^ ((long) Math.Round(Math.Abs((double) (this.Z * 1000.0))));
            num2 += 0x10;
            num = (num * 0x18dL) ^ (Math.Sign(this.X) + 5);
            num2 += 0x100;
            num = (num * 0x18dL) ^ (Math.Sign(this.Y) + 7);
            num2 += 0x10000;
            num = (num * 0x18dL) ^ (Math.Sign(this.Z) + 11);
            num2++;
            return ((num * 0x18dL) ^ num2);
        }

        public double Length() => 
            Math.Sqrt(((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z));

        public double LengthSquared() => 
            (((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z));

        public static double Distance(Vector3D value1, Vector3D value2)
        {
            double num = value1.X - value2.X;
            double num2 = value1.Y - value2.Y;
            double num3 = value1.Z - value2.Z;
            return Math.Sqrt(((num * num) + (num2 * num2)) + (num3 * num3));
        }

        public static double Distance(Vector3D value1, Vector3 value2)
        {
            double num = value1.X - value2.X;
            double num2 = value1.Y - value2.Y;
            double num3 = value1.Z - value2.Z;
            return Math.Sqrt(((num * num) + (num2 * num2)) + (num3 * num3));
        }

        public static double Distance(Vector3 value1, Vector3D value2)
        {
            double num = value1.X - value2.X;
            double num2 = value1.Y - value2.Y;
            double num3 = value1.Z - value2.Z;
            return Math.Sqrt(((num * num) + (num2 * num2)) + (num3 * num3));
        }

        public static void Distance(ref Vector3D value1, ref Vector3D value2, out double result)
        {
            double num = value1.X - value2.X;
            double num2 = value1.Y - value2.Y;
            double num3 = value1.Z - value2.Z;
            double d = ((num * num) + (num2 * num2)) + (num3 * num3);
            result = Math.Sqrt(d);
        }

        public static double DistanceSquared(Vector3D value1, Vector3D value2)
        {
            double num = value1.X - value2.X;
            double num2 = value1.Y - value2.Y;
            double num3 = value1.Z - value2.Z;
            return (((num * num) + (num2 * num2)) + (num3 * num3));
        }

        public static void DistanceSquared(ref Vector3D value1, ref Vector3D value2, out double result)
        {
            double num = value1.X - value2.X;
            double num2 = value1.Y - value2.Y;
            double num3 = value1.Z - value2.Z;
            result = ((num * num) + (num2 * num2)) + (num3 * num3);
        }

        public static double RectangularDistance(Vector3D value1, Vector3D value2)
        {
            Vector3D vectord = Abs(value1 - value2);
            return ((vectord.X + vectord.Y) + vectord.Z);
        }

        public static double RectangularDistance(ref Vector3D value1, ref Vector3D value2)
        {
            Vector3D vectord = Abs(value1 - value2);
            return ((vectord.X + vectord.Y) + vectord.Z);
        }

        public static double Dot(Vector3D vector1, Vector3D vector2) => 
            (((vector1.X * vector2.X) + (vector1.Y * vector2.Y)) + (vector1.Z * vector2.Z));

        public static double Dot(Vector3D vector1, Vector3 vector2) => 
            (((vector1.X * vector2.X) + (vector1.Y * vector2.Y)) + (vector1.Z * vector2.Z));

        public static void Dot(ref Vector3D vector1, ref Vector3D vector2, out double result)
        {
            result = ((vector1.X * vector2.X) + (vector1.Y * vector2.Y)) + (vector1.Z * vector2.Z);
        }

        public static void Dot(ref Vector3D vector1, ref Vector3 vector2, out double result)
        {
            result = ((vector1.X * vector2.X) + (vector1.Y * vector2.Y)) + (vector1.Z * vector2.Z);
        }

        public static void Dot(ref Vector3 vector1, ref Vector3D vector2, out double result)
        {
            result = ((vector1.X * vector2.X) + (vector1.Y * vector2.Y)) + (vector1.Z * vector2.Z);
        }

        public double Dot(Vector3D v) => 
            Dot(this, v);

        public double Dot(Vector3 v) => 
            (((this.X * v.X) + (this.Y * v.Y)) + (this.Z * v.Z));

        public double Dot(ref Vector3D v) => 
            (((this.X * v.X) + (this.Y * v.Y)) + (this.Z * v.Z));

        public Vector3D Cross(Vector3D v) => 
            Cross(this, v);

        public double Normalize()
        {
            double num = Math.Sqrt(((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z));
            double num2 = 1.0 / num;
            this.X *= num2;
            this.Y *= num2;
            this.Z *= num2;
            return num;
        }

        public static Vector3D Normalize(Vector3D value)
        {
            Vector3D vectord;
            double num = 1.0 / Math.Sqrt(((value.X * value.X) + (value.Y * value.Y)) + (value.Z * value.Z));
            vectord.X = value.X * num;
            vectord.Y = value.Y * num;
            vectord.Z = value.Z * num;
            return vectord;
        }

        public static void Normalize(ref Vector3D value, out Vector3D result)
        {
            double num = 1.0 / Math.Sqrt(((value.X * value.X) + (value.Y * value.Y)) + (value.Z * value.Z));
            result.X = value.X * num;
            result.Y = value.Y * num;
            result.Z = value.Z * num;
        }

        public static Vector3D Cross(Vector3D vector1, Vector3D vector2)
        {
            Vector3D vectord;
            vectord.X = (vector1.Y * vector2.Z) - (vector1.Z * vector2.Y);
            vectord.Y = (vector1.Z * vector2.X) - (vector1.X * vector2.Z);
            vectord.Z = (vector1.X * vector2.Y) - (vector1.Y * vector2.X);
            return vectord;
        }

        public static void Cross(ref Vector3D vector1, ref Vector3D vector2, out Vector3D result)
        {
            double num = (vector1.Y * vector2.Z) - (vector1.Z * vector2.Y);
            double num2 = (vector1.Z * vector2.X) - (vector1.X * vector2.Z);
            double num3 = (vector1.X * vector2.Y) - (vector1.Y * vector2.X);
            result.X = num;
            result.Y = num2;
            result.Z = num3;
        }

        public static Vector3D Reflect(Vector3D vector, Vector3D normal)
        {
            Vector3D vectord;
            double num = ((vector.X * normal.X) + (vector.Y * normal.Y)) + (vector.Z * normal.Z);
            vectord.X = vector.X - ((2.0 * num) * normal.X);
            vectord.Y = vector.Y - ((2.0 * num) * normal.Y);
            vectord.Z = vector.Z - ((2.0 * num) * normal.Z);
            return vectord;
        }

        public static void Reflect(ref Vector3D vector, ref Vector3D normal, out Vector3D result)
        {
            double num = ((vector.X * normal.X) + (vector.Y * normal.Y)) + (vector.Z * normal.Z);
            result.X = vector.X - ((2.0 * num) * normal.X);
            result.Y = vector.Y - ((2.0 * num) * normal.Y);
            result.Z = vector.Z - ((2.0 * num) * normal.Z);
        }

        public static Vector3D Reject(Vector3D vector, Vector3D direction)
        {
            Vector3D vectord;
            Reject(ref vector, ref direction, out vectord);
            return vectord;
        }

        public static void Reject(ref Vector3D vector, ref Vector3D direction, out Vector3D result)
        {
            double num;
            double num2;
            Vector3D vectord;
            Dot(ref direction, ref direction, out num);
            num = 1.0 / num;
            Dot(ref direction, ref vector, out num2);
            num2 *= num;
            vectord.X = direction.X * num;
            vectord.Y = direction.Y * num;
            vectord.Z = direction.Z * num;
            result.X = vector.X - (num2 * vectord.X);
            result.Y = vector.Y - (num2 * vectord.Y);
            result.Z = vector.Z - (num2 * vectord.Z);
        }

        public double Min()
        {
            if (this.X < this.Y)
            {
                if (this.X < this.Z)
                {
                    return this.X;
                }
                return this.Z;
            }
            if (this.Y < this.Z)
            {
                return this.Y;
            }
            return this.Z;
        }

        public double AbsMin()
        {
            if (Math.Abs(this.X) < Math.Abs(this.Y))
            {
                if (Math.Abs(this.X) < Math.Abs(this.Z))
                {
                    return Math.Abs(this.X);
                }
                return Math.Abs(this.Z);
            }
            if (Math.Abs(this.Y) < Math.Abs(this.Z))
            {
                return Math.Abs(this.Y);
            }
            return Math.Abs(this.Z);
        }

        public double Max()
        {
            if (this.X > this.Y)
            {
                if (this.X > this.Z)
                {
                    return this.X;
                }
                return this.Z;
            }
            if (this.Y > this.Z)
            {
                return this.Y;
            }
            return this.Z;
        }

        public double AbsMax()
        {
            if (Math.Abs(this.X) > Math.Abs(this.Y))
            {
                if (Math.Abs(this.X) > Math.Abs(this.Z))
                {
                    return Math.Abs(this.X);
                }
                return Math.Abs(this.Z);
            }
            if (Math.Abs(this.Y) > Math.Abs(this.Z))
            {
                return Math.Abs(this.Y);
            }
            return Math.Abs(this.Z);
        }

        public int AbsMaxComponent()
        {
            if (Math.Abs(this.X) > Math.Abs(this.Y))
            {
                if (Math.Abs(this.X) > Math.Abs(this.Z))
                {
                    return 0;
                }
                return 2;
            }
            if (Math.Abs(this.Y) > Math.Abs(this.Z))
            {
                return 1;
            }
            return 2;
        }

        public static Vector3D Min(Vector3D value1, Vector3D value2)
        {
            Vector3D vectord;
            vectord.X = (value1.X < value2.X) ? value1.X : value2.X;
            vectord.Y = (value1.Y < value2.Y) ? value1.Y : value2.Y;
            vectord.Z = (value1.Z < value2.Z) ? value1.Z : value2.Z;
            return vectord;
        }

        public static void Min(ref Vector3D value1, ref Vector3D value2, out Vector3D result)
        {
            result.X = (value1.X < value2.X) ? value1.X : value2.X;
            result.Y = (value1.Y < value2.Y) ? value1.Y : value2.Y;
            result.Z = (value1.Z < value2.Z) ? value1.Z : value2.Z;
        }

        public static Vector3D Max(Vector3D value1, Vector3D value2)
        {
            Vector3D vectord;
            vectord.X = (value1.X > value2.X) ? value1.X : value2.X;
            vectord.Y = (value1.Y > value2.Y) ? value1.Y : value2.Y;
            vectord.Z = (value1.Z > value2.Z) ? value1.Z : value2.Z;
            return vectord;
        }

        public static void Max(ref Vector3D value1, ref Vector3D value2, out Vector3D result)
        {
            result.X = (value1.X > value2.X) ? value1.X : value2.X;
            result.Y = (value1.Y > value2.Y) ? value1.Y : value2.Y;
            result.Z = (value1.Z > value2.Z) ? value1.Z : value2.Z;
        }

        public static void MinMax(ref Vector3D min, ref Vector3D max)
        {
            double x;
            if (min.X > max.X)
            {
                x = min.X;
                min.X = max.X;
                max.X = x;
            }
            if (min.Y > max.Y)
            {
                x = min.Y;
                min.Y = max.Y;
                max.Y = x;
            }
            if (min.Z > max.Z)
            {
                x = min.Z;
                min.Z = max.Z;
                max.Z = x;
            }
        }

        public static Vector3D DominantAxisProjection(Vector3D value1)
        {
            if (Math.Abs(value1.X) > Math.Abs(value1.Y))
            {
                value1.Y = 0.0;
                if (Math.Abs(value1.X) > Math.Abs(value1.Z))
                {
                    value1.Z = 0.0;
                    return value1;
                }
                value1.X = 0.0;
                return value1;
            }
            value1.X = 0.0;
            if (Math.Abs(value1.Y) > Math.Abs(value1.Z))
            {
                value1.Z = 0.0;
                return value1;
            }
            value1.Y = 0.0;
            return value1;
        }

        public static void DominantAxisProjection(ref Vector3D value1, out Vector3D result)
        {
            if (Math.Abs(value1.X) > Math.Abs(value1.Y))
            {
                if (Math.Abs(value1.X) > Math.Abs(value1.Z))
                {
                    result = new Vector3D(value1.X, 0.0, 0.0);
                }
                else
                {
                    result = new Vector3D(0.0, 0.0, value1.Z);
                }
            }
            else if (Math.Abs(value1.Y) > Math.Abs(value1.Z))
            {
                result = new Vector3D(0.0, value1.Y, 0.0);
            }
            else
            {
                result = new Vector3D(0.0, 0.0, value1.Z);
            }
        }

        public static Vector3D Clamp(Vector3D value1, Vector3D min, Vector3D max)
        {
            Vector3D vectord;
            double x = value1.X;
            double num2 = (x > max.X) ? max.X : x;
            double num3 = (num2 < min.X) ? min.X : num2;
            double y = value1.Y;
            double num5 = (y > max.Y) ? max.Y : y;
            double num6 = (num5 < min.Y) ? min.Y : num5;
            double z = value1.Z;
            double num8 = (z > max.Z) ? max.Z : z;
            double num9 = (num8 < min.Z) ? min.Z : num8;
            vectord.X = num3;
            vectord.Y = num6;
            vectord.Z = num9;
            return vectord;
        }

        public static void Clamp(ref Vector3D value1, ref Vector3D min, ref Vector3D max, out Vector3D result)
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
            result.X = num3;
            result.Y = num6;
            result.Z = num9;
        }

        [UnsharperDisableReflection]
        public static Vector3D ClampToSphere(Vector3D vector, double radius)
        {
            double num = vector.LengthSquared();
            double num2 = radius * radius;
            if (num > num2)
            {
                return (Vector3D) (vector * Math.Sqrt(num2 / num));
            }
            return vector;
        }

        [UnsharperDisableReflection]
        public static void ClampToSphere(ref Vector3D vector, double radius)
        {
            double num = vector.LengthSquared();
            double num2 = radius * radius;
            if (num > num2)
            {
                vector = (Vector3D) (vector * Math.Sqrt(num2 / num));
            }
        }

        public static Vector3D Lerp(Vector3D value1, Vector3D value2, double amount)
        {
            Vector3D vectord;
            vectord.X = value1.X + ((value2.X - value1.X) * amount);
            vectord.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            vectord.Z = value1.Z + ((value2.Z - value1.Z) * amount);
            return vectord;
        }

        public static void Lerp(ref Vector3D value1, ref Vector3D value2, double amount, out Vector3D result)
        {
            result.X = value1.X + ((value2.X - value1.X) * amount);
            result.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            result.Z = value1.Z + ((value2.Z - value1.Z) * amount);
        }

        public static Vector3D Barycentric(Vector3D value1, Vector3D value2, Vector3D value3, double amount1, double amount2)
        {
            Vector3D vectord;
            vectord.X = (value1.X + (amount1 * (value2.X - value1.X))) + (amount2 * (value3.X - value1.X));
            vectord.Y = (value1.Y + (amount1 * (value2.Y - value1.Y))) + (amount2 * (value3.Y - value1.Y));
            vectord.Z = (value1.Z + (amount1 * (value2.Z - value1.Z))) + (amount2 * (value3.Z - value1.Z));
            return vectord;
        }

        public static void Barycentric(ref Vector3D value1, ref Vector3D value2, ref Vector3D value3, double amount1, double amount2, out Vector3D result)
        {
            result.X = (value1.X + (amount1 * (value2.X - value1.X))) + (amount2 * (value3.X - value1.X));
            result.Y = (value1.Y + (amount1 * (value2.Y - value1.Y))) + (amount2 * (value3.Y - value1.Y));
            result.Z = (value1.Z + (amount1 * (value2.Z - value1.Z))) + (amount2 * (value3.Z - value1.Z));
        }

        public static void Barycentric(Vector3D p, Vector3D a, Vector3D b, Vector3D c, out double u, out double v, out double w)
        {
            Vector3D vectord = b - a;
            Vector3D vectord2 = c - a;
            Vector3D vectord3 = p - a;
            double num = Dot(vectord, vectord);
            double num2 = Dot(vectord, vectord2);
            double num3 = Dot(vectord2, vectord2);
            double num4 = Dot(vectord3, vectord);
            double num5 = Dot(vectord3, vectord2);
            double num6 = (num * num3) - (num2 * num2);
            v = ((num3 * num4) - (num2 * num5)) / num6;
            w = ((num * num5) - (num2 * num4)) / num6;
            u = (1.0 - v) - w;
        }

        public static Vector3D SmoothStep(Vector3D value1, Vector3D value2, double amount)
        {
            Vector3D vectord;
            amount = (amount > 1.0) ? 1.0 : ((amount < 0.0) ? 0.0 : amount);
            amount = (amount * amount) * (3.0 - (2.0 * amount));
            vectord.X = value1.X + ((value2.X - value1.X) * amount);
            vectord.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            vectord.Z = value1.Z + ((value2.Z - value1.Z) * amount);
            return vectord;
        }

        public static void SmoothStep(ref Vector3D value1, ref Vector3D value2, double amount, out Vector3D result)
        {
            amount = (amount > 1.0) ? 1.0 : ((amount < 0.0) ? 0.0 : amount);
            amount = (amount * amount) * (3.0 - (2.0 * amount));
            result.X = value1.X + ((value2.X - value1.X) * amount);
            result.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            result.Z = value1.Z + ((value2.Z - value1.Z) * amount);
        }

        public static Vector3D CatmullRom(Vector3D value1, Vector3D value2, Vector3D value3, Vector3D value4, double amount)
        {
            Vector3D vectord;
            double num = amount * amount;
            double num2 = amount * num;
            vectord.X = 0.5 * ((((2.0 * value2.X) + ((-value1.X + value3.X) * amount)) + (((((2.0 * value1.X) - (5.0 * value2.X)) + (4.0 * value3.X)) - value4.X) * num)) + ((((-value1.X + (3.0 * value2.X)) - (3.0 * value3.X)) + value4.X) * num2));
            vectord.Y = 0.5 * ((((2.0 * value2.Y) + ((-value1.Y + value3.Y) * amount)) + (((((2.0 * value1.Y) - (5.0 * value2.Y)) + (4.0 * value3.Y)) - value4.Y) * num)) + ((((-value1.Y + (3.0 * value2.Y)) - (3.0 * value3.Y)) + value4.Y) * num2));
            vectord.Z = 0.5 * ((((2.0 * value2.Z) + ((-value1.Z + value3.Z) * amount)) + (((((2.0 * value1.Z) - (5.0 * value2.Z)) + (4.0 * value3.Z)) - value4.Z) * num)) + ((((-value1.Z + (3.0 * value2.Z)) - (3.0 * value3.Z)) + value4.Z) * num2));
            return vectord;
        }

        public static void CatmullRom(ref Vector3D value1, ref Vector3D value2, ref Vector3D value3, ref Vector3D value4, double amount, out Vector3D result)
        {
            double num = amount * amount;
            double num2 = amount * num;
            result.X = 0.5 * ((((2.0 * value2.X) + ((-value1.X + value3.X) * amount)) + (((((2.0 * value1.X) - (5.0 * value2.X)) + (4.0 * value3.X)) - value4.X) * num)) + ((((-value1.X + (3.0 * value2.X)) - (3.0 * value3.X)) + value4.X) * num2));
            result.Y = 0.5 * ((((2.0 * value2.Y) + ((-value1.Y + value3.Y) * amount)) + (((((2.0 * value1.Y) - (5.0 * value2.Y)) + (4.0 * value3.Y)) - value4.Y) * num)) + ((((-value1.Y + (3.0 * value2.Y)) - (3.0 * value3.Y)) + value4.Y) * num2));
            result.Z = 0.5 * ((((2.0 * value2.Z) + ((-value1.Z + value3.Z) * amount)) + (((((2.0 * value1.Z) - (5.0 * value2.Z)) + (4.0 * value3.Z)) - value4.Z) * num)) + ((((-value1.Z + (3.0 * value2.Z)) - (3.0 * value3.Z)) + value4.Z) * num2));
        }

        public static Vector3D Hermite(Vector3D value1, Vector3D tangent1, Vector3D value2, Vector3D tangent2, double amount)
        {
            Vector3D vectord;
            double num = amount * amount;
            double num2 = amount * num;
            double num3 = ((2.0 * num2) - (3.0 * num)) + 1.0;
            double num4 = (-2.0 * num2) + (3.0 * num);
            double num5 = (num2 - (2.0 * num)) + amount;
            double num6 = num2 - num;
            vectord.X = (((value1.X * num3) + (value2.X * num4)) + (tangent1.X * num5)) + (tangent2.X * num6);
            vectord.Y = (((value1.Y * num3) + (value2.Y * num4)) + (tangent1.Y * num5)) + (tangent2.Y * num6);
            vectord.Z = (((value1.Z * num3) + (value2.Z * num4)) + (tangent1.Z * num5)) + (tangent2.Z * num6);
            return vectord;
        }

        public static void Hermite(ref Vector3D value1, ref Vector3D tangent1, ref Vector3D value2, ref Vector3D tangent2, double amount, out Vector3D result)
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
        }

        public static Vector3D Transform(Vector3D position, MatrixD matrix)
        {
            Vector3D vectord;
            double num = (((position.X * matrix.M11) + (position.Y * matrix.M21)) + (position.Z * matrix.M31)) + matrix.M41;
            double num2 = (((position.X * matrix.M12) + (position.Y * matrix.M22)) + (position.Z * matrix.M32)) + matrix.M42;
            double num3 = (((position.X * matrix.M13) + (position.Y * matrix.M23)) + (position.Z * matrix.M33)) + matrix.M43;
            double num4 = 1.0 / ((((position.X * matrix.M14) + (position.Y * matrix.M24)) + (position.Z * matrix.M34)) + matrix.M44);
            vectord.X = num * num4;
            vectord.Y = num2 * num4;
            vectord.Z = num3 * num4;
            return vectord;
        }

        public static Vector3D Transform(Vector3 position, MatrixD matrix)
        {
            Vector3D vectord;
            double num = (((position.X * matrix.M11) + (position.Y * matrix.M21)) + (position.Z * matrix.M31)) + matrix.M41;
            double num2 = (((position.X * matrix.M12) + (position.Y * matrix.M22)) + (position.Z * matrix.M32)) + matrix.M42;
            double num3 = (((position.X * matrix.M13) + (position.Y * matrix.M23)) + (position.Z * matrix.M33)) + matrix.M43;
            double num4 = 1.0 / ((((position.X * matrix.M14) + (position.Y * matrix.M24)) + (position.Z * matrix.M34)) + matrix.M44);
            vectord.X = num * num4;
            vectord.Y = num2 * num4;
            vectord.Z = num3 * num4;
            return vectord;
        }

        public static Vector3D Transform(Vector3D position, Matrix matrix)
        {
            Vector3D vectord;
            double num = (((position.X * matrix.M11) + (position.Y * matrix.M21)) + (position.Z * matrix.M31)) + matrix.M41;
            double num2 = (((position.X * matrix.M12) + (position.Y * matrix.M22)) + (position.Z * matrix.M32)) + matrix.M42;
            double num3 = (((position.X * matrix.M13) + (position.Y * matrix.M23)) + (position.Z * matrix.M33)) + matrix.M43;
            double num4 = 1.0 / ((((position.X * matrix.M14) + (position.Y * matrix.M24)) + (position.Z * matrix.M34)) + matrix.M44);
            vectord.X = num * num4;
            vectord.Y = num2 * num4;
            vectord.Z = num3 * num4;
            return vectord;
        }

        public static Vector3D Transform(Vector3D position, ref MatrixD matrix)
        {
            Transform(ref position, ref matrix, out position);
            return position;
        }

        public static void Transform(ref Vector3D position, ref MatrixD matrix, out Vector3D result)
        {
            double num = (((position.X * matrix.M11) + (position.Y * matrix.M21)) + (position.Z * matrix.M31)) + matrix.M41;
            double num2 = (((position.X * matrix.M12) + (position.Y * matrix.M22)) + (position.Z * matrix.M32)) + matrix.M42;
            double num3 = (((position.X * matrix.M13) + (position.Y * matrix.M23)) + (position.Z * matrix.M33)) + matrix.M43;
            double num4 = 1.0 / ((((position.X * matrix.M14) + (position.Y * matrix.M24)) + (position.Z * matrix.M34)) + matrix.M44);
            result.X = num * num4;
            result.Y = num2 * num4;
            result.Z = num3 * num4;
        }

        public static void Transform(ref Vector3 position, ref MatrixD matrix, out Vector3D result)
        {
            double num = (((position.X * matrix.M11) + (position.Y * matrix.M21)) + (position.Z * matrix.M31)) + matrix.M41;
            double num2 = (((position.X * matrix.M12) + (position.Y * matrix.M22)) + (position.Z * matrix.M32)) + matrix.M42;
            double num3 = (((position.X * matrix.M13) + (position.Y * matrix.M23)) + (position.Z * matrix.M33)) + matrix.M43;
            double num4 = 1.0 / ((((position.X * matrix.M14) + (position.Y * matrix.M24)) + (position.Z * matrix.M34)) + matrix.M44);
            result.X = num * num4;
            result.Y = num2 * num4;
            result.Z = num3 * num4;
        }

        public static void TransformNoProjection(ref Vector3D vector, ref MatrixD matrix, out Vector3D result)
        {
            double num = (((vector.X * matrix.M11) + (vector.Y * matrix.M21)) + (vector.Z * matrix.M31)) + matrix.M41;
            double num2 = (((vector.X * matrix.M12) + (vector.Y * matrix.M22)) + (vector.Z * matrix.M32)) + matrix.M42;
            double num3 = (((vector.X * matrix.M13) + (vector.Y * matrix.M23)) + (vector.Z * matrix.M33)) + matrix.M43;
            result.X = num;
            result.Y = num2;
            result.Z = num3;
        }

        public static void RotateAndScale(ref Vector3D vector, ref MatrixD matrix, out Vector3D result)
        {
            double num = ((vector.X * matrix.M11) + (vector.Y * matrix.M21)) + (vector.Z * matrix.M31);
            double num2 = ((vector.X * matrix.M12) + (vector.Y * matrix.M22)) + (vector.Z * matrix.M32);
            double num3 = ((vector.X * matrix.M13) + (vector.Y * matrix.M23)) + (vector.Z * matrix.M33);
            result.X = num;
            result.Y = num2;
            result.Z = num3;
        }

        public static void Transform(ref Vector3D position, ref MatrixI matrix, out Vector3D result)
        {
            result = ((Vector3D) (((position.X * new Vector3D(Base6Directions.GetVector(matrix.Right))) + (position.Y * new Vector3D(Base6Directions.GetVector(matrix.Up)))) + (position.Z * new Vector3D(Base6Directions.GetVector(matrix.Backward))))) + new Vector3D(matrix.Translation);
        }

        public static Vector3D TransformNormal(Vector3D normal, Matrix matrix)
        {
            Vector3D vectord;
            double num = ((normal.X * matrix.M11) + (normal.Y * matrix.M21)) + (normal.Z * matrix.M31);
            double num2 = ((normal.X * matrix.M12) + (normal.Y * matrix.M22)) + (normal.Z * matrix.M32);
            double num3 = ((normal.X * matrix.M13) + (normal.Y * matrix.M23)) + (normal.Z * matrix.M33);
            vectord.X = num;
            vectord.Y = num2;
            vectord.Z = num3;
            return vectord;
        }

        public static Vector3D TransformNormal(Vector3 normal, MatrixD matrix)
        {
            Vector3D vectord;
            double num = ((normal.X * matrix.M11) + (normal.Y * matrix.M21)) + (normal.Z * matrix.M31);
            double num2 = ((normal.X * matrix.M12) + (normal.Y * matrix.M22)) + (normal.Z * matrix.M32);
            double num3 = ((normal.X * matrix.M13) + (normal.Y * matrix.M23)) + (normal.Z * matrix.M33);
            vectord.X = num;
            vectord.Y = num2;
            vectord.Z = num3;
            return vectord;
        }

        public static Vector3D TransformNormal(Vector3D normal, MatrixD matrix)
        {
            Vector3D vectord;
            double num = ((normal.X * matrix.M11) + (normal.Y * matrix.M21)) + (normal.Z * matrix.M31);
            double num2 = ((normal.X * matrix.M12) + (normal.Y * matrix.M22)) + (normal.Z * matrix.M32);
            double num3 = ((normal.X * matrix.M13) + (normal.Y * matrix.M23)) + (normal.Z * matrix.M33);
            vectord.X = num;
            vectord.Y = num2;
            vectord.Z = num3;
            return vectord;
        }

        public static void TransformNormal(ref Vector3D normal, ref MatrixD matrix, out Vector3D result)
        {
            double num = ((normal.X * matrix.M11) + (normal.Y * matrix.M21)) + (normal.Z * matrix.M31);
            double num2 = ((normal.X * matrix.M12) + (normal.Y * matrix.M22)) + (normal.Z * matrix.M32);
            double num3 = ((normal.X * matrix.M13) + (normal.Y * matrix.M23)) + (normal.Z * matrix.M33);
            result.X = num;
            result.Y = num2;
            result.Z = num3;
        }

        public static void TransformNormal(ref Vector3 normal, ref MatrixD matrix, out Vector3D result)
        {
            double num = ((normal.X * matrix.M11) + (normal.Y * matrix.M21)) + (normal.Z * matrix.M31);
            double num2 = ((normal.X * matrix.M12) + (normal.Y * matrix.M22)) + (normal.Z * matrix.M32);
            double num3 = ((normal.X * matrix.M13) + (normal.Y * matrix.M23)) + (normal.Z * matrix.M33);
            result.X = num;
            result.Y = num2;
            result.Z = num3;
        }

        public static void TransformNormal(ref Vector3D normal, ref MatrixI matrix, out Vector3D result)
        {
            result = (Vector3D) (((normal.X * new Vector3D(Base6Directions.GetVector(matrix.Right))) + (normal.Y * new Vector3D(Base6Directions.GetVector(matrix.Up)))) + (normal.Z * new Vector3D(Base6Directions.GetVector(matrix.Backward))));
        }

        public static Vector3D TransformNormal(Vector3D normal, MyBlockOrientation orientation)
        {
            Vector3D vectord;
            TransformNormal(ref normal, orientation, out vectord);
            return vectord;
        }

        public static void TransformNormal(ref Vector3D normal, MyBlockOrientation orientation, out Vector3D result)
        {
            result = (Vector3D) (((-normal.X * new Vector3D(Base6Directions.GetVector(orientation.Left))) + (normal.Y * new Vector3D(Base6Directions.GetVector(orientation.Up)))) - (normal.Z * new Vector3D(Base6Directions.GetVector(orientation.Forward))));
        }

        public static Vector3D TransformNormal(Vector3D normal, ref MatrixD matrix)
        {
            TransformNormal(ref normal, ref matrix, out normal);
            return normal;
        }

        public static Vector3D Transform(Vector3D value, Quaternion rotation)
        {
            Vector3D vectord;
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
            return vectord;
        }

        public static void Transform(ref Vector3D value, ref Quaternion rotation, out Vector3D result)
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
        }

        public static void Rotate(ref Vector3D vector, ref MatrixD rotationMatrix, out Vector3D result)
        {
            double num = ((vector.X * rotationMatrix.M11) + (vector.Y * rotationMatrix.M21)) + (vector.Z * rotationMatrix.M31);
            double num2 = ((vector.X * rotationMatrix.M12) + (vector.Y * rotationMatrix.M22)) + (vector.Z * rotationMatrix.M32);
            double num3 = ((vector.X * rotationMatrix.M13) + (vector.Y * rotationMatrix.M23)) + (vector.Z * rotationMatrix.M33);
            result.X = num;
            result.Y = num2;
            result.Z = num3;
        }

        public static Vector3D Rotate(Vector3D vector, MatrixD rotationMatrix)
        {
            Vector3D vectord;
            Rotate(ref vector, ref rotationMatrix, out vectord);
            return vectord;
        }

        public static void Transform(Vector3D[] sourceArray, ref MatrixD matrix, Vector3D[] destinationArray)
        {
            for (int i = 0; i < sourceArray.Length; i++)
            {
                double x = sourceArray[i].X;
                double y = sourceArray[i].Y;
                double z = sourceArray[i].Z;
                destinationArray[i].X = (((x * matrix.M11) + (y * matrix.M21)) + (z * matrix.M31)) + matrix.M41;
                destinationArray[i].Y = (((x * matrix.M12) + (y * matrix.M22)) + (z * matrix.M32)) + matrix.M42;
                destinationArray[i].Z = (((x * matrix.M13) + (y * matrix.M23)) + (z * matrix.M33)) + matrix.M43;
            }
        }

        public static unsafe void Transform(Vector3D[] sourceArray, ref MatrixD matrix, Vector3D* destinationArray)
        {
            for (int i = 0; i < sourceArray.Length; i++)
            {
                double x = sourceArray[i].X;
                double y = sourceArray[i].Y;
                double z = sourceArray[i].Z;
                destinationArray[i].X = (((x * matrix.M11) + (y * matrix.M21)) + (z * matrix.M31)) + matrix.M41;
                destinationArray[i].Y = (((x * matrix.M12) + (y * matrix.M22)) + (z * matrix.M32)) + matrix.M42;
                destinationArray[i].Z = (((x * matrix.M13) + (y * matrix.M23)) + (z * matrix.M33)) + matrix.M43;
            }
        }

        public static void Transform(Vector3D[] sourceArray, int sourceIndex, ref Matrix matrix, Vector3D[] destinationArray, int destinationIndex, int length)
        {
            while (length > 0)
            {
                double x = sourceArray[sourceIndex].X;
                double y = sourceArray[sourceIndex].Y;
                double z = sourceArray[sourceIndex].Z;
                destinationArray[destinationIndex].X = (((x * matrix.M11) + (y * matrix.M21)) + (z * matrix.M31)) + matrix.M41;
                destinationArray[destinationIndex].Y = (((x * matrix.M12) + (y * matrix.M22)) + (z * matrix.M32)) + matrix.M42;
                destinationArray[destinationIndex].Z = (((x * matrix.M13) + (y * matrix.M23)) + (z * matrix.M33)) + matrix.M43;
                sourceIndex++;
                destinationIndex++;
                length--;
            }
        }

        public static void TransformNormal(Vector3D[] sourceArray, ref Matrix matrix, Vector3D[] destinationArray)
        {
            for (int i = 0; i < sourceArray.Length; i++)
            {
                double x = sourceArray[i].X;
                double y = sourceArray[i].Y;
                double z = sourceArray[i].Z;
                destinationArray[i].X = ((x * matrix.M11) + (y * matrix.M21)) + (z * matrix.M31);
                destinationArray[i].Y = ((x * matrix.M12) + (y * matrix.M22)) + (z * matrix.M32);
                destinationArray[i].Z = ((x * matrix.M13) + (y * matrix.M23)) + (z * matrix.M33);
            }
        }

        public static unsafe void TransformNormal(Vector3D[] sourceArray, ref Matrix matrix, Vector3D* destinationArray)
        {
            for (int i = 0; i < sourceArray.Length; i++)
            {
                double x = sourceArray[i].X;
                double y = sourceArray[i].Y;
                double z = sourceArray[i].Z;
                destinationArray[i].X = ((x * matrix.M11) + (y * matrix.M21)) + (z * matrix.M31);
                destinationArray[i].Y = ((x * matrix.M12) + (y * matrix.M22)) + (z * matrix.M32);
                destinationArray[i].Z = ((x * matrix.M13) + (y * matrix.M23)) + (z * matrix.M33);
            }
        }

        public static void TransformNormal(Vector3D[] sourceArray, int sourceIndex, ref Matrix matrix, Vector3D[] destinationArray, int destinationIndex, int length)
        {
            while (length > 0)
            {
                double x = sourceArray[sourceIndex].X;
                double y = sourceArray[sourceIndex].Y;
                double z = sourceArray[sourceIndex].Z;
                destinationArray[destinationIndex].X = ((x * matrix.M11) + (y * matrix.M21)) + (z * matrix.M31);
                destinationArray[destinationIndex].Y = ((x * matrix.M12) + (y * matrix.M22)) + (z * matrix.M32);
                destinationArray[destinationIndex].Z = ((x * matrix.M13) + (y * matrix.M23)) + (z * matrix.M33);
                sourceIndex++;
                destinationIndex++;
                length--;
            }
        }

        public static void Transform(Vector3D[] sourceArray, ref Quaternion rotation, Vector3D[] destinationArray)
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
            }
        }

        public static void Transform(Vector3D[] sourceArray, int sourceIndex, ref Quaternion rotation, Vector3D[] destinationArray, int destinationIndex, int length)
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
                destinationArray[destinationIndex].X = ((x * num13) + (y * num14)) + (z * num15);
                destinationArray[destinationIndex].Y = ((x * num16) + (y * num17)) + (z * num18);
                destinationArray[destinationIndex].Z = ((x * num19) + (y * num20)) + (z * num21);
                sourceIndex++;
                destinationIndex++;
                length--;
            }
        }

        public static Vector3D Negate(Vector3D value)
        {
            Vector3D vectord;
            vectord.X = -value.X;
            vectord.Y = -value.Y;
            vectord.Z = -value.Z;
            return vectord;
        }

        public static void Negate(ref Vector3D value, out Vector3D result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
            result.Z = -value.Z;
        }

        public static Vector3D Add(Vector3D value1, Vector3D value2)
        {
            Vector3D vectord;
            vectord.X = value1.X + value2.X;
            vectord.Y = value1.Y + value2.Y;
            vectord.Z = value1.Z + value2.Z;
            return vectord;
        }

        public static void Add(ref Vector3D value1, ref Vector3D value2, out Vector3D result)
        {
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
            result.Z = value1.Z + value2.Z;
        }

        public static Vector3D Subtract(Vector3D value1, Vector3D value2)
        {
            Vector3D vectord;
            vectord.X = value1.X - value2.X;
            vectord.Y = value1.Y - value2.Y;
            vectord.Z = value1.Z - value2.Z;
            return vectord;
        }

        public static void Subtract(ref Vector3D value1, ref Vector3D value2, out Vector3D result)
        {
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
            result.Z = value1.Z - value2.Z;
        }

        public static Vector3D Multiply(Vector3D value1, Vector3D value2)
        {
            Vector3D vectord;
            vectord.X = value1.X * value2.X;
            vectord.Y = value1.Y * value2.Y;
            vectord.Z = value1.Z * value2.Z;
            return vectord;
        }

        public static void Multiply(ref Vector3D value1, ref Vector3D value2, out Vector3D result)
        {
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
            result.Z = value1.Z * value2.Z;
        }

        public static Vector3D Multiply(Vector3D value1, double scaleFactor)
        {
            Vector3D vectord;
            vectord.X = value1.X * scaleFactor;
            vectord.Y = value1.Y * scaleFactor;
            vectord.Z = value1.Z * scaleFactor;
            return vectord;
        }

        public static void Multiply(ref Vector3D value1, double scaleFactor, out Vector3D result)
        {
            result.X = value1.X * scaleFactor;
            result.Y = value1.Y * scaleFactor;
            result.Z = value1.Z * scaleFactor;
        }

        public static Vector3D Divide(Vector3D value1, Vector3D value2)
        {
            Vector3D vectord;
            vectord.X = value1.X / value2.X;
            vectord.Y = value1.Y / value2.Y;
            vectord.Z = value1.Z / value2.Z;
            return vectord;
        }

        public static void Divide(ref Vector3D value1, ref Vector3D value2, out Vector3D result)
        {
            result.X = value1.X / value2.X;
            result.Y = value1.Y / value2.Y;
            result.Z = value1.Z / value2.Z;
        }

        public static Vector3D Divide(Vector3D value1, double value2)
        {
            Vector3D vectord;
            double num = 1.0 / value2;
            vectord.X = value1.X * num;
            vectord.Y = value1.Y * num;
            vectord.Z = value1.Z * num;
            return vectord;
        }

        public static void Divide(ref Vector3D value1, double value2, out Vector3D result)
        {
            double num = 1.0 / value2;
            result.X = value1.X * num;
            result.Y = value1.Y * num;
            result.Z = value1.Z * num;
        }

        [UnsharperDisableReflection]
        public static Vector3D CalculatePerpendicularVector(Vector3D v)
        {
            Vector3D vectord;
            v.CalculatePerpendicularVector(out vectord);
            return vectord;
        }

        [UnsharperDisableReflection]
        public void CalculatePerpendicularVector(out Vector3D result)
        {
            if ((Math.Abs((double) (this.Y + this.Z)) > 9.9999997473787516E-05) || (Math.Abs(this.X) > 9.9999997473787516E-05))
            {
                result = new Vector3D(-(this.Y + this.Z), this.X, this.X);
            }
            else
            {
                result = new Vector3D(this.Z, this.Z, -(this.X + this.Y));
            }
            Normalize(ref result, out result);
        }

        public static void GetAzimuthAndElevation(Vector3D v, out double azimuth, out double elevation)
        {
            double num;
            double num2;
            Dot(ref v, ref Up, out num);
            v.Y = 0.0;
            v.Normalize();
            Dot(ref v, ref Forward, out num2);
            elevation = Math.Asin(num);
            if (v.X >= 0.0)
            {
                azimuth = -Math.Acos(num2);
            }
            else
            {
                azimuth = Math.Acos(num2);
            }
        }

        public static void CreateFromAzimuthAndElevation(double azimuth, double elevation, out Vector3D direction)
        {
            MatrixD matrix = MatrixD.CreateRotationY(azimuth);
            MatrixD xd2 = MatrixD.CreateRotationX(elevation);
            direction = Forward;
            TransformNormal(ref direction, ref xd2, out direction);
            TransformNormal(ref direction, ref matrix, out direction);
        }

        public double Sum =>
            ((this.X + this.Y) + this.Z);
        public double Volume =>
            ((this.X * this.Y) * this.Z);
        public long VolumeInt(double multiplier) => 
            ((((long) (this.X * multiplier)) * ((long) (this.Y * multiplier))) * ((long) (this.Z * multiplier)));

        public bool IsInsideInclusive(ref Vector3D min, ref Vector3D max) => 
            (((((min.X <= this.X) && (this.X <= max.X)) && ((min.Y <= this.Y) && (this.Y <= max.Y))) && (min.Z <= this.Z)) && (this.Z <= max.Z));

        public static Vector3D SwapYZCoordinates(Vector3D v) => 
            new Vector3D(v.X, v.Z, -v.Y);

        public double GetDim(int i)
        {
            switch (i)
            {
                case 0:
                    return this.X;

                case 1:
                    return this.Y;

                case 2:
                    return this.Z;
            }
            return this.GetDim(((i % 3) + 3) % 3);
        }

        public void SetDim(int i, double value)
        {
            switch (i)
            {
                case 0:
                    this.X = value;
                    return;

                case 1:
                    this.Y = value;
                    return;

                case 2:
                    this.Z = value;
                    return;
            }
            this.SetDim(((i % 3) + 3) % 3, value);
        }

        public static explicit operator Vector3I(Vector3D v) => 
            new Vector3I((int) v.X, (int) v.Y, (int) v.Z);

        public static implicit operator Vector3(Vector3D v) => 
            new Vector3((float) v.X, (float) v.Y, (float) v.Z);

        public static implicit operator Vector3D(Vector3 v) => 
            new Vector3D((double) v.X, (double) v.Y, (double) v.Z);

        public static Vector3I Round(Vector3D vect3d) => 
            new Vector3I(vect3d + ((Vector3D) 0.5));

        public static Vector3I Floor(Vector3D vect3d) => 
            new Vector3I((int) Math.Floor(vect3d.X), (int) Math.Floor(vect3d.Y), (int) Math.Floor(vect3d.Z));

        public static void Fract(ref Vector3D o, out Vector3D r)
        {
            r.X = o.X - Math.Floor(o.X);
            r.Y = o.Y - Math.Floor(o.Y);
            r.Z = o.Z - Math.Floor(o.Z);
        }

        public static Vector3D Round(Vector3D v, int numDecimals) => 
            new Vector3D(Math.Round(v.X, numDecimals), Math.Round(v.Y, numDecimals), Math.Round(v.Z, numDecimals));

        public static void Abs(ref Vector3D vector3D, out Vector3D abs)
        {
            abs.X = Math.Abs(vector3D.X);
            abs.Y = Math.Abs(vector3D.Y);
            abs.Z = Math.Abs(vector3D.Z);
        }

        public static Vector3D ProjectOnPlane(ref Vector3D vec, ref Vector3D planeNormal)
        {
            double num = vec.Dot((Vector3D) planeNormal);
            double num2 = planeNormal.LengthSquared();
            return (Vector3D) (vec - ((num / num2) * planeNormal));
        }

        public static Vector3D ProjectOnVector(ref Vector3D vec, ref Vector3D guideVector)
        {
            if (!IsZero(ref vec) && !IsZero(ref guideVector))
            {
                return (Vector3D) ((guideVector * Dot(vec, guideVector)) / guideVector.LengthSquared());
            }
            return Zero;
        }

        private static bool IsZero(ref Vector3D vec) => 
            ((IsZero(vec.X) && IsZero(vec.Y)) && IsZero(vec.Z));

        private static bool IsZero(double d) => 
            ((d > -9.9999997473787516E-06) && (d < 9.9999997473787516E-06));
    }
}

