namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct Vector4 : IEquatable<Vector4>
    {
        public static Vector4 Zero;
        public static Vector4 One;
        public static Vector4 UnitX;
        public static Vector4 UnitY;
        public static Vector4 UnitZ;
        public static Vector4 UnitW;
        [ProtoMember(0x19)]
        public float X;
        [ProtoMember(30)]
        public float Y;
        [ProtoMember(0x23)]
        public float Z;
        [ProtoMember(40)]
        public float W;
        static Vector4()
        {
            Zero = new Vector4();
            One = new Vector4(1f, 1f, 1f, 1f);
            UnitX = new Vector4(1f, 0f, 0f, 0f);
            UnitY = new Vector4(0f, 1f, 0f, 0f);
            UnitZ = new Vector4(0f, 0f, 1f, 0f);
            UnitW = new Vector4(0f, 0f, 0f, 1f);
        }

        public Vector4(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public Vector4(Vector2 value, float z, float w)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = z;
            this.W = w;
        }

        public Vector4(Vector3 value, float w)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = value.Z;
            this.W = w;
        }

        public Vector4(float value)
        {
            this.X = this.Y = this.Z = this.W = value;
        }

        public static Vector4 operator -(Vector4 value)
        {
            Vector4 vector;
            vector.X = -value.X;
            vector.Y = -value.Y;
            vector.Z = -value.Z;
            vector.W = -value.W;
            return vector;
        }

        public static bool operator ==(Vector4 value1, Vector4 value2) => 
            ((((value1.X == value2.X) && (value1.Y == value2.Y)) && (value1.Z == value2.Z)) && (value1.W == value2.W));

        public static bool operator !=(Vector4 value1, Vector4 value2)
        {
            if (((value1.X == value2.X) && (value1.Y == value2.Y)) && (value1.Z == value2.Z))
            {
                return !(value1.W == value2.W);
            }
            return true;
        }

        public static Vector4 operator +(Vector4 value1, Vector4 value2)
        {
            Vector4 vector;
            vector.X = value1.X + value2.X;
            vector.Y = value1.Y + value2.Y;
            vector.Z = value1.Z + value2.Z;
            vector.W = value1.W + value2.W;
            return vector;
        }

        public static Vector4 operator -(Vector4 value1, Vector4 value2)
        {
            Vector4 vector;
            vector.X = value1.X - value2.X;
            vector.Y = value1.Y - value2.Y;
            vector.Z = value1.Z - value2.Z;
            vector.W = value1.W - value2.W;
            return vector;
        }

        public static Vector4 operator *(Vector4 value1, Vector4 value2)
        {
            Vector4 vector;
            vector.X = value1.X * value2.X;
            vector.Y = value1.Y * value2.Y;
            vector.Z = value1.Z * value2.Z;
            vector.W = value1.W * value2.W;
            return vector;
        }

        public static Vector4 operator *(Vector4 value1, float scaleFactor)
        {
            Vector4 vector;
            vector.X = value1.X * scaleFactor;
            vector.Y = value1.Y * scaleFactor;
            vector.Z = value1.Z * scaleFactor;
            vector.W = value1.W * scaleFactor;
            return vector;
        }

        public static Vector4 operator *(float scaleFactor, Vector4 value1)
        {
            Vector4 vector;
            vector.X = value1.X * scaleFactor;
            vector.Y = value1.Y * scaleFactor;
            vector.Z = value1.Z * scaleFactor;
            vector.W = value1.W * scaleFactor;
            return vector;
        }

        public static Vector4 operator /(Vector4 value1, Vector4 value2)
        {
            Vector4 vector;
            vector.X = value1.X / value2.X;
            vector.Y = value1.Y / value2.Y;
            vector.Z = value1.Z / value2.Z;
            vector.W = value1.W / value2.W;
            return vector;
        }

        public static Vector4 operator /(Vector4 value1, float divider)
        {
            Vector4 vector;
            float num = 1f / divider;
            vector.X = value1.X * num;
            vector.Y = value1.Y * num;
            vector.Z = value1.Z * num;
            vector.W = value1.W * num;
            return vector;
        }

        public static Vector4 operator /(float lhs, Vector4 rhs)
        {
            Vector4 vector;
            vector.X = lhs / rhs.X;
            vector.Y = lhs / rhs.Y;
            vector.Z = lhs / rhs.Z;
            vector.W = lhs / rhs.W;
            return vector;
        }

        public static Vector4 PackOrthoMatrix(Vector3 position, Vector3 forward, Vector3 up)
        {
            int direction = (int) Base6Directions.GetDirection(forward);
            int num2 = (int) Base6Directions.GetDirection(up);
            return new Vector4(position, (float) ((direction * 6) + num2));
        }

        public static Vector4 PackOrthoMatrix(ref Matrix matrix)
        {
            int direction = (int) Base6Directions.GetDirection(matrix.Forward);
            int num2 = (int) Base6Directions.GetDirection(matrix.Up);
            return new Vector4(matrix.Translation, (float) ((direction * 6) + num2));
        }

        public static Matrix UnpackOrthoMatrix(ref Vector4 packed)
        {
            int w = (int) packed.W;
            return Matrix.CreateWorld(new Vector3(packed), Base6Directions.GetVector((int) (w / 6)), Base6Directions.GetVector((int) (w % 6)));
        }

        public static void UnpackOrthoMatrix(ref Vector4 packed, out Matrix matrix)
        {
            int w = (int) packed.W;
            Vector3 position = new Vector3(packed);
            Vector3 vector = Base6Directions.GetVector((int) (w / 6));
            Vector3 up = Base6Directions.GetVector((int) (w % 6));
            Matrix.CreateWorld(ref position, ref vector, ref up, out matrix);
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

        public float Length() => 
            ((float) Math.Sqrt((((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z)) + (this.W * this.W)));

        public float LengthSquared() => 
            ((((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z)) + (this.W * this.W));

        public static float Distance(Vector4 value1, Vector4 value2)
        {
            float num = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            float num3 = value1.Z - value2.Z;
            float num4 = value1.W - value2.W;
            return (float) Math.Sqrt((((num * num) + (num2 * num2)) + (num3 * num3)) + (num4 * num4));
        }

        public static void Distance(ref Vector4 value1, ref Vector4 value2, out float result)
        {
            float num = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            float num3 = value1.Z - value2.Z;
            float num4 = value1.W - value2.W;
            float num5 = (((num * num) + (num2 * num2)) + (num3 * num3)) + (num4 * num4);
            result = (float) Math.Sqrt((double) num5);
        }

        public static float DistanceSquared(Vector4 value1, Vector4 value2)
        {
            float num = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            float num3 = value1.Z - value2.Z;
            float num4 = value1.W - value2.W;
            return ((((num * num) + (num2 * num2)) + (num3 * num3)) + (num4 * num4));
        }

        public static void DistanceSquared(ref Vector4 value1, ref Vector4 value2, out float result)
        {
            float num = value1.X - value2.X;
            float num2 = value1.Y - value2.Y;
            float num3 = value1.Z - value2.Z;
            float num4 = value1.W - value2.W;
            result = (((num * num) + (num2 * num2)) + (num3 * num3)) + (num4 * num4);
        }

        public static float Dot(Vector4 vector1, Vector4 vector2) => 
            ((((vector1.X * vector2.X) + (vector1.Y * vector2.Y)) + (vector1.Z * vector2.Z)) + (vector1.W * vector2.W));

        public static void Dot(ref Vector4 vector1, ref Vector4 vector2, out float result)
        {
            result = (((vector1.X * vector2.X) + (vector1.Y * vector2.Y)) + (vector1.Z * vector2.Z)) + (vector1.W * vector2.W);
        }

        public void Normalize()
        {
            float num = 1f / ((float) Math.Sqrt((((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z)) + (this.W * this.W)));
            this.X *= num;
            this.Y *= num;
            this.Z *= num;
            this.W *= num;
        }

        public static Vector4 Normalize(Vector4 vector)
        {
            Vector4 vector2;
            float num = 1f / ((float) Math.Sqrt((((vector.X * vector.X) + (vector.Y * vector.Y)) + (vector.Z * vector.Z)) + (vector.W * vector.W)));
            vector2.X = vector.X * num;
            vector2.Y = vector.Y * num;
            vector2.Z = vector.Z * num;
            vector2.W = vector.W * num;
            return vector2;
        }

        public static void Normalize(ref Vector4 vector, out Vector4 result)
        {
            float num = 1f / ((float) Math.Sqrt((((vector.X * vector.X) + (vector.Y * vector.Y)) + (vector.Z * vector.Z)) + (vector.W * vector.W)));
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

        public static Vector4 Clamp(Vector4 value1, Vector4 min, Vector4 max)
        {
            Vector4 vector;
            float x = value1.X;
            float num2 = (x > max.X) ? max.X : x;
            float num3 = (num2 < min.X) ? min.X : num2;
            float y = value1.Y;
            float num5 = (y > max.Y) ? max.Y : y;
            float num6 = (num5 < min.Y) ? min.Y : num5;
            float z = value1.Z;
            float num8 = (z > max.Z) ? max.Z : z;
            float num9 = (num8 < min.Z) ? min.Z : num8;
            float w = value1.W;
            float num11 = (w > max.W) ? max.W : w;
            float num12 = (num11 < min.W) ? min.W : num11;
            vector.X = num3;
            vector.Y = num6;
            vector.Z = num9;
            vector.W = num12;
            return vector;
        }

        public static void Clamp(ref Vector4 value1, ref Vector4 min, ref Vector4 max, out Vector4 result)
        {
            float x = value1.X;
            float num2 = (x > max.X) ? max.X : x;
            float num3 = (num2 < min.X) ? min.X : num2;
            float y = value1.Y;
            float num5 = (y > max.Y) ? max.Y : y;
            float num6 = (num5 < min.Y) ? min.Y : num5;
            float z = value1.Z;
            float num8 = (z > max.Z) ? max.Z : z;
            float num9 = (num8 < min.Z) ? min.Z : num8;
            float w = value1.W;
            float num11 = (w > max.W) ? max.W : w;
            float num12 = (num11 < min.W) ? min.W : num11;
            result.X = num3;
            result.Y = num6;
            result.Z = num9;
            result.W = num12;
        }

        public static Vector4 Lerp(Vector4 value1, Vector4 value2, float amount)
        {
            Vector4 vector;
            vector.X = value1.X + ((value2.X - value1.X) * amount);
            vector.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            vector.Z = value1.Z + ((value2.Z - value1.Z) * amount);
            vector.W = value1.W + ((value2.W - value1.W) * amount);
            return vector;
        }

        public static void Lerp(ref Vector4 value1, ref Vector4 value2, float amount, out Vector4 result)
        {
            result.X = value1.X + ((value2.X - value1.X) * amount);
            result.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            result.Z = value1.Z + ((value2.Z - value1.Z) * amount);
            result.W = value1.W + ((value2.W - value1.W) * amount);
        }

        public static Vector4 Barycentric(Vector4 value1, Vector4 value2, Vector4 value3, float amount1, float amount2)
        {
            Vector4 vector;
            vector.X = (value1.X + (amount1 * (value2.X - value1.X))) + (amount2 * (value3.X - value1.X));
            vector.Y = (value1.Y + (amount1 * (value2.Y - value1.Y))) + (amount2 * (value3.Y - value1.Y));
            vector.Z = (value1.Z + (amount1 * (value2.Z - value1.Z))) + (amount2 * (value3.Z - value1.Z));
            vector.W = (value1.W + (amount1 * (value2.W - value1.W))) + (amount2 * (value3.W - value1.W));
            return vector;
        }

        public static void Barycentric(ref Vector4 value1, ref Vector4 value2, ref Vector4 value3, float amount1, float amount2, out Vector4 result)
        {
            result.X = (value1.X + (amount1 * (value2.X - value1.X))) + (amount2 * (value3.X - value1.X));
            result.Y = (value1.Y + (amount1 * (value2.Y - value1.Y))) + (amount2 * (value3.Y - value1.Y));
            result.Z = (value1.Z + (amount1 * (value2.Z - value1.Z))) + (amount2 * (value3.Z - value1.Z));
            result.W = (value1.W + (amount1 * (value2.W - value1.W))) + (amount2 * (value3.W - value1.W));
        }

        public static Vector4 SmoothStep(Vector4 value1, Vector4 value2, float amount)
        {
            Vector4 vector;
            amount = (amount > 1.0) ? 1f : ((amount < 0.0) ? 0f : amount);
            amount = (float) ((amount * amount) * (3.0 - (2.0 * amount)));
            vector.X = value1.X + ((value2.X - value1.X) * amount);
            vector.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            vector.Z = value1.Z + ((value2.Z - value1.Z) * amount);
            vector.W = value1.W + ((value2.W - value1.W) * amount);
            return vector;
        }

        public static void SmoothStep(ref Vector4 value1, ref Vector4 value2, float amount, out Vector4 result)
        {
            amount = (amount > 1.0) ? 1f : ((amount < 0.0) ? 0f : amount);
            amount = (float) ((amount * amount) * (3.0 - (2.0 * amount)));
            result.X = value1.X + ((value2.X - value1.X) * amount);
            result.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            result.Z = value1.Z + ((value2.Z - value1.Z) * amount);
            result.W = value1.W + ((value2.W - value1.W) * amount);
        }

        public static Vector4 CatmullRom(Vector4 value1, Vector4 value2, Vector4 value3, Vector4 value4, float amount)
        {
            Vector4 vector;
            float num = amount * amount;
            float num2 = amount * num;
            vector.X = (float) (0.5 * ((((2.0 * value2.X) + ((-((double) value1.X) + value3.X) * amount)) + (((((2.0 * value1.X) - (5.0 * value2.X)) + (4.0 * value3.X)) - value4.X) * num)) + ((((-((double) value1.X) + (3.0 * value2.X)) - (3.0 * value3.X)) + value4.X) * num2)));
            vector.Y = (float) (0.5 * ((((2.0 * value2.Y) + ((-((double) value1.Y) + value3.Y) * amount)) + (((((2.0 * value1.Y) - (5.0 * value2.Y)) + (4.0 * value3.Y)) - value4.Y) * num)) + ((((-((double) value1.Y) + (3.0 * value2.Y)) - (3.0 * value3.Y)) + value4.Y) * num2)));
            vector.Z = (float) (0.5 * ((((2.0 * value2.Z) + ((-((double) value1.Z) + value3.Z) * amount)) + (((((2.0 * value1.Z) - (5.0 * value2.Z)) + (4.0 * value3.Z)) - value4.Z) * num)) + ((((-((double) value1.Z) + (3.0 * value2.Z)) - (3.0 * value3.Z)) + value4.Z) * num2)));
            vector.W = (float) (0.5 * ((((2.0 * value2.W) + ((-((double) value1.W) + value3.W) * amount)) + (((((2.0 * value1.W) - (5.0 * value2.W)) + (4.0 * value3.W)) - value4.W) * num)) + ((((-((double) value1.W) + (3.0 * value2.W)) - (3.0 * value3.W)) + value4.W) * num2)));
            return vector;
        }

        public static void CatmullRom(ref Vector4 value1, ref Vector4 value2, ref Vector4 value3, ref Vector4 value4, float amount, out Vector4 result)
        {
            float num = amount * amount;
            float num2 = amount * num;
            result.X = (float) (0.5 * ((((2.0 * value2.X) + ((-((double) value1.X) + value3.X) * amount)) + (((((2.0 * value1.X) - (5.0 * value2.X)) + (4.0 * value3.X)) - value4.X) * num)) + ((((-((double) value1.X) + (3.0 * value2.X)) - (3.0 * value3.X)) + value4.X) * num2)));
            result.Y = (float) (0.5 * ((((2.0 * value2.Y) + ((-((double) value1.Y) + value3.Y) * amount)) + (((((2.0 * value1.Y) - (5.0 * value2.Y)) + (4.0 * value3.Y)) - value4.Y) * num)) + ((((-((double) value1.Y) + (3.0 * value2.Y)) - (3.0 * value3.Y)) + value4.Y) * num2)));
            result.Z = (float) (0.5 * ((((2.0 * value2.Z) + ((-((double) value1.Z) + value3.Z) * amount)) + (((((2.0 * value1.Z) - (5.0 * value2.Z)) + (4.0 * value3.Z)) - value4.Z) * num)) + ((((-((double) value1.Z) + (3.0 * value2.Z)) - (3.0 * value3.Z)) + value4.Z) * num2)));
            result.W = (float) (0.5 * ((((2.0 * value2.W) + ((-((double) value1.W) + value3.W) * amount)) + (((((2.0 * value1.W) - (5.0 * value2.W)) + (4.0 * value3.W)) - value4.W) * num)) + ((((-((double) value1.W) + (3.0 * value2.W)) - (3.0 * value3.W)) + value4.W) * num2)));
        }

        public static Vector4 Hermite(Vector4 value1, Vector4 tangent1, Vector4 value2, Vector4 tangent2, float amount)
        {
            Vector4 vector;
            float num = amount * amount;
            float num2 = amount * num;
            float num3 = (float) (((2.0 * num2) - (3.0 * num)) + 1.0);
            float num4 = (float) ((-2.0 * num2) + (3.0 * num));
            float num5 = (num2 - (2f * num)) + amount;
            float num6 = num2 - num;
            vector.X = (((value1.X * num3) + (value2.X * num4)) + (tangent1.X * num5)) + (tangent2.X * num6);
            vector.Y = (((value1.Y * num3) + (value2.Y * num4)) + (tangent1.Y * num5)) + (tangent2.Y * num6);
            vector.Z = (((value1.Z * num3) + (value2.Z * num4)) + (tangent1.Z * num5)) + (tangent2.Z * num6);
            vector.W = (((value1.W * num3) + (value2.W * num4)) + (tangent1.W * num5)) + (tangent2.W * num6);
            return vector;
        }

        public static void Hermite(ref Vector4 value1, ref Vector4 tangent1, ref Vector4 value2, ref Vector4 tangent2, float amount, out Vector4 result)
        {
            float num = amount * amount;
            float num2 = amount * num;
            float num3 = (float) (((2.0 * num2) - (3.0 * num)) + 1.0);
            float num4 = (float) ((-2.0 * num2) + (3.0 * num));
            float num5 = (num2 - (2f * num)) + amount;
            float num6 = num2 - num;
            result.X = (((value1.X * num3) + (value2.X * num4)) + (tangent1.X * num5)) + (tangent2.X * num6);
            result.Y = (((value1.Y * num3) + (value2.Y * num4)) + (tangent1.Y * num5)) + (tangent2.Y * num6);
            result.Z = (((value1.Z * num3) + (value2.Z * num4)) + (tangent1.Z * num5)) + (tangent2.Z * num6);
            result.W = (((value1.W * num3) + (value2.W * num4)) + (tangent1.W * num5)) + (tangent2.W * num6);
        }

        public static Vector4 Transform(Vector2 position, Matrix matrix)
        {
            Vector4 vector;
            float num = ((position.X * matrix.M11) + (position.Y * matrix.M21)) + matrix.M41;
            float num2 = ((position.X * matrix.M12) + (position.Y * matrix.M22)) + matrix.M42;
            float num3 = ((position.X * matrix.M13) + (position.Y * matrix.M23)) + matrix.M43;
            float num4 = ((position.X * matrix.M14) + (position.Y * matrix.M24)) + matrix.M44;
            vector.X = num;
            vector.Y = num2;
            vector.Z = num3;
            vector.W = num4;
            return vector;
        }

        public static void Transform(ref Vector2 position, ref Matrix matrix, out Vector4 result)
        {
            float num = ((position.X * matrix.M11) + (position.Y * matrix.M21)) + matrix.M41;
            float num2 = ((position.X * matrix.M12) + (position.Y * matrix.M22)) + matrix.M42;
            float num3 = ((position.X * matrix.M13) + (position.Y * matrix.M23)) + matrix.M43;
            float num4 = ((position.X * matrix.M14) + (position.Y * matrix.M24)) + matrix.M44;
            result.X = num;
            result.Y = num2;
            result.Z = num3;
            result.W = num4;
        }

        public static Vector4 Transform(Vector3 position, Matrix matrix)
        {
            Vector4 vector;
            float num = (((position.X * matrix.M11) + (position.Y * matrix.M21)) + (position.Z * matrix.M31)) + matrix.M41;
            float num2 = (((position.X * matrix.M12) + (position.Y * matrix.M22)) + (position.Z * matrix.M32)) + matrix.M42;
            float num3 = (((position.X * matrix.M13) + (position.Y * matrix.M23)) + (position.Z * matrix.M33)) + matrix.M43;
            float num4 = (((position.X * matrix.M14) + (position.Y * matrix.M24)) + (position.Z * matrix.M34)) + matrix.M44;
            vector.X = num;
            vector.Y = num2;
            vector.Z = num3;
            vector.W = num4;
            return vector;
        }

        public static void Transform(ref Vector3 position, ref Matrix matrix, out Vector4 result)
        {
            float num = (((position.X * matrix.M11) + (position.Y * matrix.M21)) + (position.Z * matrix.M31)) + matrix.M41;
            float num2 = (((position.X * matrix.M12) + (position.Y * matrix.M22)) + (position.Z * matrix.M32)) + matrix.M42;
            float num3 = (((position.X * matrix.M13) + (position.Y * matrix.M23)) + (position.Z * matrix.M33)) + matrix.M43;
            float num4 = (((position.X * matrix.M14) + (position.Y * matrix.M24)) + (position.Z * matrix.M34)) + matrix.M44;
            result.X = num;
            result.Y = num2;
            result.Z = num3;
            result.W = num4;
        }

        public static Vector4 Transform(Vector4 vector, Matrix matrix)
        {
            Vector4 vector2;
            float num = (((vector.X * matrix.M11) + (vector.Y * matrix.M21)) + (vector.Z * matrix.M31)) + (vector.W * matrix.M41);
            float num2 = (((vector.X * matrix.M12) + (vector.Y * matrix.M22)) + (vector.Z * matrix.M32)) + (vector.W * matrix.M42);
            float num3 = (((vector.X * matrix.M13) + (vector.Y * matrix.M23)) + (vector.Z * matrix.M33)) + (vector.W * matrix.M43);
            float num4 = (((vector.X * matrix.M14) + (vector.Y * matrix.M24)) + (vector.Z * matrix.M34)) + (vector.W * matrix.M44);
            vector2.X = num;
            vector2.Y = num2;
            vector2.Z = num3;
            vector2.W = num4;
            return vector2;
        }

        public static void Transform(ref Vector4 vector, ref Matrix matrix, out Vector4 result)
        {
            float num = (((vector.X * matrix.M11) + (vector.Y * matrix.M21)) + (vector.Z * matrix.M31)) + (vector.W * matrix.M41);
            float num2 = (((vector.X * matrix.M12) + (vector.Y * matrix.M22)) + (vector.Z * matrix.M32)) + (vector.W * matrix.M42);
            float num3 = (((vector.X * matrix.M13) + (vector.Y * matrix.M23)) + (vector.Z * matrix.M33)) + (vector.W * matrix.M43);
            float num4 = (((vector.X * matrix.M14) + (vector.Y * matrix.M24)) + (vector.Z * matrix.M34)) + (vector.W * matrix.M44);
            result.X = num;
            result.Y = num2;
            result.Z = num3;
            result.W = num4;
        }

        public static Vector4 Transform(Vector2 value, Quaternion rotation)
        {
            Vector4 vector;
            float num = rotation.X + rotation.X;
            float num2 = rotation.Y + rotation.Y;
            float num3 = rotation.Z + rotation.Z;
            float num4 = rotation.W * num;
            float num5 = rotation.W * num2;
            float num6 = rotation.W * num3;
            float num7 = rotation.X * num;
            float num8 = rotation.X * num2;
            float num9 = rotation.X * num3;
            float num10 = rotation.Y * num2;
            float num11 = rotation.Y * num3;
            float num12 = rotation.Z * num3;
            float num13 = ((float) (value.X * ((1.0 - num10) - num12))) + (value.Y * (num8 - num6));
            float num14 = (value.X * (num8 + num6)) + ((float) (value.Y * ((1.0 - num7) - num12)));
            float num15 = (value.X * (num9 - num5)) + (value.Y * (num11 + num4));
            vector.X = num13;
            vector.Y = num14;
            vector.Z = num15;
            vector.W = 1f;
            return vector;
        }

        public static void Transform(ref Vector2 value, ref Quaternion rotation, out Vector4 result)
        {
            float num = rotation.X + rotation.X;
            float num2 = rotation.Y + rotation.Y;
            float num3 = rotation.Z + rotation.Z;
            float num4 = rotation.W * num;
            float num5 = rotation.W * num2;
            float num6 = rotation.W * num3;
            float num7 = rotation.X * num;
            float num8 = rotation.X * num2;
            float num9 = rotation.X * num3;
            float num10 = rotation.Y * num2;
            float num11 = rotation.Y * num3;
            float num12 = rotation.Z * num3;
            float num13 = ((float) (value.X * ((1.0 - num10) - num12))) + (value.Y * (num8 - num6));
            float num14 = (value.X * (num8 + num6)) + ((float) (value.Y * ((1.0 - num7) - num12)));
            float num15 = (value.X * (num9 - num5)) + (value.Y * (num11 + num4));
            result.X = num13;
            result.Y = num14;
            result.Z = num15;
            result.W = 1f;
        }

        public static Vector4 Transform(Vector3 value, Quaternion rotation)
        {
            Vector4 vector;
            float num = rotation.X + rotation.X;
            float num2 = rotation.Y + rotation.Y;
            float num3 = rotation.Z + rotation.Z;
            float num4 = rotation.W * num;
            float num5 = rotation.W * num2;
            float num6 = rotation.W * num3;
            float num7 = rotation.X * num;
            float num8 = rotation.X * num2;
            float num9 = rotation.X * num3;
            float num10 = rotation.Y * num2;
            float num11 = rotation.Y * num3;
            float num12 = rotation.Z * num3;
            float num13 = (((float) (value.X * ((1.0 - num10) - num12))) + (value.Y * (num8 - num6))) + (value.Z * (num9 + num5));
            float num14 = ((value.X * (num8 + num6)) + ((float) (value.Y * ((1.0 - num7) - num12)))) + (value.Z * (num11 - num4));
            float num15 = ((value.X * (num9 - num5)) + (value.Y * (num11 + num4))) + ((float) (value.Z * ((1.0 - num7) - num10)));
            vector.X = num13;
            vector.Y = num14;
            vector.Z = num15;
            vector.W = 1f;
            return vector;
        }

        public static void Transform(ref Vector3 value, ref Quaternion rotation, out Vector4 result)
        {
            float num = rotation.X + rotation.X;
            float num2 = rotation.Y + rotation.Y;
            float num3 = rotation.Z + rotation.Z;
            float num4 = rotation.W * num;
            float num5 = rotation.W * num2;
            float num6 = rotation.W * num3;
            float num7 = rotation.X * num;
            float num8 = rotation.X * num2;
            float num9 = rotation.X * num3;
            float num10 = rotation.Y * num2;
            float num11 = rotation.Y * num3;
            float num12 = rotation.Z * num3;
            float num13 = (((float) (value.X * ((1.0 - num10) - num12))) + (value.Y * (num8 - num6))) + (value.Z * (num9 + num5));
            float num14 = ((value.X * (num8 + num6)) + ((float) (value.Y * ((1.0 - num7) - num12)))) + (value.Z * (num11 - num4));
            float num15 = ((value.X * (num9 - num5)) + (value.Y * (num11 + num4))) + ((float) (value.Z * ((1.0 - num7) - num10)));
            result.X = num13;
            result.Y = num14;
            result.Z = num15;
            result.W = 1f;
        }

        public static Vector4 Transform(Vector4 value, Quaternion rotation)
        {
            Vector4 vector;
            float num = rotation.X + rotation.X;
            float num2 = rotation.Y + rotation.Y;
            float num3 = rotation.Z + rotation.Z;
            float num4 = rotation.W * num;
            float num5 = rotation.W * num2;
            float num6 = rotation.W * num3;
            float num7 = rotation.X * num;
            float num8 = rotation.X * num2;
            float num9 = rotation.X * num3;
            float num10 = rotation.Y * num2;
            float num11 = rotation.Y * num3;
            float num12 = rotation.Z * num3;
            float num13 = (((float) (value.X * ((1.0 - num10) - num12))) + (value.Y * (num8 - num6))) + (value.Z * (num9 + num5));
            float num14 = ((value.X * (num8 + num6)) + ((float) (value.Y * ((1.0 - num7) - num12)))) + (value.Z * (num11 - num4));
            float num15 = ((value.X * (num9 - num5)) + (value.Y * (num11 + num4))) + ((float) (value.Z * ((1.0 - num7) - num10)));
            vector.X = num13;
            vector.Y = num14;
            vector.Z = num15;
            vector.W = value.W;
            return vector;
        }

        public static void Transform(ref Vector4 value, ref Quaternion rotation, out Vector4 result)
        {
            float num = rotation.X + rotation.X;
            float num2 = rotation.Y + rotation.Y;
            float num3 = rotation.Z + rotation.Z;
            float num4 = rotation.W * num;
            float num5 = rotation.W * num2;
            float num6 = rotation.W * num3;
            float num7 = rotation.X * num;
            float num8 = rotation.X * num2;
            float num9 = rotation.X * num3;
            float num10 = rotation.Y * num2;
            float num11 = rotation.Y * num3;
            float num12 = rotation.Z * num3;
            float num13 = (((float) (value.X * ((1.0 - num10) - num12))) + (value.Y * (num8 - num6))) + (value.Z * (num9 + num5));
            float num14 = ((value.X * (num8 + num6)) + ((float) (value.Y * ((1.0 - num7) - num12)))) + (value.Z * (num11 - num4));
            float num15 = ((value.X * (num9 - num5)) + (value.Y * (num11 + num4))) + ((float) (value.Z * ((1.0 - num7) - num10)));
            result.X = num13;
            result.Y = num14;
            result.Z = num15;
            result.W = value.W;
        }

        public static void Transform(Vector4[] sourceArray, ref Matrix matrix, Vector4[] destinationArray)
        {
            for (int i = 0; i < sourceArray.Length; i++)
            {
                float x = sourceArray[i].X;
                float y = sourceArray[i].Y;
                float z = sourceArray[i].Z;
                float w = sourceArray[i].W;
                destinationArray[i].X = (((x * matrix.M11) + (y * matrix.M21)) + (z * matrix.M31)) + (w * matrix.M41);
                destinationArray[i].Y = (((x * matrix.M12) + (y * matrix.M22)) + (z * matrix.M32)) + (w * matrix.M42);
                destinationArray[i].Z = (((x * matrix.M13) + (y * matrix.M23)) + (z * matrix.M33)) + (w * matrix.M43);
                destinationArray[i].W = (((x * matrix.M14) + (y * matrix.M24)) + (z * matrix.M34)) + (w * matrix.M44);
            }
        }

        public static void Transform(Vector4[] sourceArray, int sourceIndex, ref Matrix matrix, Vector4[] destinationArray, int destinationIndex, int length)
        {
            while (length > 0)
            {
                float x = sourceArray[sourceIndex].X;
                float y = sourceArray[sourceIndex].Y;
                float z = sourceArray[sourceIndex].Z;
                float w = sourceArray[sourceIndex].W;
                destinationArray[destinationIndex].X = (((x * matrix.M11) + (y * matrix.M21)) + (z * matrix.M31)) + (w * matrix.M41);
                destinationArray[destinationIndex].Y = (((x * matrix.M12) + (y * matrix.M22)) + (z * matrix.M32)) + (w * matrix.M42);
                destinationArray[destinationIndex].Z = (((x * matrix.M13) + (y * matrix.M23)) + (z * matrix.M33)) + (w * matrix.M43);
                destinationArray[destinationIndex].W = (((x * matrix.M14) + (y * matrix.M24)) + (z * matrix.M34)) + (w * matrix.M44);
                sourceIndex++;
                destinationIndex++;
                length--;
            }
        }

        public static void Transform(Vector4[] sourceArray, ref Quaternion rotation, Vector4[] destinationArray)
        {
            float num = rotation.X + rotation.X;
            float num2 = rotation.Y + rotation.Y;
            float num3 = rotation.Z + rotation.Z;
            float num4 = rotation.W * num;
            float num5 = rotation.W * num2;
            float num6 = rotation.W * num3;
            float num7 = rotation.X * num;
            float num8 = rotation.X * num2;
            float num9 = rotation.X * num3;
            float num10 = rotation.Y * num2;
            float num11 = rotation.Y * num3;
            float num12 = rotation.Z * num3;
            float num13 = (1f - num10) - num12;
            float num14 = num8 - num6;
            float num15 = num9 + num5;
            float num16 = num8 + num6;
            float num17 = (1f - num7) - num12;
            float num18 = num11 - num4;
            float num19 = num9 - num5;
            float num20 = num11 + num4;
            float num21 = (1f - num7) - num10;
            for (int i = 0; i < sourceArray.Length; i++)
            {
                float x = sourceArray[i].X;
                float y = sourceArray[i].Y;
                float z = sourceArray[i].Z;
                destinationArray[i].X = ((x * num13) + (y * num14)) + (z * num15);
                destinationArray[i].Y = ((x * num16) + (y * num17)) + (z * num18);
                destinationArray[i].Z = ((x * num19) + (y * num20)) + (z * num21);
                destinationArray[i].W = sourceArray[i].W;
            }
        }

        public static void Transform(Vector4[] sourceArray, int sourceIndex, ref Quaternion rotation, Vector4[] destinationArray, int destinationIndex, int length)
        {
            float num = rotation.X + rotation.X;
            float num2 = rotation.Y + rotation.Y;
            float num3 = rotation.Z + rotation.Z;
            float num4 = rotation.W * num;
            float num5 = rotation.W * num2;
            float num6 = rotation.W * num3;
            float num7 = rotation.X * num;
            float num8 = rotation.X * num2;
            float num9 = rotation.X * num3;
            float num10 = rotation.Y * num2;
            float num11 = rotation.Y * num3;
            float num12 = rotation.Z * num3;
            float num13 = (1f - num10) - num12;
            float num14 = num8 - num6;
            float num15 = num9 + num5;
            float num16 = num8 + num6;
            float num17 = (1f - num7) - num12;
            float num18 = num11 - num4;
            float num19 = num9 - num5;
            float num20 = num11 + num4;
            float num21 = (1f - num7) - num10;
            while (length > 0)
            {
                float x = sourceArray[sourceIndex].X;
                float y = sourceArray[sourceIndex].Y;
                float z = sourceArray[sourceIndex].Z;
                float w = sourceArray[sourceIndex].W;
                destinationArray[destinationIndex].X = ((x * num13) + (y * num14)) + (z * num15);
                destinationArray[destinationIndex].Y = ((x * num16) + (y * num17)) + (z * num18);
                destinationArray[destinationIndex].Z = ((x * num19) + (y * num20)) + (z * num21);
                destinationArray[destinationIndex].W = w;
                sourceIndex++;
                destinationIndex++;
                length--;
            }
        }

        public static Vector4 Negate(Vector4 value)
        {
            Vector4 vector;
            vector.X = -value.X;
            vector.Y = -value.Y;
            vector.Z = -value.Z;
            vector.W = -value.W;
            return vector;
        }

        public static void Negate(ref Vector4 value, out Vector4 result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
            result.Z = -value.Z;
            result.W = -value.W;
        }

        public static Vector4 Add(Vector4 value1, Vector4 value2)
        {
            Vector4 vector;
            vector.X = value1.X + value2.X;
            vector.Y = value1.Y + value2.Y;
            vector.Z = value1.Z + value2.Z;
            vector.W = value1.W + value2.W;
            return vector;
        }

        public static void Add(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
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

        public static void Subtract(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
            result.Z = value1.Z - value2.Z;
            result.W = value1.W - value2.W;
        }

        public static Vector4 Multiply(Vector4 value1, Vector4 value2)
        {
            Vector4 vector;
            vector.X = value1.X * value2.X;
            vector.Y = value1.Y * value2.Y;
            vector.Z = value1.Z * value2.Z;
            vector.W = value1.W * value2.W;
            return vector;
        }

        public static void Multiply(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
            result.Z = value1.Z * value2.Z;
            result.W = value1.W * value2.W;
        }

        public static Vector4 Multiply(Vector4 value1, float scaleFactor)
        {
            Vector4 vector;
            vector.X = value1.X * scaleFactor;
            vector.Y = value1.Y * scaleFactor;
            vector.Z = value1.Z * scaleFactor;
            vector.W = value1.W * scaleFactor;
            return vector;
        }

        public static void Multiply(ref Vector4 value1, float scaleFactor, out Vector4 result)
        {
            result.X = value1.X * scaleFactor;
            result.Y = value1.Y * scaleFactor;
            result.Z = value1.Z * scaleFactor;
            result.W = value1.W * scaleFactor;
        }

        public static Vector4 Divide(Vector4 value1, Vector4 value2)
        {
            Vector4 vector;
            vector.X = value1.X / value2.X;
            vector.Y = value1.Y / value2.Y;
            vector.Z = value1.Z / value2.Z;
            vector.W = value1.W / value2.W;
            return vector;
        }

        public static void Divide(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            result.X = value1.X / value2.X;
            result.Y = value1.Y / value2.Y;
            result.Z = value1.Z / value2.Z;
            result.W = value1.W / value2.W;
        }

        public static Vector4 Divide(Vector4 value1, float divider)
        {
            Vector4 vector;
            float num = 1f / divider;
            vector.X = value1.X * num;
            vector.Y = value1.Y * num;
            vector.Z = value1.Z * num;
            vector.W = value1.W * num;
            return vector;
        }

        public static void Divide(ref Vector4 value1, float divider, out Vector4 result)
        {
            float num = 1f / divider;
            result.X = value1.X * num;
            result.Y = value1.Y * num;
            result.Z = value1.Z * num;
            result.W = value1.W * num;
        }

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.X;

                    case 1:
                        return this.Y;

                    case 2:
                        return this.Z;

                    case 3:
                        return this.W;
                }
                throw new Exception("Index out of bounds");
            }
            set
            {
                switch (index)
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

                    case 3:
                        this.W = value;
                        return;
                }
                throw new Exception("Index out of bounds");
            }
        }
    }
}

