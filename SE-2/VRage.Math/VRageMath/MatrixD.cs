namespace VRageMath
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using Unsharper;

    [Serializable, StructLayout(LayoutKind.Explicit)]
    public struct MatrixD : IEquatable<MatrixD>
    {
        public static MatrixD Identity;
        [FieldOffset(0)]
        public double M11;
        [FieldOffset(8)]
        public double M12;
        [FieldOffset(0x10)]
        public double M13;
        [FieldOffset(0x18)]
        public double M14;
        [FieldOffset(0x20)]
        public double M21;
        [FieldOffset(40)]
        public double M22;
        [FieldOffset(0x30)]
        public double M23;
        [FieldOffset(0x38)]
        public double M24;
        [FieldOffset(0x40)]
        public double M31;
        [FieldOffset(0x48)]
        public double M32;
        [FieldOffset(80)]
        public double M33;
        [FieldOffset(0x58)]
        public double M34;
        [FieldOffset(0x60)]
        public double M41;
        [FieldOffset(0x68)]
        public double M42;
        [FieldOffset(0x70)]
        public double M43;
        [FieldOffset(120)]
        public double M44;
        public static MatrixD Zero;

        static MatrixD()
        {
            Identity = new MatrixD(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
            Zero = new MatrixD(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
        }

        public MatrixD(Matrix m)
        {
            this.M11 = m.M11;
            this.M12 = m.M12;
            this.M13 = m.M13;
            this.M14 = m.M14;
            this.M21 = m.M21;
            this.M22 = m.M22;
            this.M23 = m.M23;
            this.M24 = m.M24;
            this.M31 = m.M31;
            this.M32 = m.M32;
            this.M33 = m.M33;
            this.M34 = m.M34;
            this.M41 = m.M41;
            this.M42 = m.M42;
            this.M43 = m.M43;
            this.M44 = m.M44;
        }

        public MatrixD(double m11, double m12, double m13, double m21, double m22, double m23, double m31, double m32, double m33)
        {
            this.M11 = m11;
            this.M12 = m12;
            this.M13 = m13;
            this.M14 = 0.0;
            this.M21 = m21;
            this.M22 = m22;
            this.M23 = m23;
            this.M24 = 0.0;
            this.M31 = m31;
            this.M32 = m32;
            this.M33 = m33;
            this.M34 = 0.0;
            this.M41 = 0.0;
            this.M42 = 0.0;
            this.M43 = 0.0;
            this.M44 = 1.0;
        }

        public MatrixD(double m11, double m12, double m13, double m14, double m21, double m22, double m23, double m24, double m31, double m32, double m33, double m34, double m41, double m42, double m43, double m44)
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

        public static MatrixD Add(MatrixD matrix1, MatrixD matrix2)
        {
            MatrixD xd;
            xd.M11 = matrix1.M11 + matrix2.M11;
            xd.M12 = matrix1.M12 + matrix2.M12;
            xd.M13 = matrix1.M13 + matrix2.M13;
            xd.M14 = matrix1.M14 + matrix2.M14;
            xd.M21 = matrix1.M21 + matrix2.M21;
            xd.M22 = matrix1.M22 + matrix2.M22;
            xd.M23 = matrix1.M23 + matrix2.M23;
            xd.M24 = matrix1.M24 + matrix2.M24;
            xd.M31 = matrix1.M31 + matrix2.M31;
            xd.M32 = matrix1.M32 + matrix2.M32;
            xd.M33 = matrix1.M33 + matrix2.M33;
            xd.M34 = matrix1.M34 + matrix2.M34;
            xd.M41 = matrix1.M41 + matrix2.M41;
            xd.M42 = matrix1.M42 + matrix2.M42;
            xd.M43 = matrix1.M43 + matrix2.M43;
            xd.M44 = matrix1.M44 + matrix2.M44;
            return xd;
        }

        public static void Add(ref MatrixD matrix1, ref MatrixD matrix2, out MatrixD result)
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

        public static MatrixD AlignRotationToAxes(ref MatrixD toAlign, ref MatrixD axisDefinitionMatrix)
        {
            MatrixD identity = Identity;
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;
            double num = toAlign.Right.Dot(axisDefinitionMatrix.Right);
            double num2 = toAlign.Right.Dot(axisDefinitionMatrix.Up);
            double num3 = toAlign.Right.Dot(axisDefinitionMatrix.Backward);
            if (Math.Abs(num) > Math.Abs(num2))
            {
                if (Math.Abs(num) > Math.Abs(num3))
                {
                    identity.Right = (num > 0.0) ? axisDefinitionMatrix.Right : axisDefinitionMatrix.Left;
                    flag = true;
                }
                else
                {
                    identity.Right = (num3 > 0.0) ? axisDefinitionMatrix.Backward : axisDefinitionMatrix.Forward;
                    flag3 = true;
                }
            }
            else if (Math.Abs(num2) > Math.Abs(num3))
            {
                identity.Right = (num2 > 0.0) ? axisDefinitionMatrix.Up : axisDefinitionMatrix.Down;
                flag2 = true;
            }
            else
            {
                identity.Right = (num3 > 0.0) ? axisDefinitionMatrix.Backward : axisDefinitionMatrix.Forward;
                flag3 = true;
            }
            num = toAlign.Up.Dot(axisDefinitionMatrix.Right);
            num2 = toAlign.Up.Dot(axisDefinitionMatrix.Up);
            num3 = toAlign.Up.Dot(axisDefinitionMatrix.Backward);
            if (flag2 || ((Math.Abs(num) > Math.Abs(num2)) && !flag))
            {
                if ((Math.Abs(num) > Math.Abs(num3)) || flag3)
                {
                    identity.Up = (num > 0.0) ? axisDefinitionMatrix.Right : axisDefinitionMatrix.Left;
                    flag = true;
                }
                else
                {
                    identity.Up = (num3 > 0.0) ? axisDefinitionMatrix.Backward : axisDefinitionMatrix.Forward;
                    flag3 = true;
                }
            }
            else if ((Math.Abs(num2) > Math.Abs(num3)) || flag3)
            {
                identity.Up = (num2 > 0.0) ? axisDefinitionMatrix.Up : axisDefinitionMatrix.Down;
                flag2 = true;
            }
            else
            {
                identity.Up = (num3 > 0.0) ? axisDefinitionMatrix.Backward : axisDefinitionMatrix.Forward;
                flag3 = true;
            }
            if (!flag)
            {
                num = toAlign.Backward.Dot(axisDefinitionMatrix.Right);
                identity.Backward = (num > 0.0) ? axisDefinitionMatrix.Right : axisDefinitionMatrix.Left;
                return identity;
            }
            if (!flag2)
            {
                num2 = toAlign.Backward.Dot(axisDefinitionMatrix.Up);
                identity.Backward = (num2 > 0.0) ? axisDefinitionMatrix.Up : axisDefinitionMatrix.Down;
                return identity;
            }
            num3 = toAlign.Backward.Dot(axisDefinitionMatrix.Backward);
            identity.Backward = (num3 > 0.0) ? axisDefinitionMatrix.Backward : axisDefinitionMatrix.Forward;
            return identity;
        }

        [Conditional("DEBUG")]
        public void AssertIsValid()
        {
        }

        public static MatrixD CreateBillboard(Vector3D objectPosition, Vector3D cameraPosition, Vector3D cameraUpVector, Vector3D? cameraForwardVector)
        {
            Vector3D vectord;
            Vector3D vectord2;
            Vector3D vectord3;
            MatrixD xd;
            vectord.X = objectPosition.X - cameraPosition.X;
            vectord.Y = objectPosition.Y - cameraPosition.Y;
            vectord.Z = objectPosition.Z - cameraPosition.Z;
            double d = vectord.LengthSquared();
            if (d < 9.99999974737875E-05)
            {
                vectord = cameraForwardVector.HasValue ? -cameraForwardVector.Value : Vector3D.Forward;
            }
            else
            {
                Vector3D.Multiply(ref vectord, (double) (1.0 / Math.Sqrt(d)), out vectord);
            }
            Vector3D.Cross(ref cameraUpVector, ref vectord, out vectord2);
            vectord2.Normalize();
            Vector3D.Cross(ref vectord, ref vectord2, out vectord3);
            xd.M11 = vectord2.X;
            xd.M12 = vectord2.Y;
            xd.M13 = vectord2.Z;
            xd.M14 = 0.0;
            xd.M21 = vectord3.X;
            xd.M22 = vectord3.Y;
            xd.M23 = vectord3.Z;
            xd.M24 = 0.0;
            xd.M31 = vectord.X;
            xd.M32 = vectord.Y;
            xd.M33 = vectord.Z;
            xd.M34 = 0.0;
            xd.M41 = objectPosition.X;
            xd.M42 = objectPosition.Y;
            xd.M43 = objectPosition.Z;
            xd.M44 = 1.0;
            return xd;
        }

        public static void CreateBillboard(ref Vector3D objectPosition, ref Vector3D cameraPosition, ref Vector3D cameraUpVector, Vector3D? cameraForwardVector, out MatrixD result)
        {
            Vector3D vectord;
            Vector3D vectord2;
            Vector3D vectord3;
            vectord.X = objectPosition.X - cameraPosition.X;
            vectord.Y = objectPosition.Y - cameraPosition.Y;
            vectord.Z = objectPosition.Z - cameraPosition.Z;
            double d = vectord.LengthSquared();
            if (d < 9.99999974737875E-05)
            {
                vectord = cameraForwardVector.HasValue ? -cameraForwardVector.Value : Vector3D.Forward;
            }
            else
            {
                Vector3D.Multiply(ref vectord, (double) (1.0 / Math.Sqrt(d)), out vectord);
            }
            Vector3D.Cross(ref cameraUpVector, ref vectord, out vectord2);
            vectord2.Normalize();
            Vector3D.Cross(ref vectord, ref vectord2, out vectord3);
            result.M11 = vectord2.X;
            result.M12 = vectord2.Y;
            result.M13 = vectord2.Z;
            result.M14 = 0.0;
            result.M21 = vectord3.X;
            result.M22 = vectord3.Y;
            result.M23 = vectord3.Z;
            result.M24 = 0.0;
            result.M31 = vectord.X;
            result.M32 = vectord.Y;
            result.M33 = vectord.Z;
            result.M34 = 0.0;
            result.M41 = objectPosition.X;
            result.M42 = objectPosition.Y;
            result.M43 = objectPosition.Z;
            result.M44 = 1.0;
        }

        public static MatrixD CreateConstrainedBillboard(Vector3D objectPosition, Vector3D cameraPosition, Vector3D rotateAxis, Vector3D? cameraForwardVector, Vector3D? objectForwardVector)
        {
            Vector3D vectord;
            double num2;
            Vector3D vectord3;
            Vector3D vectord4;
            MatrixD xd;
            vectord.X = objectPosition.X - cameraPosition.X;
            vectord.Y = objectPosition.Y - cameraPosition.Y;
            vectord.Z = objectPosition.Z - cameraPosition.Z;
            double d = vectord.LengthSquared();
            if (d < 9.99999974737875E-05)
            {
                vectord = cameraForwardVector.HasValue ? -cameraForwardVector.Value : Vector3D.Forward;
            }
            else
            {
                Vector3D.Multiply(ref vectord, (double) (1.0 / Math.Sqrt(d)), out vectord);
            }
            Vector3D vectord2 = rotateAxis;
            Vector3D.Dot(ref rotateAxis, ref vectord, out num2);
            if (Math.Abs(num2) > 0.998254656791687)
            {
                if (objectForwardVector.HasValue)
                {
                    vectord3 = objectForwardVector.Value;
                    Vector3D.Dot(ref rotateAxis, ref vectord3, out num2);
                    if (Math.Abs(num2) > 0.998254656791687)
                    {
                        vectord3 = (Math.Abs((double) (((rotateAxis.X * Vector3D.Forward.X) + (rotateAxis.Y * Vector3D.Forward.Y)) + (rotateAxis.Z * Vector3D.Forward.Z))) > 0.998254656791687) ? Vector3D.Right : Vector3D.Forward;
                    }
                }
                else
                {
                    vectord3 = (Math.Abs((double) (((rotateAxis.X * Vector3D.Forward.X) + (rotateAxis.Y * Vector3D.Forward.Y)) + (rotateAxis.Z * Vector3D.Forward.Z))) > 0.998254656791687) ? Vector3D.Right : Vector3D.Forward;
                }
                Vector3D.Cross(ref rotateAxis, ref vectord3, out vectord4);
                vectord4.Normalize();
                Vector3D.Cross(ref vectord4, ref rotateAxis, out vectord3);
                vectord3.Normalize();
            }
            else
            {
                Vector3D.Cross(ref rotateAxis, ref vectord, out vectord4);
                vectord4.Normalize();
                Vector3D.Cross(ref vectord4, ref vectord2, out vectord3);
                vectord3.Normalize();
            }
            xd.M11 = vectord4.X;
            xd.M12 = vectord4.Y;
            xd.M13 = vectord4.Z;
            xd.M14 = 0.0;
            xd.M21 = vectord2.X;
            xd.M22 = vectord2.Y;
            xd.M23 = vectord2.Z;
            xd.M24 = 0.0;
            xd.M31 = vectord3.X;
            xd.M32 = vectord3.Y;
            xd.M33 = vectord3.Z;
            xd.M34 = 0.0;
            xd.M41 = objectPosition.X;
            xd.M42 = objectPosition.Y;
            xd.M43 = objectPosition.Z;
            xd.M44 = 1.0;
            return xd;
        }

        public static void CreateConstrainedBillboard(ref Vector3D objectPosition, ref Vector3D cameraPosition, ref Vector3D rotateAxis, Vector3D? cameraForwardVector, Vector3D? objectForwardVector, out MatrixD result)
        {
            Vector3D vectord;
            double num2;
            Vector3D vectord3;
            Vector3D vectord4;
            vectord.X = objectPosition.X - cameraPosition.X;
            vectord.Y = objectPosition.Y - cameraPosition.Y;
            vectord.Z = objectPosition.Z - cameraPosition.Z;
            double d = vectord.LengthSquared();
            if (d < 9.99999974737875E-05)
            {
                vectord = cameraForwardVector.HasValue ? -cameraForwardVector.Value : Vector3D.Forward;
            }
            else
            {
                Vector3D.Multiply(ref vectord, (double) (1.0 / Math.Sqrt(d)), out vectord);
            }
            Vector3D vectord2 = rotateAxis;
            Vector3D.Dot(ref rotateAxis, ref vectord, out num2);
            if (Math.Abs(num2) > 0.998254656791687)
            {
                if (objectForwardVector.HasValue)
                {
                    vectord3 = objectForwardVector.Value;
                    Vector3D.Dot(ref rotateAxis, ref vectord3, out num2);
                    if (Math.Abs(num2) > 0.998254656791687)
                    {
                        vectord3 = (Math.Abs((double) (((rotateAxis.X * Vector3D.Forward.X) + (rotateAxis.Y * Vector3D.Forward.Y)) + (rotateAxis.Z * Vector3D.Forward.Z))) > 0.998254656791687) ? Vector3D.Right : Vector3D.Forward;
                    }
                }
                else
                {
                    vectord3 = (Math.Abs((double) (((rotateAxis.X * Vector3D.Forward.X) + (rotateAxis.Y * Vector3D.Forward.Y)) + (rotateAxis.Z * Vector3D.Forward.Z))) > 0.998254656791687) ? Vector3D.Right : Vector3D.Forward;
                }
                Vector3D.Cross(ref rotateAxis, ref vectord3, out vectord4);
                vectord4.Normalize();
                Vector3D.Cross(ref vectord4, ref rotateAxis, out vectord3);
                vectord3.Normalize();
            }
            else
            {
                Vector3D.Cross(ref rotateAxis, ref vectord, out vectord4);
                vectord4.Normalize();
                Vector3D.Cross(ref vectord4, ref vectord2, out vectord3);
                vectord3.Normalize();
            }
            result.M11 = vectord4.X;
            result.M12 = vectord4.Y;
            result.M13 = vectord4.Z;
            result.M14 = 0.0;
            result.M21 = vectord2.X;
            result.M22 = vectord2.Y;
            result.M23 = vectord2.Z;
            result.M24 = 0.0;
            result.M31 = vectord3.X;
            result.M32 = vectord3.Y;
            result.M33 = vectord3.Z;
            result.M34 = 0.0;
            result.M41 = objectPosition.X;
            result.M42 = objectPosition.Y;
            result.M43 = objectPosition.Z;
            result.M44 = 1.0;
        }

        public static MatrixD CreateFromAxisAngle(Vector3D axis, double angle)
        {
            MatrixD xd;
            double x = axis.X;
            double y = axis.Y;
            double z = axis.Z;
            double num4 = Math.Sin(angle);
            double num5 = Math.Cos(angle);
            double num6 = x * x;
            double num7 = y * y;
            double num8 = z * z;
            double num9 = x * y;
            double num10 = x * z;
            double num11 = y * z;
            xd.M11 = num6 + (num5 * (1.0 - num6));
            xd.M12 = (num9 - (num5 * num9)) + (num4 * z);
            xd.M13 = (num10 - (num5 * num10)) - (num4 * y);
            xd.M14 = 0.0;
            xd.M21 = (num9 - (num5 * num9)) - (num4 * z);
            xd.M22 = num7 + (num5 * (1.0 - num7));
            xd.M23 = (num11 - (num5 * num11)) + (num4 * x);
            xd.M24 = 0.0;
            xd.M31 = (num10 - (num5 * num10)) + (num4 * y);
            xd.M32 = (num11 - (num5 * num11)) - (num4 * x);
            xd.M33 = num8 + (num5 * (1.0 - num8));
            xd.M34 = 0.0;
            xd.M41 = 0.0;
            xd.M42 = 0.0;
            xd.M43 = 0.0;
            xd.M44 = 1.0;
            return xd;
        }

        public static void CreateFromAxisAngle(ref Vector3D axis, double angle, out MatrixD result)
        {
            double x = axis.X;
            double y = axis.Y;
            double z = axis.Z;
            double num4 = Math.Sin(angle);
            double num5 = Math.Cos(angle);
            double num6 = x * x;
            double num7 = y * y;
            double num8 = z * z;
            double num9 = x * y;
            double num10 = x * z;
            double num11 = y * z;
            result.M11 = num6 + (num5 * (1.0 - num6));
            result.M12 = (num9 - (num5 * num9)) + (num4 * z);
            result.M13 = (num10 - (num5 * num10)) - (num4 * y);
            result.M14 = 0.0;
            result.M21 = (num9 - (num5 * num9)) - (num4 * z);
            result.M22 = num7 + (num5 * (1.0 - num7));
            result.M23 = (num11 - (num5 * num11)) + (num4 * x);
            result.M24 = 0.0;
            result.M31 = (num10 - (num5 * num10)) + (num4 * y);
            result.M32 = (num11 - (num5 * num11)) - (num4 * x);
            result.M33 = num8 + (num5 * (1.0 - num8));
            result.M34 = 0.0;
            result.M41 = 0.0;
            result.M42 = 0.0;
            result.M43 = 0.0;
            result.M44 = 1.0;
        }

        public static MatrixD CreateFromDir(Vector3D dir)
        {
            Vector3D vectord2;
            Vector3D vectord = new Vector3D(0.0, 0.0, 1.0);
            double z = dir.Z;
            if ((z > -0.99999) && (z < 0.99999))
            {
                vectord -= (Vector3D) (dir * z);
                vectord = Vector3D.Normalize(vectord);
                vectord2 = Vector3D.Cross(dir, vectord);
            }
            else
            {
                vectord = new Vector3D(dir.Z, 0.0, -dir.X);
                vectord2 = new Vector3D(0.0, 1.0, 0.0);
            }
            MatrixD identity = Identity;
            identity.Right = vectord;
            identity.Up = vectord2;
            identity.Forward = dir;
            return identity;
        }

        public static MatrixD CreateFromDir(Vector3D dir, Vector3D suggestedUp)
        {
            Vector3D up = Vector3D.Cross(Vector3D.Cross(dir, suggestedUp), dir);
            return CreateWorld(Vector3D.Zero, dir, up);
        }

        public static MatrixD CreateFromQuaternion(Quaternion quaternion)
        {
            MatrixD xd;
            double num = quaternion.X * quaternion.X;
            double num2 = quaternion.Y * quaternion.Y;
            double num3 = quaternion.Z * quaternion.Z;
            double num4 = quaternion.X * quaternion.Y;
            double num5 = quaternion.Z * quaternion.W;
            double num6 = quaternion.Z * quaternion.X;
            double num7 = quaternion.Y * quaternion.W;
            double num8 = quaternion.Y * quaternion.Z;
            double num9 = quaternion.X * quaternion.W;
            xd.M11 = 1.0 - (2.0 * (num2 + num3));
            xd.M12 = 2.0 * (num4 + num5);
            xd.M13 = 2.0 * (num6 - num7);
            xd.M14 = 0.0;
            xd.M21 = 2.0 * (num4 - num5);
            xd.M22 = 1.0 - (2.0 * (num3 + num));
            xd.M23 = 2.0 * (num8 + num9);
            xd.M24 = 0.0;
            xd.M31 = 2.0 * (num6 + num7);
            xd.M32 = 2.0 * (num8 - num9);
            xd.M33 = 1.0 - (2.0 * (num2 + num));
            xd.M34 = 0.0;
            xd.M41 = 0.0;
            xd.M42 = 0.0;
            xd.M43 = 0.0;
            xd.M44 = 1.0;
            return xd;
        }

        public static MatrixD CreateFromQuaternion(QuaternionD quaternion)
        {
            MatrixD xd;
            double num = quaternion.X * quaternion.X;
            double num2 = quaternion.Y * quaternion.Y;
            double num3 = quaternion.Z * quaternion.Z;
            double num4 = quaternion.X * quaternion.Y;
            double num5 = quaternion.Z * quaternion.W;
            double num6 = quaternion.Z * quaternion.X;
            double num7 = quaternion.Y * quaternion.W;
            double num8 = quaternion.Y * quaternion.Z;
            double num9 = quaternion.X * quaternion.W;
            xd.M11 = 1.0 - (2.0 * (num2 + num3));
            xd.M12 = 2.0 * (num4 + num5);
            xd.M13 = 2.0 * (num6 - num7);
            xd.M14 = 0.0;
            xd.M21 = 2.0 * (num4 - num5);
            xd.M22 = 1.0 - (2.0 * (num3 + num));
            xd.M23 = 2.0 * (num8 + num9);
            xd.M24 = 0.0;
            xd.M31 = 2.0 * (num6 + num7);
            xd.M32 = 2.0 * (num8 - num9);
            xd.M33 = 1.0 - (2.0 * (num2 + num));
            xd.M34 = 0.0;
            xd.M41 = 0.0;
            xd.M42 = 0.0;
            xd.M43 = 0.0;
            xd.M44 = 1.0;
            return xd;
        }

        public static void CreateFromQuaternion(ref Quaternion quaternion, out MatrixD result)
        {
            double num = quaternion.X * quaternion.X;
            double num2 = quaternion.Y * quaternion.Y;
            double num3 = quaternion.Z * quaternion.Z;
            double num4 = quaternion.X * quaternion.Y;
            double num5 = quaternion.Z * quaternion.W;
            double num6 = quaternion.Z * quaternion.X;
            double num7 = quaternion.Y * quaternion.W;
            double num8 = quaternion.Y * quaternion.Z;
            double num9 = quaternion.X * quaternion.W;
            result.M11 = 1.0 - (2.0 * (num2 + num3));
            result.M12 = 2.0 * (num4 + num5);
            result.M13 = 2.0 * (num6 - num7);
            result.M14 = 0.0;
            result.M21 = 2.0 * (num4 - num5);
            result.M22 = 1.0 - (2.0 * (num3 + num));
            result.M23 = 2.0 * (num8 + num9);
            result.M24 = 0.0;
            result.M31 = 2.0 * (num6 + num7);
            result.M32 = 2.0 * (num8 - num9);
            result.M33 = 1.0 - (2.0 * (num2 + num));
            result.M34 = 0.0;
            result.M41 = 0.0;
            result.M42 = 0.0;
            result.M43 = 0.0;
            result.M44 = 1.0;
        }

        public static MatrixD CreateFromTransformScale(Quaternion orientation, Vector3D position, Vector3D scale)
        {
            MatrixD matrix = CreateFromQuaternion(orientation);
            matrix.Translation = position;
            Rescale(ref matrix, ref scale);
            return matrix;
        }

        public static MatrixD CreateFromYawPitchRoll(double yaw, double pitch, double roll)
        {
            Quaternion quaternion;
            MatrixD xd;
            Quaternion.CreateFromYawPitchRoll((float) yaw, (float) pitch, (float) roll, out quaternion);
            CreateFromQuaternion(ref quaternion, out xd);
            return xd;
        }

        public static void CreateFromYawPitchRoll(double yaw, double pitch, double roll, out MatrixD result)
        {
            Quaternion quaternion;
            Quaternion.CreateFromYawPitchRoll((float) yaw, (float) pitch, (float) roll, out quaternion);
            CreateFromQuaternion(ref quaternion, out result);
        }

        public static MatrixD CreateLookAt(Vector3D cameraPosition, Vector3D cameraTarget, Vector3 cameraUpVector) => 
            CreateLookAt(cameraPosition, cameraTarget, (Vector3D) cameraUpVector);

        public static MatrixD CreateLookAt(Vector3D cameraPosition, Vector3D cameraTarget, Vector3D cameraUpVector)
        {
            MatrixD xd;
            Vector3D vectord = Vector3D.Normalize(cameraPosition - cameraTarget);
            Vector3D vectord2 = Vector3D.Normalize(Vector3D.Cross(cameraUpVector, vectord));
            Vector3D vectord3 = Vector3D.Cross(vectord, vectord2);
            xd.M11 = vectord2.X;
            xd.M12 = vectord3.X;
            xd.M13 = vectord.X;
            xd.M14 = 0.0;
            xd.M21 = vectord2.Y;
            xd.M22 = vectord3.Y;
            xd.M23 = vectord.Y;
            xd.M24 = 0.0;
            xd.M31 = vectord2.Z;
            xd.M32 = vectord3.Z;
            xd.M33 = vectord.Z;
            xd.M34 = 0.0;
            xd.M41 = -Vector3D.Dot(vectord2, cameraPosition);
            xd.M42 = -Vector3D.Dot(vectord3, cameraPosition);
            xd.M43 = -Vector3D.Dot(vectord, cameraPosition);
            xd.M44 = 1.0;
            return xd;
        }

        public static void CreateLookAt(ref Vector3D cameraPosition, ref Vector3D cameraTarget, ref Vector3D cameraUpVector, out MatrixD result)
        {
            Vector3D vectord = Vector3D.Normalize(cameraPosition - cameraTarget);
            Vector3D vectord2 = Vector3D.Normalize(Vector3D.Cross(cameraUpVector, vectord));
            Vector3D vectord3 = Vector3D.Cross(vectord, vectord2);
            result.M11 = vectord2.X;
            result.M12 = vectord3.X;
            result.M13 = vectord.X;
            result.M14 = 0.0;
            result.M21 = vectord2.Y;
            result.M22 = vectord3.Y;
            result.M23 = vectord.Y;
            result.M24 = 0.0;
            result.M31 = vectord2.Z;
            result.M32 = vectord3.Z;
            result.M33 = vectord.Z;
            result.M34 = 0.0;
            result.M41 = -Vector3D.Dot(vectord2, cameraPosition);
            result.M42 = -Vector3D.Dot(vectord3, cameraPosition);
            result.M43 = -Vector3D.Dot(vectord, cameraPosition);
            result.M44 = 1.0;
        }

        public static Matrix CreateLookAtInverse(Vector3D cameraPosition, Vector3D cameraTarget, Vector3D cameraUpVector)
        {
            MatrixD xd;
            Vector3D vectord = Vector3D.Normalize(cameraPosition - cameraTarget);
            Vector3D vectord2 = Vector3D.Normalize(Vector3D.Cross(cameraUpVector, vectord));
            Vector3D vectord3 = Vector3D.Cross(vectord, vectord2);
            xd.M11 = vectord2.X;
            xd.M12 = vectord2.Y;
            xd.M13 = vectord2.Z;
            xd.M14 = 0.0;
            xd.M21 = vectord3.X;
            xd.M22 = vectord3.Y;
            xd.M23 = vectord3.Z;
            xd.M24 = 0.0;
            xd.M31 = vectord.X;
            xd.M32 = vectord.Y;
            xd.M33 = vectord.Z;
            xd.M34 = 0.0;
            xd.M41 = cameraPosition.X;
            xd.M42 = cameraPosition.Y;
            xd.M43 = cameraPosition.Z;
            xd.M44 = 1.0;
            return (Matrix) xd;
        }

        public static MatrixD CreateOrthographic(double width, double height, double zNearPlane, double zFarPlane)
        {
            MatrixD xd;
            xd.M11 = 2.0 / width;
            xd.M12 = xd.M13 = xd.M14 = 0.0;
            xd.M22 = 2.0 / height;
            xd.M21 = xd.M23 = xd.M24 = 0.0;
            xd.M33 = 1.0 / (zNearPlane - zFarPlane);
            xd.M31 = xd.M32 = xd.M34 = 0.0;
            xd.M41 = xd.M42 = 0.0;
            xd.M43 = zNearPlane / (zNearPlane - zFarPlane);
            xd.M44 = 1.0;
            return xd;
        }

        public static void CreateOrthographic(double width, double height, double zNearPlane, double zFarPlane, out MatrixD result)
        {
            result.M11 = 2.0 / width;
            result.M12 = result.M13 = result.M14 = 0.0;
            result.M22 = 2.0 / height;
            result.M21 = result.M23 = result.M24 = 0.0;
            result.M33 = 1.0 / (zNearPlane - zFarPlane);
            result.M31 = result.M32 = result.M34 = 0.0;
            result.M41 = result.M42 = 0.0;
            result.M43 = zNearPlane / (zNearPlane - zFarPlane);
            result.M44 = 1.0;
        }

        public static MatrixD CreateOrthographicOffCenter(double left, double right, double bottom, double top, double zNearPlane, double zFarPlane)
        {
            MatrixD xd;
            xd.M11 = 2.0 / (right - left);
            xd.M12 = xd.M13 = xd.M14 = 0.0;
            xd.M22 = 2.0 / (top - bottom);
            xd.M21 = xd.M23 = xd.M24 = 0.0;
            xd.M33 = 1.0 / (zNearPlane - zFarPlane);
            xd.M31 = xd.M32 = xd.M34 = 0.0;
            xd.M41 = (left + right) / (left - right);
            xd.M42 = (top + bottom) / (bottom - top);
            xd.M43 = zNearPlane / (zNearPlane - zFarPlane);
            xd.M44 = 1.0;
            return xd;
        }

        public static void CreateOrthographicOffCenter(double left, double right, double bottom, double top, double zNearPlane, double zFarPlane, out MatrixD result)
        {
            result.M11 = 2.0 / (right - left);
            result.M12 = result.M13 = result.M14 = 0.0;
            result.M22 = 2.0 / (top - bottom);
            result.M21 = result.M23 = result.M24 = 0.0;
            result.M33 = 1.0 / (zNearPlane - zFarPlane);
            result.M31 = result.M32 = result.M34 = 0.0;
            result.M41 = (left + right) / (left - right);
            result.M42 = (top + bottom) / (bottom - top);
            result.M43 = zNearPlane / (zNearPlane - zFarPlane);
            result.M44 = 1.0;
        }

        public static MatrixD CreatePerspective(double width, double height, double nearPlaneDistance, double farPlaneDistance)
        {
            MatrixD xd;
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
            xd.M11 = (2.0 * nearPlaneDistance) / width;
            xd.M12 = xd.M13 = xd.M14 = 0.0;
            xd.M22 = (2.0 * nearPlaneDistance) / height;
            xd.M21 = xd.M23 = xd.M24 = 0.0;
            xd.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            xd.M31 = xd.M32 = 0.0;
            xd.M34 = -1.0;
            xd.M41 = xd.M42 = xd.M44 = 0.0;
            xd.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
            return xd;
        }

        public static void CreatePerspective(double width, double height, double nearPlaneDistance, double farPlaneDistance, out MatrixD result)
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
            result.M11 = (2.0 * nearPlaneDistance) / width;
            result.M12 = result.M13 = result.M14 = 0.0;
            result.M22 = (2.0 * nearPlaneDistance) / height;
            result.M21 = result.M23 = result.M24 = 0.0;
            result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            result.M31 = result.M32 = 0.0;
            result.M34 = -1.0;
            result.M41 = result.M42 = result.M44 = 0.0;
            result.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
        }

        public static MatrixD CreatePerspectiveFieldOfView(double fieldOfView, double aspectRatio, double nearPlaneDistance, double farPlaneDistance)
        {
            MatrixD xd;
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
            double num = 1.0 / Math.Tan(fieldOfView * 0.5);
            double num2 = num / aspectRatio;
            xd.M11 = num2;
            xd.M12 = xd.M13 = xd.M14 = 0.0;
            xd.M22 = num;
            xd.M21 = xd.M23 = xd.M24 = 0.0;
            xd.M31 = xd.M32 = 0.0;
            xd.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            xd.M34 = -1.0;
            xd.M41 = xd.M42 = xd.M44 = 0.0;
            xd.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
            return xd;
        }

        public static void CreatePerspectiveFieldOfView(double fieldOfView, double aspectRatio, double nearPlaneDistance, double farPlaneDistance, out MatrixD result)
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
            double num = 1.0 / Math.Tan(fieldOfView * 0.5);
            double num2 = num / aspectRatio;
            result.M11 = num2;
            result.M12 = result.M13 = result.M14 = 0.0;
            result.M22 = num;
            result.M21 = result.M23 = result.M24 = 0.0;
            result.M31 = result.M32 = 0.0;
            result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            result.M34 = -1.0;
            result.M41 = result.M42 = result.M44 = 0.0;
            result.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
        }

        public static MatrixD CreatePerspectiveOffCenter(double left, double right, double bottom, double top, double nearPlaneDistance, double farPlaneDistance)
        {
            MatrixD xd;
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
            xd.M11 = (2.0 * nearPlaneDistance) / (right - left);
            xd.M12 = xd.M13 = xd.M14 = 0.0;
            xd.M22 = (2.0 * nearPlaneDistance) / (top - bottom);
            xd.M21 = xd.M23 = xd.M24 = 0.0;
            xd.M31 = (left + right) / (right - left);
            xd.M32 = (top + bottom) / (top - bottom);
            xd.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            xd.M34 = -1.0;
            xd.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
            xd.M41 = xd.M42 = xd.M44 = 0.0;
            return xd;
        }

        public static void CreatePerspectiveOffCenter(double left, double right, double bottom, double top, double nearPlaneDistance, double farPlaneDistance, out MatrixD result)
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
            result.M11 = (2.0 * nearPlaneDistance) / (right - left);
            result.M12 = result.M13 = result.M14 = 0.0;
            result.M22 = (2.0 * nearPlaneDistance) / (top - bottom);
            result.M21 = result.M23 = result.M24 = 0.0;
            result.M31 = (left + right) / (right - left);
            result.M32 = (top + bottom) / (top - bottom);
            result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            result.M34 = -1.0;
            result.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
            result.M41 = result.M42 = result.M44 = 0.0;
        }

        public static MatrixD CreateReflection(Plane value)
        {
            MatrixD xd;
            value.Normalize();
            double x = value.Normal.X;
            double y = value.Normal.Y;
            double z = value.Normal.Z;
            double num4 = -2.0 * x;
            double num5 = -2.0 * y;
            double num6 = -2.0 * z;
            xd.M11 = (num4 * x) + 1.0;
            xd.M12 = num5 * x;
            xd.M13 = num6 * x;
            xd.M14 = 0.0;
            xd.M21 = num4 * y;
            xd.M22 = (num5 * y) + 1.0;
            xd.M23 = num6 * y;
            xd.M24 = 0.0;
            xd.M31 = num4 * z;
            xd.M32 = num5 * z;
            xd.M33 = (num6 * z) + 1.0;
            xd.M34 = 0.0;
            xd.M41 = num4 * value.D;
            xd.M42 = num5 * value.D;
            xd.M43 = num6 * value.D;
            xd.M44 = 1.0;
            return xd;
        }

        public static void CreateReflection(ref Plane value, out MatrixD result)
        {
            Plane plane;
            Plane.Normalize(ref value, out plane);
            value.Normalize();
            double x = plane.Normal.X;
            double y = plane.Normal.Y;
            double z = plane.Normal.Z;
            double num4 = -2.0 * x;
            double num5 = -2.0 * y;
            double num6 = -2.0 * z;
            result.M11 = (num4 * x) + 1.0;
            result.M12 = num5 * x;
            result.M13 = num6 * x;
            result.M14 = 0.0;
            result.M21 = num4 * y;
            result.M22 = (num5 * y) + 1.0;
            result.M23 = num6 * y;
            result.M24 = 0.0;
            result.M31 = num4 * z;
            result.M32 = num5 * z;
            result.M33 = (num6 * z) + 1.0;
            result.M34 = 0.0;
            result.M41 = num4 * plane.D;
            result.M42 = num5 * plane.D;
            result.M43 = num6 * plane.D;
            result.M44 = 1.0;
        }

        public static MatrixD CreateRotationX(double radians)
        {
            MatrixD xd;
            double num = Math.Cos(radians);
            double num2 = Math.Sin(radians);
            xd.M11 = 1.0;
            xd.M12 = 0.0;
            xd.M13 = 0.0;
            xd.M14 = 0.0;
            xd.M21 = 0.0;
            xd.M22 = num;
            xd.M23 = num2;
            xd.M24 = 0.0;
            xd.M31 = 0.0;
            xd.M32 = -num2;
            xd.M33 = num;
            xd.M34 = 0.0;
            xd.M41 = 0.0;
            xd.M42 = 0.0;
            xd.M43 = 0.0;
            xd.M44 = 1.0;
            return xd;
        }

        public static void CreateRotationX(double radians, out MatrixD result)
        {
            double num = Math.Cos(radians);
            double num2 = Math.Sin(radians);
            result.M11 = 1.0;
            result.M12 = 0.0;
            result.M13 = 0.0;
            result.M14 = 0.0;
            result.M21 = 0.0;
            result.M22 = num;
            result.M23 = num2;
            result.M24 = 0.0;
            result.M31 = 0.0;
            result.M32 = -num2;
            result.M33 = num;
            result.M34 = 0.0;
            result.M41 = 0.0;
            result.M42 = 0.0;
            result.M43 = 0.0;
            result.M44 = 1.0;
        }

        public static MatrixD CreateRotationY(double radians)
        {
            MatrixD xd;
            double num = Math.Cos(radians);
            double num2 = Math.Sin(radians);
            xd.M11 = num;
            xd.M12 = 0.0;
            xd.M13 = -num2;
            xd.M14 = 0.0;
            xd.M21 = 0.0;
            xd.M22 = 1.0;
            xd.M23 = 0.0;
            xd.M24 = 0.0;
            xd.M31 = num2;
            xd.M32 = 0.0;
            xd.M33 = num;
            xd.M34 = 0.0;
            xd.M41 = 0.0;
            xd.M42 = 0.0;
            xd.M43 = 0.0;
            xd.M44 = 1.0;
            return xd;
        }

        public static void CreateRotationY(double radians, out MatrixD result)
        {
            double num = Math.Cos(radians);
            double num2 = Math.Sin(radians);
            result.M11 = num;
            result.M12 = 0.0;
            result.M13 = -num2;
            result.M14 = 0.0;
            result.M21 = 0.0;
            result.M22 = 1.0;
            result.M23 = 0.0;
            result.M24 = 0.0;
            result.M31 = num2;
            result.M32 = 0.0;
            result.M33 = num;
            result.M34 = 0.0;
            result.M41 = 0.0;
            result.M42 = 0.0;
            result.M43 = 0.0;
            result.M44 = 1.0;
        }

        public static MatrixD CreateRotationZ(double radians)
        {
            MatrixD xd;
            double num = Math.Cos(radians);
            double num2 = Math.Sin(radians);
            xd.M11 = num;
            xd.M12 = num2;
            xd.M13 = 0.0;
            xd.M14 = 0.0;
            xd.M21 = -num2;
            xd.M22 = num;
            xd.M23 = 0.0;
            xd.M24 = 0.0;
            xd.M31 = 0.0;
            xd.M32 = 0.0;
            xd.M33 = 1.0;
            xd.M34 = 0.0;
            xd.M41 = 0.0;
            xd.M42 = 0.0;
            xd.M43 = 0.0;
            xd.M44 = 1.0;
            return xd;
        }

        public static void CreateRotationZ(double radians, out MatrixD result)
        {
            double num = Math.Cos(radians);
            double num2 = Math.Sin(radians);
            result.M11 = num;
            result.M12 = num2;
            result.M13 = 0.0;
            result.M14 = 0.0;
            result.M21 = -num2;
            result.M22 = num;
            result.M23 = 0.0;
            result.M24 = 0.0;
            result.M31 = 0.0;
            result.M32 = 0.0;
            result.M33 = 1.0;
            result.M34 = 0.0;
            result.M41 = 0.0;
            result.M42 = 0.0;
            result.M43 = 0.0;
            result.M44 = 1.0;
        }

        public static MatrixD CreateScale(double scale)
        {
            MatrixD xd;
            double num = scale;
            xd.M11 = num;
            xd.M12 = 0.0;
            xd.M13 = 0.0;
            xd.M14 = 0.0;
            xd.M21 = 0.0;
            xd.M22 = num;
            xd.M23 = 0.0;
            xd.M24 = 0.0;
            xd.M31 = 0.0;
            xd.M32 = 0.0;
            xd.M33 = num;
            xd.M34 = 0.0;
            xd.M41 = 0.0;
            xd.M42 = 0.0;
            xd.M43 = 0.0;
            xd.M44 = 1.0;
            return xd;
        }

        public static MatrixD CreateScale(Vector3D scales)
        {
            MatrixD xd;
            double x = scales.X;
            double y = scales.Y;
            double z = scales.Z;
            xd.M11 = x;
            xd.M12 = 0.0;
            xd.M13 = 0.0;
            xd.M14 = 0.0;
            xd.M21 = 0.0;
            xd.M22 = y;
            xd.M23 = 0.0;
            xd.M24 = 0.0;
            xd.M31 = 0.0;
            xd.M32 = 0.0;
            xd.M33 = z;
            xd.M34 = 0.0;
            xd.M41 = 0.0;
            xd.M42 = 0.0;
            xd.M43 = 0.0;
            xd.M44 = 1.0;
            return xd;
        }

        public static void CreateScale(ref Vector3D scales, out MatrixD result)
        {
            double x = scales.X;
            double y = scales.Y;
            double z = scales.Z;
            result.M11 = x;
            result.M12 = 0.0;
            result.M13 = 0.0;
            result.M14 = 0.0;
            result.M21 = 0.0;
            result.M22 = y;
            result.M23 = 0.0;
            result.M24 = 0.0;
            result.M31 = 0.0;
            result.M32 = 0.0;
            result.M33 = z;
            result.M34 = 0.0;
            result.M41 = 0.0;
            result.M42 = 0.0;
            result.M43 = 0.0;
            result.M44 = 1.0;
        }

        public static void CreateScale(double scale, out MatrixD result)
        {
            double num = scale;
            result.M11 = num;
            result.M12 = 0.0;
            result.M13 = 0.0;
            result.M14 = 0.0;
            result.M21 = 0.0;
            result.M22 = num;
            result.M23 = 0.0;
            result.M24 = 0.0;
            result.M31 = 0.0;
            result.M32 = 0.0;
            result.M33 = num;
            result.M34 = 0.0;
            result.M41 = 0.0;
            result.M42 = 0.0;
            result.M43 = 0.0;
            result.M44 = 1.0;
        }

        public static MatrixD CreateScale(double xScale, double yScale, double zScale)
        {
            MatrixD xd;
            double num = xScale;
            double num2 = yScale;
            double num3 = zScale;
            xd.M11 = num;
            xd.M12 = 0.0;
            xd.M13 = 0.0;
            xd.M14 = 0.0;
            xd.M21 = 0.0;
            xd.M22 = num2;
            xd.M23 = 0.0;
            xd.M24 = 0.0;
            xd.M31 = 0.0;
            xd.M32 = 0.0;
            xd.M33 = num3;
            xd.M34 = 0.0;
            xd.M41 = 0.0;
            xd.M42 = 0.0;
            xd.M43 = 0.0;
            xd.M44 = 1.0;
            return xd;
        }

        public static void CreateScale(double xScale, double yScale, double zScale, out MatrixD result)
        {
            double num = xScale;
            double num2 = yScale;
            double num3 = zScale;
            result.M11 = num;
            result.M12 = 0.0;
            result.M13 = 0.0;
            result.M14 = 0.0;
            result.M21 = 0.0;
            result.M22 = num2;
            result.M23 = 0.0;
            result.M24 = 0.0;
            result.M31 = 0.0;
            result.M32 = 0.0;
            result.M33 = num3;
            result.M34 = 0.0;
            result.M41 = 0.0;
            result.M42 = 0.0;
            result.M43 = 0.0;
            result.M44 = 1.0;
        }

        public static MatrixD CreateShadow(Vector3D lightDirection, Plane plane)
        {
            Plane plane2;
            MatrixD xd;
            Plane.Normalize(ref plane, out plane2);
            double num = ((plane2.Normal.X * lightDirection.X) + (plane2.Normal.Y * lightDirection.Y)) + (plane2.Normal.Z * lightDirection.Z);
            double num2 = -plane2.Normal.X;
            double num3 = -plane2.Normal.Y;
            double num4 = -plane2.Normal.Z;
            double num5 = -plane2.D;
            xd.M11 = (num2 * lightDirection.X) + num;
            xd.M21 = num3 * lightDirection.X;
            xd.M31 = num4 * lightDirection.X;
            xd.M41 = num5 * lightDirection.X;
            xd.M12 = num2 * lightDirection.Y;
            xd.M22 = (num3 * lightDirection.Y) + num;
            xd.M32 = num4 * lightDirection.Y;
            xd.M42 = num5 * lightDirection.Y;
            xd.M13 = num2 * lightDirection.Z;
            xd.M23 = num3 * lightDirection.Z;
            xd.M33 = (num4 * lightDirection.Z) + num;
            xd.M43 = num5 * lightDirection.Z;
            xd.M14 = 0.0;
            xd.M24 = 0.0;
            xd.M34 = 0.0;
            xd.M44 = num;
            return xd;
        }

        public static void CreateShadow(ref Vector3D lightDirection, ref Plane plane, out MatrixD result)
        {
            Plane plane2;
            Plane.Normalize(ref plane, out plane2);
            double num = ((plane2.Normal.X * lightDirection.X) + (plane2.Normal.Y * lightDirection.Y)) + (plane2.Normal.Z * lightDirection.Z);
            double num2 = -plane2.Normal.X;
            double num3 = -plane2.Normal.Y;
            double num4 = -plane2.Normal.Z;
            double num5 = -plane2.D;
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
            result.M14 = 0.0;
            result.M24 = 0.0;
            result.M34 = 0.0;
            result.M44 = num;
        }

        public static MatrixD CreateTranslation(Vector3 position)
        {
            MatrixD xd;
            xd.M11 = 1.0;
            xd.M12 = 0.0;
            xd.M13 = 0.0;
            xd.M14 = 0.0;
            xd.M21 = 0.0;
            xd.M22 = 1.0;
            xd.M23 = 0.0;
            xd.M24 = 0.0;
            xd.M31 = 0.0;
            xd.M32 = 0.0;
            xd.M33 = 1.0;
            xd.M34 = 0.0;
            xd.M41 = position.X;
            xd.M42 = position.Y;
            xd.M43 = position.Z;
            xd.M44 = 1.0;
            return xd;
        }

        public static MatrixD CreateTranslation(Vector3D position)
        {
            MatrixD xd;
            xd.M11 = 1.0;
            xd.M12 = 0.0;
            xd.M13 = 0.0;
            xd.M14 = 0.0;
            xd.M21 = 0.0;
            xd.M22 = 1.0;
            xd.M23 = 0.0;
            xd.M24 = 0.0;
            xd.M31 = 0.0;
            xd.M32 = 0.0;
            xd.M33 = 1.0;
            xd.M34 = 0.0;
            xd.M41 = position.X;
            xd.M42 = position.Y;
            xd.M43 = position.Z;
            xd.M44 = 1.0;
            return xd;
        }

        public static void CreateTranslation(ref Vector3D position, out MatrixD result)
        {
            result.M11 = 1.0;
            result.M12 = 0.0;
            result.M13 = 0.0;
            result.M14 = 0.0;
            result.M21 = 0.0;
            result.M22 = 1.0;
            result.M23 = 0.0;
            result.M24 = 0.0;
            result.M31 = 0.0;
            result.M32 = 0.0;
            result.M33 = 1.0;
            result.M34 = 0.0;
            result.M41 = position.X;
            result.M42 = position.Y;
            result.M43 = position.Z;
            result.M44 = 1.0;
        }

        public static MatrixD CreateTranslation(double xPosition, double yPosition, double zPosition)
        {
            MatrixD xd;
            xd.M11 = 1.0;
            xd.M12 = 0.0;
            xd.M13 = 0.0;
            xd.M14 = 0.0;
            xd.M21 = 0.0;
            xd.M22 = 1.0;
            xd.M23 = 0.0;
            xd.M24 = 0.0;
            xd.M31 = 0.0;
            xd.M32 = 0.0;
            xd.M33 = 1.0;
            xd.M34 = 0.0;
            xd.M41 = xPosition;
            xd.M42 = yPosition;
            xd.M43 = zPosition;
            xd.M44 = 1.0;
            return xd;
        }

        public static void CreateTranslation(double xPosition, double yPosition, double zPosition, out MatrixD result)
        {
            result.M11 = 1.0;
            result.M12 = 0.0;
            result.M13 = 0.0;
            result.M14 = 0.0;
            result.M21 = 0.0;
            result.M22 = 1.0;
            result.M23 = 0.0;
            result.M24 = 0.0;
            result.M31 = 0.0;
            result.M32 = 0.0;
            result.M33 = 1.0;
            result.M34 = 0.0;
            result.M41 = xPosition;
            result.M42 = yPosition;
            result.M43 = zPosition;
            result.M44 = 1.0;
        }

        public static MatrixD CreateWorld(Vector3D position) => 
            CreateWorld(position, Vector3D.Forward, Vector3D.Up);

        public static MatrixD CreateWorld(Vector3D position, Vector3 forward, Vector3 up) => 
            CreateWorld(position, (Vector3D) forward, (Vector3D) up);

        public static MatrixD CreateWorld(Vector3D position, Vector3D forward, Vector3D up)
        {
            MatrixD xd;
            Vector3D vectord = Vector3D.Normalize(-forward);
            Vector3D vectord2 = Vector3D.Normalize(Vector3D.Cross(up, vectord));
            Vector3D vectord3 = Vector3D.Cross(vectord, vectord2);
            xd.M11 = vectord2.X;
            xd.M12 = vectord2.Y;
            xd.M13 = vectord2.Z;
            xd.M14 = 0.0;
            xd.M21 = vectord3.X;
            xd.M22 = vectord3.Y;
            xd.M23 = vectord3.Z;
            xd.M24 = 0.0;
            xd.M31 = vectord.X;
            xd.M32 = vectord.Y;
            xd.M33 = vectord.Z;
            xd.M34 = 0.0;
            xd.M41 = position.X;
            xd.M42 = position.Y;
            xd.M43 = position.Z;
            xd.M44 = 1.0;
            return xd;
        }

        public static void CreateWorld(ref Vector3D position, ref Vector3D forward, ref Vector3D up, out MatrixD result)
        {
            Vector3D vectord = Vector3D.Normalize(-forward);
            Vector3D vectord2 = Vector3D.Normalize(Vector3D.Cross(up, vectord));
            Vector3D vectord3 = Vector3D.Cross(vectord, vectord2);
            result.M11 = vectord2.X;
            result.M12 = vectord2.Y;
            result.M13 = vectord2.Z;
            result.M14 = 0.0;
            result.M21 = vectord3.X;
            result.M22 = vectord3.Y;
            result.M23 = vectord3.Z;
            result.M24 = 0.0;
            result.M31 = vectord.X;
            result.M32 = vectord.Y;
            result.M33 = vectord.Z;
            result.M34 = 0.0;
            result.M41 = position.X;
            result.M42 = position.Y;
            result.M43 = position.Z;
            result.M44 = 1.0;
        }

        public double Determinant()
        {
            double num = this.M11;
            double num2 = this.M12;
            double num3 = this.M13;
            double num4 = this.M14;
            double num5 = this.M21;
            double num6 = this.M22;
            double num7 = this.M23;
            double num8 = this.M24;
            double num9 = this.M31;
            double num10 = this.M32;
            double num11 = this.M33;
            double num12 = this.M34;
            double num13 = this.M41;
            double num14 = this.M42;
            double num15 = this.M43;
            double num16 = this.M44;
            double num17 = (num11 * num16) - (num12 * num15);
            double num18 = (num10 * num16) - (num12 * num14);
            double num19 = (num10 * num15) - (num11 * num14);
            double num20 = (num9 * num16) - (num12 * num13);
            double num21 = (num9 * num15) - (num11 * num13);
            double num22 = (num9 * num14) - (num10 * num13);
            return ((((num * (((num6 * num17) - (num7 * num18)) + (num8 * num19))) - (num2 * (((num5 * num17) - (num7 * num20)) + (num8 * num21)))) + (num3 * (((num5 * num18) - (num6 * num20)) + (num8 * num22)))) - (num4 * (((num5 * num19) - (num6 * num21)) + (num7 * num22))));
        }

        public static MatrixD Divide(MatrixD matrix1, double divider)
        {
            MatrixD xd;
            double num = 1.0 / divider;
            xd.M11 = matrix1.M11 * num;
            xd.M12 = matrix1.M12 * num;
            xd.M13 = matrix1.M13 * num;
            xd.M14 = matrix1.M14 * num;
            xd.M21 = matrix1.M21 * num;
            xd.M22 = matrix1.M22 * num;
            xd.M23 = matrix1.M23 * num;
            xd.M24 = matrix1.M24 * num;
            xd.M31 = matrix1.M31 * num;
            xd.M32 = matrix1.M32 * num;
            xd.M33 = matrix1.M33 * num;
            xd.M34 = matrix1.M34 * num;
            xd.M41 = matrix1.M41 * num;
            xd.M42 = matrix1.M42 * num;
            xd.M43 = matrix1.M43 * num;
            xd.M44 = matrix1.M44 * num;
            return xd;
        }

        public static MatrixD Divide(MatrixD matrix1, MatrixD matrix2)
        {
            MatrixD xd;
            xd.M11 = matrix1.M11 / matrix2.M11;
            xd.M12 = matrix1.M12 / matrix2.M12;
            xd.M13 = matrix1.M13 / matrix2.M13;
            xd.M14 = matrix1.M14 / matrix2.M14;
            xd.M21 = matrix1.M21 / matrix2.M21;
            xd.M22 = matrix1.M22 / matrix2.M22;
            xd.M23 = matrix1.M23 / matrix2.M23;
            xd.M24 = matrix1.M24 / matrix2.M24;
            xd.M31 = matrix1.M31 / matrix2.M31;
            xd.M32 = matrix1.M32 / matrix2.M32;
            xd.M33 = matrix1.M33 / matrix2.M33;
            xd.M34 = matrix1.M34 / matrix2.M34;
            xd.M41 = matrix1.M41 / matrix2.M41;
            xd.M42 = matrix1.M42 / matrix2.M42;
            xd.M43 = matrix1.M43 / matrix2.M43;
            xd.M44 = matrix1.M44 / matrix2.M44;
            return xd;
        }

        public static void Divide(ref MatrixD matrix1, ref MatrixD matrix2, out MatrixD result)
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

        public static void Divide(ref MatrixD matrix1, double divider, out MatrixD result)
        {
            double num = 1.0 / divider;
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
            if (obj is MatrixD)
            {
                flag = this.Equals((MatrixD) obj);
            }
            return flag;
        }

        public bool Equals(MatrixD other) => 
            ((((((this.M11 == other.M11) && (this.M22 == other.M22)) && ((this.M33 == other.M33) && (this.M44 == other.M44))) && (((this.M12 == other.M12) && (this.M13 == other.M13)) && ((this.M14 == other.M14) && (this.M21 == other.M21)))) && ((((this.M23 == other.M23) && (this.M24 == other.M24)) && ((this.M31 == other.M31) && (this.M32 == other.M32))) && (((this.M34 == other.M34) && (this.M41 == other.M41)) && (this.M42 == other.M42)))) && (this.M43 == other.M43));

        public bool EqualsFast(ref MatrixD other, double epsilon = 0.0001)
        {
            double num = this.M21 - other.M21;
            double num2 = this.M22 - other.M22;
            double num3 = this.M23 - other.M23;
            double num4 = this.M31 - other.M31;
            double num5 = this.M32 - other.M32;
            double num6 = this.M33 - other.M33;
            double num7 = this.M41 - other.M41;
            double num8 = this.M42 - other.M42;
            double num9 = this.M43 - other.M43;
            double num10 = epsilon * epsilon;
            return ((((((num * num) + (num2 * num2)) + (num3 * num3)) < num10) & ((((num4 * num4) + (num5 * num5)) + (num6 * num6)) < num10)) & ((((num7 * num7) + (num8 * num8)) + (num9 * num9)) < num10));
        }

        public Base6Directions.Direction GetClosestDirection(Vector3D referenceVector) => 
            this.GetClosestDirection(ref referenceVector);

        public Base6Directions.Direction GetClosestDirection(ref Vector3D referenceVector)
        {
            double num = Vector3D.Dot(referenceVector, this.Right);
            double num2 = Vector3D.Dot(referenceVector, this.Up);
            double num3 = Vector3D.Dot(referenceVector, this.Backward);
            double num4 = Math.Abs(num);
            double num5 = Math.Abs(num2);
            double num6 = Math.Abs(num3);
            if (num4 > num5)
            {
                if (num4 > num6)
                {
                    if (num > 0.0)
                    {
                        return Base6Directions.Direction.Right;
                    }
                    return Base6Directions.Direction.Left;
                }
                if (num3 > 0.0)
                {
                    return Base6Directions.Direction.Backward;
                }
                return Base6Directions.Direction.Forward;
            }
            if (num5 > num6)
            {
                if (num2 > 0.0)
                {
                    return Base6Directions.Direction.Up;
                }
                return Base6Directions.Direction.Down;
            }
            if (num3 > 0.0)
            {
                return Base6Directions.Direction.Backward;
            }
            return Base6Directions.Direction.Forward;
        }

        public Vector3D GetDirectionVector(Base6Directions.Direction direction)
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
            return Vector3D.Zero;
        }

        public static bool GetEulerAnglesXYZ(ref MatrixD mat, out Vector3D xyz)
        {
            double x = mat.GetRow(0).X;
            double y = mat.GetRow(0).Y;
            double z = mat.GetRow(0).Z;
            double num4 = mat.GetRow(1).X;
            double num5 = mat.GetRow(1).Y;
            double num6 = mat.GetRow(1).Z;
            float single1 = mat.GetRow(2).X;
            float single2 = mat.GetRow(2).Y;
            double num7 = mat.GetRow(2).Z;
            double num8 = z;
            if (num8 < 1.0)
            {
                if (num8 > -1.0)
                {
                    xyz = new Vector3D(Math.Atan2(-num6, num7), Math.Asin(z), Math.Atan2(-y, x));
                    return true;
                }
                xyz = new Vector3D(-Math.Atan2(num4, num5), -1.570796012878418, 0.0);
                return false;
            }
            xyz = new Vector3D(Math.Atan2(num4, num5), -1.570796012878418, 0.0);
            return false;
        }

        public override int GetHashCode() => 
            (((((((((((((((this.M11.GetHashCode() + this.M12.GetHashCode()) + this.M13.GetHashCode()) + this.M14.GetHashCode()) + this.M21.GetHashCode()) + this.M22.GetHashCode()) + this.M23.GetHashCode()) + this.M24.GetHashCode()) + this.M31.GetHashCode()) + this.M32.GetHashCode()) + this.M33.GetHashCode()) + this.M34.GetHashCode()) + this.M41.GetHashCode()) + this.M42.GetHashCode()) + this.M43.GetHashCode()) + this.M44.GetHashCode());

        public MatrixD GetOrientation()
        {
            MatrixD identity = Identity;
            identity.Forward = this.Forward;
            identity.Up = this.Up;
            identity.Right = this.Right;
            return identity;
        }

        public unsafe Vector4 GetRow(int row)
        {
            fixed (double* numRef = &this.M11)
            {
                double* numPtr = numRef + ((row * 4) * 8);
                return new Vector4((float) numPtr[0], (float) numPtr[8], (float) numPtr[0x10], (float) numPtr[0x18]);
            }
        }

        public bool HasNoTranslationOrPerspective()
        {
            double num = 9.9999997473787516E-05;
            double num2 = ((((this.M41 + this.M42) + this.M43) + this.M34) + this.M24) + this.M14;
            if (num2 > num)
            {
                return false;
            }
            if (Math.Abs((double) (this.M44 - 1.0)) > num)
            {
                return false;
            }
            return true;
        }

        public static MatrixD Invert(MatrixD matrix) => 
            Invert(ref matrix);

        public static MatrixD Invert(ref MatrixD matrix)
        {
            MatrixD xd;
            double num = matrix.M11;
            double num2 = matrix.M12;
            double num3 = matrix.M13;
            double num4 = matrix.M14;
            double num5 = matrix.M21;
            double num6 = matrix.M22;
            double num7 = matrix.M23;
            double num8 = matrix.M24;
            double num9 = matrix.M31;
            double num10 = matrix.M32;
            double num11 = matrix.M33;
            double num12 = matrix.M34;
            double num13 = matrix.M41;
            double num14 = matrix.M42;
            double num15 = matrix.M43;
            double num16 = matrix.M44;
            double num17 = (num11 * num16) - (num12 * num15);
            double num18 = (num10 * num16) - (num12 * num14);
            double num19 = (num10 * num15) - (num11 * num14);
            double num20 = (num9 * num16) - (num12 * num13);
            double num21 = (num9 * num15) - (num11 * num13);
            double num22 = (num9 * num14) - (num10 * num13);
            double num23 = ((num6 * num17) - (num7 * num18)) + (num8 * num19);
            double num24 = -(((num5 * num17) - (num7 * num20)) + (num8 * num21));
            double num25 = ((num5 * num18) - (num6 * num20)) + (num8 * num22);
            double num26 = -(((num5 * num19) - (num6 * num21)) + (num7 * num22));
            double num27 = 1.0 / ((((num * num23) + (num2 * num24)) + (num3 * num25)) + (num4 * num26));
            xd.M11 = num23 * num27;
            xd.M21 = num24 * num27;
            xd.M31 = num25 * num27;
            xd.M41 = num26 * num27;
            xd.M12 = -(((num2 * num17) - (num3 * num18)) + (num4 * num19)) * num27;
            xd.M22 = (((num * num17) - (num3 * num20)) + (num4 * num21)) * num27;
            xd.M32 = -(((num * num18) - (num2 * num20)) + (num4 * num22)) * num27;
            xd.M42 = (((num * num19) - (num2 * num21)) + (num3 * num22)) * num27;
            double num28 = (num7 * num16) - (num8 * num15);
            double num29 = (num6 * num16) - (num8 * num14);
            double num30 = (num6 * num15) - (num7 * num14);
            double num31 = (num5 * num16) - (num8 * num13);
            double num32 = (num5 * num15) - (num7 * num13);
            double num33 = (num5 * num14) - (num6 * num13);
            xd.M13 = (((num2 * num28) - (num3 * num29)) + (num4 * num30)) * num27;
            xd.M23 = -(((num * num28) - (num3 * num31)) + (num4 * num32)) * num27;
            xd.M33 = (((num * num29) - (num2 * num31)) + (num4 * num33)) * num27;
            xd.M43 = -(((num * num30) - (num2 * num32)) + (num3 * num33)) * num27;
            double num34 = (num7 * num12) - (num8 * num11);
            double num35 = (num6 * num12) - (num8 * num10);
            double num36 = (num6 * num11) - (num7 * num10);
            double num37 = (num5 * num12) - (num8 * num9);
            double num38 = (num5 * num11) - (num7 * num9);
            double num39 = (num5 * num10) - (num6 * num9);
            xd.M14 = -(((num2 * num34) - (num3 * num35)) + (num4 * num36)) * num27;
            xd.M24 = (((num * num34) - (num3 * num37)) + (num4 * num38)) * num27;
            xd.M34 = -(((num * num35) - (num2 * num37)) + (num4 * num39)) * num27;
            xd.M44 = (((num * num36) - (num2 * num38)) + (num3 * num39)) * num27;
            return xd;
        }

        public static void Invert(ref MatrixD matrix, out MatrixD result)
        {
            double num = matrix.M11;
            double num2 = matrix.M12;
            double num3 = matrix.M13;
            double num4 = matrix.M14;
            double num5 = matrix.M21;
            double num6 = matrix.M22;
            double num7 = matrix.M23;
            double num8 = matrix.M24;
            double num9 = matrix.M31;
            double num10 = matrix.M32;
            double num11 = matrix.M33;
            double num12 = matrix.M34;
            double num13 = matrix.M41;
            double num14 = matrix.M42;
            double num15 = matrix.M43;
            double num16 = matrix.M44;
            double num17 = (num11 * num16) - (num12 * num15);
            double num18 = (num10 * num16) - (num12 * num14);
            double num19 = (num10 * num15) - (num11 * num14);
            double num20 = (num9 * num16) - (num12 * num13);
            double num21 = (num9 * num15) - (num11 * num13);
            double num22 = (num9 * num14) - (num10 * num13);
            double num23 = ((num6 * num17) - (num7 * num18)) + (num8 * num19);
            double num24 = -(((num5 * num17) - (num7 * num20)) + (num8 * num21));
            double num25 = ((num5 * num18) - (num6 * num20)) + (num8 * num22);
            double num26 = -(((num5 * num19) - (num6 * num21)) + (num7 * num22));
            double num27 = 1.0 / ((((num * num23) + (num2 * num24)) + (num3 * num25)) + (num4 * num26));
            result.M11 = num23 * num27;
            result.M21 = num24 * num27;
            result.M31 = num25 * num27;
            result.M41 = num26 * num27;
            result.M12 = -(((num2 * num17) - (num3 * num18)) + (num4 * num19)) * num27;
            result.M22 = (((num * num17) - (num3 * num20)) + (num4 * num21)) * num27;
            result.M32 = -(((num * num18) - (num2 * num20)) + (num4 * num22)) * num27;
            result.M42 = (((num * num19) - (num2 * num21)) + (num3 * num22)) * num27;
            double num28 = (num7 * num16) - (num8 * num15);
            double num29 = (num6 * num16) - (num8 * num14);
            double num30 = (num6 * num15) - (num7 * num14);
            double num31 = (num5 * num16) - (num8 * num13);
            double num32 = (num5 * num15) - (num7 * num13);
            double num33 = (num5 * num14) - (num6 * num13);
            result.M13 = (((num2 * num28) - (num3 * num29)) + (num4 * num30)) * num27;
            result.M23 = -(((num * num28) - (num3 * num31)) + (num4 * num32)) * num27;
            result.M33 = (((num * num29) - (num2 * num31)) + (num4 * num33)) * num27;
            result.M43 = -(((num * num30) - (num2 * num32)) + (num3 * num33)) * num27;
            double num34 = (num7 * num12) - (num8 * num11);
            double num35 = (num6 * num12) - (num8 * num10);
            double num36 = (num6 * num11) - (num7 * num10);
            double num37 = (num5 * num12) - (num8 * num9);
            double num38 = (num5 * num11) - (num7 * num9);
            double num39 = (num5 * num10) - (num6 * num9);
            result.M14 = -(((num2 * num34) - (num3 * num35)) + (num4 * num36)) * num27;
            result.M24 = (((num * num34) - (num3 * num37)) + (num4 * num38)) * num27;
            result.M34 = -(((num * num35) - (num2 * num37)) + (num4 * num39)) * num27;
            result.M44 = (((num * num36) - (num2 * num38)) + (num3 * num39)) * num27;
        }

        public bool IsMirrored() => 
            (this.Determinant() < 0.0);

        public bool IsNan() => 
            double.IsNaN(((((((((((((((this.M11 + this.M12) + this.M13) + this.M14) + this.M21) + this.M22) + this.M23) + this.M24) + this.M31) + this.M32) + this.M33) + this.M34) + this.M41) + this.M42) + this.M43) + this.M44);

        public bool IsOrthogonal()
        {
            double epsilon = 0.0001;
            return this.IsOrthogonal(epsilon);
        }

        public bool IsOrthogonal(double epsilon) => 
            (((((Math.Abs(this.Up.LengthSquared()) - 1.0) < epsilon) && ((Math.Abs(this.Right.LengthSquared()) - 1.0) < epsilon)) && (((Math.Abs(this.Forward.LengthSquared()) - 1.0) < epsilon) && (Math.Abs(this.Right.Dot(this.Up)) < epsilon))) && (Math.Abs(this.Right.Dot(this.Forward)) < epsilon));

        public bool IsRotation()
        {
            double num = 0.01;
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
            if (Math.Abs((double) (this.Right.LengthSquared() - 1.0)) > num)
            {
                return false;
            }
            if (Math.Abs((double) (this.Up.LengthSquared() - 1.0)) > num)
            {
                return false;
            }
            if (Math.Abs((double) (this.Backward.LengthSquared() - 1.0)) > num)
            {
                return false;
            }
            return true;
        }

        public bool IsValid() => 
            (((((((((((((((this.M11 + this.M12) + this.M13) + this.M14) + this.M21) + this.M22) + this.M23) + this.M24) + this.M31) + this.M32) + this.M33) + this.M34) + this.M41) + this.M42) + this.M43) + this.M44).IsValid();

        public static MatrixD Lerp(MatrixD matrix1, MatrixD matrix2, double amount)
        {
            MatrixD xd;
            xd.M11 = matrix1.M11 + ((matrix2.M11 - matrix1.M11) * amount);
            xd.M12 = matrix1.M12 + ((matrix2.M12 - matrix1.M12) * amount);
            xd.M13 = matrix1.M13 + ((matrix2.M13 - matrix1.M13) * amount);
            xd.M14 = matrix1.M14 + ((matrix2.M14 - matrix1.M14) * amount);
            xd.M21 = matrix1.M21 + ((matrix2.M21 - matrix1.M21) * amount);
            xd.M22 = matrix1.M22 + ((matrix2.M22 - matrix1.M22) * amount);
            xd.M23 = matrix1.M23 + ((matrix2.M23 - matrix1.M23) * amount);
            xd.M24 = matrix1.M24 + ((matrix2.M24 - matrix1.M24) * amount);
            xd.M31 = matrix1.M31 + ((matrix2.M31 - matrix1.M31) * amount);
            xd.M32 = matrix1.M32 + ((matrix2.M32 - matrix1.M32) * amount);
            xd.M33 = matrix1.M33 + ((matrix2.M33 - matrix1.M33) * amount);
            xd.M34 = matrix1.M34 + ((matrix2.M34 - matrix1.M34) * amount);
            xd.M41 = matrix1.M41 + ((matrix2.M41 - matrix1.M41) * amount);
            xd.M42 = matrix1.M42 + ((matrix2.M42 - matrix1.M42) * amount);
            xd.M43 = matrix1.M43 + ((matrix2.M43 - matrix1.M43) * amount);
            xd.M44 = matrix1.M44 + ((matrix2.M44 - matrix1.M44) * amount);
            return xd;
        }

        public static void Lerp(ref MatrixD matrix1, ref MatrixD matrix2, double amount, out MatrixD result)
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

        public static MatrixD Multiply(MatrixD matrix1, double scaleFactor)
        {
            MatrixD xd;
            double num = scaleFactor;
            xd.M11 = matrix1.M11 * num;
            xd.M12 = matrix1.M12 * num;
            xd.M13 = matrix1.M13 * num;
            xd.M14 = matrix1.M14 * num;
            xd.M21 = matrix1.M21 * num;
            xd.M22 = matrix1.M22 * num;
            xd.M23 = matrix1.M23 * num;
            xd.M24 = matrix1.M24 * num;
            xd.M31 = matrix1.M31 * num;
            xd.M32 = matrix1.M32 * num;
            xd.M33 = matrix1.M33 * num;
            xd.M34 = matrix1.M34 * num;
            xd.M41 = matrix1.M41 * num;
            xd.M42 = matrix1.M42 * num;
            xd.M43 = matrix1.M43 * num;
            xd.M44 = matrix1.M44 * num;
            return xd;
        }

        public static MatrixD Multiply(MatrixD matrix1, Matrix matrix2)
        {
            MatrixD xd;
            xd.M11 = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
            xd.M12 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
            xd.M13 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
            xd.M14 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
            xd.M21 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
            xd.M22 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
            xd.M23 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
            xd.M24 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
            xd.M31 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
            xd.M32 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
            xd.M33 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
            xd.M34 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
            xd.M41 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
            xd.M42 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
            xd.M43 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
            xd.M44 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
            return xd;
        }

        public static MatrixD Multiply(MatrixD matrix1, MatrixD matrix2)
        {
            MatrixD xd;
            xd.M11 = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
            xd.M12 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
            xd.M13 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
            xd.M14 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
            xd.M21 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
            xd.M22 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
            xd.M23 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
            xd.M24 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
            xd.M31 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
            xd.M32 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
            xd.M33 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
            xd.M34 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
            xd.M41 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
            xd.M42 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
            xd.M43 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
            xd.M44 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
            return xd;
        }

        public static void Multiply(ref Matrix matrix1, ref MatrixD matrix2, out MatrixD result)
        {
            double num = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
            double num2 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
            double num3 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
            double num4 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
            double num5 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
            double num6 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
            double num7 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
            double num8 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
            double num9 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
            double num10 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
            double num11 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
            double num12 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
            double num13 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
            double num14 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
            double num15 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
            double num16 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
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

        public static void Multiply(ref MatrixD matrix1, ref Matrix matrix2, out MatrixD result)
        {
            double num = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
            double num2 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
            double num3 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
            double num4 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
            double num5 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
            double num6 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
            double num7 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
            double num8 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
            double num9 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
            double num10 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
            double num11 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
            double num12 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
            double num13 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
            double num14 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
            double num15 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
            double num16 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
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

        public static void Multiply(ref MatrixD matrix1, ref MatrixD matrix2, out MatrixD result)
        {
            double num = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
            double num2 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
            double num3 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
            double num4 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
            double num5 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
            double num6 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
            double num7 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
            double num8 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
            double num9 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
            double num10 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
            double num11 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
            double num12 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
            double num13 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
            double num14 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
            double num15 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
            double num16 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
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

        public static void Multiply(ref MatrixD matrix1, double scaleFactor, out MatrixD result)
        {
            double num = scaleFactor;
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

        public static MatrixD Negate(MatrixD matrix)
        {
            MatrixD xd;
            xd.M11 = -matrix.M11;
            xd.M12 = -matrix.M12;
            xd.M13 = -matrix.M13;
            xd.M14 = -matrix.M14;
            xd.M21 = -matrix.M21;
            xd.M22 = -matrix.M22;
            xd.M23 = -matrix.M23;
            xd.M24 = -matrix.M24;
            xd.M31 = -matrix.M31;
            xd.M32 = -matrix.M32;
            xd.M33 = -matrix.M33;
            xd.M34 = -matrix.M34;
            xd.M41 = -matrix.M41;
            xd.M42 = -matrix.M42;
            xd.M43 = -matrix.M43;
            xd.M44 = -matrix.M44;
            return xd;
        }

        public static void Negate(ref MatrixD matrix, out MatrixD result)
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

        public static MatrixD Normalize(MatrixD matrix)
        {
            MatrixD xd = matrix;
            xd.Right = Vector3D.Normalize(xd.Right);
            xd.Up = Vector3D.Normalize(xd.Up);
            xd.Forward = Vector3D.Normalize(xd.Forward);
            return xd;
        }

        public static MatrixD operator +(MatrixD matrix1, MatrixD matrix2)
        {
            MatrixD xd;
            xd.M11 = matrix1.M11 + matrix2.M11;
            xd.M12 = matrix1.M12 + matrix2.M12;
            xd.M13 = matrix1.M13 + matrix2.M13;
            xd.M14 = matrix1.M14 + matrix2.M14;
            xd.M21 = matrix1.M21 + matrix2.M21;
            xd.M22 = matrix1.M22 + matrix2.M22;
            xd.M23 = matrix1.M23 + matrix2.M23;
            xd.M24 = matrix1.M24 + matrix2.M24;
            xd.M31 = matrix1.M31 + matrix2.M31;
            xd.M32 = matrix1.M32 + matrix2.M32;
            xd.M33 = matrix1.M33 + matrix2.M33;
            xd.M34 = matrix1.M34 + matrix2.M34;
            xd.M41 = matrix1.M41 + matrix2.M41;
            xd.M42 = matrix1.M42 + matrix2.M42;
            xd.M43 = matrix1.M43 + matrix2.M43;
            xd.M44 = matrix1.M44 + matrix2.M44;
            return xd;
        }

        public static MatrixD operator /(MatrixD matrix1, double divider)
        {
            MatrixD xd;
            double num = 1.0 / divider;
            xd.M11 = matrix1.M11 * num;
            xd.M12 = matrix1.M12 * num;
            xd.M13 = matrix1.M13 * num;
            xd.M14 = matrix1.M14 * num;
            xd.M21 = matrix1.M21 * num;
            xd.M22 = matrix1.M22 * num;
            xd.M23 = matrix1.M23 * num;
            xd.M24 = matrix1.M24 * num;
            xd.M31 = matrix1.M31 * num;
            xd.M32 = matrix1.M32 * num;
            xd.M33 = matrix1.M33 * num;
            xd.M34 = matrix1.M34 * num;
            xd.M41 = matrix1.M41 * num;
            xd.M42 = matrix1.M42 * num;
            xd.M43 = matrix1.M43 * num;
            xd.M44 = matrix1.M44 * num;
            return xd;
        }

        public static MatrixD operator /(MatrixD matrix1, MatrixD matrix2)
        {
            MatrixD xd;
            xd.M11 = matrix1.M11 / matrix2.M11;
            xd.M12 = matrix1.M12 / matrix2.M12;
            xd.M13 = matrix1.M13 / matrix2.M13;
            xd.M14 = matrix1.M14 / matrix2.M14;
            xd.M21 = matrix1.M21 / matrix2.M21;
            xd.M22 = matrix1.M22 / matrix2.M22;
            xd.M23 = matrix1.M23 / matrix2.M23;
            xd.M24 = matrix1.M24 / matrix2.M24;
            xd.M31 = matrix1.M31 / matrix2.M31;
            xd.M32 = matrix1.M32 / matrix2.M32;
            xd.M33 = matrix1.M33 / matrix2.M33;
            xd.M34 = matrix1.M34 / matrix2.M34;
            xd.M41 = matrix1.M41 / matrix2.M41;
            xd.M42 = matrix1.M42 / matrix2.M42;
            xd.M43 = matrix1.M43 / matrix2.M43;
            xd.M44 = matrix1.M44 / matrix2.M44;
            return xd;
        }

        public static bool operator ==(MatrixD matrix1, MatrixD matrix2) => 
            ((((((matrix1.M11 == matrix2.M11) && (matrix1.M22 == matrix2.M22)) && ((matrix1.M33 == matrix2.M33) && (matrix1.M44 == matrix2.M44))) && (((matrix1.M12 == matrix2.M12) && (matrix1.M13 == matrix2.M13)) && ((matrix1.M14 == matrix2.M14) && (matrix1.M21 == matrix2.M21)))) && ((((matrix1.M23 == matrix2.M23) && (matrix1.M24 == matrix2.M24)) && ((matrix1.M31 == matrix2.M31) && (matrix1.M32 == matrix2.M32))) && (((matrix1.M34 == matrix2.M34) && (matrix1.M41 == matrix2.M41)) && (matrix1.M42 == matrix2.M42)))) && (matrix1.M43 == matrix2.M43));

        public static implicit operator MatrixD(Matrix m) => 
            new MatrixD((double) m.M11, (double) m.M12, (double) m.M13, (double) m.M14, (double) m.M21, (double) m.M22, (double) m.M23, (double) m.M24, (double) m.M31, (double) m.M32, (double) m.M33, (double) m.M34, (double) m.M41, (double) m.M42, (double) m.M43, (double) m.M44);

        public static implicit operator Matrix(MatrixD m) => 
            new Matrix((float) m.M11, (float) m.M12, (float) m.M13, (float) m.M14, (float) m.M21, (float) m.M22, (float) m.M23, (float) m.M24, (float) m.M31, (float) m.M32, (float) m.M33, (float) m.M34, (float) m.M41, (float) m.M42, (float) m.M43, (float) m.M44);

        public static bool operator !=(MatrixD matrix1, MatrixD matrix2)
        {
            if (((((matrix1.M11 == matrix2.M11) && (matrix1.M12 == matrix2.M12)) && ((matrix1.M13 == matrix2.M13) && (matrix1.M14 == matrix2.M14))) && (((matrix1.M21 == matrix2.M21) && (matrix1.M22 == matrix2.M22)) && ((matrix1.M23 == matrix2.M23) && (matrix1.M24 == matrix2.M24)))) && ((((matrix1.M31 == matrix2.M31) && (matrix1.M32 == matrix2.M32)) && ((matrix1.M33 == matrix2.M33) && (matrix1.M34 == matrix2.M34))) && (((matrix1.M41 == matrix2.M41) && (matrix1.M42 == matrix2.M42)) && (matrix1.M43 == matrix2.M43))))
            {
                return !(matrix1.M44 == matrix2.M44);
            }
            return true;
        }

        public static MatrixD operator *(double scaleFactor, MatrixD matrix)
        {
            MatrixD xd;
            double num = scaleFactor;
            xd.M11 = matrix.M11 * num;
            xd.M12 = matrix.M12 * num;
            xd.M13 = matrix.M13 * num;
            xd.M14 = matrix.M14 * num;
            xd.M21 = matrix.M21 * num;
            xd.M22 = matrix.M22 * num;
            xd.M23 = matrix.M23 * num;
            xd.M24 = matrix.M24 * num;
            xd.M31 = matrix.M31 * num;
            xd.M32 = matrix.M32 * num;
            xd.M33 = matrix.M33 * num;
            xd.M34 = matrix.M34 * num;
            xd.M41 = matrix.M41 * num;
            xd.M42 = matrix.M42 * num;
            xd.M43 = matrix.M43 * num;
            xd.M44 = matrix.M44 * num;
            return xd;
        }

        public static MatrixD operator *(Matrix matrix1, MatrixD matrix2)
        {
            MatrixD xd;
            xd.M11 = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
            xd.M12 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
            xd.M13 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
            xd.M14 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
            xd.M21 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
            xd.M22 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
            xd.M23 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
            xd.M24 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
            xd.M31 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
            xd.M32 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
            xd.M33 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
            xd.M34 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
            xd.M41 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
            xd.M42 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
            xd.M43 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
            xd.M44 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
            return xd;
        }

        public static MatrixD operator *(MatrixD matrix, double scaleFactor)
        {
            MatrixD xd;
            double num = scaleFactor;
            xd.M11 = matrix.M11 * num;
            xd.M12 = matrix.M12 * num;
            xd.M13 = matrix.M13 * num;
            xd.M14 = matrix.M14 * num;
            xd.M21 = matrix.M21 * num;
            xd.M22 = matrix.M22 * num;
            xd.M23 = matrix.M23 * num;
            xd.M24 = matrix.M24 * num;
            xd.M31 = matrix.M31 * num;
            xd.M32 = matrix.M32 * num;
            xd.M33 = matrix.M33 * num;
            xd.M34 = matrix.M34 * num;
            xd.M41 = matrix.M41 * num;
            xd.M42 = matrix.M42 * num;
            xd.M43 = matrix.M43 * num;
            xd.M44 = matrix.M44 * num;
            return xd;
        }

        public static MatrixD operator *(MatrixD matrix1, Matrix matrix2)
        {
            MatrixD xd;
            xd.M11 = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
            xd.M12 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
            xd.M13 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
            xd.M14 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
            xd.M21 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
            xd.M22 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
            xd.M23 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
            xd.M24 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
            xd.M31 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
            xd.M32 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
            xd.M33 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
            xd.M34 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
            xd.M41 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
            xd.M42 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
            xd.M43 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
            xd.M44 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
            return xd;
        }

        public static MatrixD operator *(MatrixD matrix1, MatrixD matrix2)
        {
            MatrixD xd;
            xd.M11 = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
            xd.M12 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
            xd.M13 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
            xd.M14 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
            xd.M21 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
            xd.M22 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
            xd.M23 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
            xd.M24 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
            xd.M31 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
            xd.M32 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
            xd.M33 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
            xd.M34 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
            xd.M41 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
            xd.M42 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
            xd.M43 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
            xd.M44 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
            return xd;
        }

        public static MatrixD operator -(MatrixD matrix1, MatrixD matrix2)
        {
            MatrixD xd;
            xd.M11 = matrix1.M11 - matrix2.M11;
            xd.M12 = matrix1.M12 - matrix2.M12;
            xd.M13 = matrix1.M13 - matrix2.M13;
            xd.M14 = matrix1.M14 - matrix2.M14;
            xd.M21 = matrix1.M21 - matrix2.M21;
            xd.M22 = matrix1.M22 - matrix2.M22;
            xd.M23 = matrix1.M23 - matrix2.M23;
            xd.M24 = matrix1.M24 - matrix2.M24;
            xd.M31 = matrix1.M31 - matrix2.M31;
            xd.M32 = matrix1.M32 - matrix2.M32;
            xd.M33 = matrix1.M33 - matrix2.M33;
            xd.M34 = matrix1.M34 - matrix2.M34;
            xd.M41 = matrix1.M41 - matrix2.M41;
            xd.M42 = matrix1.M42 - matrix2.M42;
            xd.M43 = matrix1.M43 - matrix2.M43;
            xd.M44 = matrix1.M44 - matrix2.M44;
            return xd;
        }

        public static MatrixD operator -(MatrixD matrix1)
        {
            MatrixD xd;
            xd.M11 = -matrix1.M11;
            xd.M12 = -matrix1.M12;
            xd.M13 = -matrix1.M13;
            xd.M14 = -matrix1.M14;
            xd.M21 = -matrix1.M21;
            xd.M22 = -matrix1.M22;
            xd.M23 = -matrix1.M23;
            xd.M24 = -matrix1.M24;
            xd.M31 = -matrix1.M31;
            xd.M32 = -matrix1.M32;
            xd.M33 = -matrix1.M33;
            xd.M34 = -matrix1.M34;
            xd.M41 = -matrix1.M41;
            xd.M42 = -matrix1.M42;
            xd.M43 = -matrix1.M43;
            xd.M44 = -matrix1.M44;
            return xd;
        }

        public void Orthogonalize()
        {
            Vector3D v = Vector3D.Normalize(this.Right);
            Vector3D vectord2 = Vector3D.Normalize(this.Up - ((Vector3D) (v * this.Up.Dot(v))));
            Vector3D vectord3 = Vector3D.Normalize((Vector3D) ((this.Backward - (v * this.Backward.Dot(v))) - (vectord2 * this.Backward.Dot(vectord2))));
            this.Right = v;
            this.Up = vectord2;
            this.Backward = vectord3;
        }

        public static MatrixD Orthogonalize(MatrixD rotationMatrix)
        {
            MatrixD xd = rotationMatrix;
            xd.Right = Vector3D.Normalize(xd.Right);
            xd.Up = Vector3D.Normalize(xd.Up - ((Vector3D) (xd.Right * xd.Up.Dot(xd.Right))));
            xd.Backward = Vector3D.Normalize((Vector3D) ((xd.Backward - (xd.Right * xd.Backward.Dot(xd.Right))) - (xd.Up * xd.Backward.Dot(xd.Up))));
            return xd;
        }

        [UnsharperDisableReflection]
        public static void Rescale(ref MatrixD matrix, double scale)
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
        public static MatrixD Rescale(MatrixD matrix, double scale)
        {
            Rescale(ref matrix, scale);
            return matrix;
        }

        [UnsharperDisableReflection]
        public static void Rescale(ref MatrixD matrix, float scale)
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
        public static void Rescale(ref MatrixD matrix, ref Vector3D scale)
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
        public static MatrixD Rescale(MatrixD matrix, Vector3D scale)
        {
            Rescale(ref matrix, ref scale);
            return matrix;
        }

        public void SetDirectionVector(Base6Directions.Direction direction, Vector3D newValue)
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
            fixed (double* numRef = &this.M11)
            {
                double* numPtr = numRef + ((row * 4) * 8);
                numPtr[0] = value.X;
                numPtr[8] = value.Y;
                numPtr[0x10] = value.Z;
                numPtr[0x18] = value.W;
            }
        }

        public static MatrixD Slerp(MatrixD matrix1, MatrixD matrix2, float amount)
        {
            MatrixD xd;
            Slerp(ref matrix1, ref matrix2, amount, out xd);
            return xd;
        }

        public static void Slerp(ref MatrixD matrix1, ref MatrixD matrix2, float amount, out MatrixD result)
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

        public static void Slerp(MatrixD matrix1, MatrixD matrix2, float amount, out MatrixD result)
        {
            Slerp(ref matrix1, ref matrix2, amount, out result);
        }

        public static MatrixD SlerpScale(MatrixD matrix1, MatrixD matrix2, float amount)
        {
            MatrixD xd;
            SlerpScale(ref matrix1, ref matrix2, amount, out xd);
            return xd;
        }

        public static void SlerpScale(ref MatrixD matrix1, ref MatrixD matrix2, float amount, out MatrixD result)
        {
            Vector3D scale = matrix1.Scale;
            Vector3D vectord2 = matrix2.Scale;
            if ((scale.LengthSquared() < 0.0099999997764825821) || (vectord2.LengthSquared() < 0.0099999997764825821))
            {
                result = Zero;
            }
            else
            {
                Quaternion quaternion;
                Quaternion quaternion2;
                Quaternion quaternion3;
                MatrixD matrix = Normalize(matrix1);
                MatrixD xd2 = Normalize(matrix2);
                Quaternion.CreateFromRotationMatrix(ref matrix, out quaternion);
                Quaternion.CreateFromRotationMatrix(ref xd2, out quaternion2);
                Quaternion.Slerp(ref quaternion, ref quaternion2, amount, out quaternion3);
                CreateFromQuaternion(ref quaternion3, out result);
                Vector3D vectord3 = Vector3D.Lerp(scale, vectord2, (double) amount);
                Rescale(ref result, ref vectord3);
                result.M41 = matrix1.M41 + ((matrix2.M41 - matrix1.M41) * amount);
                result.M42 = matrix1.M42 + ((matrix2.M42 - matrix1.M42) * amount);
                result.M43 = matrix1.M43 + ((matrix2.M43 - matrix1.M43) * amount);
            }
        }

        public static void SlerpScale(MatrixD matrix1, MatrixD matrix2, float amount, out MatrixD result)
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

        public static void Subtract(ref MatrixD matrix1, ref MatrixD matrix2, out MatrixD result)
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

        public static MatrixD SwapYZCoordinates(MatrixD m)
        {
            MatrixD xd = m;
            Vector3D right = m.Right;
            Vector3D up = m.Up;
            Vector3D forward = m.Forward;
            xd.Right = new Vector3D(right.X, right.Z, -right.Y);
            xd.Up = new Vector3D(forward.X, forward.Z, -forward.Y);
            xd.Forward = new Vector3D(-up.X, -up.Z, up.Y);
            Vector3D translation = m.Translation;
            xd.Translation = Vector3D.SwapYZCoordinates(translation);
            return xd;
        }

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return ("{ " + string.Format(currentCulture, "{{M11:{0} M12:{1} M13:{2} M14:{3}}} ", new object[] { this.M11.ToString(currentCulture), this.M12.ToString(currentCulture), this.M13.ToString(currentCulture), this.M14.ToString(currentCulture) }) + string.Format(currentCulture, "{{M21:{0} M22:{1} M23:{2} M24:{3}}} ", new object[] { this.M21.ToString(currentCulture), this.M22.ToString(currentCulture), this.M23.ToString(currentCulture), this.M24.ToString(currentCulture) }) + string.Format(currentCulture, "{{M31:{0} M32:{1} M33:{2} M34:{3}}} ", new object[] { this.M31.ToString(currentCulture), this.M32.ToString(currentCulture), this.M33.ToString(currentCulture), this.M34.ToString(currentCulture) }) + string.Format(currentCulture, "{{M41:{0} M42:{1} M43:{2} M44:{3}}} ", new object[] { this.M41.ToString(currentCulture), this.M42.ToString(currentCulture), this.M43.ToString(currentCulture), this.M44.ToString(currentCulture) }) + "}");
        }

        public static MatrixD Transform(MatrixD value, Quaternion rotation)
        {
            MatrixD xd;
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
            xd.M11 = ((value.M11 * num13) + (value.M12 * num14)) + (value.M13 * num15);
            xd.M12 = ((value.M11 * num16) + (value.M12 * num17)) + (value.M13 * num18);
            xd.M13 = ((value.M11 * num19) + (value.M12 * num20)) + (value.M13 * num21);
            xd.M14 = value.M14;
            xd.M21 = ((value.M21 * num13) + (value.M22 * num14)) + (value.M23 * num15);
            xd.M22 = ((value.M21 * num16) + (value.M22 * num17)) + (value.M23 * num18);
            xd.M23 = ((value.M21 * num19) + (value.M22 * num20)) + (value.M23 * num21);
            xd.M24 = value.M24;
            xd.M31 = ((value.M31 * num13) + (value.M32 * num14)) + (value.M33 * num15);
            xd.M32 = ((value.M31 * num16) + (value.M32 * num17)) + (value.M33 * num18);
            xd.M33 = ((value.M31 * num19) + (value.M32 * num20)) + (value.M33 * num21);
            xd.M34 = value.M34;
            xd.M41 = ((value.M41 * num13) + (value.M42 * num14)) + (value.M43 * num15);
            xd.M42 = ((value.M41 * num16) + (value.M42 * num17)) + (value.M43 * num18);
            xd.M43 = ((value.M41 * num19) + (value.M42 * num20)) + (value.M43 * num21);
            xd.M44 = value.M44;
            return xd;
        }

        public static void Transform(ref MatrixD value, ref Quaternion rotation, out MatrixD result)
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
            double num22 = ((value.M11 * num13) + (value.M12 * num14)) + (value.M13 * num15);
            double num23 = ((value.M11 * num16) + (value.M12 * num17)) + (value.M13 * num18);
            double num24 = ((value.M11 * num19) + (value.M12 * num20)) + (value.M13 * num21);
            double num25 = value.M14;
            double num26 = ((value.M21 * num13) + (value.M22 * num14)) + (value.M23 * num15);
            double num27 = ((value.M21 * num16) + (value.M22 * num17)) + (value.M23 * num18);
            double num28 = ((value.M21 * num19) + (value.M22 * num20)) + (value.M23 * num21);
            double num29 = value.M24;
            double num30 = ((value.M31 * num13) + (value.M32 * num14)) + (value.M33 * num15);
            double num31 = ((value.M31 * num16) + (value.M32 * num17)) + (value.M33 * num18);
            double num32 = ((value.M31 * num19) + (value.M32 * num20)) + (value.M33 * num21);
            double num33 = value.M34;
            double num34 = ((value.M41 * num13) + (value.M42 * num14)) + (value.M43 * num15);
            double num35 = ((value.M41 * num16) + (value.M42 * num17)) + (value.M43 * num18);
            double num36 = ((value.M41 * num19) + (value.M42 * num20)) + (value.M43 * num21);
            double num37 = value.M44;
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

        public static MatrixD Transpose(MatrixD matrix)
        {
            MatrixD xd;
            xd.M11 = matrix.M11;
            xd.M12 = matrix.M21;
            xd.M13 = matrix.M31;
            xd.M14 = matrix.M41;
            xd.M21 = matrix.M12;
            xd.M22 = matrix.M22;
            xd.M23 = matrix.M32;
            xd.M24 = matrix.M42;
            xd.M31 = matrix.M13;
            xd.M32 = matrix.M23;
            xd.M33 = matrix.M33;
            xd.M34 = matrix.M43;
            xd.M41 = matrix.M14;
            xd.M42 = matrix.M24;
            xd.M43 = matrix.M34;
            xd.M44 = matrix.M44;
            return xd;
        }

        public static void Transpose(ref MatrixD matrix, out MatrixD result)
        {
            double num = matrix.M11;
            double num2 = matrix.M12;
            double num3 = matrix.M13;
            double num4 = matrix.M14;
            double num5 = matrix.M21;
            double num6 = matrix.M22;
            double num7 = matrix.M23;
            double num8 = matrix.M24;
            double num9 = matrix.M31;
            double num10 = matrix.M32;
            double num11 = matrix.M33;
            double num12 = matrix.M34;
            double num13 = matrix.M41;
            double num14 = matrix.M42;
            double num15 = matrix.M43;
            double num16 = matrix.M44;
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

        public Vector3D Backward
        {
            get
            {
                Vector3D vectord;
                vectord.X = this.M31;
                vectord.Y = this.M32;
                vectord.Z = this.M33;
                return vectord;
            }
            set
            {
                this.M31 = value.X;
                this.M32 = value.Y;
                this.M33 = value.Z;
            }
        }

        public Vector3D Col0
        {
            get
            {
                Vector3D vectord;
                vectord.X = this.M11;
                vectord.Y = this.M21;
                vectord.Z = this.M31;
                return vectord;
            }
        }

        public Vector3D Col1
        {
            get
            {
                Vector3D vectord;
                vectord.X = this.M12;
                vectord.Y = this.M22;
                vectord.Z = this.M32;
                return vectord;
            }
        }

        public Vector3D Col2
        {
            get
            {
                Vector3D vectord;
                vectord.X = this.M13;
                vectord.Y = this.M23;
                vectord.Z = this.M33;
                return vectord;
            }
        }

        public Vector3D Down
        {
            get
            {
                Vector3D vectord;
                vectord.X = -this.M21;
                vectord.Y = -this.M22;
                vectord.Z = -this.M23;
                return vectord;
            }
            set
            {
                this.M21 = -value.X;
                this.M22 = -value.Y;
                this.M23 = -value.Z;
            }
        }

        public Vector3D Forward
        {
            get
            {
                Vector3D vectord;
                vectord.X = -this.M31;
                vectord.Y = -this.M32;
                vectord.Z = -this.M33;
                return vectord;
            }
            set
            {
                this.M31 = -value.X;
                this.M32 = -value.Y;
                this.M33 = -value.Z;
            }
        }

        public double this[int row, int column]
        {
            get
            {
                fixed (double* numRef = &this.M11)
                {
                    return numRef[((row * 4) + column) * 8];
                }
            }
            set
            {
                fixed (double* numRef = &this.M11)
                {
                    numRef[((row * 4) + column) * 8] = value;
                }
            }
        }

        public Vector3D Left
        {
            get
            {
                Vector3D vectord;
                vectord.X = -this.M11;
                vectord.Y = -this.M12;
                vectord.Z = -this.M13;
                return vectord;
            }
            set
            {
                this.M11 = -value.X;
                this.M12 = -value.Y;
                this.M13 = -value.Z;
            }
        }

        public Vector3D Right
        {
            get
            {
                Vector3D vectord;
                vectord.X = this.M11;
                vectord.Y = this.M12;
                vectord.Z = this.M13;
                return vectord;
            }
            set
            {
                this.M11 = value.X;
                this.M12 = value.Y;
                this.M13 = value.Z;
            }
        }

        public Matrix3x3 Rotation =>
            new Matrix3x3((float) this.M11, (float) this.M12, (float) this.M13, (float) this.M21, (float) this.M22, (float) this.M23, (float) this.M31, (float) this.M32, (float) this.M33);

        public Vector3D Scale =>
            new Vector3D(this.Right.Length(), this.Up.Length(), this.Forward.Length());

        public Vector3D Translation
        {
            get
            {
                Vector3D vectord;
                vectord.X = this.M41;
                vectord.Y = this.M42;
                vectord.Z = this.M43;
                return vectord;
            }
            set
            {
                this.M41 = value.X;
                this.M42 = value.Y;
                this.M43 = value.Z;
            }
        }

        public Vector3D Up
        {
            get
            {
                Vector3D vectord;
                vectord.X = this.M21;
                vectord.Y = this.M22;
                vectord.Z = this.M23;
                return vectord;
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
            [FixedBuffer(typeof(double), 0x10)]
            public <data>e__FixedBuffer1 data;
            [StructLayout(LayoutKind.Sequential, Size=0x80), CompilerGenerated, UnsafeValueType]
            public struct <data>e__FixedBuffer1
            {
                public double FixedElementField;
            }
        }
    }
}

