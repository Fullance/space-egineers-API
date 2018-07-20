namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using Unsharper;

    [Serializable, StructLayout(LayoutKind.Explicit), ProtoContract]
    public struct Matrix3x3 : IEquatable<Matrix3x3>
    {
        public static Matrix3x3 Identity;
        [FieldOffset(0)]
        private F9 M;
        [ProtoMember(0x24), FieldOffset(0)]
        public float M11;
        [ProtoMember(0x2a), FieldOffset(4)]
        public float M12;
        [ProtoMember(0x30), FieldOffset(8)]
        public float M13;
        [ProtoMember(0x36), FieldOffset(12)]
        public float M21;
        [ProtoMember(60), FieldOffset(0x10)]
        public float M22;
        [ProtoMember(0x42), FieldOffset(20)]
        public float M23;
        [ProtoMember(0x48), FieldOffset(0x18)]
        public float M31;
        [ProtoMember(0x4e), FieldOffset(0x1c)]
        public float M32;
        [ProtoMember(0x54), FieldOffset(0x20)]
        public float M33;
        public static Matrix3x3 Zero;

        static Matrix3x3()
        {
            Identity = new Matrix3x3(1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 1f);
            Zero = new Matrix3x3(0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f);
        }

        public Matrix3x3(Matrix3x3 other)
        {
            this.M11 = other.M11;
            this.M12 = other.M12;
            this.M13 = other.M13;
            this.M21 = other.M21;
            this.M22 = other.M22;
            this.M23 = other.M23;
            this.M31 = other.M31;
            this.M32 = other.M32;
            this.M33 = other.M33;
        }

        public Matrix3x3(MatrixD other)
        {
            this.M11 = (float) other.M11;
            this.M12 = (float) other.M12;
            this.M13 = (float) other.M13;
            this.M21 = (float) other.M21;
            this.M22 = (float) other.M22;
            this.M23 = (float) other.M23;
            this.M31 = (float) other.M31;
            this.M32 = (float) other.M32;
            this.M33 = (float) other.M33;
        }

        public Matrix3x3(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
        {
            this.M11 = m11;
            this.M12 = m12;
            this.M13 = m13;
            this.M21 = m21;
            this.M22 = m22;
            this.M23 = m23;
            this.M31 = m31;
            this.M32 = m32;
            this.M33 = m33;
        }

        public static void Add(ref Matrix3x3 matrix1, ref Matrix3x3 matrix2, out Matrix3x3 result)
        {
            result.M11 = matrix1.M11 + matrix2.M11;
            result.M12 = matrix1.M12 + matrix2.M12;
            result.M13 = matrix1.M13 + matrix2.M13;
            result.M21 = matrix1.M21 + matrix2.M21;
            result.M22 = matrix1.M22 + matrix2.M22;
            result.M23 = matrix1.M23 + matrix2.M23;
            result.M31 = matrix1.M31 + matrix2.M31;
            result.M32 = matrix1.M32 + matrix2.M32;
            result.M33 = matrix1.M33 + matrix2.M33;
        }

        public static Matrix3x3 AlignRotationToAxes(ref Matrix3x3 toAlign, ref Matrix3x3 axisDefinitionMatrix)
        {
            Matrix3x3 identity = Identity;
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;
            float num = toAlign.Right.Dot(axisDefinitionMatrix.Right);
            float num2 = toAlign.Right.Dot(axisDefinitionMatrix.Up);
            float num3 = toAlign.Right.Dot(axisDefinitionMatrix.Backward);
            if (Math.Abs(num) > Math.Abs(num2))
            {
                if (Math.Abs(num) > Math.Abs(num3))
                {
                    identity.Right = (num > 0f) ? axisDefinitionMatrix.Right : axisDefinitionMatrix.Left;
                    flag = true;
                }
                else
                {
                    identity.Right = (num3 > 0f) ? axisDefinitionMatrix.Backward : axisDefinitionMatrix.Forward;
                    flag3 = true;
                }
            }
            else if (Math.Abs(num2) > Math.Abs(num3))
            {
                identity.Right = (num2 > 0f) ? axisDefinitionMatrix.Up : axisDefinitionMatrix.Down;
                flag2 = true;
            }
            else
            {
                identity.Right = (num3 > 0f) ? axisDefinitionMatrix.Backward : axisDefinitionMatrix.Forward;
                flag3 = true;
            }
            num = toAlign.Up.Dot(axisDefinitionMatrix.Right);
            num2 = toAlign.Up.Dot(axisDefinitionMatrix.Up);
            num3 = toAlign.Up.Dot(axisDefinitionMatrix.Backward);
            if (flag2 || ((Math.Abs(num) > Math.Abs(num2)) && !flag))
            {
                if ((Math.Abs(num) > Math.Abs(num3)) || flag3)
                {
                    identity.Up = (num > 0f) ? axisDefinitionMatrix.Right : axisDefinitionMatrix.Left;
                    flag = true;
                }
                else
                {
                    identity.Up = (num3 > 0f) ? axisDefinitionMatrix.Backward : axisDefinitionMatrix.Forward;
                    flag3 = true;
                }
            }
            else if ((Math.Abs(num2) > Math.Abs(num3)) || flag3)
            {
                identity.Up = (num2 > 0f) ? axisDefinitionMatrix.Up : axisDefinitionMatrix.Down;
                flag2 = true;
            }
            else
            {
                identity.Up = (num3 > 0f) ? axisDefinitionMatrix.Backward : axisDefinitionMatrix.Forward;
                flag3 = true;
            }
            if (!flag)
            {
                num = toAlign.Backward.Dot(axisDefinitionMatrix.Right);
                identity.Backward = (num > 0f) ? axisDefinitionMatrix.Right : axisDefinitionMatrix.Left;
                return identity;
            }
            if (!flag2)
            {
                num2 = toAlign.Backward.Dot(axisDefinitionMatrix.Up);
                identity.Backward = (num2 > 0f) ? axisDefinitionMatrix.Up : axisDefinitionMatrix.Down;
                return identity;
            }
            num3 = toAlign.Backward.Dot(axisDefinitionMatrix.Backward);
            identity.Backward = (num3 > 0f) ? axisDefinitionMatrix.Backward : axisDefinitionMatrix.Forward;
            return identity;
        }

        [Conditional("DEBUG")]
        public void AssertIsValid()
        {
        }

        public static Matrix3x3 CreateFromAxisAngle(Vector3 axis, float angle)
        {
            Matrix3x3 matrixx;
            float x = axis.X;
            float y = axis.Y;
            float z = axis.Z;
            float num4 = (float) Math.Sin((double) angle);
            float num5 = (float) Math.Cos((double) angle);
            float num6 = x * x;
            float num7 = y * y;
            float num8 = z * z;
            float num9 = x * y;
            float num10 = x * z;
            float num11 = y * z;
            matrixx.M11 = num6 + (num5 * (1f - num6));
            matrixx.M12 = (num9 - (num5 * num9)) + (num4 * z);
            matrixx.M13 = (num10 - (num5 * num10)) - (num4 * y);
            matrixx.M21 = (num9 - (num5 * num9)) - (num4 * z);
            matrixx.M22 = num7 + (num5 * (1f - num7));
            matrixx.M23 = (num11 - (num5 * num11)) + (num4 * x);
            matrixx.M31 = (num10 - (num5 * num10)) + (num4 * y);
            matrixx.M32 = (num11 - (num5 * num11)) - (num4 * x);
            matrixx.M33 = num8 + (num5 * (1f - num8));
            return matrixx;
        }

        public static void CreateFromAxisAngle(ref Vector3 axis, float angle, out Matrix3x3 result)
        {
            float x = axis.X;
            float y = axis.Y;
            float z = axis.Z;
            float num4 = (float) Math.Sin((double) angle);
            float num5 = (float) Math.Cos((double) angle);
            float num6 = x * x;
            float num7 = y * y;
            float num8 = z * z;
            float num9 = x * y;
            float num10 = x * z;
            float num11 = y * z;
            result.M11 = num6 + (num5 * (1f - num6));
            result.M12 = (num9 - (num5 * num9)) + (num4 * z);
            result.M13 = (num10 - (num5 * num10)) - (num4 * y);
            result.M21 = (num9 - (num5 * num9)) - (num4 * z);
            result.M22 = num7 + (num5 * (1f - num7));
            result.M23 = (num11 - (num5 * num11)) + (num4 * x);
            result.M31 = (num10 - (num5 * num10)) + (num4 * y);
            result.M32 = (num11 - (num5 * num11)) - (num4 * x);
            result.M33 = num8 + (num5 * (1f - num8));
        }

        public static Matrix3x3 CreateFromDir(Vector3 dir)
        {
            Vector3 vector2;
            Vector3 vector = new Vector3(0f, 0f, 1f);
            float z = dir.Z;
            if ((z > -0.99999) && (z < 0.99999))
            {
                vector -= (Vector3) (dir * z);
                vector = Vector3.Normalize(vector);
                vector2 = Vector3.Cross(dir, vector);
            }
            else
            {
                vector = new Vector3(dir.Z, 0f, -dir.X);
                vector2 = new Vector3(0f, 1f, 0f);
            }
            Matrix3x3 identity = Identity;
            identity.Right = vector;
            identity.Up = vector2;
            identity.Forward = dir;
            return identity;
        }

        public static Matrix3x3 CreateFromDir(Vector3 dir, Vector3 suggestedUp)
        {
            Vector3 up = Vector3.Cross(Vector3.Cross(dir, suggestedUp), dir);
            return CreateWorld(ref dir, ref up);
        }

        public static Matrix3x3 CreateFromQuaternion(Quaternion quaternion)
        {
            Matrix3x3 matrixx;
            float num = quaternion.X * quaternion.X;
            float num2 = quaternion.Y * quaternion.Y;
            float num3 = quaternion.Z * quaternion.Z;
            float num4 = quaternion.X * quaternion.Y;
            float num5 = quaternion.Z * quaternion.W;
            float num6 = quaternion.Z * quaternion.X;
            float num7 = quaternion.Y * quaternion.W;
            float num8 = quaternion.Y * quaternion.Z;
            float num9 = quaternion.X * quaternion.W;
            matrixx.M11 = (float) (1.0 - (2.0 * (num2 + num3)));
            matrixx.M12 = (float) (2.0 * (num4 + num5));
            matrixx.M13 = (float) (2.0 * (num6 - num7));
            matrixx.M21 = (float) (2.0 * (num4 - num5));
            matrixx.M22 = (float) (1.0 - (2.0 * (num3 + num)));
            matrixx.M23 = (float) (2.0 * (num8 + num9));
            matrixx.M31 = (float) (2.0 * (num6 + num7));
            matrixx.M32 = (float) (2.0 * (num8 - num9));
            matrixx.M33 = (float) (1.0 - (2.0 * (num2 + num)));
            return matrixx;
        }

        public static void CreateFromQuaternion(ref Quaternion quaternion, out Matrix3x3 result)
        {
            float num = quaternion.X * quaternion.X;
            float num2 = quaternion.Y * quaternion.Y;
            float num3 = quaternion.Z * quaternion.Z;
            float num4 = quaternion.X * quaternion.Y;
            float num5 = quaternion.Z * quaternion.W;
            float num6 = quaternion.Z * quaternion.X;
            float num7 = quaternion.Y * quaternion.W;
            float num8 = quaternion.Y * quaternion.Z;
            float num9 = quaternion.X * quaternion.W;
            result.M11 = (float) (1.0 - (2.0 * (num2 + num3)));
            result.M12 = (float) (2.0 * (num4 + num5));
            result.M13 = (float) (2.0 * (num6 - num7));
            result.M21 = (float) (2.0 * (num4 - num5));
            result.M22 = (float) (1.0 - (2.0 * (num3 + num)));
            result.M23 = (float) (2.0 * (num8 + num9));
            result.M31 = (float) (2.0 * (num6 + num7));
            result.M32 = (float) (2.0 * (num8 - num9));
            result.M33 = (float) (1.0 - (2.0 * (num2 + num)));
        }

        public static Matrix3x3 CreateFromYawPitchRoll(float yaw, float pitch, float roll)
        {
            Quaternion quaternion;
            Matrix3x3 matrixx;
            Quaternion.CreateFromYawPitchRoll(yaw, pitch, roll, out quaternion);
            CreateFromQuaternion(ref quaternion, out matrixx);
            return matrixx;
        }

        public static void CreateFromYawPitchRoll(float yaw, float pitch, float roll, out Matrix3x3 result)
        {
            Quaternion quaternion;
            Quaternion.CreateFromYawPitchRoll(yaw, pitch, roll, out quaternion);
            CreateFromQuaternion(ref quaternion, out result);
        }

        public static void CreateRotationFromTwoVectors(ref Vector3 fromVector, ref Vector3 toVector, out Matrix3x3 resultMatrix)
        {
            Vector3 vector3;
            Vector3 vector4;
            Vector3 vector = Vector3.Normalize(fromVector);
            Vector3 vector2 = Vector3.Normalize(toVector);
            Vector3.Cross(ref vector, ref vector2, out vector3);
            vector3.Normalize();
            Vector3.Cross(ref vector, ref vector3, out vector4);
            Matrix3x3 matrixx = new Matrix3x3(vector.X, vector3.X, vector4.X, vector.Y, vector3.Y, vector4.Y, vector.Z, vector3.Z, vector4.Z);
            Vector3.Cross(ref vector2, ref vector3, out vector4);
            Matrix3x3 matrixx2 = new Matrix3x3(vector2.X, vector2.Y, vector2.Z, vector3.X, vector3.Y, vector3.Z, vector4.X, vector4.Y, vector4.Z);
            Multiply(ref matrixx, ref matrixx2, out resultMatrix);
        }

        public static Matrix3x3 CreateRotationX(float radians)
        {
            Matrix3x3 matrixx;
            float num = (float) Math.Cos((double) radians);
            float num2 = (float) Math.Sin((double) radians);
            matrixx.M11 = 1f;
            matrixx.M12 = 0f;
            matrixx.M13 = 0f;
            matrixx.M21 = 0f;
            matrixx.M22 = num;
            matrixx.M23 = num2;
            matrixx.M31 = 0f;
            matrixx.M32 = -num2;
            matrixx.M33 = num;
            return matrixx;
        }

        public static void CreateRotationX(float radians, out Matrix3x3 result)
        {
            float num = (float) Math.Cos((double) radians);
            float num2 = (float) Math.Sin((double) radians);
            result.M11 = 1f;
            result.M12 = 0f;
            result.M13 = 0f;
            result.M21 = 0f;
            result.M22 = num;
            result.M23 = num2;
            result.M31 = 0f;
            result.M32 = -num2;
            result.M33 = num;
        }

        public static Matrix3x3 CreateRotationY(float radians)
        {
            Matrix3x3 matrixx;
            float num = (float) Math.Cos((double) radians);
            float num2 = (float) Math.Sin((double) radians);
            matrixx.M11 = num;
            matrixx.M12 = 0f;
            matrixx.M13 = -num2;
            matrixx.M21 = 0f;
            matrixx.M22 = 1f;
            matrixx.M23 = 0f;
            matrixx.M31 = num2;
            matrixx.M32 = 0f;
            matrixx.M33 = num;
            return matrixx;
        }

        public static void CreateRotationY(float radians, out Matrix3x3 result)
        {
            float num = (float) Math.Cos((double) radians);
            float num2 = (float) Math.Sin((double) radians);
            result.M11 = num;
            result.M12 = 0f;
            result.M13 = -num2;
            result.M21 = 0f;
            result.M22 = 1f;
            result.M23 = 0f;
            result.M31 = num2;
            result.M32 = 0f;
            result.M33 = num;
        }

        public static Matrix3x3 CreateRotationZ(float radians)
        {
            Matrix3x3 matrixx;
            float num = (float) Math.Cos((double) radians);
            float num2 = (float) Math.Sin((double) radians);
            matrixx.M11 = num;
            matrixx.M12 = num2;
            matrixx.M13 = 0f;
            matrixx.M21 = -num2;
            matrixx.M22 = num;
            matrixx.M23 = 0f;
            matrixx.M31 = 0f;
            matrixx.M32 = 0f;
            matrixx.M33 = 1f;
            return matrixx;
        }

        public static void CreateRotationZ(float radians, out Matrix3x3 result)
        {
            float num = (float) Math.Cos((double) radians);
            float num2 = (float) Math.Sin((double) radians);
            result.M11 = num;
            result.M12 = num2;
            result.M13 = 0f;
            result.M21 = -num2;
            result.M22 = num;
            result.M23 = 0f;
            result.M31 = 0f;
            result.M32 = 0f;
            result.M33 = 1f;
        }

        public static Matrix3x3 CreateScale(float scale)
        {
            Matrix3x3 matrixx;
            float num = scale;
            matrixx.M11 = num;
            matrixx.M12 = 0f;
            matrixx.M13 = 0f;
            matrixx.M21 = 0f;
            matrixx.M22 = num;
            matrixx.M23 = 0f;
            matrixx.M31 = 0f;
            matrixx.M32 = 0f;
            matrixx.M33 = num;
            return matrixx;
        }

        public static Matrix3x3 CreateScale(Vector3 scales)
        {
            Matrix3x3 matrixx;
            float x = scales.X;
            float y = scales.Y;
            float z = scales.Z;
            matrixx.M11 = x;
            matrixx.M12 = 0f;
            matrixx.M13 = 0f;
            matrixx.M21 = 0f;
            matrixx.M22 = y;
            matrixx.M23 = 0f;
            matrixx.M31 = 0f;
            matrixx.M32 = 0f;
            matrixx.M33 = z;
            return matrixx;
        }

        public static void CreateScale(ref Vector3 scales, out Matrix3x3 result)
        {
            float x = scales.X;
            float y = scales.Y;
            float z = scales.Z;
            result.M11 = x;
            result.M12 = 0f;
            result.M13 = 0f;
            result.M21 = 0f;
            result.M22 = y;
            result.M23 = 0f;
            result.M31 = 0f;
            result.M32 = 0f;
            result.M33 = z;
        }

        public static void CreateScale(float scale, out Matrix3x3 result)
        {
            float num = scale;
            result.M11 = num;
            result.M12 = 0f;
            result.M13 = 0f;
            result.M21 = 0f;
            result.M22 = num;
            result.M23 = 0f;
            result.M31 = 0f;
            result.M32 = 0f;
            result.M33 = num;
        }

        public static Matrix3x3 CreateScale(float xScale, float yScale, float zScale)
        {
            Matrix3x3 matrixx;
            float num = xScale;
            float num2 = yScale;
            float num3 = zScale;
            matrixx.M11 = num;
            matrixx.M12 = 0f;
            matrixx.M13 = 0f;
            matrixx.M21 = 0f;
            matrixx.M22 = num2;
            matrixx.M23 = 0f;
            matrixx.M31 = 0f;
            matrixx.M32 = 0f;
            matrixx.M33 = num3;
            return matrixx;
        }

        public static void CreateScale(float xScale, float yScale, float zScale, out Matrix3x3 result)
        {
            float num = xScale;
            float num2 = yScale;
            float num3 = zScale;
            result.M11 = num;
            result.M12 = 0f;
            result.M13 = 0f;
            result.M21 = 0f;
            result.M22 = num2;
            result.M23 = 0f;
            result.M31 = 0f;
            result.M32 = 0f;
            result.M33 = num3;
        }

        public static Matrix3x3 CreateWorld(ref Vector3 forward, ref Vector3 up)
        {
            Vector3 vector;
            Vector3 vector2;
            Vector3 vector3;
            Vector3 vector4;
            Matrix3x3 matrixx;
            Vector3.Normalize(ref forward, out vector);
            vector = -vector;
            Vector3.Cross(ref up, ref vector, out vector2);
            Vector3.Normalize(ref vector2, out vector3);
            Vector3.Cross(ref vector, ref vector3, out vector4);
            matrixx.M11 = vector3.X;
            matrixx.M12 = vector3.Y;
            matrixx.M13 = vector3.Z;
            matrixx.M21 = vector4.X;
            matrixx.M22 = vector4.Y;
            matrixx.M23 = vector4.Z;
            matrixx.M31 = vector.X;
            matrixx.M32 = vector.Y;
            matrixx.M33 = vector.Z;
            return matrixx;
        }

        public float Determinant() => 
            (((this.M11 * ((this.M22 * this.M33) - (this.M32 * this.M23))) - (this.M12 * ((this.M21 * this.M33) - (this.M23 * this.M31)))) + (this.M13 * ((this.M21 * this.M32) - (this.M22 * this.M31))));

        public static void Divide(ref Matrix3x3 matrix1, ref Matrix3x3 matrix2, out Matrix3x3 result)
        {
            result.M11 = matrix1.M11 / matrix2.M11;
            result.M12 = matrix1.M12 / matrix2.M12;
            result.M13 = matrix1.M13 / matrix2.M13;
            result.M21 = matrix1.M21 / matrix2.M21;
            result.M22 = matrix1.M22 / matrix2.M22;
            result.M23 = matrix1.M23 / matrix2.M23;
            result.M31 = matrix1.M31 / matrix2.M31;
            result.M32 = matrix1.M32 / matrix2.M32;
            result.M33 = matrix1.M33 / matrix2.M33;
        }

        public static void Divide(ref Matrix3x3 matrix1, float divider, out Matrix3x3 result)
        {
            float num = 1f / divider;
            result.M11 = matrix1.M11 * num;
            result.M12 = matrix1.M12 * num;
            result.M13 = matrix1.M13 * num;
            result.M21 = matrix1.M21 * num;
            result.M22 = matrix1.M22 * num;
            result.M23 = matrix1.M23 * num;
            result.M31 = matrix1.M31 * num;
            result.M32 = matrix1.M32 * num;
            result.M33 = matrix1.M33 * num;
        }

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is Matrix3x3)
            {
                flag = this.Equals((Matrix3x3) obj);
            }
            return flag;
        }

        public bool Equals(Matrix3x3 other) => 
            (((((this.M11 == other.M11) && (this.M22 == other.M22)) && ((this.M33 == other.M33) && (this.M12 == other.M12))) && (((this.M13 == other.M13) && (this.M21 == other.M21)) && ((this.M23 == other.M23) && (this.M31 == other.M31)))) && (this.M32 == other.M32));

        public bool EqualsFast(ref Matrix3x3 other, float epsilon = 0.0001f)
        {
            float num = this.M21 - other.M21;
            float num2 = this.M22 - other.M22;
            float num3 = this.M23 - other.M23;
            float num4 = this.M31 - other.M31;
            float num5 = this.M32 - other.M32;
            float num6 = this.M33 - other.M33;
            float num7 = epsilon * epsilon;
            return (((((num * num) + (num2 * num2)) + (num3 * num3)) < num7) & ((((num4 * num4) + (num5 * num5)) + (num6 * num6)) < num7));
        }

        public Base6Directions.Direction GetClosestDirection(Vector3 referenceVector) => 
            this.GetClosestDirection(ref referenceVector);

        public Base6Directions.Direction GetClosestDirection(ref Vector3 referenceVector)
        {
            float num = Vector3.Dot(referenceVector, this.Right);
            float num2 = Vector3.Dot(referenceVector, this.Up);
            float num3 = Vector3.Dot(referenceVector, this.Backward);
            float num4 = Math.Abs(num);
            float num5 = Math.Abs(num2);
            float num6 = Math.Abs(num3);
            if (num4 > num5)
            {
                if (num4 > num6)
                {
                    if (num > 0f)
                    {
                        return Base6Directions.Direction.Right;
                    }
                    return Base6Directions.Direction.Left;
                }
                if (num3 > 0f)
                {
                    return Base6Directions.Direction.Backward;
                }
                return Base6Directions.Direction.Forward;
            }
            if (num5 > num6)
            {
                if (num2 > 0f)
                {
                    return Base6Directions.Direction.Up;
                }
                return Base6Directions.Direction.Down;
            }
            if (num3 > 0f)
            {
                return Base6Directions.Direction.Backward;
            }
            return Base6Directions.Direction.Forward;
        }

        public Vector3 GetDirectionVector(Base6Directions.Direction direction)
        {
            switch (direction)
            {
                case Base6Directions.Direction.Forward:
                    return this.Forward;

                case Base6Directions.Direction.Backward:
                    return this.Backward;

                case Base6Directions.Direction.Left:
                    return this.Left;

                case Base6Directions.Direction.Right:
                    return this.Right;

                case Base6Directions.Direction.Up:
                    return this.Up;

                case Base6Directions.Direction.Down:
                    return this.Down;
            }
            return Vector3.Zero;
        }

        public static bool GetEulerAnglesXYZ(ref Matrix3x3 mat, out Vector3 xyz)
        {
            float x = mat.GetRow(0).X;
            float y = mat.GetRow(0).Y;
            float z = mat.GetRow(0).Z;
            float num4 = mat.GetRow(1).X;
            float num5 = mat.GetRow(1).Y;
            float num6 = mat.GetRow(1).Z;
            float single1 = mat.GetRow(2).X;
            float single2 = mat.GetRow(2).Y;
            float num7 = mat.GetRow(2).Z;
            float num8 = z;
            if (num8 < 1f)
            {
                if (num8 > -1f)
                {
                    xyz = new Vector3((float) Math.Atan2((double) -num6, (double) num7), (float) Math.Asin((double) z), (float) Math.Atan2((double) -y, (double) x));
                    return true;
                }
                xyz = new Vector3((float) -Math.Atan2((double) num4, (double) num5), -1.570796f, 0f);
                return false;
            }
            xyz = new Vector3((float) Math.Atan2((double) num4, (double) num5), -1.570796f, 0f);
            return false;
        }

        public override int GetHashCode() => 
            ((((((((this.M11.GetHashCode() + this.M12.GetHashCode()) + this.M13.GetHashCode()) + this.M21.GetHashCode()) + this.M22.GetHashCode()) + this.M23.GetHashCode()) + this.M31.GetHashCode()) + this.M32.GetHashCode()) + this.M33.GetHashCode());

        public Matrix3x3 GetOrientation()
        {
            Matrix3x3 identity = Identity;
            identity.Forward = this.Forward;
            identity.Up = this.Up;
            identity.Right = this.Right;
            return identity;
        }

        public unsafe Vector3 GetRow(int row)
        {
            fixed (float* numRef = &this.M11)
            {
                float* numPtr = numRef + ((row * 4) * 4);
                return new Vector3(numPtr[0], numPtr[4], numPtr[8]);
            }
        }

        public static void Invert(ref Matrix3x3 matrix, out Matrix3x3 result)
        {
            float num = matrix.Determinant();
            float num2 = 1f / num;
            result.M11 = ((matrix.M22 * matrix.M33) - (matrix.M32 * matrix.M23)) * num2;
            result.M12 = ((matrix.M13 * matrix.M32) - (matrix.M12 * matrix.M33)) * num2;
            result.M13 = ((matrix.M12 * matrix.M23) - (matrix.M13 * matrix.M22)) * num2;
            result.M21 = ((matrix.M23 * matrix.M31) - (matrix.M21 * matrix.M33)) * num2;
            result.M22 = ((matrix.M11 * matrix.M33) - (matrix.M13 * matrix.M31)) * num2;
            result.M23 = ((matrix.M21 * matrix.M13) - (matrix.M11 * matrix.M23)) * num2;
            result.M31 = ((matrix.M21 * matrix.M32) - (matrix.M31 * matrix.M22)) * num2;
            result.M32 = ((matrix.M31 * matrix.M12) - (matrix.M11 * matrix.M32)) * num2;
            result.M33 = ((matrix.M11 * matrix.M22) - (matrix.M21 * matrix.M12)) * num2;
        }

        public bool IsMirrored() => 
            (this.Determinant() < 0f);

        public bool IsNan() => 
            float.IsNaN((((((((this.M11 + this.M12) + this.M13) + this.M21) + this.M22) + this.M23) + this.M31) + this.M32) + this.M33);

        public bool IsOrthogonal() => 
            (((((Math.Abs(this.Up.LengthSquared()) - 1f) < 0.0001f) && ((Math.Abs(this.Right.LengthSquared()) - 1f) < 0.0001f)) && (((Math.Abs(this.Forward.LengthSquared()) - 1f) < 0.0001f) && (Math.Abs(this.Right.Dot(this.Up)) < 0.0001f))) && (Math.Abs(this.Right.Dot(this.Forward)) < 0.0001f));

        public bool IsRotation()
        {
            float num = 0.01f;
            if (Math.Abs(this.Right.Dot(this.Up)) > num)
            {
                return false;
            }
            if (Math.Abs(this.Right.Dot(this.Backward)) > num)
            {
                return false;
            }
            if (Math.Abs(this.Up.Dot(this.Backward)) > num)
            {
                return false;
            }
            if (Math.Abs((float) (this.Right.LengthSquared() - 1f)) > num)
            {
                return false;
            }
            if (Math.Abs((float) (this.Up.LengthSquared() - 1f)) > num)
            {
                return false;
            }
            if (Math.Abs((float) (this.Backward.LengthSquared() - 1f)) > num)
            {
                return false;
            }
            return true;
        }

        public bool IsValid() => 
            ((((((((this.M11 + this.M12) + this.M13) + this.M21) + this.M22) + this.M23) + this.M31) + this.M32) + this.M33).IsValid();

        public static void Lerp(ref Matrix3x3 matrix1, ref Matrix3x3 matrix2, float amount, out Matrix3x3 result)
        {
            result.M11 = matrix1.M11 + ((matrix2.M11 - matrix1.M11) * amount);
            result.M12 = matrix1.M12 + ((matrix2.M12 - matrix1.M12) * amount);
            result.M13 = matrix1.M13 + ((matrix2.M13 - matrix1.M13) * amount);
            result.M21 = matrix1.M21 + ((matrix2.M21 - matrix1.M21) * amount);
            result.M22 = matrix1.M22 + ((matrix2.M22 - matrix1.M22) * amount);
            result.M23 = matrix1.M23 + ((matrix2.M23 - matrix1.M23) * amount);
            result.M31 = matrix1.M31 + ((matrix2.M31 - matrix1.M31) * amount);
            result.M32 = matrix1.M32 + ((matrix2.M32 - matrix1.M32) * amount);
            result.M33 = matrix1.M33 + ((matrix2.M33 - matrix1.M33) * amount);
        }

        public static void Multiply(ref Matrix3x3 matrix1, ref Matrix3x3 matrix2, out Matrix3x3 result)
        {
            float num = ((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31);
            float num2 = ((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32);
            float num3 = ((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33);
            float num4 = ((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31);
            float num5 = ((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32);
            float num6 = ((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33);
            float num7 = ((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31);
            float num8 = ((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32);
            float num9 = ((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33);
            result.M11 = num;
            result.M12 = num2;
            result.M13 = num3;
            result.M21 = num4;
            result.M22 = num5;
            result.M23 = num6;
            result.M31 = num7;
            result.M32 = num8;
            result.M33 = num9;
        }

        public static void Multiply(ref Matrix3x3 matrix1, float scaleFactor, out Matrix3x3 result)
        {
            float num = scaleFactor;
            result.M11 = matrix1.M11 * num;
            result.M12 = matrix1.M12 * num;
            result.M13 = matrix1.M13 * num;
            result.M21 = matrix1.M21 * num;
            result.M22 = matrix1.M22 * num;
            result.M23 = matrix1.M23 * num;
            result.M31 = matrix1.M31 * num;
            result.M32 = matrix1.M32 * num;
            result.M33 = matrix1.M33 * num;
        }

        public static void Negate(ref Matrix3x3 matrix, out Matrix3x3 result)
        {
            result.M11 = -matrix.M11;
            result.M12 = -matrix.M12;
            result.M13 = -matrix.M13;
            result.M21 = -matrix.M21;
            result.M22 = -matrix.M22;
            result.M23 = -matrix.M23;
            result.M31 = -matrix.M31;
            result.M32 = -matrix.M32;
            result.M33 = -matrix.M33;
        }

        public static Matrix3x3 Normalize(Matrix3x3 matrix)
        {
            Matrix3x3 matrixx = matrix;
            matrixx.Right = Vector3.Normalize(matrixx.Right);
            matrixx.Up = Vector3.Normalize(matrixx.Up);
            matrixx.Forward = Vector3.Normalize(matrixx.Forward);
            return matrixx;
        }

        public static Matrix3x3 Orthogonalize(Matrix3x3 rotationMatrix)
        {
            Matrix3x3 matrixx = rotationMatrix;
            matrixx.Right = Vector3.Normalize(matrixx.Right);
            matrixx.Up = Vector3.Normalize(matrixx.Up - ((Vector3) (matrixx.Right * matrixx.Up.Dot(matrixx.Right))));
            matrixx.Backward = Vector3.Normalize((Vector3) ((matrixx.Backward - (matrixx.Right * matrixx.Backward.Dot(matrixx.Right))) - (matrixx.Up * matrixx.Backward.Dot(matrixx.Up))));
            return matrixx;
        }

        [UnsharperDisableReflection]
        public static void Rescale(ref Matrix3x3 matrix, float scale)
        {
            matrix.M11 *= scale;
            matrix.M12 *= scale;
            matrix.M13 *= scale;
            matrix.M21 *= scale;
            matrix.M22 *= scale;
            matrix.M23 *= scale;
            matrix.M31 *= scale;
            matrix.M32 *= scale;
            matrix.M33 *= scale;
        }

        [UnsharperDisableReflection]
        public static void Rescale(ref Matrix3x3 matrix, ref Vector3 scale)
        {
            matrix.M11 *= scale.X;
            matrix.M12 *= scale.X;
            matrix.M13 *= scale.X;
            matrix.M21 *= scale.Y;
            matrix.M22 *= scale.Y;
            matrix.M23 *= scale.Y;
            matrix.M31 *= scale.Z;
            matrix.M32 *= scale.Z;
            matrix.M33 *= scale.Z;
        }

        [UnsharperDisableReflection]
        public static Matrix3x3 Rescale(Matrix3x3 matrix, float scale)
        {
            Rescale(ref matrix, scale);
            return matrix;
        }

        [UnsharperDisableReflection]
        public static Matrix3x3 Rescale(Matrix3x3 matrix, Vector3 scale)
        {
            Rescale(ref matrix, ref scale);
            return matrix;
        }

        public static Matrix3x3 Round(ref Matrix3x3 matrix)
        {
            Matrix3x3 matrixx = matrix;
            matrixx.Right = (Vector3) Vector3I.Round(matrixx.Right);
            matrixx.Up = (Vector3) Vector3I.Round(matrixx.Up);
            matrixx.Forward = (Vector3) Vector3I.Round(matrixx.Forward);
            return matrixx;
        }

        public void SetDirectionVector(Base6Directions.Direction direction, Vector3 newValue)
        {
            switch (direction)
            {
                case Base6Directions.Direction.Forward:
                    this.Forward = newValue;
                    return;

                case Base6Directions.Direction.Backward:
                    this.Backward = newValue;
                    return;

                case Base6Directions.Direction.Left:
                    this.Left = newValue;
                    return;

                case Base6Directions.Direction.Right:
                    this.Right = newValue;
                    return;

                case Base6Directions.Direction.Up:
                    this.Up = newValue;
                    return;

                case Base6Directions.Direction.Down:
                    this.Down = newValue;
                    return;
            }
        }

        public unsafe void SetRow(int row, Vector3 value)
        {
            fixed (float* numRef = &this.M11)
            {
                float* numPtr = numRef + ((row * 4) * 4);
                numPtr[0] = value.X;
                numPtr[4] = value.Y;
                numPtr[8] = value.Z;
            }
        }

        public static void Slerp(ref Matrix3x3 matrix1, ref Matrix3x3 matrix2, float amount, out Matrix3x3 result)
        {
            Quaternion quaternion;
            Quaternion quaternion2;
            Quaternion quaternion3;
            Quaternion.CreateFromRotationMatrix(ref matrix1, out quaternion);
            Quaternion.CreateFromRotationMatrix(ref matrix2, out quaternion2);
            Quaternion.Slerp(ref quaternion, ref quaternion2, amount, out quaternion3);
            CreateFromQuaternion(ref quaternion3, out result);
        }

        public static void SlerpScale(ref Matrix3x3 matrix1, ref Matrix3x3 matrix2, float amount, out Matrix3x3 result)
        {
            Vector3 scale = matrix1.Scale;
            Vector3 vector2 = matrix2.Scale;
            if ((scale.LengthSquared() < 1E-06f) || (vector2.LengthSquared() < 1E-06f))
            {
                result = Zero;
            }
            else
            {
                Quaternion quaternion;
                Quaternion quaternion2;
                Quaternion quaternion3;
                Matrix3x3 matrix = Normalize(matrix1);
                Matrix3x3 matrixx2 = Normalize(matrix2);
                Quaternion.CreateFromRotationMatrix(ref matrix, out quaternion);
                Quaternion.CreateFromRotationMatrix(ref matrixx2, out quaternion2);
                Quaternion.Slerp(ref quaternion, ref quaternion2, amount, out quaternion3);
                CreateFromQuaternion(ref quaternion3, out result);
                Vector3 vector3 = Vector3.Lerp(scale, vector2, amount);
                Rescale(ref result, ref vector3);
            }
        }

        public static void Subtract(ref Matrix3x3 matrix1, ref Matrix3x3 matrix2, out Matrix3x3 result)
        {
            result.M11 = matrix1.M11 - matrix2.M11;
            result.M12 = matrix1.M12 - matrix2.M12;
            result.M13 = matrix1.M13 - matrix2.M13;
            result.M21 = matrix1.M21 - matrix2.M21;
            result.M22 = matrix1.M22 - matrix2.M22;
            result.M23 = matrix1.M23 - matrix2.M23;
            result.M31 = matrix1.M31 - matrix2.M31;
            result.M32 = matrix1.M32 - matrix2.M32;
            result.M33 = matrix1.M33 - matrix2.M33;
        }

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return ("{ " + string.Format(currentCulture, "{{M11:{0} M12:{1} M13:{2}}} ", this.M11.ToString(currentCulture), this.M12.ToString(currentCulture), this.M13.ToString(currentCulture) + string.Format(currentCulture, "{{M21:{0} M22:{1} M23:{2}}} ", this.M21.ToString(currentCulture), this.M22.ToString(currentCulture), this.M23.ToString(currentCulture) + string.Format(currentCulture, "{{M31:{0} M32:{1} M33:{2}}} ", this.M31.ToString(currentCulture), this.M32.ToString(currentCulture), this.M33.ToString(currentCulture)))) + "}");
        }

        public static void Transform(ref Matrix3x3 value, ref Quaternion rotation, out Matrix3x3 result)
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
            float num22 = ((value.M11 * num13) + (value.M12 * num14)) + (value.M13 * num15);
            float num23 = ((value.M11 * num16) + (value.M12 * num17)) + (value.M13 * num18);
            float num24 = ((value.M11 * num19) + (value.M12 * num20)) + (value.M13 * num21);
            float num25 = ((value.M21 * num13) + (value.M22 * num14)) + (value.M23 * num15);
            float num26 = ((value.M21 * num16) + (value.M22 * num17)) + (value.M23 * num18);
            float num27 = ((value.M21 * num19) + (value.M22 * num20)) + (value.M23 * num21);
            float num28 = ((value.M31 * num13) + (value.M32 * num14)) + (value.M33 * num15);
            float num29 = ((value.M31 * num16) + (value.M32 * num17)) + (value.M33 * num18);
            float num30 = ((value.M31 * num19) + (value.M32 * num20)) + (value.M33 * num21);
            result.M11 = num22;
            result.M12 = num23;
            result.M13 = num24;
            result.M21 = num25;
            result.M22 = num26;
            result.M23 = num27;
            result.M31 = num28;
            result.M32 = num29;
            result.M33 = num30;
        }

        public void Transpose()
        {
            float num = this.M12;
            float num2 = this.M13;
            float num3 = this.M21;
            float num4 = this.M23;
            float num5 = this.M31;
            float num6 = this.M32;
            this.M12 = num3;
            this.M13 = num5;
            this.M21 = num;
            this.M23 = num6;
            this.M31 = num2;
            this.M32 = num4;
        }

        public static void Transpose(ref Matrix3x3 matrix, out Matrix3x3 result)
        {
            float num = matrix.M11;
            float num2 = matrix.M12;
            float num3 = matrix.M13;
            float num4 = matrix.M21;
            float num5 = matrix.M22;
            float num6 = matrix.M23;
            float num7 = matrix.M31;
            float num8 = matrix.M32;
            float num9 = matrix.M33;
            result.M11 = num;
            result.M12 = num4;
            result.M13 = num7;
            result.M21 = num2;
            result.M22 = num5;
            result.M23 = num8;
            result.M31 = num3;
            result.M32 = num6;
            result.M33 = num9;
        }

        public Vector3 Backward
        {
            get
            {
                Vector3 vector;
                vector.X = this.M31;
                vector.Y = this.M32;
                vector.Z = this.M33;
                return vector;
            }
            set
            {
                this.M31 = value.X;
                this.M32 = value.Y;
                this.M33 = value.Z;
            }
        }

        public Vector3 Col0
        {
            get
            {
                Vector3 vector;
                vector.X = this.M11;
                vector.Y = this.M21;
                vector.Z = this.M31;
                return vector;
            }
        }

        public Vector3 Col1
        {
            get
            {
                Vector3 vector;
                vector.X = this.M12;
                vector.Y = this.M22;
                vector.Z = this.M32;
                return vector;
            }
        }

        public Vector3 Col2
        {
            get
            {
                Vector3 vector;
                vector.X = this.M13;
                vector.Y = this.M23;
                vector.Z = this.M33;
                return vector;
            }
        }

        public Vector3 Down
        {
            get
            {
                Vector3 vector;
                vector.X = -this.M21;
                vector.Y = -this.M22;
                vector.Z = -this.M23;
                return vector;
            }
            set
            {
                this.M21 = -value.X;
                this.M22 = -value.Y;
                this.M23 = -value.Z;
            }
        }

        public Vector3 Forward
        {
            get
            {
                Vector3 vector;
                vector.X = -this.M31;
                vector.Y = -this.M32;
                vector.Z = -this.M33;
                return vector;
            }
            set
            {
                this.M31 = -value.X;
                this.M32 = -value.Y;
                this.M33 = -value.Z;
            }
        }

        public float this[int row, int column]
        {
            get
            {
                fixed (float* numRef = &this.M11)
                {
                    return numRef[((row * 4) + column) * 4];
                }
            }
            set
            {
                fixed (float* numRef = &this.M11)
                {
                    numRef[((row * 4) + column) * 4] = value;
                }
            }
        }

        public Vector3 Left
        {
            get
            {
                Vector3 vector;
                vector.X = -this.M11;
                vector.Y = -this.M12;
                vector.Z = -this.M13;
                return vector;
            }
            set
            {
                this.M11 = -value.X;
                this.M12 = -value.Y;
                this.M13 = -value.Z;
            }
        }

        public Vector3 Right
        {
            get
            {
                Vector3 vector;
                vector.X = this.M11;
                vector.Y = this.M12;
                vector.Z = this.M13;
                return vector;
            }
            set
            {
                this.M11 = value.X;
                this.M12 = value.Y;
                this.M13 = value.Z;
            }
        }

        public Vector3 Scale =>
            new Vector3(this.Right.Length(), this.Up.Length(), this.Forward.Length());

        public Vector3 Up
        {
            get
            {
                Vector3 vector;
                vector.X = this.M21;
                vector.Y = this.M22;
                vector.Z = this.M23;
                return vector;
            }
            set
            {
                this.M21 = value.X;
                this.M22 = value.Y;
                this.M23 = value.Z;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct F9
        {
            [FixedBuffer(typeof(float), 9)]
            public <data>e__FixedBuffer0 data;
            [StructLayout(LayoutKind.Sequential, Size=0x24), CompilerGenerated, UnsafeValueType]
            public struct <data>e__FixedBuffer0
            {
                public float FixedElementField;
            }
        }
    }
}

