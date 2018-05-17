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
    public struct Matrix : IEquatable<Matrix>
    {
        public static Matrix Identity;
        [FieldOffset(0)]
        private F16 M;
        [ProtoMember(0x25), FieldOffset(0)]
        public float M11;
        [ProtoMember(0x2b), FieldOffset(4)]
        public float M12;
        [ProtoMember(0x31), FieldOffset(8)]
        public float M13;
        [ProtoMember(0x37), FieldOffset(12)]
        public float M14;
        [ProtoMember(0x3d), FieldOffset(0x10)]
        public float M21;
        [ProtoMember(0x43), FieldOffset(20)]
        public float M22;
        [ProtoMember(0x49), FieldOffset(0x18)]
        public float M23;
        [ProtoMember(0x4f), FieldOffset(0x1c)]
        public float M24;
        [ProtoMember(0x55), FieldOffset(0x20)]
        public float M31;
        [ProtoMember(0x5b), FieldOffset(0x24)]
        public float M32;
        [ProtoMember(0x61), FieldOffset(40)]
        public float M33;
        [ProtoMember(0x67), FieldOffset(0x2c)]
        public float M34;
        [ProtoMember(0x6d), FieldOffset(0x30)]
        public float M41;
        [ProtoMember(0x73), FieldOffset(0x34)]
        public float M42;
        [ProtoMember(0x79), FieldOffset(0x38)]
        public float M43;
        [ProtoMember(0x7f), FieldOffset(60)]
        public float M44;
        public static Matrix Zero;

        static Matrix()
        {
            Identity = new Matrix(1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f);
            Zero = new Matrix(0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f);
        }

        public Matrix(MatrixD other)
        {
            this.M11 = (float) other.M11;
            this.M12 = (float) other.M12;
            this.M13 = (float) other.M13;
            this.M14 = (float) other.M14;
            this.M21 = (float) other.M21;
            this.M22 = (float) other.M22;
            this.M23 = (float) other.M23;
            this.M24 = (float) other.M24;
            this.M31 = (float) other.M31;
            this.M32 = (float) other.M32;
            this.M33 = (float) other.M33;
            this.M34 = (float) other.M34;
            this.M41 = (float) other.M41;
            this.M42 = (float) other.M42;
            this.M43 = (float) other.M43;
            this.M44 = (float) other.M44;
        }

        public Matrix(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
        {
            this.M11 = m11;
            this.M12 = m12;
            this.M13 = m13;
            this.M14 = 0f;
            this.M21 = m21;
            this.M22 = m22;
            this.M23 = m23;
            this.M24 = 0f;
            this.M31 = m31;
            this.M32 = m32;
            this.M33 = m33;
            this.M34 = 0f;
            this.M41 = 0f;
            this.M42 = 0f;
            this.M43 = 0f;
            this.M44 = 1f;
        }

        public Matrix(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44)
        {
            this.M11 = m11;
            this.M12 = m12;
            this.M13 = m13;
            this.M14 = m14;
            this.M21 = m21;
            this.M22 = m22;
            this.M23 = m23;
            this.M24 = m24;
            this.M31 = m31;
            this.M32 = m32;
            this.M33 = m33;
            this.M34 = m34;
            this.M41 = m41;
            this.M42 = m42;
            this.M43 = m43;
            this.M44 = m44;
        }

        public static Matrix Add(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrix;
            matrix.M11 = matrix1.M11 + matrix2.M11;
            matrix.M12 = matrix1.M12 + matrix2.M12;
            matrix.M13 = matrix1.M13 + matrix2.M13;
            matrix.M14 = matrix1.M14 + matrix2.M14;
            matrix.M21 = matrix1.M21 + matrix2.M21;
            matrix.M22 = matrix1.M22 + matrix2.M22;
            matrix.M23 = matrix1.M23 + matrix2.M23;
            matrix.M24 = matrix1.M24 + matrix2.M24;
            matrix.M31 = matrix1.M31 + matrix2.M31;
            matrix.M32 = matrix1.M32 + matrix2.M32;
            matrix.M33 = matrix1.M33 + matrix2.M33;
            matrix.M34 = matrix1.M34 + matrix2.M34;
            matrix.M41 = matrix1.M41 + matrix2.M41;
            matrix.M42 = matrix1.M42 + matrix2.M42;
            matrix.M43 = matrix1.M43 + matrix2.M43;
            matrix.M44 = matrix1.M44 + matrix2.M44;
            return matrix;
        }

        public static void Add(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
        {
            result.M11 = matrix1.M11 + matrix2.M11;
            result.M12 = matrix1.M12 + matrix2.M12;
            result.M13 = matrix1.M13 + matrix2.M13;
            result.M14 = matrix1.M14 + matrix2.M14;
            result.M21 = matrix1.M21 + matrix2.M21;
            result.M22 = matrix1.M22 + matrix2.M22;
            result.M23 = matrix1.M23 + matrix2.M23;
            result.M24 = matrix1.M24 + matrix2.M24;
            result.M31 = matrix1.M31 + matrix2.M31;
            result.M32 = matrix1.M32 + matrix2.M32;
            result.M33 = matrix1.M33 + matrix2.M33;
            result.M34 = matrix1.M34 + matrix2.M34;
            result.M41 = matrix1.M41 + matrix2.M41;
            result.M42 = matrix1.M42 + matrix2.M42;
            result.M43 = matrix1.M43 + matrix2.M43;
            result.M44 = matrix1.M44 + matrix2.M44;
        }

        public static Matrix AlignRotationToAxes(ref Matrix toAlign, ref Matrix axisDefinitionMatrix)
        {
            Matrix identity = Identity;
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

        public static Matrix CreateBillboard(Vector3 objectPosition, Vector3 cameraPosition, Vector3 cameraUpVector, Vector3? cameraForwardVector)
        {
            Vector3 vector;
            Vector3 vector2;
            Vector3 vector3;
            Matrix matrix;
            vector.X = objectPosition.X - cameraPosition.X;
            vector.Y = objectPosition.Y - cameraPosition.Y;
            vector.Z = objectPosition.Z - cameraPosition.Z;
            float num = vector.LengthSquared();
            if (num < 9.99999974737875E-05)
            {
                vector = cameraForwardVector.HasValue ? -cameraForwardVector.Value : Vector3.Forward;
            }
            else
            {
                Vector3.Multiply(ref vector, (float) (1f / ((float) Math.Sqrt((double) num))), out vector);
            }
            Vector3.Cross(ref cameraUpVector, ref vector, out vector2);
            vector2.Normalize();
            Vector3.Cross(ref vector, ref vector2, out vector3);
            matrix.M11 = vector2.X;
            matrix.M12 = vector2.Y;
            matrix.M13 = vector2.Z;
            matrix.M14 = 0f;
            matrix.M21 = vector3.X;
            matrix.M22 = vector3.Y;
            matrix.M23 = vector3.Z;
            matrix.M24 = 0f;
            matrix.M31 = vector.X;
            matrix.M32 = vector.Y;
            matrix.M33 = vector.Z;
            matrix.M34 = 0f;
            matrix.M41 = objectPosition.X;
            matrix.M42 = objectPosition.Y;
            matrix.M43 = objectPosition.Z;
            matrix.M44 = 1f;
            return matrix;
        }

        public static void CreateBillboard(ref Vector3 objectPosition, ref Vector3 cameraPosition, ref Vector3 cameraUpVector, Vector3? cameraForwardVector, out Matrix result)
        {
            Vector3 vector;
            Vector3 vector2;
            Vector3 vector3;
            vector.X = objectPosition.X - cameraPosition.X;
            vector.Y = objectPosition.Y - cameraPosition.Y;
            vector.Z = objectPosition.Z - cameraPosition.Z;
            float num = vector.LengthSquared();
            if (num < 9.99999974737875E-05)
            {
                vector = cameraForwardVector.HasValue ? -cameraForwardVector.Value : Vector3.Forward;
            }
            else
            {
                Vector3.Multiply(ref vector, (float) (1f / ((float) Math.Sqrt((double) num))), out vector);
            }
            Vector3.Cross(ref cameraUpVector, ref vector, out vector2);
            vector2.Normalize();
            Vector3.Cross(ref vector, ref vector2, out vector3);
            result.M11 = vector2.X;
            result.M12 = vector2.Y;
            result.M13 = vector2.Z;
            result.M14 = 0f;
            result.M21 = vector3.X;
            result.M22 = vector3.Y;
            result.M23 = vector3.Z;
            result.M24 = 0f;
            result.M31 = vector.X;
            result.M32 = vector.Y;
            result.M33 = vector.Z;
            result.M34 = 0f;
            result.M41 = objectPosition.X;
            result.M42 = objectPosition.Y;
            result.M43 = objectPosition.Z;
            result.M44 = 1f;
        }

        public static Matrix CreateConstrainedBillboard(Vector3 objectPosition, Vector3 cameraPosition, Vector3 rotateAxis, Vector3? cameraForwardVector, Vector3? objectForwardVector)
        {
            Vector3 vector;
            float num2;
            Vector3 vector3;
            Vector3 vector4;
            Matrix matrix;
            vector.X = objectPosition.X - cameraPosition.X;
            vector.Y = objectPosition.Y - cameraPosition.Y;
            vector.Z = objectPosition.Z - cameraPosition.Z;
            float num = vector.LengthSquared();
            if (num < 9.99999974737875E-05)
            {
                vector = cameraForwardVector.HasValue ? -cameraForwardVector.Value : Vector3.Forward;
            }
            else
            {
                Vector3.Multiply(ref vector, (float) (1f / ((float) Math.Sqrt((double) num))), out vector);
            }
            Vector3 vector2 = rotateAxis;
            Vector3.Dot(ref rotateAxis, ref vector, out num2);
            if (Math.Abs(num2) > 0.998254656791687)
            {
                if (objectForwardVector.HasValue)
                {
                    vector3 = objectForwardVector.Value;
                    Vector3.Dot(ref rotateAxis, ref vector3, out num2);
                    if (Math.Abs(num2) > 0.998254656791687)
                    {
                        vector3 = (Math.Abs((float) (((rotateAxis.X * Vector3.Forward.X) + (rotateAxis.Y * Vector3.Forward.Y)) + (rotateAxis.Z * Vector3.Forward.Z))) > 0.998254656791687) ? Vector3.Right : Vector3.Forward;
                    }
                }
                else
                {
                    vector3 = (Math.Abs((float) (((rotateAxis.X * Vector3.Forward.X) + (rotateAxis.Y * Vector3.Forward.Y)) + (rotateAxis.Z * Vector3.Forward.Z))) > 0.998254656791687) ? Vector3.Right : Vector3.Forward;
                }
                Vector3.Cross(ref rotateAxis, ref vector3, out vector4);
                vector4.Normalize();
                Vector3.Cross(ref vector4, ref rotateAxis, out vector3);
                vector3.Normalize();
            }
            else
            {
                Vector3.Cross(ref rotateAxis, ref vector, out vector4);
                vector4.Normalize();
                Vector3.Cross(ref vector4, ref vector2, out vector3);
                vector3.Normalize();
            }
            matrix.M11 = vector4.X;
            matrix.M12 = vector4.Y;
            matrix.M13 = vector4.Z;
            matrix.M14 = 0f;
            matrix.M21 = vector2.X;
            matrix.M22 = vector2.Y;
            matrix.M23 = vector2.Z;
            matrix.M24 = 0f;
            matrix.M31 = vector3.X;
            matrix.M32 = vector3.Y;
            matrix.M33 = vector3.Z;
            matrix.M34 = 0f;
            matrix.M41 = objectPosition.X;
            matrix.M42 = objectPosition.Y;
            matrix.M43 = objectPosition.Z;
            matrix.M44 = 1f;
            return matrix;
        }

        public static void CreateConstrainedBillboard(ref Vector3 objectPosition, ref Vector3 cameraPosition, ref Vector3 rotateAxis, Vector3? cameraForwardVector, Vector3? objectForwardVector, out Matrix result)
        {
            Vector3 vector;
            float num2;
            Vector3 vector3;
            Vector3 vector4;
            vector.X = objectPosition.X - cameraPosition.X;
            vector.Y = objectPosition.Y - cameraPosition.Y;
            vector.Z = objectPosition.Z - cameraPosition.Z;
            float num = vector.LengthSquared();
            if (num < 9.99999974737875E-05)
            {
                vector = cameraForwardVector.HasValue ? -cameraForwardVector.Value : Vector3.Forward;
            }
            else
            {
                Vector3.Multiply(ref vector, (float) (1f / ((float) Math.Sqrt((double) num))), out vector);
            }
            Vector3 vector2 = rotateAxis;
            Vector3.Dot(ref rotateAxis, ref vector, out num2);
            if (Math.Abs(num2) > 0.998254656791687)
            {
                if (objectForwardVector.HasValue)
                {
                    vector3 = objectForwardVector.Value;
                    Vector3.Dot(ref rotateAxis, ref vector3, out num2);
                    if (Math.Abs(num2) > 0.998254656791687)
                    {
                        vector3 = (Math.Abs((float) (((rotateAxis.X * Vector3.Forward.X) + (rotateAxis.Y * Vector3.Forward.Y)) + (rotateAxis.Z * Vector3.Forward.Z))) > 0.998254656791687) ? Vector3.Right : Vector3.Forward;
                    }
                }
                else
                {
                    vector3 = (Math.Abs((float) (((rotateAxis.X * Vector3.Forward.X) + (rotateAxis.Y * Vector3.Forward.Y)) + (rotateAxis.Z * Vector3.Forward.Z))) > 0.998254656791687) ? Vector3.Right : Vector3.Forward;
                }
                Vector3.Cross(ref rotateAxis, ref vector3, out vector4);
                vector4.Normalize();
                Vector3.Cross(ref vector4, ref rotateAxis, out vector3);
                vector3.Normalize();
            }
            else
            {
                Vector3.Cross(ref rotateAxis, ref vector, out vector4);
                vector4.Normalize();
                Vector3.Cross(ref vector4, ref vector2, out vector3);
                vector3.Normalize();
            }
            result.M11 = vector4.X;
            result.M12 = vector4.Y;
            result.M13 = vector4.Z;
            result.M14 = 0f;
            result.M21 = vector2.X;
            result.M22 = vector2.Y;
            result.M23 = vector2.Z;
            result.M24 = 0f;
            result.M31 = vector3.X;
            result.M32 = vector3.Y;
            result.M33 = vector3.Z;
            result.M34 = 0f;
            result.M41 = objectPosition.X;
            result.M42 = objectPosition.Y;
            result.M43 = objectPosition.Z;
            result.M44 = 1f;
        }

        public static Matrix CreateFromAxisAngle(Vector3 axis, float angle)
        {
            Matrix matrix;
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
            matrix.M11 = num6 + (num5 * (1f - num6));
            matrix.M12 = (num9 - (num5 * num9)) + (num4 * z);
            matrix.M13 = (num10 - (num5 * num10)) - (num4 * y);
            matrix.M14 = 0f;
            matrix.M21 = (num9 - (num5 * num9)) - (num4 * z);
            matrix.M22 = num7 + (num5 * (1f - num7));
            matrix.M23 = (num11 - (num5 * num11)) + (num4 * x);
            matrix.M24 = 0f;
            matrix.M31 = (num10 - (num5 * num10)) + (num4 * y);
            matrix.M32 = (num11 - (num5 * num11)) - (num4 * x);
            matrix.M33 = num8 + (num5 * (1f - num8));
            matrix.M34 = 0f;
            matrix.M41 = 0f;
            matrix.M42 = 0f;
            matrix.M43 = 0f;
            matrix.M44 = 1f;
            return matrix;
        }

        public static void CreateFromAxisAngle(ref Vector3 axis, float angle, out Matrix result)
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
            result.M14 = 0f;
            result.M21 = (num9 - (num5 * num9)) - (num4 * z);
            result.M22 = num7 + (num5 * (1f - num7));
            result.M23 = (num11 - (num5 * num11)) + (num4 * x);
            result.M24 = 0f;
            result.M31 = (num10 - (num5 * num10)) + (num4 * y);
            result.M32 = (num11 - (num5 * num11)) - (num4 * x);
            result.M33 = num8 + (num5 * (1f - num8));
            result.M34 = 0f;
            result.M41 = 0f;
            result.M42 = 0f;
            result.M43 = 0f;
            result.M44 = 1f;
        }

        public static Matrix CreateFromDir(Vector3 dir)
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
            Matrix identity = Identity;
            identity.Right = vector;
            identity.Up = vector2;
            identity.Forward = dir;
            return identity;
        }

        public static Matrix CreateFromDir(Vector3 dir, Vector3 suggestedUp)
        {
            Vector3 up = Vector3.Cross(Vector3.Cross(dir, suggestedUp), dir);
            return CreateWorld(Vector3.Zero, dir, up);
        }

        public static Matrix CreateFromPerspectiveFieldOfView(ref Matrix proj, float nearPlaneDistance, float farPlaneDistance)
        {
            Matrix matrix = proj;
            matrix.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            matrix.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
            return matrix;
        }

        public static Matrix CreateFromQuaternion(Quaternion quaternion)
        {
            Matrix matrix;
            float num = quaternion.X * quaternion.X;
            float num2 = quaternion.Y * quaternion.Y;
            float num3 = quaternion.Z * quaternion.Z;
            float num4 = quaternion.X * quaternion.Y;
            float num5 = quaternion.Z * quaternion.W;
            float num6 = quaternion.Z * quaternion.X;
            float num7 = quaternion.Y * quaternion.W;
            float num8 = quaternion.Y * quaternion.Z;
            float num9 = quaternion.X * quaternion.W;
            matrix.M11 = (float) (1.0 - (2.0 * (num2 + num3)));
            matrix.M12 = (float) (2.0 * (num4 + num5));
            matrix.M13 = (float) (2.0 * (num6 - num7));
            matrix.M14 = 0f;
            matrix.M21 = (float) (2.0 * (num4 - num5));
            matrix.M22 = (float) (1.0 - (2.0 * (num3 + num)));
            matrix.M23 = (float) (2.0 * (num8 + num9));
            matrix.M24 = 0f;
            matrix.M31 = (float) (2.0 * (num6 + num7));
            matrix.M32 = (float) (2.0 * (num8 - num9));
            matrix.M33 = (float) (1.0 - (2.0 * (num2 + num)));
            matrix.M34 = 0f;
            matrix.M41 = 0f;
            matrix.M42 = 0f;
            matrix.M43 = 0f;
            matrix.M44 = 1f;
            return matrix;
        }

        public static void CreateFromQuaternion(ref Quaternion quaternion, out Matrix result)
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
            result.M14 = 0f;
            result.M21 = (float) (2.0 * (num4 - num5));
            result.M22 = (float) (1.0 - (2.0 * (num3 + num)));
            result.M23 = (float) (2.0 * (num8 + num9));
            result.M24 = 0f;
            result.M31 = (float) (2.0 * (num6 + num7));
            result.M32 = (float) (2.0 * (num8 - num9));
            result.M33 = (float) (1.0 - (2.0 * (num2 + num)));
            result.M34 = 0f;
            result.M41 = 0f;
            result.M42 = 0f;
            result.M43 = 0f;
            result.M44 = 1f;
        }

        public static Matrix CreateFromTransformScale(Quaternion orientation, Vector3 position, Vector3 scale)
        {
            Matrix matrix = CreateFromQuaternion(orientation);
            matrix.Translation = position;
            Rescale(ref matrix, ref scale);
            return matrix;
        }

        public static Matrix CreateFromYawPitchRoll(float yaw, float pitch, float roll)
        {
            Quaternion quaternion;
            Matrix matrix;
            Quaternion.CreateFromYawPitchRoll(yaw, pitch, roll, out quaternion);
            CreateFromQuaternion(ref quaternion, out matrix);
            return matrix;
        }

        public static void CreateFromYawPitchRoll(float yaw, float pitch, float roll, out Matrix result)
        {
            Quaternion quaternion;
            Quaternion.CreateFromYawPitchRoll(yaw, pitch, roll, out quaternion);
            CreateFromQuaternion(ref quaternion, out result);
        }

        public static Matrix CreateLookAt(Vector3 cameraPosition, Vector3 cameraTarget, Vector3 cameraUpVector)
        {
            Matrix matrix;
            Vector3 vector = Vector3.Normalize(cameraPosition - cameraTarget);
            Vector3 vector2 = Vector3.Normalize(Vector3.Cross(cameraUpVector, vector));
            Vector3 vector3 = Vector3.Cross(vector, vector2);
            matrix.M11 = vector2.X;
            matrix.M12 = vector3.X;
            matrix.M13 = vector.X;
            matrix.M14 = 0f;
            matrix.M21 = vector2.Y;
            matrix.M22 = vector3.Y;
            matrix.M23 = vector.Y;
            matrix.M24 = 0f;
            matrix.M31 = vector2.Z;
            matrix.M32 = vector3.Z;
            matrix.M33 = vector.Z;
            matrix.M34 = 0f;
            matrix.M41 = -Vector3.Dot(vector2, cameraPosition);
            matrix.M42 = -Vector3.Dot(vector3, cameraPosition);
            matrix.M43 = -Vector3.Dot(vector, cameraPosition);
            matrix.M44 = 1f;
            return matrix;
        }

        public static void CreateLookAt(ref Vector3 cameraPosition, ref Vector3 cameraTarget, ref Vector3 cameraUpVector, out Matrix result)
        {
            Vector3 vector = Vector3.Normalize(cameraPosition - cameraTarget);
            Vector3 vector2 = Vector3.Normalize(Vector3.Cross(cameraUpVector, vector));
            Vector3 vector3 = Vector3.Cross(vector, vector2);
            result.M11 = vector2.X;
            result.M12 = vector3.X;
            result.M13 = vector.X;
            result.M14 = 0f;
            result.M21 = vector2.Y;
            result.M22 = vector3.Y;
            result.M23 = vector.Y;
            result.M24 = 0f;
            result.M31 = vector2.Z;
            result.M32 = vector3.Z;
            result.M33 = vector.Z;
            result.M34 = 0f;
            result.M41 = -Vector3.Dot(vector2, cameraPosition);
            result.M42 = -Vector3.Dot(vector3, cameraPosition);
            result.M43 = -Vector3.Dot(vector, cameraPosition);
            result.M44 = 1f;
        }

        public static Matrix CreateLookAtInverse(Vector3 cameraPosition, Vector3 cameraTarget, Vector3 cameraUpVector)
        {
            Matrix matrix;
            Vector3 vector = Vector3.Normalize(cameraPosition - cameraTarget);
            Vector3 vector2 = Vector3.Normalize(Vector3.Cross(cameraUpVector, vector));
            Vector3 vector3 = Vector3.Cross(vector, vector2);
            matrix.M11 = vector2.X;
            matrix.M12 = vector2.Y;
            matrix.M13 = vector2.Z;
            matrix.M14 = 0f;
            matrix.M21 = vector3.X;
            matrix.M22 = vector3.Y;
            matrix.M23 = vector3.Z;
            matrix.M24 = 0f;
            matrix.M31 = vector.X;
            matrix.M32 = vector.Y;
            matrix.M33 = vector.Z;
            matrix.M34 = 0f;
            matrix.M41 = cameraPosition.X;
            matrix.M42 = cameraPosition.Y;
            matrix.M43 = cameraPosition.Z;
            matrix.M44 = 1f;
            return matrix;
        }

        public static Matrix CreateOrthographic(float width, float height, float zNearPlane, float zFarPlane)
        {
            Matrix matrix;
            matrix.M11 = 2f / width;
            matrix.M12 = matrix.M13 = matrix.M14 = 0f;
            matrix.M22 = 2f / height;
            matrix.M21 = matrix.M23 = matrix.M24 = 0f;
            matrix.M33 = (float) (1.0 / (zNearPlane - zFarPlane));
            matrix.M31 = matrix.M32 = matrix.M34 = 0f;
            matrix.M41 = matrix.M42 = 0f;
            matrix.M43 = zNearPlane / (zNearPlane - zFarPlane);
            matrix.M44 = 1f;
            return matrix;
        }

        public static void CreateOrthographic(float width, float height, float zNearPlane, float zFarPlane, out Matrix result)
        {
            result.M11 = 2f / width;
            result.M12 = result.M13 = result.M14 = 0f;
            result.M22 = 2f / height;
            result.M21 = result.M23 = result.M24 = 0f;
            result.M33 = (float) (1.0 / (zNearPlane - zFarPlane));
            result.M31 = result.M32 = result.M34 = 0f;
            result.M41 = result.M42 = 0f;
            result.M43 = zNearPlane / (zNearPlane - zFarPlane);
            result.M44 = 1f;
        }

        public static Matrix CreateOrthographicOffCenter(float left, float right, float bottom, float top, float zNearPlane, float zFarPlane)
        {
            Matrix matrix;
            matrix.M11 = (float) (2.0 / (right - left));
            matrix.M12 = matrix.M13 = matrix.M14 = 0f;
            matrix.M22 = (float) (2.0 / (top - bottom));
            matrix.M21 = matrix.M23 = matrix.M24 = 0f;
            matrix.M33 = (float) (1.0 / (zNearPlane - zFarPlane));
            matrix.M31 = matrix.M32 = matrix.M34 = 0f;
            matrix.M41 = (left + right) / (left - right);
            matrix.M42 = (top + bottom) / (bottom - top);
            matrix.M43 = zNearPlane / (zNearPlane - zFarPlane);
            matrix.M44 = 1f;
            return matrix;
        }

        public static void CreateOrthographicOffCenter(float left, float right, float bottom, float top, float zNearPlane, float zFarPlane, out Matrix result)
        {
            result.M11 = (float) (2.0 / (right - left));
            result.M12 = result.M13 = result.M14 = 0f;
            result.M22 = (float) (2.0 / (top - bottom));
            result.M21 = result.M23 = result.M24 = 0f;
            result.M33 = (float) (1.0 / (zNearPlane - zFarPlane));
            result.M31 = result.M32 = result.M34 = 0f;
            result.M41 = (left + right) / (left - right);
            result.M42 = (top + bottom) / (bottom - top);
            result.M43 = zNearPlane / (zNearPlane - zFarPlane);
            result.M44 = 1f;
        }

        public static Matrix CreatePerspective(float width, float height, float nearPlaneDistance, float farPlaneDistance)
        {
            Matrix matrix;
            if (nearPlaneDistance <= 0.0)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance", string.Format(CultureInfo.CurrentCulture, "NegativePlaneDistance", new object[] { "nearPlaneDistance" }));
            }
            if (farPlaneDistance <= 0.0)
            {
                throw new ArgumentOutOfRangeException("farPlaneDistance", string.Format(CultureInfo.CurrentCulture, "NegativePlaneDistance", new object[] { "farPlaneDistance" }));
            }
            if (nearPlaneDistance >= farPlaneDistance)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance", "OppositePlanes");
            }
            matrix.M11 = (2f * nearPlaneDistance) / width;
            matrix.M12 = matrix.M13 = matrix.M14 = 0f;
            matrix.M22 = (2f * nearPlaneDistance) / height;
            matrix.M21 = matrix.M23 = matrix.M24 = 0f;
            matrix.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            matrix.M31 = matrix.M32 = 0f;
            matrix.M34 = -1f;
            matrix.M41 = matrix.M42 = matrix.M44 = 0f;
            matrix.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
            return matrix;
        }

        public static void CreatePerspective(float width, float height, float nearPlaneDistance, float farPlaneDistance, out Matrix result)
        {
            if (nearPlaneDistance <= 0.0)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance", string.Format(CultureInfo.CurrentCulture, "NegativePlaneDistance", new object[] { "nearPlaneDistance" }));
            }
            if (farPlaneDistance <= 0.0)
            {
                throw new ArgumentOutOfRangeException("farPlaneDistance", string.Format(CultureInfo.CurrentCulture, "NegativePlaneDistance", new object[] { "farPlaneDistance" }));
            }
            if (nearPlaneDistance >= farPlaneDistance)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance", "OppositePlanes");
            }
            result.M11 = (2f * nearPlaneDistance) / width;
            result.M12 = result.M13 = result.M14 = 0f;
            result.M22 = (2f * nearPlaneDistance) / height;
            result.M21 = result.M23 = result.M24 = 0f;
            result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            result.M31 = result.M32 = 0f;
            result.M34 = -1f;
            result.M41 = result.M42 = result.M44 = 0f;
            result.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
        }

        public static Matrix CreatePerspectiveFieldOfView(float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance)
        {
            Matrix matrix;
            if ((fieldOfView <= 0.0) || (fieldOfView >= 3.14159274101257))
            {
                throw new ArgumentOutOfRangeException("fieldOfView", string.Format(CultureInfo.CurrentCulture, "OutRangeFieldOfView", new object[] { "fieldOfView" }));
            }
            if (nearPlaneDistance <= 0.0)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance", string.Format(CultureInfo.CurrentCulture, "NegativePlaneDistance", new object[] { "nearPlaneDistance" }));
            }
            if (farPlaneDistance <= 0.0)
            {
                throw new ArgumentOutOfRangeException("farPlaneDistance", string.Format(CultureInfo.CurrentCulture, "NegativePlaneDistance", new object[] { "farPlaneDistance" }));
            }
            float num = 1f / ((float) Math.Tan(fieldOfView * 0.5));
            float num2 = num / aspectRatio;
            matrix.M11 = num2;
            matrix.M12 = matrix.M13 = matrix.M14 = 0f;
            matrix.M22 = num;
            matrix.M21 = matrix.M23 = matrix.M24 = 0f;
            matrix.M31 = matrix.M32 = 0f;
            matrix.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            matrix.M34 = -1f;
            matrix.M41 = matrix.M42 = matrix.M44 = 0f;
            matrix.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
            return matrix;
        }

        public static void CreatePerspectiveFieldOfView(float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance, out Matrix result)
        {
            if ((fieldOfView <= 0.0) || (fieldOfView >= 3.14159274101257))
            {
                throw new ArgumentOutOfRangeException("fieldOfView", string.Format(CultureInfo.CurrentCulture, "OutRangeFieldOfView", new object[] { "fieldOfView" }));
            }
            if (nearPlaneDistance <= 0.0)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance", string.Format(CultureInfo.CurrentCulture, "NegativePlaneDistance", new object[] { "nearPlaneDistance" }));
            }
            if (farPlaneDistance <= 0.0)
            {
                throw new ArgumentOutOfRangeException("farPlaneDistance", string.Format(CultureInfo.CurrentCulture, "NegativePlaneDistance", new object[] { "farPlaneDistance" }));
            }
            if (nearPlaneDistance >= farPlaneDistance)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance", "OppositePlanes");
            }
            float num = 1f / ((float) Math.Tan(fieldOfView * 0.5));
            float num2 = num / aspectRatio;
            result.M11 = num2;
            result.M12 = result.M13 = result.M14 = 0f;
            result.M22 = num;
            result.M21 = result.M23 = result.M24 = 0f;
            result.M31 = result.M32 = 0f;
            result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            result.M34 = -1f;
            result.M41 = result.M42 = result.M44 = 0f;
            result.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
        }

        public static Matrix CreatePerspectiveFovRhComplementary(float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance)
        {
            Matrix matrix;
            if ((fieldOfView <= 0.0) || (fieldOfView >= 3.14159274101257))
            {
                throw new ArgumentOutOfRangeException("fieldOfView", string.Format(CultureInfo.CurrentCulture, "OutRangeFieldOfView", new object[] { "fieldOfView" }));
            }
            if (nearPlaneDistance <= 0.0)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance", string.Format(CultureInfo.CurrentCulture, "NegativePlaneDistance", new object[] { "nearPlaneDistance" }));
            }
            if (farPlaneDistance <= 0.0)
            {
                throw new ArgumentOutOfRangeException("farPlaneDistance", string.Format(CultureInfo.CurrentCulture, "NegativePlaneDistance", new object[] { "farPlaneDistance" }));
            }
            float num = 1f / ((float) Math.Tan(fieldOfView * 0.5));
            float num2 = num / aspectRatio;
            matrix.M11 = num2;
            matrix.M12 = matrix.M13 = matrix.M14 = 0f;
            matrix.M22 = num;
            matrix.M21 = matrix.M23 = matrix.M24 = 0f;
            matrix.M31 = matrix.M32 = 0f;
            matrix.M33 = (-farPlaneDistance / (nearPlaneDistance - farPlaneDistance)) - 1f;
            matrix.M34 = -1f;
            matrix.M41 = matrix.M42 = matrix.M44 = 0f;
            matrix.M43 = -((nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance));
            return matrix;
        }

        public static Matrix CreatePerspectiveFovRhInfinite(float fieldOfView, float aspectRatio, float nearPlaneDistance)
        {
            Matrix matrix;
            float num = 1f / ((float) Math.Tan(fieldOfView * 0.5));
            float num2 = num / aspectRatio;
            matrix.M11 = num2;
            matrix.M12 = matrix.M13 = matrix.M14 = 0f;
            matrix.M22 = num;
            matrix.M21 = matrix.M23 = matrix.M24 = 0f;
            matrix.M31 = matrix.M32 = 0f;
            matrix.M33 = -1f;
            matrix.M34 = -1f;
            matrix.M41 = matrix.M42 = matrix.M44 = 0f;
            matrix.M43 = -nearPlaneDistance;
            return matrix;
        }

        public static Matrix CreatePerspectiveFovRhInfiniteComplementary(float fieldOfView, float aspectRatio, float nearPlaneDistance)
        {
            Matrix matrix;
            float num = 1f / ((float) Math.Tan(fieldOfView * 0.5));
            float num2 = num / aspectRatio;
            matrix.M11 = num2;
            matrix.M12 = matrix.M13 = matrix.M14 = 0f;
            matrix.M22 = num;
            matrix.M21 = matrix.M23 = matrix.M24 = 0f;
            matrix.M31 = matrix.M32 = 0f;
            matrix.M33 = 0f;
            matrix.M34 = -1f;
            matrix.M41 = matrix.M42 = matrix.M44 = 0f;
            matrix.M43 = nearPlaneDistance;
            return matrix;
        }

        public static Matrix CreatePerspectiveFovRhInfiniteComplementaryInverse(float fieldOfView, float aspectRatio, float nearPlaneDistance)
        {
            Matrix matrix;
            float num = 1f / ((float) Math.Tan(fieldOfView * 0.5));
            float num2 = num / aspectRatio;
            matrix.M11 = num2;
            matrix.M12 = matrix.M13 = matrix.M14 = 0f;
            matrix.M22 = num;
            matrix.M21 = matrix.M23 = matrix.M24 = 0f;
            matrix.M31 = matrix.M32 = 0f;
            matrix.M33 = 0f;
            matrix.M34 = 1f / nearPlaneDistance;
            matrix.M41 = matrix.M42 = 0f;
            matrix.M43 = -1f;
            matrix.M44 = 0f;
            return matrix;
        }

        public static Matrix CreatePerspectiveFovRhInfiniteInverse(float fieldOfView, float aspectRatio, float nearPlaneDistance)
        {
            Matrix matrix;
            float num = 1f / ((float) Math.Tan(fieldOfView * 0.5));
            float num2 = num / aspectRatio;
            matrix.M11 = num2;
            matrix.M12 = matrix.M13 = matrix.M14 = 0f;
            matrix.M22 = num;
            matrix.M21 = matrix.M23 = matrix.M24 = 0f;
            matrix.M31 = matrix.M32 = 0f;
            matrix.M33 = 0f;
            matrix.M34 = -1f / nearPlaneDistance;
            matrix.M41 = matrix.M42 = 0f;
            matrix.M43 = -1f;
            matrix.M44 = 1f / nearPlaneDistance;
            return matrix;
        }

        public static Matrix CreatePerspectiveFovRhInverse(float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance)
        {
            Matrix matrix;
            float num = (float) Math.Tan(fieldOfView * 0.5);
            float num2 = aspectRatio * num;
            matrix.M11 = num2;
            matrix.M12 = matrix.M13 = matrix.M14 = 0f;
            matrix.M22 = num;
            matrix.M21 = matrix.M23 = matrix.M24 = 0f;
            matrix.M31 = matrix.M32 = matrix.M33 = 0f;
            matrix.M34 = (nearPlaneDistance - farPlaneDistance) / (nearPlaneDistance * farPlaneDistance);
            matrix.M41 = matrix.M42 = matrix.M44 = 0f;
            matrix.M43 = -1f;
            matrix.M44 = 1f / nearPlaneDistance;
            return matrix;
        }

        public static Matrix CreatePerspectiveOffCenter(float left, float right, float bottom, float top, float nearPlaneDistance, float farPlaneDistance)
        {
            Matrix matrix;
            if (nearPlaneDistance <= 0.0)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance", string.Format(CultureInfo.CurrentCulture, "NegativePlaneDistance", new object[] { "nearPlaneDistance" }));
            }
            if (farPlaneDistance <= 0.0)
            {
                throw new ArgumentOutOfRangeException("farPlaneDistance", string.Format(CultureInfo.CurrentCulture, "NegativePlaneDistance", new object[] { "farPlaneDistance" }));
            }
            if (nearPlaneDistance >= farPlaneDistance)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance", "OppositePlanes");
            }
            matrix.M11 = (float) ((2.0 * nearPlaneDistance) / (right - left));
            matrix.M12 = matrix.M13 = matrix.M14 = 0f;
            matrix.M22 = (float) ((2.0 * nearPlaneDistance) / (top - bottom));
            matrix.M21 = matrix.M23 = matrix.M24 = 0f;
            matrix.M31 = (left + right) / (right - left);
            matrix.M32 = (top + bottom) / (top - bottom);
            matrix.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            matrix.M34 = -1f;
            matrix.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
            matrix.M41 = matrix.M42 = matrix.M44 = 0f;
            return matrix;
        }

        public static void CreatePerspectiveOffCenter(float left, float right, float bottom, float top, float nearPlaneDistance, float farPlaneDistance, out Matrix result)
        {
            if (nearPlaneDistance <= 0.0)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance", string.Format(CultureInfo.CurrentCulture, "NegativePlaneDistance", new object[] { "nearPlaneDistance" }));
            }
            if (farPlaneDistance <= 0.0)
            {
                throw new ArgumentOutOfRangeException("farPlaneDistance", string.Format(CultureInfo.CurrentCulture, "NegativePlaneDistance", new object[] { "farPlaneDistance" }));
            }
            if (nearPlaneDistance >= farPlaneDistance)
            {
                throw new ArgumentOutOfRangeException("nearPlaneDistance", "OppositePlanes");
            }
            result.M11 = (float) ((2.0 * nearPlaneDistance) / (right - left));
            result.M12 = result.M13 = result.M14 = 0f;
            result.M22 = (float) ((2.0 * nearPlaneDistance) / (top - bottom));
            result.M21 = result.M23 = result.M24 = 0f;
            result.M31 = (left + right) / (right - left);
            result.M32 = (top + bottom) / (top - bottom);
            result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            result.M34 = -1f;
            result.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
            result.M41 = result.M42 = result.M44 = 0f;
        }

        public static Matrix CreateReflection(Plane value)
        {
            Matrix matrix;
            value.Normalize();
            float x = value.Normal.X;
            float y = value.Normal.Y;
            float z = value.Normal.Z;
            float num4 = -2f * x;
            float num5 = -2f * y;
            float num6 = -2f * z;
            matrix.M11 = (num4 * x) + ((float) 1.0);
            matrix.M12 = num5 * x;
            matrix.M13 = num6 * x;
            matrix.M14 = 0f;
            matrix.M21 = num4 * y;
            matrix.M22 = (num5 * y) + ((float) 1.0);
            matrix.M23 = num6 * y;
            matrix.M24 = 0f;
            matrix.M31 = num4 * z;
            matrix.M32 = num5 * z;
            matrix.M33 = (num6 * z) + ((float) 1.0);
            matrix.M34 = 0f;
            matrix.M41 = num4 * value.D;
            matrix.M42 = num5 * value.D;
            matrix.M43 = num6 * value.D;
            matrix.M44 = 1f;
            return matrix;
        }

        public static void CreateReflection(ref Plane value, out Matrix result)
        {
            Plane plane;
            Plane.Normalize(ref value, out plane);
            value.Normalize();
            float x = plane.Normal.X;
            float y = plane.Normal.Y;
            float z = plane.Normal.Z;
            float num4 = -2f * x;
            float num5 = -2f * y;
            float num6 = -2f * z;
            result.M11 = (num4 * x) + ((float) 1.0);
            result.M12 = num5 * x;
            result.M13 = num6 * x;
            result.M14 = 0f;
            result.M21 = num4 * y;
            result.M22 = (num5 * y) + ((float) 1.0);
            result.M23 = num6 * y;
            result.M24 = 0f;
            result.M31 = num4 * z;
            result.M32 = num5 * z;
            result.M33 = (num6 * z) + ((float) 1.0);
            result.M34 = 0f;
            result.M41 = num4 * plane.D;
            result.M42 = num5 * plane.D;
            result.M43 = num6 * plane.D;
            result.M44 = 1f;
        }

        public static void CreateRotationFromTwoVectors(ref Vector3 fromVector, ref Vector3 toVector, out Matrix resultMatrix)
        {
            Vector3 vector3;
            Vector3 vector4;
            Vector3 vector = Vector3.Normalize(fromVector);
            Vector3 vector2 = Vector3.Normalize(toVector);
            Vector3.Cross(ref vector, ref vector2, out vector3);
            vector3.Normalize();
            Vector3.Cross(ref vector, ref vector3, out vector4);
            Matrix matrix = new Matrix(vector.X, vector3.X, vector4.X, 0f, vector.Y, vector3.Y, vector4.Y, 0f, vector.Z, vector3.Z, vector4.Z, 0f, 0f, 0f, 0f, 1f);
            Vector3.Cross(ref vector2, ref vector3, out vector4);
            Matrix matrix2 = new Matrix(vector2.X, vector2.Y, vector2.Z, 0f, vector3.X, vector3.Y, vector3.Z, 0f, vector4.X, vector4.Y, vector4.Z, 0f, 0f, 0f, 0f, 1f);
            resultMatrix = matrix * matrix2;
        }

        public static Matrix CreateRotationX(float radians)
        {
            Matrix matrix;
            float num = (float) Math.Cos((double) radians);
            float num2 = (float) Math.Sin((double) radians);
            matrix.M11 = 1f;
            matrix.M12 = 0f;
            matrix.M13 = 0f;
            matrix.M14 = 0f;
            matrix.M21 = 0f;
            matrix.M22 = num;
            matrix.M23 = num2;
            matrix.M24 = 0f;
            matrix.M31 = 0f;
            matrix.M32 = -num2;
            matrix.M33 = num;
            matrix.M34 = 0f;
            matrix.M41 = 0f;
            matrix.M42 = 0f;
            matrix.M43 = 0f;
            matrix.M44 = 1f;
            return matrix;
        }

        public static void CreateRotationX(float radians, out Matrix result)
        {
            float num = (float) Math.Cos((double) radians);
            float num2 = (float) Math.Sin((double) radians);
            result.M11 = 1f;
            result.M12 = 0f;
            result.M13 = 0f;
            result.M14 = 0f;
            result.M21 = 0f;
            result.M22 = num;
            result.M23 = num2;
            result.M24 = 0f;
            result.M31 = 0f;
            result.M32 = -num2;
            result.M33 = num;
            result.M34 = 0f;
            result.M41 = 0f;
            result.M42 = 0f;
            result.M43 = 0f;
            result.M44 = 1f;
        }

        public static Matrix CreateRotationY(float radians)
        {
            Matrix matrix;
            float num = (float) Math.Cos((double) radians);
            float num2 = (float) Math.Sin((double) radians);
            matrix.M11 = num;
            matrix.M12 = 0f;
            matrix.M13 = -num2;
            matrix.M14 = 0f;
            matrix.M21 = 0f;
            matrix.M22 = 1f;
            matrix.M23 = 0f;
            matrix.M24 = 0f;
            matrix.M31 = num2;
            matrix.M32 = 0f;
            matrix.M33 = num;
            matrix.M34 = 0f;
            matrix.M41 = 0f;
            matrix.M42 = 0f;
            matrix.M43 = 0f;
            matrix.M44 = 1f;
            return matrix;
        }

        public static void CreateRotationY(float radians, out Matrix result)
        {
            float num = (float) Math.Cos((double) radians);
            float num2 = (float) Math.Sin((double) radians);
            result.M11 = num;
            result.M12 = 0f;
            result.M13 = -num2;
            result.M14 = 0f;
            result.M21 = 0f;
            result.M22 = 1f;
            result.M23 = 0f;
            result.M24 = 0f;
            result.M31 = num2;
            result.M32 = 0f;
            result.M33 = num;
            result.M34 = 0f;
            result.M41 = 0f;
            result.M42 = 0f;
            result.M43 = 0f;
            result.M44 = 1f;
        }

        public static Matrix CreateRotationZ(float radians)
        {
            Matrix matrix;
            float num = (float) Math.Cos((double) radians);
            float num2 = (float) Math.Sin((double) radians);
            matrix.M11 = num;
            matrix.M12 = num2;
            matrix.M13 = 0f;
            matrix.M14 = 0f;
            matrix.M21 = -num2;
            matrix.M22 = num;
            matrix.M23 = 0f;
            matrix.M24 = 0f;
            matrix.M31 = 0f;
            matrix.M32 = 0f;
            matrix.M33 = 1f;
            matrix.M34 = 0f;
            matrix.M41 = 0f;
            matrix.M42 = 0f;
            matrix.M43 = 0f;
            matrix.M44 = 1f;
            return matrix;
        }

        public static void CreateRotationZ(float radians, out Matrix result)
        {
            float num = (float) Math.Cos((double) radians);
            float num2 = (float) Math.Sin((double) radians);
            result.M11 = num;
            result.M12 = num2;
            result.M13 = 0f;
            result.M14 = 0f;
            result.M21 = -num2;
            result.M22 = num;
            result.M23 = 0f;
            result.M24 = 0f;
            result.M31 = 0f;
            result.M32 = 0f;
            result.M33 = 1f;
            result.M34 = 0f;
            result.M41 = 0f;
            result.M42 = 0f;
            result.M43 = 0f;
            result.M44 = 1f;
        }

        public static Matrix CreateScale(float scale)
        {
            Matrix matrix;
            float num = scale;
            matrix.M11 = num;
            matrix.M12 = 0f;
            matrix.M13 = 0f;
            matrix.M14 = 0f;
            matrix.M21 = 0f;
            matrix.M22 = num;
            matrix.M23 = 0f;
            matrix.M24 = 0f;
            matrix.M31 = 0f;
            matrix.M32 = 0f;
            matrix.M33 = num;
            matrix.M34 = 0f;
            matrix.M41 = 0f;
            matrix.M42 = 0f;
            matrix.M43 = 0f;
            matrix.M44 = 1f;
            return matrix;
        }

        public static Matrix CreateScale(Vector3 scales)
        {
            Matrix matrix;
            float x = scales.X;
            float y = scales.Y;
            float z = scales.Z;
            matrix.M11 = x;
            matrix.M12 = 0f;
            matrix.M13 = 0f;
            matrix.M14 = 0f;
            matrix.M21 = 0f;
            matrix.M22 = y;
            matrix.M23 = 0f;
            matrix.M24 = 0f;
            matrix.M31 = 0f;
            matrix.M32 = 0f;
            matrix.M33 = z;
            matrix.M34 = 0f;
            matrix.M41 = 0f;
            matrix.M42 = 0f;
            matrix.M43 = 0f;
            matrix.M44 = 1f;
            return matrix;
        }

        public static void CreateScale(ref Vector3 scales, out Matrix result)
        {
            float x = scales.X;
            float y = scales.Y;
            float z = scales.Z;
            result.M11 = x;
            result.M12 = 0f;
            result.M13 = 0f;
            result.M14 = 0f;
            result.M21 = 0f;
            result.M22 = y;
            result.M23 = 0f;
            result.M24 = 0f;
            result.M31 = 0f;
            result.M32 = 0f;
            result.M33 = z;
            result.M34 = 0f;
            result.M41 = 0f;
            result.M42 = 0f;
            result.M43 = 0f;
            result.M44 = 1f;
        }

        public static void CreateScale(float scale, out Matrix result)
        {
            float num = scale;
            result.M11 = num;
            result.M12 = 0f;
            result.M13 = 0f;
            result.M14 = 0f;
            result.M21 = 0f;
            result.M22 = num;
            result.M23 = 0f;
            result.M24 = 0f;
            result.M31 = 0f;
            result.M32 = 0f;
            result.M33 = num;
            result.M34 = 0f;
            result.M41 = 0f;
            result.M42 = 0f;
            result.M43 = 0f;
            result.M44 = 1f;
        }

        public static Matrix CreateScale(float xScale, float yScale, float zScale)
        {
            Matrix matrix;
            float num = xScale;
            float num2 = yScale;
            float num3 = zScale;
            matrix.M11 = num;
            matrix.M12 = 0f;
            matrix.M13 = 0f;
            matrix.M14 = 0f;
            matrix.M21 = 0f;
            matrix.M22 = num2;
            matrix.M23 = 0f;
            matrix.M24 = 0f;
            matrix.M31 = 0f;
            matrix.M32 = 0f;
            matrix.M33 = num3;
            matrix.M34 = 0f;
            matrix.M41 = 0f;
            matrix.M42 = 0f;
            matrix.M43 = 0f;
            matrix.M44 = 1f;
            return matrix;
        }

        public static void CreateScale(float xScale, float yScale, float zScale, out Matrix result)
        {
            float num = xScale;
            float num2 = yScale;
            float num3 = zScale;
            result.M11 = num;
            result.M12 = 0f;
            result.M13 = 0f;
            result.M14 = 0f;
            result.M21 = 0f;
            result.M22 = num2;
            result.M23 = 0f;
            result.M24 = 0f;
            result.M31 = 0f;
            result.M32 = 0f;
            result.M33 = num3;
            result.M34 = 0f;
            result.M41 = 0f;
            result.M42 = 0f;
            result.M43 = 0f;
            result.M44 = 1f;
        }

        public static Matrix CreateShadow(Vector3 lightDirection, Plane plane)
        {
            Plane plane2;
            Matrix matrix;
            Plane.Normalize(ref plane, out plane2);
            float num = ((plane2.Normal.X * lightDirection.X) + (plane2.Normal.Y * lightDirection.Y)) + (plane2.Normal.Z * lightDirection.Z);
            float num2 = -plane2.Normal.X;
            float num3 = -plane2.Normal.Y;
            float num4 = -plane2.Normal.Z;
            float num5 = -plane2.D;
            matrix.M11 = (num2 * lightDirection.X) + num;
            matrix.M21 = num3 * lightDirection.X;
            matrix.M31 = num4 * lightDirection.X;
            matrix.M41 = num5 * lightDirection.X;
            matrix.M12 = num2 * lightDirection.Y;
            matrix.M22 = (num3 * lightDirection.Y) + num;
            matrix.M32 = num4 * lightDirection.Y;
            matrix.M42 = num5 * lightDirection.Y;
            matrix.M13 = num2 * lightDirection.Z;
            matrix.M23 = num3 * lightDirection.Z;
            matrix.M33 = (num4 * lightDirection.Z) + num;
            matrix.M43 = num5 * lightDirection.Z;
            matrix.M14 = 0f;
            matrix.M24 = 0f;
            matrix.M34 = 0f;
            matrix.M44 = num;
            return matrix;
        }

        public static void CreateShadow(ref Vector3 lightDirection, ref Plane plane, out Matrix result)
        {
            Plane plane2;
            Plane.Normalize(ref plane, out plane2);
            float num = ((plane2.Normal.X * lightDirection.X) + (plane2.Normal.Y * lightDirection.Y)) + (plane2.Normal.Z * lightDirection.Z);
            float num2 = -plane2.Normal.X;
            float num3 = -plane2.Normal.Y;
            float num4 = -plane2.Normal.Z;
            float num5 = -plane2.D;
            result.M11 = (num2 * lightDirection.X) + num;
            result.M21 = num3 * lightDirection.X;
            result.M31 = num4 * lightDirection.X;
            result.M41 = num5 * lightDirection.X;
            result.M12 = num2 * lightDirection.Y;
            result.M22 = (num3 * lightDirection.Y) + num;
            result.M32 = num4 * lightDirection.Y;
            result.M42 = num5 * lightDirection.Y;
            result.M13 = num2 * lightDirection.Z;
            result.M23 = num3 * lightDirection.Z;
            result.M33 = (num4 * lightDirection.Z) + num;
            result.M43 = num5 * lightDirection.Z;
            result.M14 = 0f;
            result.M24 = 0f;
            result.M34 = 0f;
            result.M44 = num;
        }

        public static Matrix CreateTranslation(Vector3 position)
        {
            Matrix matrix;
            matrix.M11 = 1f;
            matrix.M12 = 0f;
            matrix.M13 = 0f;
            matrix.M14 = 0f;
            matrix.M21 = 0f;
            matrix.M22 = 1f;
            matrix.M23 = 0f;
            matrix.M24 = 0f;
            matrix.M31 = 0f;
            matrix.M32 = 0f;
            matrix.M33 = 1f;
            matrix.M34 = 0f;
            matrix.M41 = position.X;
            matrix.M42 = position.Y;
            matrix.M43 = position.Z;
            matrix.M44 = 1f;
            return matrix;
        }

        public static void CreateTranslation(ref Vector3 position, out Matrix result)
        {
            result.M11 = 1f;
            result.M12 = 0f;
            result.M13 = 0f;
            result.M14 = 0f;
            result.M21 = 0f;
            result.M22 = 1f;
            result.M23 = 0f;
            result.M24 = 0f;
            result.M31 = 0f;
            result.M32 = 0f;
            result.M33 = 1f;
            result.M34 = 0f;
            result.M41 = position.X;
            result.M42 = position.Y;
            result.M43 = position.Z;
            result.M44 = 1f;
        }

        public static Matrix CreateTranslation(float xPosition, float yPosition, float zPosition)
        {
            Matrix matrix;
            matrix.M11 = 1f;
            matrix.M12 = 0f;
            matrix.M13 = 0f;
            matrix.M14 = 0f;
            matrix.M21 = 0f;
            matrix.M22 = 1f;
            matrix.M23 = 0f;
            matrix.M24 = 0f;
            matrix.M31 = 0f;
            matrix.M32 = 0f;
            matrix.M33 = 1f;
            matrix.M34 = 0f;
            matrix.M41 = xPosition;
            matrix.M42 = yPosition;
            matrix.M43 = zPosition;
            matrix.M44 = 1f;
            return matrix;
        }

        public static void CreateTranslation(float xPosition, float yPosition, float zPosition, out Matrix result)
        {
            result.M11 = 1f;
            result.M12 = 0f;
            result.M13 = 0f;
            result.M14 = 0f;
            result.M21 = 0f;
            result.M22 = 1f;
            result.M23 = 0f;
            result.M24 = 0f;
            result.M31 = 0f;
            result.M32 = 0f;
            result.M33 = 1f;
            result.M34 = 0f;
            result.M41 = xPosition;
            result.M42 = yPosition;
            result.M43 = zPosition;
            result.M44 = 1f;
        }

        public static Matrix CreateWorld(Vector3 position) => 
            CreateWorld(position, Vector3.Forward, Vector3.Up);

        public static Matrix CreateWorld(Vector3 position, Vector3 forward, Vector3 up)
        {
            Vector3 vector2;
            Vector3 vector3;
            Vector3 vector4;
            Matrix matrix;
            Vector3 vector = Vector3.Normalize(-forward);
            Vector3.Cross(ref up, ref vector, out vector2);
            Vector3.Normalize(ref vector2, out vector3);
            Vector3.Cross(ref vector, ref vector3, out vector4);
            matrix.M11 = vector3.X;
            matrix.M12 = vector3.Y;
            matrix.M13 = vector3.Z;
            matrix.M14 = 0f;
            matrix.M21 = vector4.X;
            matrix.M22 = vector4.Y;
            matrix.M23 = vector4.Z;
            matrix.M24 = 0f;
            matrix.M31 = vector.X;
            matrix.M32 = vector.Y;
            matrix.M33 = vector.Z;
            matrix.M34 = 0f;
            matrix.M41 = position.X;
            matrix.M42 = position.Y;
            matrix.M43 = position.Z;
            matrix.M44 = 1f;
            return matrix;
        }

        public static void CreateWorld(ref Vector3 position, ref Vector3 forward, ref Vector3 up, out Matrix result)
        {
            Vector3 vector;
            Vector3 vector3;
            Vector3 vector4;
            Vector3 vector5;
            Vector3 vector2 = -forward;
            Vector3.Normalize(ref vector2, out vector);
            Vector3.Cross(ref up, ref vector, out vector3);
            Vector3.Normalize(ref vector3, out vector4);
            Vector3.Cross(ref vector, ref vector4, out vector5);
            result.M11 = vector4.X;
            result.M12 = vector4.Y;
            result.M13 = vector4.Z;
            result.M14 = 0f;
            result.M21 = vector5.X;
            result.M22 = vector5.Y;
            result.M23 = vector5.Z;
            result.M24 = 0f;
            result.M31 = vector.X;
            result.M32 = vector.Y;
            result.M33 = vector.Z;
            result.M34 = 0f;
            result.M41 = position.X;
            result.M42 = position.Y;
            result.M43 = position.Z;
            result.M44 = 1f;
        }

        public float Determinant()
        {
            float num = this.M11;
            float num2 = this.M12;
            float num3 = this.M13;
            float num4 = this.M14;
            float num5 = this.M21;
            float num6 = this.M22;
            float num7 = this.M23;
            float num8 = this.M24;
            float num9 = this.M31;
            float num10 = this.M32;
            float num11 = this.M33;
            float num12 = this.M34;
            float num13 = this.M41;
            float num14 = this.M42;
            float num15 = this.M43;
            float num16 = this.M44;
            float num17 = (num11 * num16) - (num12 * num15);
            float num18 = (num10 * num16) - (num12 * num14);
            float num19 = (num10 * num15) - (num11 * num14);
            float num20 = (num9 * num16) - (num12 * num13);
            float num21 = (num9 * num15) - (num11 * num13);
            float num22 = (num9 * num14) - (num10 * num13);
            return ((((num * (((num6 * num17) - (num7 * num18)) + (num8 * num19))) - (num2 * (((num5 * num17) - (num7 * num20)) + (num8 * num21)))) + (num3 * (((num5 * num18) - (num6 * num20)) + (num8 * num22)))) - (num4 * (((num5 * num19) - (num6 * num21)) + (num7 * num22))));
        }

        public static Matrix Divide(Matrix matrix1, float divider)
        {
            Matrix matrix;
            float num = 1f / divider;
            matrix.M11 = matrix1.M11 * num;
            matrix.M12 = matrix1.M12 * num;
            matrix.M13 = matrix1.M13 * num;
            matrix.M14 = matrix1.M14 * num;
            matrix.M21 = matrix1.M21 * num;
            matrix.M22 = matrix1.M22 * num;
            matrix.M23 = matrix1.M23 * num;
            matrix.M24 = matrix1.M24 * num;
            matrix.M31 = matrix1.M31 * num;
            matrix.M32 = matrix1.M32 * num;
            matrix.M33 = matrix1.M33 * num;
            matrix.M34 = matrix1.M34 * num;
            matrix.M41 = matrix1.M41 * num;
            matrix.M42 = matrix1.M42 * num;
            matrix.M43 = matrix1.M43 * num;
            matrix.M44 = matrix1.M44 * num;
            return matrix;
        }

        public static Matrix Divide(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrix;
            matrix.M11 = matrix1.M11 / matrix2.M11;
            matrix.M12 = matrix1.M12 / matrix2.M12;
            matrix.M13 = matrix1.M13 / matrix2.M13;
            matrix.M14 = matrix1.M14 / matrix2.M14;
            matrix.M21 = matrix1.M21 / matrix2.M21;
            matrix.M22 = matrix1.M22 / matrix2.M22;
            matrix.M23 = matrix1.M23 / matrix2.M23;
            matrix.M24 = matrix1.M24 / matrix2.M24;
            matrix.M31 = matrix1.M31 / matrix2.M31;
            matrix.M32 = matrix1.M32 / matrix2.M32;
            matrix.M33 = matrix1.M33 / matrix2.M33;
            matrix.M34 = matrix1.M34 / matrix2.M34;
            matrix.M41 = matrix1.M41 / matrix2.M41;
            matrix.M42 = matrix1.M42 / matrix2.M42;
            matrix.M43 = matrix1.M43 / matrix2.M43;
            matrix.M44 = matrix1.M44 / matrix2.M44;
            return matrix;
        }

        public static void Divide(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
        {
            result.M11 = matrix1.M11 / matrix2.M11;
            result.M12 = matrix1.M12 / matrix2.M12;
            result.M13 = matrix1.M13 / matrix2.M13;
            result.M14 = matrix1.M14 / matrix2.M14;
            result.M21 = matrix1.M21 / matrix2.M21;
            result.M22 = matrix1.M22 / matrix2.M22;
            result.M23 = matrix1.M23 / matrix2.M23;
            result.M24 = matrix1.M24 / matrix2.M24;
            result.M31 = matrix1.M31 / matrix2.M31;
            result.M32 = matrix1.M32 / matrix2.M32;
            result.M33 = matrix1.M33 / matrix2.M33;
            result.M34 = matrix1.M34 / matrix2.M34;
            result.M41 = matrix1.M41 / matrix2.M41;
            result.M42 = matrix1.M42 / matrix2.M42;
            result.M43 = matrix1.M43 / matrix2.M43;
            result.M44 = matrix1.M44 / matrix2.M44;
        }

        public static void Divide(ref Matrix matrix1, float divider, out Matrix result)
        {
            float num = 1f / divider;
            result.M11 = matrix1.M11 * num;
            result.M12 = matrix1.M12 * num;
            result.M13 = matrix1.M13 * num;
            result.M14 = matrix1.M14 * num;
            result.M21 = matrix1.M21 * num;
            result.M22 = matrix1.M22 * num;
            result.M23 = matrix1.M23 * num;
            result.M24 = matrix1.M24 * num;
            result.M31 = matrix1.M31 * num;
            result.M32 = matrix1.M32 * num;
            result.M33 = matrix1.M33 * num;
            result.M34 = matrix1.M34 * num;
            result.M41 = matrix1.M41 * num;
            result.M42 = matrix1.M42 * num;
            result.M43 = matrix1.M43 * num;
            result.M44 = matrix1.M44 * num;
        }

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is Matrix)
            {
                flag = this.Equals((Matrix) obj);
            }
            return flag;
        }

        public bool Equals(Matrix other) => 
            ((((((this.M11 == other.M11) && (this.M22 == other.M22)) && ((this.M33 == other.M33) && (this.M44 == other.M44))) && (((this.M12 == other.M12) && (this.M13 == other.M13)) && ((this.M14 == other.M14) && (this.M21 == other.M21)))) && ((((this.M23 == other.M23) && (this.M24 == other.M24)) && ((this.M31 == other.M31) && (this.M32 == other.M32))) && (((this.M34 == other.M34) && (this.M41 == other.M41)) && (this.M42 == other.M42)))) && (this.M43 == other.M43));

        public bool EqualsFast(ref Matrix other, float epsilon = 0.0001f)
        {
            float num = this.M21 - other.M21;
            float num2 = this.M22 - other.M22;
            float num3 = this.M23 - other.M23;
            float num4 = this.M31 - other.M31;
            float num5 = this.M32 - other.M32;
            float num6 = this.M33 - other.M33;
            float num7 = this.M41 - other.M41;
            float num8 = this.M42 - other.M42;
            float num9 = this.M43 - other.M43;
            float num10 = epsilon * epsilon;
            return ((((((num * num) + (num2 * num2)) + (num3 * num3)) < num10) & ((((num4 * num4) + (num5 * num5)) + (num6 * num6)) < num10)) & ((((num7 * num7) + (num8 * num8)) + (num9 * num9)) < num10));
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

        public static bool GetEulerAnglesXYZ(ref Matrix mat, out Vector3 xyz)
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
            (((((((((((((((this.M11.GetHashCode() + this.M12.GetHashCode()) + this.M13.GetHashCode()) + this.M14.GetHashCode()) + this.M21.GetHashCode()) + this.M22.GetHashCode()) + this.M23.GetHashCode()) + this.M24.GetHashCode()) + this.M31.GetHashCode()) + this.M32.GetHashCode()) + this.M33.GetHashCode()) + this.M34.GetHashCode()) + this.M41.GetHashCode()) + this.M42.GetHashCode()) + this.M43.GetHashCode()) + this.M44.GetHashCode());

        public Matrix GetOrientation()
        {
            Matrix identity = Identity;
            identity.Forward = this.Forward;
            identity.Up = this.Up;
            identity.Right = this.Right;
            return identity;
        }

        public unsafe Vector4 GetRow(int row)
        {
            fixed (float* numRef = &this.M11)
            {
                float* numPtr = numRef + ((row * 4) * 4);
                return new Vector4(numPtr[0], numPtr[4], numPtr[8], numPtr[12]);
            }
        }

        public bool HasNoTranslationOrPerspective()
        {
            float num = 0.0001f;
            float num2 = ((((this.M41 + this.M42) + this.M43) + this.M34) + this.M24) + this.M14;
            if (num2 > num)
            {
                return false;
            }
            if (Math.Abs((float) (this.M44 - 1f)) > num)
            {
                return false;
            }
            return true;
        }

        public static Matrix Invert(Matrix matrix) => 
            Invert(ref matrix);

        public static Matrix Invert(ref Matrix matrix)
        {
            Matrix matrix2;
            float num = matrix.M11;
            float num2 = matrix.M12;
            float num3 = matrix.M13;
            float num4 = matrix.M14;
            float num5 = matrix.M21;
            float num6 = matrix.M22;
            float num7 = matrix.M23;
            float num8 = matrix.M24;
            float num9 = matrix.M31;
            float num10 = matrix.M32;
            float num11 = matrix.M33;
            float num12 = matrix.M34;
            float num13 = matrix.M41;
            float num14 = matrix.M42;
            float num15 = matrix.M43;
            float num16 = matrix.M44;
            float num17 = (num11 * num16) - (num12 * num15);
            float num18 = (num10 * num16) - (num12 * num14);
            float num19 = (num10 * num15) - (num11 * num14);
            float num20 = (num9 * num16) - (num12 * num13);
            float num21 = (num9 * num15) - (num11 * num13);
            float num22 = (num9 * num14) - (num10 * num13);
            float num23 = ((num6 * num17) - (num7 * num18)) + (num8 * num19);
            float num24 = -(((num5 * num17) - (num7 * num20)) + (num8 * num21));
            float num25 = ((num5 * num18) - (num6 * num20)) + (num8 * num22);
            float num26 = -(((num5 * num19) - (num6 * num21)) + (num7 * num22));
            float num27 = (float) (1.0 / ((((num * num23) + (num2 * num24)) + (num3 * num25)) + (num4 * num26)));
            matrix2.M11 = num23 * num27;
            matrix2.M21 = num24 * num27;
            matrix2.M31 = num25 * num27;
            matrix2.M41 = num26 * num27;
            matrix2.M12 = -(((num2 * num17) - (num3 * num18)) + (num4 * num19)) * num27;
            matrix2.M22 = (((num * num17) - (num3 * num20)) + (num4 * num21)) * num27;
            matrix2.M32 = -(((num * num18) - (num2 * num20)) + (num4 * num22)) * num27;
            matrix2.M42 = (((num * num19) - (num2 * num21)) + (num3 * num22)) * num27;
            float num28 = (num7 * num16) - (num8 * num15);
            float num29 = (num6 * num16) - (num8 * num14);
            float num30 = (num6 * num15) - (num7 * num14);
            float num31 = (num5 * num16) - (num8 * num13);
            float num32 = (num5 * num15) - (num7 * num13);
            float num33 = (num5 * num14) - (num6 * num13);
            matrix2.M13 = (((num2 * num28) - (num3 * num29)) + (num4 * num30)) * num27;
            matrix2.M23 = -(((num * num28) - (num3 * num31)) + (num4 * num32)) * num27;
            matrix2.M33 = (((num * num29) - (num2 * num31)) + (num4 * num33)) * num27;
            matrix2.M43 = -(((num * num30) - (num2 * num32)) + (num3 * num33)) * num27;
            float num34 = (num7 * num12) - (num8 * num11);
            float num35 = (num6 * num12) - (num8 * num10);
            float num36 = (num6 * num11) - (num7 * num10);
            float num37 = (num5 * num12) - (num8 * num9);
            float num38 = (num5 * num11) - (num7 * num9);
            float num39 = (num5 * num10) - (num6 * num9);
            matrix2.M14 = -(((num2 * num34) - (num3 * num35)) + (num4 * num36)) * num27;
            matrix2.M24 = (((num * num34) - (num3 * num37)) + (num4 * num38)) * num27;
            matrix2.M34 = -(((num * num35) - (num2 * num37)) + (num4 * num39)) * num27;
            matrix2.M44 = (((num * num36) - (num2 * num38)) + (num3 * num39)) * num27;
            return matrix2;
        }

        public static void Invert(ref Matrix matrix, out Matrix result)
        {
            float num = matrix.M11;
            float num2 = matrix.M12;
            float num3 = matrix.M13;
            float num4 = matrix.M14;
            float num5 = matrix.M21;
            float num6 = matrix.M22;
            float num7 = matrix.M23;
            float num8 = matrix.M24;
            float num9 = matrix.M31;
            float num10 = matrix.M32;
            float num11 = matrix.M33;
            float num12 = matrix.M34;
            float num13 = matrix.M41;
            float num14 = matrix.M42;
            float num15 = matrix.M43;
            float num16 = matrix.M44;
            float num17 = (num11 * num16) - (num12 * num15);
            float num18 = (num10 * num16) - (num12 * num14);
            float num19 = (num10 * num15) - (num11 * num14);
            float num20 = (num9 * num16) - (num12 * num13);
            float num21 = (num9 * num15) - (num11 * num13);
            float num22 = (num9 * num14) - (num10 * num13);
            float num23 = ((num6 * num17) - (num7 * num18)) + (num8 * num19);
            float num24 = -(((num5 * num17) - (num7 * num20)) + (num8 * num21));
            float num25 = ((num5 * num18) - (num6 * num20)) + (num8 * num22);
            float num26 = -(((num5 * num19) - (num6 * num21)) + (num7 * num22));
            float num27 = (float) (1.0 / ((((num * num23) + (num2 * num24)) + (num3 * num25)) + (num4 * num26)));
            result.M11 = num23 * num27;
            result.M21 = num24 * num27;
            result.M31 = num25 * num27;
            result.M41 = num26 * num27;
            result.M12 = -(((num2 * num17) - (num3 * num18)) + (num4 * num19)) * num27;
            result.M22 = (((num * num17) - (num3 * num20)) + (num4 * num21)) * num27;
            result.M32 = -(((num * num18) - (num2 * num20)) + (num4 * num22)) * num27;
            result.M42 = (((num * num19) - (num2 * num21)) + (num3 * num22)) * num27;
            float num28 = (num7 * num16) - (num8 * num15);
            float num29 = (num6 * num16) - (num8 * num14);
            float num30 = (num6 * num15) - (num7 * num14);
            float num31 = (num5 * num16) - (num8 * num13);
            float num32 = (num5 * num15) - (num7 * num13);
            float num33 = (num5 * num14) - (num6 * num13);
            result.M13 = (((num2 * num28) - (num3 * num29)) + (num4 * num30)) * num27;
            result.M23 = -(((num * num28) - (num3 * num31)) + (num4 * num32)) * num27;
            result.M33 = (((num * num29) - (num2 * num31)) + (num4 * num33)) * num27;
            result.M43 = -(((num * num30) - (num2 * num32)) + (num3 * num33)) * num27;
            float num34 = (num7 * num12) - (num8 * num11);
            float num35 = (num6 * num12) - (num8 * num10);
            float num36 = (num6 * num11) - (num7 * num10);
            float num37 = (num5 * num12) - (num8 * num9);
            float num38 = (num5 * num11) - (num7 * num9);
            float num39 = (num5 * num10) - (num6 * num9);
            result.M14 = -(((num2 * num34) - (num3 * num35)) + (num4 * num36)) * num27;
            result.M24 = (((num * num34) - (num3 * num37)) + (num4 * num38)) * num27;
            result.M34 = -(((num * num35) - (num2 * num37)) + (num4 * num39)) * num27;
            result.M44 = (((num * num36) - (num2 * num38)) + (num3 * num39)) * num27;
        }

        public bool IsMirrored() => 
            (this.Determinant() < 0f);

        public bool IsNan() => 
            float.IsNaN(((((((((((((((this.M11 + this.M12) + this.M13) + this.M14) + this.M21) + this.M22) + this.M23) + this.M24) + this.M31) + this.M32) + this.M33) + this.M34) + this.M41) + this.M42) + this.M43) + this.M44);

        public bool IsOrthogonal() => 
            (((((Math.Abs(this.Up.LengthSquared()) - 1f) < 0.0001f) && ((Math.Abs(this.Right.LengthSquared()) - 1f) < 0.0001f)) && (((Math.Abs(this.Forward.LengthSquared()) - 1f) < 0.0001f) && (Math.Abs(this.Right.Dot(this.Up)) < 0.0001f))) && (Math.Abs(this.Right.Dot(this.Forward)) < 0.0001f));

        public bool IsRotation()
        {
            float num = 0.01f;
            if (!this.HasNoTranslationOrPerspective())
            {
                return false;
            }
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
            (((((((((((((((this.M11 + this.M12) + this.M13) + this.M14) + this.M21) + this.M22) + this.M23) + this.M24) + this.M31) + this.M32) + this.M33) + this.M34) + this.M41) + this.M42) + this.M43) + this.M44).IsValid();

        public static Matrix Lerp(Matrix matrix1, Matrix matrix2, float amount)
        {
            Matrix matrix;
            matrix.M11 = matrix1.M11 + ((matrix2.M11 - matrix1.M11) * amount);
            matrix.M12 = matrix1.M12 + ((matrix2.M12 - matrix1.M12) * amount);
            matrix.M13 = matrix1.M13 + ((matrix2.M13 - matrix1.M13) * amount);
            matrix.M14 = matrix1.M14 + ((matrix2.M14 - matrix1.M14) * amount);
            matrix.M21 = matrix1.M21 + ((matrix2.M21 - matrix1.M21) * amount);
            matrix.M22 = matrix1.M22 + ((matrix2.M22 - matrix1.M22) * amount);
            matrix.M23 = matrix1.M23 + ((matrix2.M23 - matrix1.M23) * amount);
            matrix.M24 = matrix1.M24 + ((matrix2.M24 - matrix1.M24) * amount);
            matrix.M31 = matrix1.M31 + ((matrix2.M31 - matrix1.M31) * amount);
            matrix.M32 = matrix1.M32 + ((matrix2.M32 - matrix1.M32) * amount);
            matrix.M33 = matrix1.M33 + ((matrix2.M33 - matrix1.M33) * amount);
            matrix.M34 = matrix1.M34 + ((matrix2.M34 - matrix1.M34) * amount);
            matrix.M41 = matrix1.M41 + ((matrix2.M41 - matrix1.M41) * amount);
            matrix.M42 = matrix1.M42 + ((matrix2.M42 - matrix1.M42) * amount);
            matrix.M43 = matrix1.M43 + ((matrix2.M43 - matrix1.M43) * amount);
            matrix.M44 = matrix1.M44 + ((matrix2.M44 - matrix1.M44) * amount);
            return matrix;
        }

        public static void Lerp(ref Matrix matrix1, ref Matrix matrix2, float amount, out Matrix result)
        {
            result.M11 = matrix1.M11 + ((matrix2.M11 - matrix1.M11) * amount);
            result.M12 = matrix1.M12 + ((matrix2.M12 - matrix1.M12) * amount);
            result.M13 = matrix1.M13 + ((matrix2.M13 - matrix1.M13) * amount);
            result.M14 = matrix1.M14 + ((matrix2.M14 - matrix1.M14) * amount);
            result.M21 = matrix1.M21 + ((matrix2.M21 - matrix1.M21) * amount);
            result.M22 = matrix1.M22 + ((matrix2.M22 - matrix1.M22) * amount);
            result.M23 = matrix1.M23 + ((matrix2.M23 - matrix1.M23) * amount);
            result.M24 = matrix1.M24 + ((matrix2.M24 - matrix1.M24) * amount);
            result.M31 = matrix1.M31 + ((matrix2.M31 - matrix1.M31) * amount);
            result.M32 = matrix1.M32 + ((matrix2.M32 - matrix1.M32) * amount);
            result.M33 = matrix1.M33 + ((matrix2.M33 - matrix1.M33) * amount);
            result.M34 = matrix1.M34 + ((matrix2.M34 - matrix1.M34) * amount);
            result.M41 = matrix1.M41 + ((matrix2.M41 - matrix1.M41) * amount);
            result.M42 = matrix1.M42 + ((matrix2.M42 - matrix1.M42) * amount);
            result.M43 = matrix1.M43 + ((matrix2.M43 - matrix1.M43) * amount);
            result.M44 = matrix1.M44 + ((matrix2.M44 - matrix1.M44) * amount);
        }

        public static Matrix Multiply(Matrix matrix1, float scaleFactor)
        {
            Matrix matrix;
            float num = scaleFactor;
            matrix.M11 = matrix1.M11 * num;
            matrix.M12 = matrix1.M12 * num;
            matrix.M13 = matrix1.M13 * num;
            matrix.M14 = matrix1.M14 * num;
            matrix.M21 = matrix1.M21 * num;
            matrix.M22 = matrix1.M22 * num;
            matrix.M23 = matrix1.M23 * num;
            matrix.M24 = matrix1.M24 * num;
            matrix.M31 = matrix1.M31 * num;
            matrix.M32 = matrix1.M32 * num;
            matrix.M33 = matrix1.M33 * num;
            matrix.M34 = matrix1.M34 * num;
            matrix.M41 = matrix1.M41 * num;
            matrix.M42 = matrix1.M42 * num;
            matrix.M43 = matrix1.M43 * num;
            matrix.M44 = matrix1.M44 * num;
            return matrix;
        }

        public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrix;
            matrix.M11 = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
            matrix.M12 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
            matrix.M13 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
            matrix.M14 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
            matrix.M21 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
            matrix.M22 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
            matrix.M23 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
            matrix.M24 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
            matrix.M31 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
            matrix.M32 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
            matrix.M33 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
            matrix.M34 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
            matrix.M41 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
            matrix.M42 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
            matrix.M43 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
            matrix.M44 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
            return matrix;
        }

        public static void Multiply(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
        {
            float num = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
            float num2 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
            float num3 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
            float num4 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
            float num5 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
            float num6 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
            float num7 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
            float num8 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
            float num9 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
            float num10 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
            float num11 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
            float num12 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
            float num13 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
            float num14 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
            float num15 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
            float num16 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
            result.M11 = num;
            result.M12 = num2;
            result.M13 = num3;
            result.M14 = num4;
            result.M21 = num5;
            result.M22 = num6;
            result.M23 = num7;
            result.M24 = num8;
            result.M31 = num9;
            result.M32 = num10;
            result.M33 = num11;
            result.M34 = num12;
            result.M41 = num13;
            result.M42 = num14;
            result.M43 = num15;
            result.M44 = num16;
        }

        public static void Multiply(ref Matrix matrix1, float scaleFactor, out Matrix result)
        {
            float num = scaleFactor;
            result.M11 = matrix1.M11 * num;
            result.M12 = matrix1.M12 * num;
            result.M13 = matrix1.M13 * num;
            result.M14 = matrix1.M14 * num;
            result.M21 = matrix1.M21 * num;
            result.M22 = matrix1.M22 * num;
            result.M23 = matrix1.M23 * num;
            result.M24 = matrix1.M24 * num;
            result.M31 = matrix1.M31 * num;
            result.M32 = matrix1.M32 * num;
            result.M33 = matrix1.M33 * num;
            result.M34 = matrix1.M34 * num;
            result.M41 = matrix1.M41 * num;
            result.M42 = matrix1.M42 * num;
            result.M43 = matrix1.M43 * num;
            result.M44 = matrix1.M44 * num;
        }

        public static Matrix Negate(Matrix matrix)
        {
            Matrix matrix2;
            matrix2.M11 = -matrix.M11;
            matrix2.M12 = -matrix.M12;
            matrix2.M13 = -matrix.M13;
            matrix2.M14 = -matrix.M14;
            matrix2.M21 = -matrix.M21;
            matrix2.M22 = -matrix.M22;
            matrix2.M23 = -matrix.M23;
            matrix2.M24 = -matrix.M24;
            matrix2.M31 = -matrix.M31;
            matrix2.M32 = -matrix.M32;
            matrix2.M33 = -matrix.M33;
            matrix2.M34 = -matrix.M34;
            matrix2.M41 = -matrix.M41;
            matrix2.M42 = -matrix.M42;
            matrix2.M43 = -matrix.M43;
            matrix2.M44 = -matrix.M44;
            return matrix2;
        }

        public static void Negate(ref Matrix matrix, out Matrix result)
        {
            result.M11 = -matrix.M11;
            result.M12 = -matrix.M12;
            result.M13 = -matrix.M13;
            result.M14 = -matrix.M14;
            result.M21 = -matrix.M21;
            result.M22 = -matrix.M22;
            result.M23 = -matrix.M23;
            result.M24 = -matrix.M24;
            result.M31 = -matrix.M31;
            result.M32 = -matrix.M32;
            result.M33 = -matrix.M33;
            result.M34 = -matrix.M34;
            result.M41 = -matrix.M41;
            result.M42 = -matrix.M42;
            result.M43 = -matrix.M43;
            result.M44 = -matrix.M44;
        }

        public static Matrix Normalize(Matrix matrix)
        {
            Matrix matrix2 = matrix;
            matrix2.Right = Vector3.Normalize(matrix2.Right);
            matrix2.Up = Vector3.Normalize(matrix2.Up);
            matrix2.Forward = Vector3.Normalize(matrix2.Forward);
            return matrix2;
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrix;
            matrix.M11 = matrix1.M11 + matrix2.M11;
            matrix.M12 = matrix1.M12 + matrix2.M12;
            matrix.M13 = matrix1.M13 + matrix2.M13;
            matrix.M14 = matrix1.M14 + matrix2.M14;
            matrix.M21 = matrix1.M21 + matrix2.M21;
            matrix.M22 = matrix1.M22 + matrix2.M22;
            matrix.M23 = matrix1.M23 + matrix2.M23;
            matrix.M24 = matrix1.M24 + matrix2.M24;
            matrix.M31 = matrix1.M31 + matrix2.M31;
            matrix.M32 = matrix1.M32 + matrix2.M32;
            matrix.M33 = matrix1.M33 + matrix2.M33;
            matrix.M34 = matrix1.M34 + matrix2.M34;
            matrix.M41 = matrix1.M41 + matrix2.M41;
            matrix.M42 = matrix1.M42 + matrix2.M42;
            matrix.M43 = matrix1.M43 + matrix2.M43;
            matrix.M44 = matrix1.M44 + matrix2.M44;
            return matrix;
        }

        public static Matrix operator /(Matrix matrix1, float divider)
        {
            Matrix matrix;
            float num = 1f / divider;
            matrix.M11 = matrix1.M11 * num;
            matrix.M12 = matrix1.M12 * num;
            matrix.M13 = matrix1.M13 * num;
            matrix.M14 = matrix1.M14 * num;
            matrix.M21 = matrix1.M21 * num;
            matrix.M22 = matrix1.M22 * num;
            matrix.M23 = matrix1.M23 * num;
            matrix.M24 = matrix1.M24 * num;
            matrix.M31 = matrix1.M31 * num;
            matrix.M32 = matrix1.M32 * num;
            matrix.M33 = matrix1.M33 * num;
            matrix.M34 = matrix1.M34 * num;
            matrix.M41 = matrix1.M41 * num;
            matrix.M42 = matrix1.M42 * num;
            matrix.M43 = matrix1.M43 * num;
            matrix.M44 = matrix1.M44 * num;
            return matrix;
        }

        public static Matrix operator /(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrix;
            matrix.M11 = matrix1.M11 / matrix2.M11;
            matrix.M12 = matrix1.M12 / matrix2.M12;
            matrix.M13 = matrix1.M13 / matrix2.M13;
            matrix.M14 = matrix1.M14 / matrix2.M14;
            matrix.M21 = matrix1.M21 / matrix2.M21;
            matrix.M22 = matrix1.M22 / matrix2.M22;
            matrix.M23 = matrix1.M23 / matrix2.M23;
            matrix.M24 = matrix1.M24 / matrix2.M24;
            matrix.M31 = matrix1.M31 / matrix2.M31;
            matrix.M32 = matrix1.M32 / matrix2.M32;
            matrix.M33 = matrix1.M33 / matrix2.M33;
            matrix.M34 = matrix1.M34 / matrix2.M34;
            matrix.M41 = matrix1.M41 / matrix2.M41;
            matrix.M42 = matrix1.M42 / matrix2.M42;
            matrix.M43 = matrix1.M43 / matrix2.M43;
            matrix.M44 = matrix1.M44 / matrix2.M44;
            return matrix;
        }

        public static bool operator ==(Matrix matrix1, Matrix matrix2) => 
            ((((((matrix1.M11 == matrix2.M11) && (matrix1.M22 == matrix2.M22)) && ((matrix1.M33 == matrix2.M33) && (matrix1.M44 == matrix2.M44))) && (((matrix1.M12 == matrix2.M12) && (matrix1.M13 == matrix2.M13)) && ((matrix1.M14 == matrix2.M14) && (matrix1.M21 == matrix2.M21)))) && ((((matrix1.M23 == matrix2.M23) && (matrix1.M24 == matrix2.M24)) && ((matrix1.M31 == matrix2.M31) && (matrix1.M32 == matrix2.M32))) && (((matrix1.M34 == matrix2.M34) && (matrix1.M41 == matrix2.M41)) && (matrix1.M42 == matrix2.M42)))) && (matrix1.M43 == matrix2.M43));

        public static bool operator !=(Matrix matrix1, Matrix matrix2)
        {
            if (((((matrix1.M11 == matrix2.M11) && (matrix1.M12 == matrix2.M12)) && ((matrix1.M13 == matrix2.M13) && (matrix1.M14 == matrix2.M14))) && (((matrix1.M21 == matrix2.M21) && (matrix1.M22 == matrix2.M22)) && ((matrix1.M23 == matrix2.M23) && (matrix1.M24 == matrix2.M24)))) && ((((matrix1.M31 == matrix2.M31) && (matrix1.M32 == matrix2.M32)) && ((matrix1.M33 == matrix2.M33) && (matrix1.M34 == matrix2.M34))) && (((matrix1.M41 == matrix2.M41) && (matrix1.M42 == matrix2.M42)) && (matrix1.M43 == matrix2.M43))))
            {
                return !(matrix1.M44 == matrix2.M44);
            }
            return true;
        }

        public static Matrix operator *(float scaleFactor, Matrix matrix)
        {
            Matrix matrix2;
            float num = scaleFactor;
            matrix2.M11 = matrix.M11 * num;
            matrix2.M12 = matrix.M12 * num;
            matrix2.M13 = matrix.M13 * num;
            matrix2.M14 = matrix.M14 * num;
            matrix2.M21 = matrix.M21 * num;
            matrix2.M22 = matrix.M22 * num;
            matrix2.M23 = matrix.M23 * num;
            matrix2.M24 = matrix.M24 * num;
            matrix2.M31 = matrix.M31 * num;
            matrix2.M32 = matrix.M32 * num;
            matrix2.M33 = matrix.M33 * num;
            matrix2.M34 = matrix.M34 * num;
            matrix2.M41 = matrix.M41 * num;
            matrix2.M42 = matrix.M42 * num;
            matrix2.M43 = matrix.M43 * num;
            matrix2.M44 = matrix.M44 * num;
            return matrix2;
        }

        public static Matrix operator *(Matrix matrix, float scaleFactor)
        {
            Matrix matrix2;
            float num = scaleFactor;
            matrix2.M11 = matrix.M11 * num;
            matrix2.M12 = matrix.M12 * num;
            matrix2.M13 = matrix.M13 * num;
            matrix2.M14 = matrix.M14 * num;
            matrix2.M21 = matrix.M21 * num;
            matrix2.M22 = matrix.M22 * num;
            matrix2.M23 = matrix.M23 * num;
            matrix2.M24 = matrix.M24 * num;
            matrix2.M31 = matrix.M31 * num;
            matrix2.M32 = matrix.M32 * num;
            matrix2.M33 = matrix.M33 * num;
            matrix2.M34 = matrix.M34 * num;
            matrix2.M41 = matrix.M41 * num;
            matrix2.M42 = matrix.M42 * num;
            matrix2.M43 = matrix.M43 * num;
            matrix2.M44 = matrix.M44 * num;
            return matrix2;
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrix;
            matrix.M11 = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
            matrix.M12 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
            matrix.M13 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
            matrix.M14 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
            matrix.M21 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
            matrix.M22 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
            matrix.M23 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
            matrix.M24 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
            matrix.M31 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
            matrix.M32 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
            matrix.M33 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
            matrix.M34 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
            matrix.M41 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
            matrix.M42 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
            matrix.M43 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
            matrix.M44 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
            return matrix;
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrix;
            matrix.M11 = matrix1.M11 - matrix2.M11;
            matrix.M12 = matrix1.M12 - matrix2.M12;
            matrix.M13 = matrix1.M13 - matrix2.M13;
            matrix.M14 = matrix1.M14 - matrix2.M14;
            matrix.M21 = matrix1.M21 - matrix2.M21;
            matrix.M22 = matrix1.M22 - matrix2.M22;
            matrix.M23 = matrix1.M23 - matrix2.M23;
            matrix.M24 = matrix1.M24 - matrix2.M24;
            matrix.M31 = matrix1.M31 - matrix2.M31;
            matrix.M32 = matrix1.M32 - matrix2.M32;
            matrix.M33 = matrix1.M33 - matrix2.M33;
            matrix.M34 = matrix1.M34 - matrix2.M34;
            matrix.M41 = matrix1.M41 - matrix2.M41;
            matrix.M42 = matrix1.M42 - matrix2.M42;
            matrix.M43 = matrix1.M43 - matrix2.M43;
            matrix.M44 = matrix1.M44 - matrix2.M44;
            return matrix;
        }

        public static Matrix operator -(Matrix matrix1)
        {
            Matrix matrix;
            matrix.M11 = -matrix1.M11;
            matrix.M12 = -matrix1.M12;
            matrix.M13 = -matrix1.M13;
            matrix.M14 = -matrix1.M14;
            matrix.M21 = -matrix1.M21;
            matrix.M22 = -matrix1.M22;
            matrix.M23 = -matrix1.M23;
            matrix.M24 = -matrix1.M24;
            matrix.M31 = -matrix1.M31;
            matrix.M32 = -matrix1.M32;
            matrix.M33 = -matrix1.M33;
            matrix.M34 = -matrix1.M34;
            matrix.M41 = -matrix1.M41;
            matrix.M42 = -matrix1.M42;
            matrix.M43 = -matrix1.M43;
            matrix.M44 = -matrix1.M44;
            return matrix;
        }

        public static Matrix Orthogonalize(Matrix rotationMatrix)
        {
            Matrix matrix = rotationMatrix;
            matrix.Right = Vector3.Normalize(matrix.Right);
            matrix.Up = Vector3.Normalize(matrix.Up - ((Vector3) (matrix.Right * matrix.Up.Dot(matrix.Right))));
            matrix.Backward = Vector3.Normalize((Vector3) ((matrix.Backward - (matrix.Right * matrix.Backward.Dot(matrix.Right))) - (matrix.Up * matrix.Backward.Dot(matrix.Up))));
            return matrix;
        }

        [UnsharperDisableReflection]
        public static void Rescale(ref Matrix matrix, float scale)
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
        public static void Rescale(ref Matrix matrix, ref Vector3 scale)
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
        public static Matrix Rescale(Matrix matrix, float scale)
        {
            Rescale(ref matrix, scale);
            return matrix;
        }

        [UnsharperDisableReflection]
        public static Matrix Rescale(Matrix matrix, Vector3 scale)
        {
            Rescale(ref matrix, ref scale);
            return matrix;
        }

        public static Matrix Round(ref Matrix matrix)
        {
            Matrix matrix2 = matrix;
            matrix2.Right = (Vector3) Vector3I.Round(matrix2.Right);
            matrix2.Up = (Vector3) Vector3I.Round(matrix2.Up);
            matrix2.Forward = (Vector3) Vector3I.Round(matrix2.Forward);
            return matrix2;
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

        public unsafe void SetRow(int row, Vector4 value)
        {
            fixed (float* numRef = &this.M11)
            {
                float* numPtr = numRef + ((row * 4) * 4);
                numPtr[0] = value.X;
                numPtr[4] = value.Y;
                numPtr[8] = value.Z;
                numPtr[12] = value.W;
            }
        }

        public static Matrix Slerp(Matrix matrix1, Matrix matrix2, float amount)
        {
            Matrix matrix;
            Slerp(ref matrix1, ref matrix2, amount, out matrix);
            return matrix;
        }

        public static void Slerp(ref Matrix matrix1, ref Matrix matrix2, float amount, out Matrix result)
        {
            Quaternion quaternion;
            Quaternion quaternion2;
            Quaternion quaternion3;
            Quaternion.CreateFromRotationMatrix(ref matrix1, out quaternion);
            Quaternion.CreateFromRotationMatrix(ref matrix2, out quaternion2);
            Quaternion.Slerp(ref quaternion, ref quaternion2, amount, out quaternion3);
            CreateFromQuaternion(ref quaternion3, out result);
            result.M41 = matrix1.M41 + ((matrix2.M41 - matrix1.M41) * amount);
            result.M42 = matrix1.M42 + ((matrix2.M42 - matrix1.M42) * amount);
            result.M43 = matrix1.M43 + ((matrix2.M43 - matrix1.M43) * amount);
        }

        public static void Slerp(Matrix matrix1, Matrix matrix2, float amount, out Matrix result)
        {
            Slerp(ref matrix1, ref matrix2, amount, out result);
        }

        public static Matrix SlerpScale(Matrix matrix1, Matrix matrix2, float amount)
        {
            Matrix matrix;
            SlerpScale(ref matrix1, ref matrix2, amount, out matrix);
            return matrix;
        }

        public static void SlerpScale(ref Matrix matrix1, ref Matrix matrix2, float amount, out Matrix result)
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
                Matrix matrix = Normalize(matrix1);
                Matrix matrix3 = Normalize(matrix2);
                Quaternion.CreateFromRotationMatrix(ref matrix, out quaternion);
                Quaternion.CreateFromRotationMatrix(ref matrix3, out quaternion2);
                Quaternion.Slerp(ref quaternion, ref quaternion2, amount, out quaternion3);
                CreateFromQuaternion(ref quaternion3, out result);
                Vector3 vector3 = Vector3.Lerp(scale, vector2, amount);
                Rescale(ref result, ref vector3);
                result.M41 = matrix1.M41 + ((matrix2.M41 - matrix1.M41) * amount);
                result.M42 = matrix1.M42 + ((matrix2.M42 - matrix1.M42) * amount);
                result.M43 = matrix1.M43 + ((matrix2.M43 - matrix1.M43) * amount);
            }
        }

        public static void SlerpScale(Matrix matrix1, Matrix matrix2, float amount, out Matrix result)
        {
            SlerpScale(ref matrix1, ref matrix2, amount, out result);
        }

        public static Matrix Subtract(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrix;
            matrix.M11 = matrix1.M11 - matrix2.M11;
            matrix.M12 = matrix1.M12 - matrix2.M12;
            matrix.M13 = matrix1.M13 - matrix2.M13;
            matrix.M14 = matrix1.M14 - matrix2.M14;
            matrix.M21 = matrix1.M21 - matrix2.M21;
            matrix.M22 = matrix1.M22 - matrix2.M22;
            matrix.M23 = matrix1.M23 - matrix2.M23;
            matrix.M24 = matrix1.M24 - matrix2.M24;
            matrix.M31 = matrix1.M31 - matrix2.M31;
            matrix.M32 = matrix1.M32 - matrix2.M32;
            matrix.M33 = matrix1.M33 - matrix2.M33;
            matrix.M34 = matrix1.M34 - matrix2.M34;
            matrix.M41 = matrix1.M41 - matrix2.M41;
            matrix.M42 = matrix1.M42 - matrix2.M42;
            matrix.M43 = matrix1.M43 - matrix2.M43;
            matrix.M44 = matrix1.M44 - matrix2.M44;
            return matrix;
        }

        public static void Subtract(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
        {
            result.M11 = matrix1.M11 - matrix2.M11;
            result.M12 = matrix1.M12 - matrix2.M12;
            result.M13 = matrix1.M13 - matrix2.M13;
            result.M14 = matrix1.M14 - matrix2.M14;
            result.M21 = matrix1.M21 - matrix2.M21;
            result.M22 = matrix1.M22 - matrix2.M22;
            result.M23 = matrix1.M23 - matrix2.M23;
            result.M24 = matrix1.M24 - matrix2.M24;
            result.M31 = matrix1.M31 - matrix2.M31;
            result.M32 = matrix1.M32 - matrix2.M32;
            result.M33 = matrix1.M33 - matrix2.M33;
            result.M34 = matrix1.M34 - matrix2.M34;
            result.M41 = matrix1.M41 - matrix2.M41;
            result.M42 = matrix1.M42 - matrix2.M42;
            result.M43 = matrix1.M43 - matrix2.M43;
            result.M44 = matrix1.M44 - matrix2.M44;
        }

        public static Matrix SwapYZCoordinates(Matrix m) => 
            (m * CreateRotationX(MathHelper.ToRadians((float) -90f)));

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return ("{ " + string.Format(currentCulture, "{{M11:{0} M12:{1} M13:{2} M14:{3}}} ", new object[] { this.M11.ToString(currentCulture), this.M12.ToString(currentCulture), this.M13.ToString(currentCulture), this.M14.ToString(currentCulture) }) + string.Format(currentCulture, "{{M21:{0} M22:{1} M23:{2} M24:{3}}} ", new object[] { this.M21.ToString(currentCulture), this.M22.ToString(currentCulture), this.M23.ToString(currentCulture), this.M24.ToString(currentCulture) }) + string.Format(currentCulture, "{{M31:{0} M32:{1} M33:{2} M34:{3}}} ", new object[] { this.M31.ToString(currentCulture), this.M32.ToString(currentCulture), this.M33.ToString(currentCulture), this.M34.ToString(currentCulture) }) + string.Format(currentCulture, "{{M41:{0} M42:{1} M43:{2} M44:{3}}} ", new object[] { this.M41.ToString(currentCulture), this.M42.ToString(currentCulture), this.M43.ToString(currentCulture), this.M44.ToString(currentCulture) }) + "}");
        }

        public static Matrix Transform(Matrix value, Quaternion rotation)
        {
            Matrix matrix;
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
            matrix.M11 = ((value.M11 * num13) + (value.M12 * num14)) + (value.M13 * num15);
            matrix.M12 = ((value.M11 * num16) + (value.M12 * num17)) + (value.M13 * num18);
            matrix.M13 = ((value.M11 * num19) + (value.M12 * num20)) + (value.M13 * num21);
            matrix.M14 = value.M14;
            matrix.M21 = ((value.M21 * num13) + (value.M22 * num14)) + (value.M23 * num15);
            matrix.M22 = ((value.M21 * num16) + (value.M22 * num17)) + (value.M23 * num18);
            matrix.M23 = ((value.M21 * num19) + (value.M22 * num20)) + (value.M23 * num21);
            matrix.M24 = value.M24;
            matrix.M31 = ((value.M31 * num13) + (value.M32 * num14)) + (value.M33 * num15);
            matrix.M32 = ((value.M31 * num16) + (value.M32 * num17)) + (value.M33 * num18);
            matrix.M33 = ((value.M31 * num19) + (value.M32 * num20)) + (value.M33 * num21);
            matrix.M34 = value.M34;
            matrix.M41 = ((value.M41 * num13) + (value.M42 * num14)) + (value.M43 * num15);
            matrix.M42 = ((value.M41 * num16) + (value.M42 * num17)) + (value.M43 * num18);
            matrix.M43 = ((value.M41 * num19) + (value.M42 * num20)) + (value.M43 * num21);
            matrix.M44 = value.M44;
            return matrix;
        }

        public static void Transform(ref Matrix value, ref Quaternion rotation, out Matrix result)
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
            float num25 = value.M14;
            float num26 = ((value.M21 * num13) + (value.M22 * num14)) + (value.M23 * num15);
            float num27 = ((value.M21 * num16) + (value.M22 * num17)) + (value.M23 * num18);
            float num28 = ((value.M21 * num19) + (value.M22 * num20)) + (value.M23 * num21);
            float num29 = value.M24;
            float num30 = ((value.M31 * num13) + (value.M32 * num14)) + (value.M33 * num15);
            float num31 = ((value.M31 * num16) + (value.M32 * num17)) + (value.M33 * num18);
            float num32 = ((value.M31 * num19) + (value.M32 * num20)) + (value.M33 * num21);
            float num33 = value.M34;
            float num34 = ((value.M41 * num13) + (value.M42 * num14)) + (value.M43 * num15);
            float num35 = ((value.M41 * num16) + (value.M42 * num17)) + (value.M43 * num18);
            float num36 = ((value.M41 * num19) + (value.M42 * num20)) + (value.M43 * num21);
            float num37 = value.M44;
            result.M11 = num22;
            result.M12 = num23;
            result.M13 = num24;
            result.M14 = num25;
            result.M21 = num26;
            result.M22 = num27;
            result.M23 = num28;
            result.M24 = num29;
            result.M31 = num30;
            result.M32 = num31;
            result.M33 = num32;
            result.M34 = num33;
            result.M41 = num34;
            result.M42 = num35;
            result.M43 = num36;
            result.M44 = num37;
        }

        public static Matrix Transpose(Matrix matrix)
        {
            Matrix matrix2;
            matrix2.M11 = matrix.M11;
            matrix2.M12 = matrix.M21;
            matrix2.M13 = matrix.M31;
            matrix2.M14 = matrix.M41;
            matrix2.M21 = matrix.M12;
            matrix2.M22 = matrix.M22;
            matrix2.M23 = matrix.M32;
            matrix2.M24 = matrix.M42;
            matrix2.M31 = matrix.M13;
            matrix2.M32 = matrix.M23;
            matrix2.M33 = matrix.M33;
            matrix2.M34 = matrix.M43;
            matrix2.M41 = matrix.M14;
            matrix2.M42 = matrix.M24;
            matrix2.M43 = matrix.M34;
            matrix2.M44 = matrix.M44;
            return matrix2;
        }

        public static void Transpose(ref Matrix matrix, out Matrix result)
        {
            float num = matrix.M11;
            float num2 = matrix.M12;
            float num3 = matrix.M13;
            float num4 = matrix.M14;
            float num5 = matrix.M21;
            float num6 = matrix.M22;
            float num7 = matrix.M23;
            float num8 = matrix.M24;
            float num9 = matrix.M31;
            float num10 = matrix.M32;
            float num11 = matrix.M33;
            float num12 = matrix.M34;
            float num13 = matrix.M41;
            float num14 = matrix.M42;
            float num15 = matrix.M43;
            float num16 = matrix.M44;
            result.M11 = num;
            result.M12 = num5;
            result.M13 = num9;
            result.M14 = num13;
            result.M21 = num2;
            result.M22 = num6;
            result.M23 = num10;
            result.M24 = num14;
            result.M31 = num3;
            result.M32 = num7;
            result.M33 = num11;
            result.M34 = num15;
            result.M41 = num4;
            result.M42 = num8;
            result.M43 = num12;
            result.M44 = num16;
        }

        public void TransposeRotationInPlace()
        {
            float num = this.M12;
            this.M12 = this.M21;
            this.M21 = num;
            num = this.M13;
            this.M13 = this.M31;
            this.M31 = num;
            num = this.M23;
            this.M23 = this.M32;
            this.M32 = num;
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

        public Vector3 Translation
        {
            get
            {
                Vector3 vector;
                vector.X = this.M41;
                vector.Y = this.M42;
                vector.Z = this.M43;
                return vector;
            }
            set
            {
                this.M41 = value.X;
                this.M42 = value.Y;
                this.M43 = value.Z;
            }
        }

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
        private struct F16
        {
            [FixedBuffer(typeof(float), 0x10)]
            public <data>e__FixedBuffer1 data;
            [StructLayout(LayoutKind.Sequential, Size=0x40), CompilerGenerated, UnsafeValueType]
            public struct <data>e__FixedBuffer1
            {
                public float FixedElementField;
            }
        }
    }
}

