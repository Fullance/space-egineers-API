namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using Unsharper;

    [Serializable, StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct Vector2 : IEquatable<Vector2>
    {
        public static Vector2 Zero;
        public static Vector2 One;
        public static Vector2 UnitX;
        public static Vector2 UnitY;
        public static Vector2 PositiveInfinity;
        [ProtoMember(0x16)]
        public float X;
        [ProtoMember(0x1b)]
        public float Y;
        static Vector2()
        {
            Zero = new Vector2();
            One = new Vector2(1f, 1f);
            UnitX = new Vector2(1f, 0f);
            UnitY = new Vector2(0f, 1f);
            PositiveInfinity = (Vector2) (One * (float) 1.0 / (float) 0.0);
        }

        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector2(float value)
        {
            this.X = this.Y = value;
        }

        public float this[int index]
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
        public static explicit operator Vector2I(Vector2 vector) => 
            new Vector2I(vector);

        public static Vector2 operator -(Vector2 value)
        {
            Vector2 vector;
            vector.X = -value.X;
            vector.Y = -value.Y;
            return vector;
        }

        public static bool operator ==(Vector2 value1, Vector2 value2) => 
            ((value1.X == value2.X) && (value1.Y == value2.Y));

        public static bool operator !=(Vector2 value1, Vector2 value2)
        {
            if (value1.X == value2.X)
            {
                return !(value1.Y == value2.Y);
            }
            return true;
        }

        public static Vector2 operator +(Vector2 value1, Vector2 value2)
        {
            Vector2 vector;
            vector.X = value1.X + value2.X;
            vector.Y = value1.Y + value2.Y;
            return vector;
        }

        public static Vector2 operator +(Vector2 value1, float value2)
        {
            Vector2 vector;
            vector.X = value1.X + value2;
            vector.Y = value1.Y + value2;
            return vector;
        }

        public static Vector2 operator -(Vector2 value1, Vector2 value2)
        {
            Vector2 vector;
            vector.X = value1.X - value2.X;
            vector.Y = value1.Y - value2.Y;
            return vector;
        }

        public static Vector2 operator -(Vector2 value1, float value2)
        {
            Vector2 vector;
            vector.X = value1.X - value2;
            vector.Y = value1.Y - value2;
            return vector;
        }

        public static Vector2 operator *(Vector2 value1, Vector2 value2)
        {
            Vector2 vector;
            vector.X = value1.X * value2.X;
            vector.Y = value1.Y * value2.Y;
            return vector;
        }

        public static Vector2 operator *(Vector2 value, float scaleFactor)
        {
            Vector2 vector;
            vector.X = value.X * scaleFactor;
            vector.Y = value.Y * scaleFactor;
            return vector;
        }

        public static Vector2 operator *(float scaleFactor, Vector2 value)
        {
            Vector2 vector;
            vector.X = value.X * scaleFactor;
            vector.Y = value.Y * scaleFactor;
            return vector;
        }

        public static Vector2 operator /(Vector2 value1, Vector2 value2)
        {
            Vector2 vector;
            vector.X = value1.X / value2.X;
            vector.Y = value1.Y / value2.Y;
            return vector;
        }

        public static Vector2 operator /(Vector2 value1, float divider)
        {
            Vector2 vector;
            float num = 1f / divider;
            vector.X = value1.X * num;
            vector.Y = value1.Y * num;
            return vector;
        }

        public static Vector2 operator /(float value1, Vector2 value2)
        {
            Vector2 vector;
            vector.X = value1 / value2.X;
            vector.Y = value1 / value2.Y;
            return vector;
        }

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format(currentCulture, "{{X:{0} Y:{1}}}", new object[] { this.X.ToString(currentCulture), this.Y.ToString(currentCulture) });
        }

        public bool Equals(Vector2 other) => 
            ((this.X == other.X) && (this.Y == other.Y));

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is Vector2)
            {
                flag = this.Equals((Vector2) obj);
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

        public float Length() => 
            ((float) Math.Sqrt((this.X * this.X) + (this.Y * this.Y)));

        public float LengthSquared() => 
            ((this.X * this.X) + (this.Y * this.Y));

        public static float Distance(Vector2 value1, Vector2 value2)
        {
            float num = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            return (float) Math.Sqrt((num * num) + (num2 * num2));
        }

        public static void Distance(ref Vector2 value1, ref Vector2 value2, out float result)
        {
            float num = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            float num3 = (num * num) + (num2 * num2);
            result = (float) Math.Sqrt((double) num3);
        }

        public static float DistanceSquared(Vector2 value1, Vector2 value2)
        {
            float num = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            return ((num * num) + (num2 * num2));
        }

        public static void DistanceSquared(ref Vector2 value1, ref Vector2 value2, out float result)
        {
            float num = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            result = (num * num) + (num2 * num2);
        }

        public static float Dot(Vector2 value1, Vector2 value2) => 
            ((value1.X * value2.X) + (value1.Y * value2.Y));

        public static void Dot(ref Vector2 value1, ref Vector2 value2, out float result)
        {
            result = (value1.X * value2.X) + (value1.Y * value2.Y);
        }

        public void Normalize()
        {
            float num = 1f / ((float) Math.Sqrt((this.X * this.X) + (this.Y * this.Y)));
            this.X *= num;
            this.Y *= num;
        }

        public static Vector2 Normalize(Vector2 value)
        {
            Vector2 vector;
            float num = 1f / ((float) Math.Sqrt((value.X * value.X) + (value.Y * value.Y)));
            vector.X = value.X * num;
            vector.Y = value.Y * num;
            return vector;
        }

        public static void Normalize(ref Vector2 value, out Vector2 result)
        {
            float num = 1f / ((float) Math.Sqrt((value.X * value.X) + (value.Y * value.Y)));
            result.X = value.X * num;
            result.Y = value.Y * num;
        }

        public static Vector2 Reflect(Vector2 vector, Vector2 normal)
        {
            Vector2 vector2;
            float num = (vector.X * normal.X) + (vector.Y * normal.Y);
            vector2.X = vector.X - ((2f * num) * normal.X);
            vector2.Y = vector.Y - ((2f * num) * normal.Y);
            return vector2;
        }

        public static void Reflect(ref Vector2 vector, ref Vector2 normal, out Vector2 result)
        {
            float num = (vector.X * normal.X) + (vector.Y * normal.Y);
            result.X = vector.X - ((2f * num) * normal.X);
            result.Y = vector.Y - ((2f * num) * normal.Y);
        }

        public static Vector2 Min(Vector2 value1, Vector2 value2)
        {
            Vector2 vector;
            vector.X = (value1.X < value2.X) ? value1.X : value2.X;
            vector.Y = (value1.Y < value2.Y) ? value1.Y : value2.Y;
            return vector;
        }

        public static void Min(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = (value1.X < value2.X) ? value1.X : value2.X;
            result.Y = (value1.Y < value2.Y) ? value1.Y : value2.Y;
        }

        public static Vector2 Max(Vector2 value1, Vector2 value2)
        {
            Vector2 vector;
            vector.X = (value1.X > value2.X) ? value1.X : value2.X;
            vector.Y = (value1.Y > value2.Y) ? value1.Y : value2.Y;
            return vector;
        }

        public static void Max(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = (value1.X > value2.X) ? value1.X : value2.X;
            result.Y = (value1.Y > value2.Y) ? value1.Y : value2.Y;
        }

        public static Vector2 Clamp(Vector2 value1, Vector2 min, Vector2 max)
        {
            Vector2 vector;
            float x = value1.X;
            float num2 = (x > max.X) ? max.X : x;
            float num3 = (num2 < min.X) ? min.X : num2;
            float y = value1.Y;
            float num5 = (y > max.Y) ? max.Y : y;
            float num6 = (num5 < min.Y) ? min.Y : num5;
            vector.X = num3;
            vector.Y = num6;
            return vector;
        }

        public static void Clamp(ref Vector2 value1, ref Vector2 min, ref Vector2 max, out Vector2 result)
        {
            float x = value1.X;
            float num2 = (x > max.X) ? max.X : x;
            float num3 = (num2 < min.X) ? min.X : num2;
            float y = value1.Y;
            float num5 = (y > max.Y) ? max.Y : y;
            float num6 = (num5 < min.Y) ? min.Y : num5;
            result.X = num3;
            result.Y = num6;
        }

        [UnsharperDisableReflection]
        public static Vector2 ClampToSphere(Vector2 vector, float radius)
        {
            float num = vector.LengthSquared();
            float num2 = radius * radius;
            if (num > num2)
            {
                return (Vector2) (vector * ((float) Math.Sqrt((double) (num2 / num))));
            }
            return vector;
        }

        [UnsharperDisableReflection]
        public static void ClampToSphere(ref Vector2 vector, float radius)
        {
            float num = vector.LengthSquared();
            float num2 = radius * radius;
            if (num > num2)
            {
                vector = (Vector2) (vector * ((float) Math.Sqrt((double) (num2 / num))));
            }
        }

        public static Vector2 Lerp(Vector2 value1, Vector2 value2, float amount)
        {
            Vector2 vector;
            vector.X = value1.X + ((value2.X - value1.X) * amount);
            vector.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            return vector;
        }

        public static void Lerp(ref Vector2 value1, ref Vector2 value2, float amount, out Vector2 result)
        {
            result.X = value1.X + ((value2.X - value1.X) * amount);
            result.Y = value1.Y + ((value2.Y - value1.Y) * amount);
        }

        public static Vector2 Barycentric(Vector2 value1, Vector2 value2, Vector2 value3, float amount1, float amount2)
        {
            Vector2 vector;
            vector.X = (value1.X + (amount1 * (value2.X - value1.X))) + (amount2 * (value3.X - value1.X));
            vector.Y = (value1.Y + (amount1 * (value2.Y - value1.Y))) + (amount2 * (value3.Y - value1.Y));
            return vector;
        }

        public static void Barycentric(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, float amount1, float amount2, out Vector2 result)
        {
            result.X = (value1.X + (amount1 * (value2.X - value1.X))) + (amount2 * (value3.X - value1.X));
            result.Y = (value1.Y + (amount1 * (value2.Y - value1.Y))) + (amount2 * (value3.Y - value1.Y));
        }

        public static Vector2 SmoothStep(Vector2 value1, Vector2 value2, float amount)
        {
            Vector2 vector;
            amount = (amount > 1.0) ? 1f : ((amount < 0.0) ? 0f : amount);
            amount = (float) ((amount * amount) * (3.0 - (2.0 * amount)));
            vector.X = value1.X + ((value2.X - value1.X) * amount);
            vector.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            return vector;
        }

        public static void SmoothStep(ref Vector2 value1, ref Vector2 value2, float amount, out Vector2 result)
        {
            amount = (amount > 1.0) ? 1f : ((amount < 0.0) ? 0f : amount);
            amount = (float) ((amount * amount) * (3.0 - (2.0 * amount)));
            result.X = value1.X + ((value2.X - value1.X) * amount);
            result.Y = value1.Y + ((value2.Y - value1.Y) * amount);
        }

        public static Vector2 CatmullRom(Vector2 value1, Vector2 value2, Vector2 value3, Vector2 value4, float amount)
        {
            Vector2 vector;
            float num = amount * amount;
            float num2 = amount * num;
            vector.X = (float) (0.5 * ((((2.0 * value2.X) + ((-((double) value1.X) + value3.X) * amount)) + (((((2.0 * value1.X) - (5.0 * value2.X)) + (4.0 * value3.X)) - value4.X) * num)) + ((((-((double) value1.X) + (3.0 * value2.X)) - (3.0 * value3.X)) + value4.X) * num2)));
            vector.Y = (float) (0.5 * ((((2.0 * value2.Y) + ((-((double) value1.Y) + value3.Y) * amount)) + (((((2.0 * value1.Y) - (5.0 * value2.Y)) + (4.0 * value3.Y)) - value4.Y) * num)) + ((((-((double) value1.Y) + (3.0 * value2.Y)) - (3.0 * value3.Y)) + value4.Y) * num2)));
            return vector;
        }

        public static void CatmullRom(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, ref Vector2 value4, float amount, out Vector2 result)
        {
            float num = amount * amount;
            float num2 = amount * num;
            result.X = (float) (0.5 * ((((2.0 * value2.X) + ((-((double) value1.X) + value3.X) * amount)) + (((((2.0 * value1.X) - (5.0 * value2.X)) + (4.0 * value3.X)) - value4.X) * num)) + ((((-((double) value1.X) + (3.0 * value2.X)) - (3.0 * value3.X)) + value4.X) * num2)));
            result.Y = (float) (0.5 * ((((2.0 * value2.Y) + ((-((double) value1.Y) + value3.Y) * amount)) + (((((2.0 * value1.Y) - (5.0 * value2.Y)) + (4.0 * value3.Y)) - value4.Y) * num)) + ((((-((double) value1.Y) + (3.0 * value2.Y)) - (3.0 * value3.Y)) + value4.Y) * num2)));
        }

        public static Vector2 Hermite(Vector2 value1, Vector2 tangent1, Vector2 value2, Vector2 tangent2, float amount)
        {
            Vector2 vector;
            float num = amount * amount;
            float num2 = amount * num;
            float num3 = (float) (((2.0 * num2) - (3.0 * num)) + 1.0);
            float num4 = (float) ((-2.0 * num2) + (3.0 * num));
            float num5 = (num2 - (2f * num)) + amount;
            float num6 = num2 - num;
            vector.X = (((value1.X * num3) + (value2.X * num4)) + (tangent1.X * num5)) + (tangent2.X * num6);
            vector.Y = (((value1.Y * num3) + (value2.Y * num4)) + (tangent1.Y * num5)) + (tangent2.Y * num6);
            return vector;
        }

        public static void Hermite(ref Vector2 value1, ref Vector2 tangent1, ref Vector2 value2, ref Vector2 tangent2, float amount, out Vector2 result)
        {
            float num = amount * amount;
            float num2 = amount * num;
            float num3 = (float) (((2.0 * num2) - (3.0 * num)) + 1.0);
            float num4 = (float) ((-2.0 * num2) + (3.0 * num));
            float num5 = (num2 - (2f * num)) + amount;
            float num6 = num2 - num;
            result.X = (((value1.X * num3) + (value2.X * num4)) + (tangent1.X * num5)) + (tangent2.X * num6);
            result.Y = (((value1.Y * num3) + (value2.Y * num4)) + (tangent1.Y * num5)) + (tangent2.Y * num6);
        }

        public static Vector2 Transform(Vector2 position, Matrix matrix)
        {
            Vector2 vector;
            float num = ((position.X * matrix.M11) + (position.Y * matrix.M21)) + matrix.M41;
            float num2 = ((position.X * matrix.M12) + (position.Y * matrix.M22)) + matrix.M42;
            vector.X = num;
            vector.Y = num2;
            return vector;
        }

        public static void Transform(ref Vector2 position, ref Matrix matrix, out Vector2 result)
        {
            float num = ((position.X * matrix.M11) + (position.Y * matrix.M21)) + matrix.M41;
            float num2 = ((position.X * matrix.M12) + (position.Y * matrix.M22)) + matrix.M42;
            result.X = num;
            result.Y = num2;
        }

        public static Vector2 TransformNormal(Vector2 normal, Matrix matrix)
        {
            Vector2 vector;
            float num = (normal.X * matrix.M11) + (normal.Y * matrix.M21);
            float num2 = (normal.X * matrix.M12) + (normal.Y * matrix.M22);
            vector.X = num;
            vector.Y = num2;
            return vector;
        }

        public static void TransformNormal(ref Vector2 normal, ref Matrix matrix, out Vector2 result)
        {
            float num = (normal.X * matrix.M11) + (normal.Y * matrix.M21);
            float num2 = (normal.X * matrix.M12) + (normal.Y * matrix.M22);
            result.X = num;
            result.Y = num2;
        }

        public static Vector2 Transform(Vector2 value, Quaternion rotation)
        {
            Vector2 vector;
            float num = rotation.X + rotation.X;
            float num2 = rotation.Y + rotation.Y;
            float num3 = rotation.Z + rotation.Z;
            float num4 = rotation.W * num3;
            float num5 = rotation.X * num;
            float num6 = rotation.X * num2;
            float num7 = rotation.Y * num2;
            float num8 = rotation.Z * num3;
            float num9 = ((float) (value.X * ((1.0 - num7) - num8))) + (value.Y * (num6 - num4));
            float num10 = (value.X * (num6 + num4)) + ((float) (value.Y * ((1.0 - num5) - num8)));
            vector.X = num9;
            vector.Y = num10;
            return vector;
        }

        public static void Transform(ref Vector2 value, ref Quaternion rotation, out Vector2 result)
        {
            float num = rotation.X + rotation.X;
            float num2 = rotation.Y + rotation.Y;
            float num3 = rotation.Z + rotation.Z;
            float num4 = rotation.W * num3;
            float num5 = rotation.X * num;
            float num6 = rotation.X * num2;
            float num7 = rotation.Y * num2;
            float num8 = rotation.Z * num3;
            float num9 = ((float) (value.X * ((1.0 - num7) - num8))) + (value.Y * (num6 - num4));
            float num10 = (value.X * (num6 + num4)) + ((float) (value.Y * ((1.0 - num5) - num8)));
            result.X = num9;
            result.Y = num10;
        }

        public static void Transform(Vector2[] sourceArray, ref Matrix matrix, Vector2[] destinationArray)
        {
            for (int i = 0; i < sourceArray.Length; i++)
            {
                float x = sourceArray[i].X;
                float y = sourceArray[i].Y;
                destinationArray[i].X = ((x * matrix.M11) + (y * matrix.M21)) + matrix.M41;
                destinationArray[i].Y = ((x * matrix.M12) + (y * matrix.M22)) + matrix.M42;
            }
        }

        public static void Transform(Vector2[] sourceArray, int sourceIndex, ref Matrix matrix, Vector2[] destinationArray, int destinationIndex, int length)
        {
            while (length > 0)
            {
                float x = sourceArray[sourceIndex].X;
                float y = sourceArray[sourceIndex].Y;
                destinationArray[destinationIndex].X = ((x * matrix.M11) + (y * matrix.M21)) + matrix.M41;
                destinationArray[destinationIndex].Y = ((x * matrix.M12) + (y * matrix.M22)) + matrix.M42;
                sourceIndex++;
                destinationIndex++;
                length--;
            }
        }

        public static void TransformNormal(Vector2[] sourceArray, ref Matrix matrix, Vector2[] destinationArray)
        {
            for (int i = 0; i < sourceArray.Length; i++)
            {
                float x = sourceArray[i].X;
                float y = sourceArray[i].Y;
                destinationArray[i].X = (x * matrix.M11) + (y * matrix.M21);
                destinationArray[i].Y = (x * matrix.M12) + (y * matrix.M22);
            }
        }

        public static void TransformNormal(Vector2[] sourceArray, int sourceIndex, ref Matrix matrix, Vector2[] destinationArray, int destinationIndex, int length)
        {
            while (length > 0)
            {
                float x = sourceArray[sourceIndex].X;
                float y = sourceArray[sourceIndex].Y;
                destinationArray[destinationIndex].X = (x * matrix.M11) + (y * matrix.M21);
                destinationArray[destinationIndex].Y = (x * matrix.M12) + (y * matrix.M22);
                sourceIndex++;
                destinationIndex++;
                length--;
            }
        }

        public static void Transform(Vector2[] sourceArray, ref Quaternion rotation, Vector2[] destinationArray)
        {
            float num = rotation.X + rotation.X;
            float num2 = rotation.Y + rotation.Y;
            float num3 = rotation.Z + rotation.Z;
            float num4 = rotation.W * num3;
            float num5 = rotation.X * num;
            float num6 = rotation.X * num2;
            float num7 = rotation.Y * num2;
            float num8 = rotation.Z * num3;
            float num9 = (1f - num7) - num8;
            float num10 = num6 - num4;
            float num11 = num6 + num4;
            float num12 = (1f - num5) - num8;
            for (int i = 0; i < sourceArray.Length; i++)
            {
                float x = sourceArray[i].X;
                float y = sourceArray[i].Y;
                destinationArray[i].X = (x * num9) + (y * num10);
                destinationArray[i].Y = (x * num11) + (y * num12);
            }
        }

        public static void Transform(Vector2[] sourceArray, int sourceIndex, ref Quaternion rotation, Vector2[] destinationArray, int destinationIndex, int length)
        {
            float num = rotation.X + rotation.X;
            float num2 = rotation.Y + rotation.Y;
            float num3 = rotation.Z + rotation.Z;
            float num4 = rotation.W * num3;
            float num5 = rotation.X * num;
            float num6 = rotation.X * num2;
            float num7 = rotation.Y * num2;
            float num8 = rotation.Z * num3;
            float num9 = (1f - num7) - num8;
            float num10 = num6 - num4;
            float num11 = num6 + num4;
            float num12 = (1f - num5) - num8;
            while (length > 0)
            {
                float x = sourceArray[sourceIndex].X;
                float y = sourceArray[sourceIndex].Y;
                destinationArray[destinationIndex].X = (x * num9) + (y * num10);
                destinationArray[destinationIndex].Y = (x * num11) + (y * num12);
                sourceIndex++;
                destinationIndex++;
                length--;
            }
        }

        public static Vector2 Negate(Vector2 value)
        {
            Vector2 vector;
            vector.X = -value.X;
            vector.Y = -value.Y;
            return vector;
        }

        public static void Negate(ref Vector2 value, out Vector2 result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
        }

        public static Vector2 Add(Vector2 value1, Vector2 value2)
        {
            Vector2 vector;
            vector.X = value1.X + value2.X;
            vector.Y = value1.Y + value2.Y;
            return vector;
        }

        public static void Add(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
        }

        public static Vector2 Subtract(Vector2 value1, Vector2 value2)
        {
            Vector2 vector;
            vector.X = value1.X - value2.X;
            vector.Y = value1.Y - value2.Y;
            return vector;
        }

        public static void Subtract(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
        }

        public static Vector2 Multiply(Vector2 value1, Vector2 value2)
        {
            Vector2 vector;
            vector.X = value1.X * value2.X;
            vector.Y = value1.Y * value2.Y;
            return vector;
        }

        public static void Multiply(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
        }

        public static Vector2 Multiply(Vector2 value1, float scaleFactor)
        {
            Vector2 vector;
            vector.X = value1.X * scaleFactor;
            vector.Y = value1.Y * scaleFactor;
            return vector;
        }

        public static void Multiply(ref Vector2 value1, float scaleFactor, out Vector2 result)
        {
            result.X = value1.X * scaleFactor;
            result.Y = value1.Y * scaleFactor;
        }

        public static Vector2 Divide(Vector2 value1, Vector2 value2)
        {
            Vector2 vector;
            vector.X = value1.X / value2.X;
            vector.Y = value1.Y / value2.Y;
            return vector;
        }

        public static void Divide(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = value1.X / value2.X;
            result.Y = value1.Y / value2.Y;
        }

        public static Vector2 Divide(Vector2 value1, float divider)
        {
            Vector2 vector;
            float num = 1f / divider;
            vector.X = value1.X * num;
            vector.Y = value1.Y * num;
            return vector;
        }

        public static void Divide(ref Vector2 value1, float divider, out Vector2 result)
        {
            float num = 1f / divider;
            result.X = value1.X * num;
            result.Y = value1.Y * num;
        }

        public bool Between(ref Vector2 start, ref Vector2 end) => 
            (((this.X >= start.X) && (this.X <= end.X)) || ((this.Y >= start.Y) && (this.Y <= end.Y)));

        public static Vector2 Floor(Vector2 position) => 
            new Vector2((float) Math.Floor((double) position.X), (float) Math.Floor((double) position.Y));

        public void Rotate(double angle)
        {
            float x = this.X;
            this.X = (this.X * ((float) Math.Cos(angle))) - (this.Y * ((float) Math.Sin(angle)));
            this.Y = (this.Y * ((float) Math.Cos(angle))) + (x * ((float) Math.Sin(angle)));
        }

        public static bool IsZero(ref Vector2 value) => 
            IsZero(ref value, 0.0001f);

        public static bool IsZero(ref Vector2 value, float epsilon) => 
            ((Math.Abs(value.X) < epsilon) && (Math.Abs(value.Y) < epsilon));

        public static bool IsZero(Vector2 value, float epsilon) => 
            ((Math.Abs(value.X) < epsilon) && (Math.Abs(value.Y) < epsilon));

        public static Vector2 SignNonZero(Vector2 value) => 
            new Vector2((value.X < 0f) ? ((float) (-1)) : ((float) 1), (value.Y < 0f) ? ((float) (-1)) : ((float) 1));
    }
}

