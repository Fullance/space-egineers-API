namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Reflection;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct Vector2D : IEquatable<Vector2D>
    {
        public static Vector2D Zero;
        public static Vector2D One;
        public static Vector2D UnitX;
        public static Vector2D UnitY;
        public static Vector2D PositiveInfinity;
        [ProtoMember(0x16)]
        public double X;
        [ProtoMember(0x1b)]
        public double Y;
        static Vector2D()
        {
            Zero = new Vector2D();
            One = new Vector2D(1.0, 1.0);
            UnitX = new Vector2D(1.0, 0.0);
            UnitY = new Vector2D(0.0, 1.0);
            PositiveInfinity = (Vector2D) (One * (double) 1.0 / (double) 0.0);
        }

        public Vector2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector2D(double value)
        {
            this.X = this.Y = value;
        }

        public double this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return this.X;
                }
                if (index != 1)
                {
                    throw new ArgumentException();
                }
                return this.Y;
            }
            set
            {
                if (index == 0)
                {
                    this.X = value;
                }
                else
                {
                    if (index != 1)
                    {
                        throw new ArgumentException();
                    }
                    this.Y = value;
                }
            }
        }
        public static explicit operator Vector2I(Vector2D vector) => 
            new Vector2I(vector);

        public static Vector2D operator -(Vector2D value)
        {
            Vector2D vectord;
            vectord.X = -value.X;
            vectord.Y = -value.Y;
            return vectord;
        }

        public static bool operator ==(Vector2D value1, Vector2D value2) => 
            ((value1.X == value2.X) && (value1.Y == value2.Y));

        public static bool operator !=(Vector2D value1, Vector2D value2)
        {
            if (value1.X == value2.X)
            {
                return !(value1.Y == value2.Y);
            }
            return true;
        }

        public static Vector2D operator +(Vector2D value1, Vector2D value2)
        {
            Vector2D vectord;
            vectord.X = value1.X + value2.X;
            vectord.Y = value1.Y + value2.Y;
            return vectord;
        }

        public static Vector2D operator +(Vector2D value1, double value2)
        {
            Vector2D vectord;
            vectord.X = value1.X + value2;
            vectord.Y = value1.Y + value2;
            return vectord;
        }

        public static Vector2D operator -(Vector2D value1, Vector2D value2)
        {
            Vector2D vectord;
            vectord.X = value1.X - value2.X;
            vectord.Y = value1.Y - value2.Y;
            return vectord;
        }

        public static Vector2D operator -(Vector2D value1, double value2)
        {
            Vector2D vectord;
            vectord.X = value1.X - value2;
            vectord.Y = value1.Y - value2;
            return vectord;
        }

        public static Vector2D operator *(Vector2D value1, Vector2D value2)
        {
            Vector2D vectord;
            vectord.X = value1.X * value2.X;
            vectord.Y = value1.Y * value2.Y;
            return vectord;
        }

        public static Vector2D operator *(Vector2D value, double scaleFactor)
        {
            Vector2D vectord;
            vectord.X = value.X * scaleFactor;
            vectord.Y = value.Y * scaleFactor;
            return vectord;
        }

        public static Vector2D operator *(double scaleFactor, Vector2D value)
        {
            Vector2D vectord;
            vectord.X = value.X * scaleFactor;
            vectord.Y = value.Y * scaleFactor;
            return vectord;
        }

        public static Vector2D operator /(Vector2D value1, Vector2D value2)
        {
            Vector2D vectord;
            vectord.X = value1.X / value2.X;
            vectord.Y = value1.Y / value2.Y;
            return vectord;
        }

        public static Vector2D operator /(Vector2D value1, double divider)
        {
            Vector2D vectord;
            double num = 1.0 / divider;
            vectord.X = value1.X * num;
            vectord.Y = value1.Y * num;
            return vectord;
        }

        public static Vector2D operator /(double value1, Vector2D value2)
        {
            Vector2D vectord;
            vectord.X = value1 / value2.X;
            vectord.Y = value1 / value2.Y;
            return vectord;
        }

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format(currentCulture, "{{X:{0} Y:{1}}}", new object[] { this.X.ToString(currentCulture), this.Y.ToString(currentCulture) });
        }

        public bool Equals(Vector2D other) => 
            ((this.X == other.X) && (this.Y == other.Y));

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is Vector2D)
            {
                flag = this.Equals((Vector2D) obj);
            }
            return flag;
        }

        public override int GetHashCode() => 
            (this.X.GetHashCode() + this.Y.GetHashCode());

        public bool IsValid() => 
            (this.X * this.Y).IsValid();

        [Conditional("DEBUG")]
        public void AssertIsValid()
        {
        }

        public double Length() => 
            Math.Sqrt((this.X * this.X) + (this.Y * this.Y));

        public double LengthSquared() => 
            ((this.X * this.X) + (this.Y * this.Y));

        public static double Distance(Vector2D value1, Vector2D value2)
        {
            double num = value1.X - value2.X;
            double num2 = value1.Y - value2.Y;
            return Math.Sqrt((num * num) + (num2 * num2));
        }

        public static void Distance(ref Vector2D value1, ref Vector2D value2, out double result)
        {
            double num = value1.X - value2.X;
            double num2 = value1.Y - value2.Y;
            double d = (num * num) + (num2 * num2);
            result = Math.Sqrt(d);
        }

        public static double DistanceSquared(Vector2D value1, Vector2D value2)
        {
            double num = value1.X - value2.X;
            double num2 = value1.Y - value2.Y;
            return ((num * num) + (num2 * num2));
        }

        public static void DistanceSquared(ref Vector2D value1, ref Vector2D value2, out double result)
        {
            double num = value1.X - value2.X;
            double num2 = value1.Y - value2.Y;
            result = (num * num) + (num2 * num2);
        }

        public static double Dot(Vector2D value1, Vector2D value2) => 
            ((value1.X * value2.X) + (value1.Y * value2.Y));

        public static void Dot(ref Vector2D value1, ref Vector2D value2, out double result)
        {
            result = (value1.X * value2.X) + (value1.Y * value2.Y);
        }

        public void Normalize()
        {
            double num = 1.0 / Math.Sqrt((this.X * this.X) + (this.Y * this.Y));
            this.X *= num;
            this.Y *= num;
        }

        public static Vector2D Normalize(Vector2D value)
        {
            Vector2D vectord;
            double num = 1.0 / Math.Sqrt((value.X * value.X) + (value.Y * value.Y));
            vectord.X = value.X * num;
            vectord.Y = value.Y * num;
            return vectord;
        }

        public static void Normalize(ref Vector2D value, out Vector2D result)
        {
            double num = 1.0 / Math.Sqrt((value.X * value.X) + (value.Y * value.Y));
            result.X = value.X * num;
            result.Y = value.Y * num;
        }

        public static Vector2D Reflect(Vector2D vector, Vector2D normal)
        {
            Vector2D vectord;
            double num = (vector.X * normal.X) + (vector.Y * normal.Y);
            vectord.X = vector.X - ((2.0 * num) * normal.X);
            vectord.Y = vector.Y - ((2.0 * num) * normal.Y);
            return vectord;
        }

        public static void Reflect(ref Vector2D vector, ref Vector2D normal, out Vector2D result)
        {
            double num = (vector.X * normal.X) + (vector.Y * normal.Y);
            result.X = vector.X - ((2.0 * num) * normal.X);
            result.Y = vector.Y - ((2.0 * num) * normal.Y);
        }

        public static Vector2D Min(Vector2D value1, Vector2D value2)
        {
            Vector2D vectord;
            vectord.X = (value1.X < value2.X) ? value1.X : value2.X;
            vectord.Y = (value1.Y < value2.Y) ? value1.Y : value2.Y;
            return vectord;
        }

        public static void Min(ref Vector2D value1, ref Vector2D value2, out Vector2D result)
        {
            result.X = (value1.X < value2.X) ? value1.X : value2.X;
            result.Y = (value1.Y < value2.Y) ? value1.Y : value2.Y;
        }

        public static Vector2D Max(Vector2D value1, Vector2D value2)
        {
            Vector2D vectord;
            vectord.X = (value1.X > value2.X) ? value1.X : value2.X;
            vectord.Y = (value1.Y > value2.Y) ? value1.Y : value2.Y;
            return vectord;
        }

        public static void Max(ref Vector2D value1, ref Vector2D value2, out Vector2D result)
        {
            result.X = (value1.X > value2.X) ? value1.X : value2.X;
            result.Y = (value1.Y > value2.Y) ? value1.Y : value2.Y;
        }

        public static Vector2D Clamp(Vector2D value1, Vector2D min, Vector2D max)
        {
            Vector2D vectord;
            double x = value1.X;
            double num2 = (x > max.X) ? max.X : x;
            double num3 = (num2 < min.X) ? min.X : num2;
            double y = value1.Y;
            double num5 = (y > max.Y) ? max.Y : y;
            double num6 = (num5 < min.Y) ? min.Y : num5;
            vectord.X = num3;
            vectord.Y = num6;
            return vectord;
        }

        public static void Clamp(ref Vector2D value1, ref Vector2D min, ref Vector2D max, out Vector2D result)
        {
            double x = value1.X;
            double num2 = (x > max.X) ? max.X : x;
            double num3 = (num2 < min.X) ? min.X : num2;
            double y = value1.Y;
            double num5 = (y > max.Y) ? max.Y : y;
            double num6 = (num5 < min.Y) ? min.Y : num5;
            result.X = num3;
            result.Y = num6;
        }

        public static Vector2D ClampToSphere(Vector2D vector, double radius)
        {
            double num = vector.LengthSquared();
            double num2 = radius * radius;
            if (num > num2)
            {
                return (Vector2D) (vector * Math.Sqrt(num2 / num));
            }
            return vector;
        }

        public static void ClampToSphere(ref Vector2D vector, double radius)
        {
            double num = vector.LengthSquared();
            double num2 = radius * radius;
            if (num > num2)
            {
                vector = (Vector2D) (vector * Math.Sqrt(num2 / num));
            }
        }

        public static Vector2D Lerp(Vector2D value1, Vector2D value2, double amount)
        {
            Vector2D vectord;
            vectord.X = value1.X + ((value2.X - value1.X) * amount);
            vectord.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            return vectord;
        }

        public static void Lerp(ref Vector2D value1, ref Vector2D value2, double amount, out Vector2D result)
        {
            result.X = value1.X + ((value2.X - value1.X) * amount);
            result.Y = value1.Y + ((value2.Y - value1.Y) * amount);
        }

        public static Vector2D Barycentric(Vector2D value1, Vector2D value2, Vector2D value3, double amount1, double amount2)
        {
            Vector2D vectord;
            vectord.X = (value1.X + (amount1 * (value2.X - value1.X))) + (amount2 * (value3.X - value1.X));
            vectord.Y = (value1.Y + (amount1 * (value2.Y - value1.Y))) + (amount2 * (value3.Y - value1.Y));
            return vectord;
        }

        public static void Barycentric(ref Vector2D value1, ref Vector2D value2, ref Vector2D value3, double amount1, double amount2, out Vector2D result)
        {
            result.X = (value1.X + (amount1 * (value2.X - value1.X))) + (amount2 * (value3.X - value1.X));
            result.Y = (value1.Y + (amount1 * (value2.Y - value1.Y))) + (amount2 * (value3.Y - value1.Y));
        }

        public static Vector2D SmoothStep(Vector2D value1, Vector2D value2, double amount)
        {
            Vector2D vectord;
            amount = (amount > 1.0) ? 1.0 : ((amount < 0.0) ? 0.0 : amount);
            amount = (amount * amount) * (3.0 - (2.0 * amount));
            vectord.X = value1.X + ((value2.X - value1.X) * amount);
            vectord.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            return vectord;
        }

        public static void SmoothStep(ref Vector2D value1, ref Vector2D value2, double amount, out Vector2D result)
        {
            amount = (amount > 1.0) ? 1.0 : ((amount < 0.0) ? 0.0 : amount);
            amount = (amount * amount) * (3.0 - (2.0 * amount));
            result.X = value1.X + ((value2.X - value1.X) * amount);
            result.Y = value1.Y + ((value2.Y - value1.Y) * amount);
        }

        public static Vector2D CatmullRom(Vector2D value1, Vector2D value2, Vector2D value3, Vector2D value4, double amount)
        {
            Vector2D vectord;
            double num = amount * amount;
            double num2 = amount * num;
            vectord.X = 0.5 * ((((2.0 * value2.X) + ((-value1.X + value3.X) * amount)) + (((((2.0 * value1.X) - (5.0 * value2.X)) + (4.0 * value3.X)) - value4.X) * num)) + ((((-value1.X + (3.0 * value2.X)) - (3.0 * value3.X)) + value4.X) * num2));
            vectord.Y = 0.5 * ((((2.0 * value2.Y) + ((-value1.Y + value3.Y) * amount)) + (((((2.0 * value1.Y) - (5.0 * value2.Y)) + (4.0 * value3.Y)) - value4.Y) * num)) + ((((-value1.Y + (3.0 * value2.Y)) - (3.0 * value3.Y)) + value4.Y) * num2));
            return vectord;
        }

        public static void CatmullRom(ref Vector2D value1, ref Vector2D value2, ref Vector2D value3, ref Vector2D value4, double amount, out Vector2D result)
        {
            double num = amount * amount;
            double num2 = amount * num;
            result.X = 0.5 * ((((2.0 * value2.X) + ((-value1.X + value3.X) * amount)) + (((((2.0 * value1.X) - (5.0 * value2.X)) + (4.0 * value3.X)) - value4.X) * num)) + ((((-value1.X + (3.0 * value2.X)) - (3.0 * value3.X)) + value4.X) * num2));
            result.Y = 0.5 * ((((2.0 * value2.Y) + ((-value1.Y + value3.Y) * amount)) + (((((2.0 * value1.Y) - (5.0 * value2.Y)) + (4.0 * value3.Y)) - value4.Y) * num)) + ((((-value1.Y + (3.0 * value2.Y)) - (3.0 * value3.Y)) + value4.Y) * num2));
        }

        public static Vector2D Hermite(Vector2D value1, Vector2D tangent1, Vector2D value2, Vector2D tangent2, double amount)
        {
            Vector2D vectord;
            double num = amount * amount;
            double num2 = amount * num;
            double num3 = ((2.0 * num2) - (3.0 * num)) + 1.0;
            double num4 = (-2.0 * num2) + (3.0 * num);
            double num5 = (num2 - (2.0 * num)) + amount;
            double num6 = num2 - num;
            vectord.X = (((value1.X * num3) + (value2.X * num4)) + (tangent1.X * num5)) + (tangent2.X * num6);
            vectord.Y = (((value1.Y * num3) + (value2.Y * num4)) + (tangent1.Y * num5)) + (tangent2.Y * num6);
            return vectord;
        }

        public static void Hermite(ref Vector2D value1, ref Vector2D tangent1, ref Vector2D value2, ref Vector2D tangent2, double amount, out Vector2D result)
        {
            double num = amount * amount;
            double num2 = amount * num;
            double num3 = ((2.0 * num2) - (3.0 * num)) + 1.0;
            double num4 = (-2.0 * num2) + (3.0 * num);
            double num5 = (num2 - (2.0 * num)) + amount;
            double num6 = num2 - num;
            result.X = (((value1.X * num3) + (value2.X * num4)) + (tangent1.X * num5)) + (tangent2.X * num6);
            result.Y = (((value1.Y * num3) + (value2.Y * num4)) + (tangent1.Y * num5)) + (tangent2.Y * num6);
        }

        public static Vector2D Transform(Vector2D position, Matrix matrix)
        {
            Vector2D vectord;
            double num = ((position.X * matrix.M11) + (position.Y * matrix.M21)) + matrix.M41;
            double num2 = ((position.X * matrix.M12) + (position.Y * matrix.M22)) + matrix.M42;
            vectord.X = num;
            vectord.Y = num2;
            return vectord;
        }

        public static void Transform(ref Vector2D position, ref Matrix matrix, out Vector2D result)
        {
            double num = ((position.X * matrix.M11) + (position.Y * matrix.M21)) + matrix.M41;
            double num2 = ((position.X * matrix.M12) + (position.Y * matrix.M22)) + matrix.M42;
            result.X = num;
            result.Y = num2;
        }

        public static Vector2D TransformNormal(Vector2D normal, Matrix matrix)
        {
            Vector2D vectord;
            double num = (normal.X * matrix.M11) + (normal.Y * matrix.M21);
            double num2 = (normal.X * matrix.M12) + (normal.Y * matrix.M22);
            vectord.X = num;
            vectord.Y = num2;
            return vectord;
        }

        public static void TransformNormal(ref Vector2D normal, ref Matrix matrix, out Vector2D result)
        {
            double num = (normal.X * matrix.M11) + (normal.Y * matrix.M21);
            double num2 = (normal.X * matrix.M12) + (normal.Y * matrix.M22);
            result.X = num;
            result.Y = num2;
        }

        public static Vector2D Transform(Vector2D value, Quaternion rotation)
        {
            Vector2D vectord;
            double num = rotation.X + rotation.X;
            double num2 = rotation.Y + rotation.Y;
            double num3 = rotation.Z + rotation.Z;
            double num4 = rotation.W * num3;
            double num5 = rotation.X * num;
            double num6 = rotation.X * num2;
            double num7 = rotation.Y * num2;
            double num8 = rotation.Z * num3;
            double num9 = (value.X * ((1.0 - num7) - num8)) + (value.Y * (num6 - num4));
            double num10 = (value.X * (num6 + num4)) + (value.Y * ((1.0 - num5) - num8));
            vectord.X = num9;
            vectord.Y = num10;
            return vectord;
        }

        public static void Transform(ref Vector2D value, ref Quaternion rotation, out Vector2D result)
        {
            double num = rotation.X + rotation.X;
            double num2 = rotation.Y + rotation.Y;
            double num3 = rotation.Z + rotation.Z;
            double num4 = rotation.W * num3;
            double num5 = rotation.X * num;
            double num6 = rotation.X * num2;
            double num7 = rotation.Y * num2;
            double num8 = rotation.Z * num3;
            double num9 = (value.X * ((1.0 - num7) - num8)) + (value.Y * (num6 - num4));
            double num10 = (value.X * (num6 + num4)) + (value.Y * ((1.0 - num5) - num8));
            result.X = num9;
            result.Y = num10;
        }

        public static void Transform(Vector2D[] sourceArray, ref Matrix matrix, Vector2D[] destinationArray)
        {
            for (int i = 0; i < sourceArray.Length; i++)
            {
                double x = sourceArray[i].X;
                double y = sourceArray[i].Y;
                destinationArray[i].X = ((x * matrix.M11) + (y * matrix.M21)) + matrix.M41;
                destinationArray[i].Y = ((x * matrix.M12) + (y * matrix.M22)) + matrix.M42;
            }
        }

        public static void Transform(Vector2D[] sourceArray, int sourceIndex, ref Matrix matrix, Vector2D[] destinationArray, int destinationIndex, int length)
        {
            while (length > 0)
            {
                double x = sourceArray[sourceIndex].X;
                double y = sourceArray[sourceIndex].Y;
                destinationArray[destinationIndex].X = ((x * matrix.M11) + (y * matrix.M21)) + matrix.M41;
                destinationArray[destinationIndex].Y = ((x * matrix.M12) + (y * matrix.M22)) + matrix.M42;
                sourceIndex++;
                destinationIndex++;
                length--;
            }
        }

        public static void TransformNormal(Vector2D[] sourceArray, ref Matrix matrix, Vector2D[] destinationArray)
        {
            for (int i = 0; i < sourceArray.Length; i++)
            {
                double x = sourceArray[i].X;
                double y = sourceArray[i].Y;
                destinationArray[i].X = (x * matrix.M11) + (y * matrix.M21);
                destinationArray[i].Y = (x * matrix.M12) + (y * matrix.M22);
            }
        }

        public static void TransformNormal(Vector2D[] sourceArray, int sourceIndex, ref Matrix matrix, Vector2D[] destinationArray, int destinationIndex, int length)
        {
            while (length > 0)
            {
                double x = sourceArray[sourceIndex].X;
                double y = sourceArray[sourceIndex].Y;
                destinationArray[destinationIndex].X = (x * matrix.M11) + (y * matrix.M21);
                destinationArray[destinationIndex].Y = (x * matrix.M12) + (y * matrix.M22);
                sourceIndex++;
                destinationIndex++;
                length--;
            }
        }

        public static void Transform(Vector2D[] sourceArray, ref Quaternion rotation, Vector2D[] destinationArray)
        {
            double num = rotation.X + rotation.X;
            double num2 = rotation.Y + rotation.Y;
            double num3 = rotation.Z + rotation.Z;
            double num4 = rotation.W * num3;
            double num5 = rotation.X * num;
            double num6 = rotation.X * num2;
            double num7 = rotation.Y * num2;
            double num8 = rotation.Z * num3;
            double num9 = (1.0 - num7) - num8;
            double num10 = num6 - num4;
            double num11 = num6 + num4;
            double num12 = (1.0 - num5) - num8;
            for (int i = 0; i < sourceArray.Length; i++)
            {
                double x = sourceArray[i].X;
                double y = sourceArray[i].Y;
                destinationArray[i].X = (x * num9) + (y * num10);
                destinationArray[i].Y = (x * num11) + (y * num12);
            }
        }

        public static void Transform(Vector2D[] sourceArray, int sourceIndex, ref Quaternion rotation, Vector2D[] destinationArray, int destinationIndex, int length)
        {
            double num = rotation.X + rotation.X;
            double num2 = rotation.Y + rotation.Y;
            double num3 = rotation.Z + rotation.Z;
            double num4 = rotation.W * num3;
            double num5 = rotation.X * num;
            double num6 = rotation.X * num2;
            double num7 = rotation.Y * num2;
            double num8 = rotation.Z * num3;
            double num9 = (1.0 - num7) - num8;
            double num10 = num6 - num4;
            double num11 = num6 + num4;
            double num12 = (1.0 - num5) - num8;
            while (length > 0)
            {
                double x = sourceArray[sourceIndex].X;
                double y = sourceArray[sourceIndex].Y;
                destinationArray[destinationIndex].X = (x * num9) + (y * num10);
                destinationArray[destinationIndex].Y = (x * num11) + (y * num12);
                sourceIndex++;
                destinationIndex++;
                length--;
            }
        }

        public static Vector2D Negate(Vector2D value)
        {
            Vector2D vectord;
            vectord.X = -value.X;
            vectord.Y = -value.Y;
            return vectord;
        }

        public static void Negate(ref Vector2D value, out Vector2D result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
        }

        public static Vector2D Add(Vector2D value1, Vector2D value2)
        {
            Vector2D vectord;
            vectord.X = value1.X + value2.X;
            vectord.Y = value1.Y + value2.Y;
            return vectord;
        }

        public static void Add(ref Vector2D value1, ref Vector2D value2, out Vector2D result)
        {
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
        }

        public static Vector2D Subtract(Vector2D value1, Vector2D value2)
        {
            Vector2D vectord;
            vectord.X = value1.X - value2.X;
            vectord.Y = value1.Y - value2.Y;
            return vectord;
        }

        public static void Subtract(ref Vector2D value1, ref Vector2D value2, out Vector2D result)
        {
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
        }

        public static Vector2D Multiply(Vector2D value1, Vector2D value2)
        {
            Vector2D vectord;
            vectord.X = value1.X * value2.X;
            vectord.Y = value1.Y * value2.Y;
            return vectord;
        }

        public static void Multiply(ref Vector2D value1, ref Vector2D value2, out Vector2D result)
        {
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
        }

        public static Vector2D Multiply(Vector2D value1, double scaleFactor)
        {
            Vector2D vectord;
            vectord.X = value1.X * scaleFactor;
            vectord.Y = value1.Y * scaleFactor;
            return vectord;
        }

        public static void Multiply(ref Vector2D value1, double scaleFactor, out Vector2D result)
        {
            result.X = value1.X * scaleFactor;
            result.Y = value1.Y * scaleFactor;
        }

        public static Vector2D Divide(Vector2D value1, Vector2D value2)
        {
            Vector2D vectord;
            vectord.X = value1.X / value2.X;
            vectord.Y = value1.Y / value2.Y;
            return vectord;
        }

        public static void Divide(ref Vector2D value1, ref Vector2D value2, out Vector2D result)
        {
            result.X = value1.X / value2.X;
            result.Y = value1.Y / value2.Y;
        }

        public static Vector2D Divide(Vector2D value1, double divider)
        {
            Vector2D vectord;
            double num = 1.0 / divider;
            vectord.X = value1.X * num;
            vectord.Y = value1.Y * num;
            return vectord;
        }

        public static void Divide(ref Vector2D value1, double divider, out Vector2D result)
        {
            double num = 1.0 / divider;
            result.X = value1.X * num;
            result.Y = value1.Y * num;
        }

        public bool Between(ref Vector2D start, ref Vector2D end) => 
            (((this.X >= start.X) && (this.X <= end.X)) || ((this.Y >= start.Y) && (this.Y <= end.Y)));

        public static Vector2D Floor(Vector2D position) => 
            new Vector2D(Math.Floor(position.X), Math.Floor(position.Y));

        public void Rotate(double angle)
        {
            double x = this.X;
            this.X = (this.X * Math.Cos(angle)) - (this.Y * Math.Sin(angle));
            this.Y = (this.Y * Math.Cos(angle)) + (x * Math.Sin(angle));
        }
    }
}

