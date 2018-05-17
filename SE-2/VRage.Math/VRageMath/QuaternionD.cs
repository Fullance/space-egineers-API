namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct QuaternionD
    {
        public static QuaternionD Identity;
        [ProtoMember(20)]
        public double X;
        [ProtoMember(0x19)]
        public double Y;
        [ProtoMember(30)]
        public double Z;
        [ProtoMember(0x23)]
        public double W;
        static QuaternionD()
        {
            Identity = new QuaternionD(0.0, 0.0, 0.0, 1.0);
        }

        public QuaternionD(double x, double y, double z, double w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public QuaternionD(Vector3D vectorPart, double scalarPart)
        {
            this.X = vectorPart.X;
            this.Y = vectorPart.Y;
            this.Z = vectorPart.Z;
            this.W = scalarPart;
        }

        public static QuaternionD operator -(QuaternionD quaternion)
        {
            QuaternionD nd;
            nd.X = -quaternion.X;
            nd.Y = -quaternion.Y;
            nd.Z = -quaternion.Z;
            nd.W = -quaternion.W;
            return nd;
        }

        public static bool operator ==(QuaternionD quaternion1, QuaternionD quaternion2) => 
            ((((quaternion1.X == quaternion2.X) && (quaternion1.Y == quaternion2.Y)) && (quaternion1.Z == quaternion2.Z)) && (quaternion1.W == quaternion2.W));

        public static bool operator !=(QuaternionD quaternion1, QuaternionD quaternion2)
        {
            if (((quaternion1.X == quaternion2.X) && (quaternion1.Y == quaternion2.Y)) && (quaternion1.Z == quaternion2.Z))
            {
                return !(quaternion1.W == quaternion2.W);
            }
            return true;
        }

        public static QuaternionD operator +(QuaternionD quaternion1, QuaternionD quaternion2)
        {
            QuaternionD nd;
            nd.X = quaternion1.X + quaternion2.X;
            nd.Y = quaternion1.Y + quaternion2.Y;
            nd.Z = quaternion1.Z + quaternion2.Z;
            nd.W = quaternion1.W + quaternion2.W;
            return nd;
        }

        public static QuaternionD operator -(QuaternionD quaternion1, QuaternionD quaternion2)
        {
            QuaternionD nd;
            nd.X = quaternion1.X - quaternion2.X;
            nd.Y = quaternion1.Y - quaternion2.Y;
            nd.Z = quaternion1.Z - quaternion2.Z;
            nd.W = quaternion1.W - quaternion2.W;
            return nd;
        }

        public static QuaternionD operator *(QuaternionD quaternion1, QuaternionD quaternion2)
        {
            QuaternionD nd;
            double x = quaternion1.X;
            double y = quaternion1.Y;
            double z = quaternion1.Z;
            double w = quaternion1.W;
            double num5 = quaternion2.X;
            double num6 = quaternion2.Y;
            double num7 = quaternion2.Z;
            double num8 = quaternion2.W;
            double num9 = (y * num7) - (z * num6);
            double num10 = (z * num5) - (x * num7);
            double num11 = (x * num6) - (y * num5);
            double num12 = ((x * num5) + (y * num6)) + (z * num7);
            nd.X = ((x * num8) + (num5 * w)) + num9;
            nd.Y = ((y * num8) + (num6 * w)) + num10;
            nd.Z = ((z * num8) + (num7 * w)) + num11;
            nd.W = (w * num8) - num12;
            return nd;
        }

        public static QuaternionD operator *(QuaternionD quaternion1, double scaleFactor)
        {
            QuaternionD nd;
            nd.X = quaternion1.X * scaleFactor;
            nd.Y = quaternion1.Y * scaleFactor;
            nd.Z = quaternion1.Z * scaleFactor;
            nd.W = quaternion1.W * scaleFactor;
            return nd;
        }

        public static QuaternionD operator /(QuaternionD quaternion1, QuaternionD quaternion2)
        {
            QuaternionD nd;
            double x = quaternion1.X;
            double y = quaternion1.Y;
            double z = quaternion1.Z;
            double w = quaternion1.W;
            double num5 = 1.0 / ((((quaternion2.X * quaternion2.X) + (quaternion2.Y * quaternion2.Y)) + (quaternion2.Z * quaternion2.Z)) + (quaternion2.W * quaternion2.W));
            double num6 = -quaternion2.X * num5;
            double num7 = -quaternion2.Y * num5;
            double num8 = -quaternion2.Z * num5;
            double num9 = quaternion2.W * num5;
            double num10 = (y * num8) - (z * num7);
            double num11 = (z * num6) - (x * num8);
            double num12 = (x * num7) - (y * num6);
            double num13 = ((x * num6) + (y * num7)) + (z * num8);
            nd.X = ((x * num9) + (num6 * w)) + num10;
            nd.Y = ((y * num9) + (num7 * w)) + num11;
            nd.Z = ((z * num9) + (num8 * w)) + num12;
            nd.W = (w * num9) - num13;
            return nd;
        }

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format(currentCulture, "{{X:{0} Y:{1} Z:{2} W:{3}}}", new object[] { this.X.ToString(currentCulture), this.Y.ToString(currentCulture), this.Z.ToString(currentCulture), this.W.ToString(currentCulture) });
        }

        public bool Equals(QuaternionD other) => 
            ((((this.X == other.X) && (this.Y == other.Y)) && (this.Z == other.Z)) && (this.W == other.W));

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is QuaternionD)
            {
                flag = this.Equals((QuaternionD) obj);
            }
            return flag;
        }

        public override int GetHashCode() => 
            (((this.X.GetHashCode() + this.Y.GetHashCode()) + this.Z.GetHashCode()) + this.W.GetHashCode());

        public double LengthSquared() => 
            ((((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z)) + (this.W * this.W));

        public double Length() => 
            Math.Sqrt((((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z)) + (this.W * this.W));

        public void Normalize()
        {
            double num = 1.0 / Math.Sqrt((((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z)) + (this.W * this.W));
            this.X *= num;
            this.Y *= num;
            this.Z *= num;
            this.W *= num;
        }

        public void GetAxisAngle(out Vector3D axis, out double angle)
        {
            axis.X = this.X;
            axis.Y = this.Y;
            axis.Z = this.Z;
            double y = axis.Length();
            double w = this.W;
            if (y != 0.0)
            {
                axis.X /= y;
                axis.Y /= y;
                axis.Z /= y;
            }
            angle = Math.Atan2(y, w) * 2.0;
        }

        public static QuaternionD Normalize(QuaternionD quaternion)
        {
            QuaternionD nd;
            double num = 1.0 / Math.Sqrt((((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y)) + (quaternion.Z * quaternion.Z)) + (quaternion.W * quaternion.W));
            nd.X = quaternion.X * num;
            nd.Y = quaternion.Y * num;
            nd.Z = quaternion.Z * num;
            nd.W = quaternion.W * num;
            return nd;
        }

        public static void Normalize(ref QuaternionD quaternion, out QuaternionD result)
        {
            double num = 1.0 / Math.Sqrt((((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y)) + (quaternion.Z * quaternion.Z)) + (quaternion.W * quaternion.W));
            result.X = quaternion.X * num;
            result.Y = quaternion.Y * num;
            result.Z = quaternion.Z * num;
            result.W = quaternion.W * num;
        }

        public void Conjugate()
        {
            this.X = -this.X;
            this.Y = -this.Y;
            this.Z = -this.Z;
        }

        public static QuaternionD Conjugate(QuaternionD value)
        {
            QuaternionD nd;
            nd.X = -value.X;
            nd.Y = -value.Y;
            nd.Z = -value.Z;
            nd.W = value.W;
            return nd;
        }

        public static void Conjugate(ref QuaternionD value, out QuaternionD result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
            result.Z = -value.Z;
            result.W = value.W;
        }

        public static QuaternionD Inverse(QuaternionD quaternion)
        {
            QuaternionD nd;
            double num = 1.0 / ((((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y)) + (quaternion.Z * quaternion.Z)) + (quaternion.W * quaternion.W));
            nd.X = -quaternion.X * num;
            nd.Y = -quaternion.Y * num;
            nd.Z = -quaternion.Z * num;
            nd.W = quaternion.W * num;
            return nd;
        }

        public static void Inverse(ref QuaternionD quaternion, out QuaternionD result)
        {
            double num = 1.0 / ((((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y)) + (quaternion.Z * quaternion.Z)) + (quaternion.W * quaternion.W));
            result.X = -quaternion.X * num;
            result.Y = -quaternion.Y * num;
            result.Z = -quaternion.Z * num;
            result.W = quaternion.W * num;
        }

        public static QuaternionD CreateFromAxisAngle(Vector3D axis, double angle)
        {
            QuaternionD nd;
            double a = angle * 0.5;
            double num2 = Math.Sin(a);
            double num3 = Math.Cos(a);
            nd.X = axis.X * num2;
            nd.Y = axis.Y * num2;
            nd.Z = axis.Z * num2;
            nd.W = num3;
            return nd;
        }

        public static void CreateFromAxisAngle(ref Vector3D axis, double angle, out QuaternionD result)
        {
            double a = angle * 0.5;
            double num2 = Math.Sin(a);
            double num3 = Math.Cos(a);
            result.X = axis.X * num2;
            result.Y = axis.Y * num2;
            result.Z = axis.Z * num2;
            result.W = num3;
        }

        public static QuaternionD CreateFromYawPitchRoll(double yaw, double pitch, double roll)
        {
            QuaternionD nd;
            double a = roll * 0.5;
            double num2 = Math.Sin(a);
            double num3 = Math.Cos(a);
            double num4 = pitch * 0.5;
            double num5 = Math.Sin(num4);
            double num6 = Math.Cos(num4);
            double num7 = yaw * 0.5;
            double num8 = Math.Sin(num7);
            double num9 = Math.Cos(num7);
            nd.X = ((num9 * num5) * num3) + ((num8 * num6) * num2);
            nd.Y = ((num8 * num6) * num3) - ((num9 * num5) * num2);
            nd.Z = ((num9 * num6) * num2) - ((num8 * num5) * num3);
            nd.W = ((num9 * num6) * num3) + ((num8 * num5) * num2);
            return nd;
        }

        public static void CreateFromYawPitchRoll(double yaw, double pitch, double roll, out QuaternionD result)
        {
            double a = roll * 0.5;
            double num2 = Math.Sin(a);
            double num3 = Math.Cos(a);
            double num4 = pitch * 0.5;
            double num5 = Math.Sin(num4);
            double num6 = Math.Cos(num4);
            double num7 = yaw * 0.5;
            double num8 = Math.Sin(num7);
            double num9 = Math.Cos(num7);
            result.X = ((num9 * num5) * num3) + ((num8 * num6) * num2);
            result.Y = ((num8 * num6) * num3) - ((num9 * num5) * num2);
            result.Z = ((num9 * num6) * num2) - ((num8 * num5) * num3);
            result.W = ((num9 * num6) * num3) + ((num8 * num5) * num2);
        }

        public static QuaternionD CreateFromForwardUp(Vector3D forward, Vector3D up)
        {
            Vector3D vectord = -forward;
            Vector3D vectord2 = Vector3D.Cross(up, vectord);
            Vector3D vectord3 = Vector3D.Cross(vectord, vectord2);
            double x = vectord2.X;
            double y = vectord2.Y;
            double z = vectord2.Z;
            double num4 = vectord3.X;
            double num5 = vectord3.Y;
            double num6 = vectord3.Z;
            double num7 = vectord.X;
            double num8 = vectord.Y;
            double num9 = vectord.Z;
            double num10 = (x + num5) + num9;
            QuaternionD nd = new QuaternionD();
            if (num10 > 0.0)
            {
                double num11 = Math.Sqrt(num10 + 1.0);
                nd.W = num11 * 0.5;
                num11 = 0.5 / num11;
                nd.X = (num6 - num8) * num11;
                nd.Y = (num7 - z) * num11;
                nd.Z = (y - num4) * num11;
                return nd;
            }
            if ((x >= num5) && (x >= num9))
            {
                double num12 = Math.Sqrt(((1.0 + x) - num5) - num9);
                double num13 = 0.5 / num12;
                nd.X = 0.5 * num12;
                nd.Y = (y + num4) * num13;
                nd.Z = (z + num7) * num13;
                nd.W = (num6 - num8) * num13;
                return nd;
            }
            if (num5 > num9)
            {
                double num14 = Math.Sqrt(((1.0 + num5) - x) - num9);
                double num15 = 0.5 / num14;
                nd.X = (num4 + y) * num15;
                nd.Y = 0.5 * num14;
                nd.Z = (num8 + num6) * num15;
                nd.W = (num7 - z) * num15;
                return nd;
            }
            double num16 = Math.Sqrt(((1.0 + num9) - x) - num5);
            double num17 = 0.5 / num16;
            nd.X = (num7 + z) * num17;
            nd.Y = (num8 + num6) * num17;
            nd.Z = 0.5 * num16;
            nd.W = (y - num4) * num17;
            return nd;
        }

        public static QuaternionD CreateFromRotationMatrix(MatrixD matrix)
        {
            double num = (matrix.M11 + matrix.M22) + matrix.M33;
            QuaternionD nd = new QuaternionD();
            if (num > 0.0)
            {
                double num2 = Math.Sqrt(num + 1.0);
                nd.W = num2 * 0.5;
                double num3 = 0.5 / num2;
                nd.X = (matrix.M23 - matrix.M32) * num3;
                nd.Y = (matrix.M31 - matrix.M13) * num3;
                nd.Z = (matrix.M12 - matrix.M21) * num3;
                return nd;
            }
            if ((matrix.M11 >= matrix.M22) && (matrix.M11 >= matrix.M33))
            {
                double num4 = Math.Sqrt(((1.0 + matrix.M11) - matrix.M22) - matrix.M33);
                double num5 = 0.5 / num4;
                nd.X = 0.5 * num4;
                nd.Y = (matrix.M12 + matrix.M21) * num5;
                nd.Z = (matrix.M13 + matrix.M31) * num5;
                nd.W = (matrix.M23 - matrix.M32) * num5;
                return nd;
            }
            if (matrix.M22 > matrix.M33)
            {
                double num6 = Math.Sqrt(((1.0 + matrix.M22) - matrix.M11) - matrix.M33);
                double num7 = 0.5 / num6;
                nd.X = (matrix.M21 + matrix.M12) * num7;
                nd.Y = 0.5 * num6;
                nd.Z = (matrix.M32 + matrix.M23) * num7;
                nd.W = (matrix.M31 - matrix.M13) * num7;
                return nd;
            }
            double num8 = Math.Sqrt(((1.0 + matrix.M33) - matrix.M11) - matrix.M22);
            double num9 = 0.5 / num8;
            nd.X = (matrix.M31 + matrix.M13) * num9;
            nd.Y = (matrix.M32 + matrix.M23) * num9;
            nd.Z = 0.5 * num8;
            nd.W = (matrix.M12 - matrix.M21) * num9;
            return nd;
        }

        public static void CreateFromRotationMatrix(ref MatrixD matrix, out QuaternionD result)
        {
            double num = (matrix.M11 + matrix.M22) + matrix.M33;
            if (num > 0.0)
            {
                double num2 = Math.Sqrt(num + 1.0);
                result.W = num2 * 0.5;
                double num3 = 0.5 / num2;
                result.X = (matrix.M23 - matrix.M32) * num3;
                result.Y = (matrix.M31 - matrix.M13) * num3;
                result.Z = (matrix.M12 - matrix.M21) * num3;
            }
            else if ((matrix.M11 >= matrix.M22) && (matrix.M11 >= matrix.M33))
            {
                double num4 = Math.Sqrt(((1.0 + matrix.M11) - matrix.M22) - matrix.M33);
                double num5 = 0.5 / num4;
                result.X = 0.5 * num4;
                result.Y = (matrix.M12 + matrix.M21) * num5;
                result.Z = (matrix.M13 + matrix.M31) * num5;
                result.W = (matrix.M23 - matrix.M32) * num5;
            }
            else if (matrix.M22 > matrix.M33)
            {
                double num6 = Math.Sqrt(((1.0 + matrix.M22) - matrix.M11) - matrix.M33);
                double num7 = 0.5 / num6;
                result.X = (matrix.M21 + matrix.M12) * num7;
                result.Y = 0.5 * num6;
                result.Z = (matrix.M32 + matrix.M23) * num7;
                result.W = (matrix.M31 - matrix.M13) * num7;
            }
            else
            {
                double num8 = Math.Sqrt(((1.0 + matrix.M33) - matrix.M11) - matrix.M22);
                double num9 = 0.5 / num8;
                result.X = (matrix.M31 + matrix.M13) * num9;
                result.Y = (matrix.M32 + matrix.M23) * num9;
                result.Z = 0.5 * num8;
                result.W = (matrix.M12 - matrix.M21) * num9;
            }
        }

        public static double Dot(QuaternionD quaternion1, QuaternionD quaternion2) => 
            ((((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W));

        public static void Dot(ref QuaternionD quaternion1, ref QuaternionD quaternion2, out double result)
        {
            result = (((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W);
        }

        public static QuaternionD Slerp(QuaternionD quaternion1, QuaternionD quaternion2, double amount)
        {
            double num3;
            double num4;
            QuaternionD nd;
            double num = amount;
            double d = (((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W);
            bool flag = false;
            if (d < 0.0)
            {
                flag = true;
                d = -d;
            }
            if (d > 0.999998986721039)
            {
                num3 = 1.0 - num;
                num4 = flag ? -num : num;
            }
            else
            {
                double a = Math.Acos(d);
                double num6 = 1.0 / Math.Sin(a);
                num3 = Math.Sin((1.0 - num) * a) * num6;
                num4 = flag ? (-Math.Sin(num * a) * num6) : (Math.Sin(num * a) * num6);
            }
            nd.X = (num3 * quaternion1.X) + (num4 * quaternion2.X);
            nd.Y = (num3 * quaternion1.Y) + (num4 * quaternion2.Y);
            nd.Z = (num3 * quaternion1.Z) + (num4 * quaternion2.Z);
            nd.W = (num3 * quaternion1.W) + (num4 * quaternion2.W);
            return nd;
        }

        public static void Slerp(ref QuaternionD quaternion1, ref QuaternionD quaternion2, double amount, out QuaternionD result)
        {
            double num3;
            double num4;
            double num = amount;
            double d = (((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W);
            bool flag = false;
            if (d < 0.0)
            {
                flag = true;
                d = -d;
            }
            if (d > 0.999998986721039)
            {
                num3 = 1.0 - num;
                num4 = flag ? -num : num;
            }
            else
            {
                double a = Math.Acos(d);
                double num6 = 1.0 / Math.Sin(a);
                num3 = Math.Sin((1.0 - num) * a) * num6;
                num4 = flag ? (-Math.Sin(num * a) * num6) : (Math.Sin(num * a) * num6);
            }
            result.X = (num3 * quaternion1.X) + (num4 * quaternion2.X);
            result.Y = (num3 * quaternion1.Y) + (num4 * quaternion2.Y);
            result.Z = (num3 * quaternion1.Z) + (num4 * quaternion2.Z);
            result.W = (num3 * quaternion1.W) + (num4 * quaternion2.W);
        }

        public static QuaternionD Lerp(QuaternionD quaternion1, QuaternionD quaternion2, double amount)
        {
            double num = amount;
            double num2 = 1.0 - num;
            QuaternionD nd = new QuaternionD();
            if (((((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W)) >= 0.0)
            {
                nd.X = (num2 * quaternion1.X) + (num * quaternion2.X);
                nd.Y = (num2 * quaternion1.Y) + (num * quaternion2.Y);
                nd.Z = (num2 * quaternion1.Z) + (num * quaternion2.Z);
                nd.W = (num2 * quaternion1.W) + (num * quaternion2.W);
            }
            else
            {
                nd.X = (num2 * quaternion1.X) - (num * quaternion2.X);
                nd.Y = (num2 * quaternion1.Y) - (num * quaternion2.Y);
                nd.Z = (num2 * quaternion1.Z) - (num * quaternion2.Z);
                nd.W = (num2 * quaternion1.W) - (num * quaternion2.W);
            }
            double num3 = 1.0 / Math.Sqrt((((nd.X * nd.X) + (nd.Y * nd.Y)) + (nd.Z * nd.Z)) + (nd.W * nd.W));
            nd.X *= num3;
            nd.Y *= num3;
            nd.Z *= num3;
            nd.W *= num3;
            return nd;
        }

        public static void Lerp(ref QuaternionD quaternion1, ref QuaternionD quaternion2, double amount, out QuaternionD result)
        {
            double num = amount;
            double num2 = 1.0 - num;
            if (((((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W)) >= 0.0)
            {
                result.X = (num2 * quaternion1.X) + (num * quaternion2.X);
                result.Y = (num2 * quaternion1.Y) + (num * quaternion2.Y);
                result.Z = (num2 * quaternion1.Z) + (num * quaternion2.Z);
                result.W = (num2 * quaternion1.W) + (num * quaternion2.W);
            }
            else
            {
                result.X = (num2 * quaternion1.X) - (num * quaternion2.X);
                result.Y = (num2 * quaternion1.Y) - (num * quaternion2.Y);
                result.Z = (num2 * quaternion1.Z) - (num * quaternion2.Z);
                result.W = (num2 * quaternion1.W) - (num * quaternion2.W);
            }
            double num3 = 1.0 / Math.Sqrt((((result.X * result.X) + (result.Y * result.Y)) + (result.Z * result.Z)) + (result.W * result.W));
            result.X *= num3;
            result.Y *= num3;
            result.Z *= num3;
            result.W *= num3;
        }

        public static QuaternionD Concatenate(QuaternionD value1, QuaternionD value2)
        {
            QuaternionD nd;
            double x = value2.X;
            double y = value2.Y;
            double z = value2.Z;
            double w = value2.W;
            double num5 = value1.X;
            double num6 = value1.Y;
            double num7 = value1.Z;
            double num8 = value1.W;
            double num9 = (y * num7) - (z * num6);
            double num10 = (z * num5) - (x * num7);
            double num11 = (x * num6) - (y * num5);
            double num12 = ((x * num5) + (y * num6)) + (z * num7);
            nd.X = ((x * num8) + (num5 * w)) + num9;
            nd.Y = ((y * num8) + (num6 * w)) + num10;
            nd.Z = ((z * num8) + (num7 * w)) + num11;
            nd.W = (w * num8) - num12;
            return nd;
        }

        public static void Concatenate(ref QuaternionD value1, ref QuaternionD value2, out QuaternionD result)
        {
            double x = value2.X;
            double y = value2.Y;
            double z = value2.Z;
            double w = value2.W;
            double num5 = value1.X;
            double num6 = value1.Y;
            double num7 = value1.Z;
            double num8 = value1.W;
            double num9 = (y * num7) - (z * num6);
            double num10 = (z * num5) - (x * num7);
            double num11 = (x * num6) - (y * num5);
            double num12 = ((x * num5) + (y * num6)) + (z * num7);
            result.X = ((x * num8) + (num5 * w)) + num9;
            result.Y = ((y * num8) + (num6 * w)) + num10;
            result.Z = ((z * num8) + (num7 * w)) + num11;
            result.W = (w * num8) - num12;
        }

        public static QuaternionD Negate(QuaternionD quaternion)
        {
            QuaternionD nd;
            nd.X = -quaternion.X;
            nd.Y = -quaternion.Y;
            nd.Z = -quaternion.Z;
            nd.W = -quaternion.W;
            return nd;
        }

        public static void Negate(ref QuaternionD quaternion, out QuaternionD result)
        {
            result.X = -quaternion.X;
            result.Y = -quaternion.Y;
            result.Z = -quaternion.Z;
            result.W = -quaternion.W;
        }

        public static QuaternionD Add(QuaternionD quaternion1, QuaternionD quaternion2)
        {
            QuaternionD nd;
            nd.X = quaternion1.X + quaternion2.X;
            nd.Y = quaternion1.Y + quaternion2.Y;
            nd.Z = quaternion1.Z + quaternion2.Z;
            nd.W = quaternion1.W + quaternion2.W;
            return nd;
        }

        public static void Add(ref QuaternionD quaternion1, ref QuaternionD quaternion2, out QuaternionD result)
        {
            result.X = quaternion1.X + quaternion2.X;
            result.Y = quaternion1.Y + quaternion2.Y;
            result.Z = quaternion1.Z + quaternion2.Z;
            result.W = quaternion1.W + quaternion2.W;
        }

        public static QuaternionD Subtract(QuaternionD quaternion1, QuaternionD quaternion2)
        {
            QuaternionD nd;
            nd.X = quaternion1.X - quaternion2.X;
            nd.Y = quaternion1.Y - quaternion2.Y;
            nd.Z = quaternion1.Z - quaternion2.Z;
            nd.W = quaternion1.W - quaternion2.W;
            return nd;
        }

        public static void Subtract(ref QuaternionD quaternion1, ref QuaternionD quaternion2, out QuaternionD result)
        {
            result.X = quaternion1.X - quaternion2.X;
            result.Y = quaternion1.Y - quaternion2.Y;
            result.Z = quaternion1.Z - quaternion2.Z;
            result.W = quaternion1.W - quaternion2.W;
        }

        public static QuaternionD Multiply(QuaternionD quaternion1, QuaternionD quaternion2)
        {
            QuaternionD nd;
            double x = quaternion1.X;
            double y = quaternion1.Y;
            double z = quaternion1.Z;
            double w = quaternion1.W;
            double num5 = quaternion2.X;
            double num6 = quaternion2.Y;
            double num7 = quaternion2.Z;
            double num8 = quaternion2.W;
            double num9 = (y * num7) - (z * num6);
            double num10 = (z * num5) - (x * num7);
            double num11 = (x * num6) - (y * num5);
            double num12 = ((x * num5) + (y * num6)) + (z * num7);
            nd.X = ((x * num8) + (num5 * w)) + num9;
            nd.Y = ((y * num8) + (num6 * w)) + num10;
            nd.Z = ((z * num8) + (num7 * w)) + num11;
            nd.W = (w * num8) - num12;
            return nd;
        }

        public static void Multiply(ref QuaternionD quaternion1, ref QuaternionD quaternion2, out QuaternionD result)
        {
            double x = quaternion1.X;
            double y = quaternion1.Y;
            double z = quaternion1.Z;
            double w = quaternion1.W;
            double num5 = quaternion2.X;
            double num6 = quaternion2.Y;
            double num7 = quaternion2.Z;
            double num8 = quaternion2.W;
            double num9 = (y * num7) - (z * num6);
            double num10 = (z * num5) - (x * num7);
            double num11 = (x * num6) - (y * num5);
            double num12 = ((x * num5) + (y * num6)) + (z * num7);
            result.X = ((x * num8) + (num5 * w)) + num9;
            result.Y = ((y * num8) + (num6 * w)) + num10;
            result.Z = ((z * num8) + (num7 * w)) + num11;
            result.W = (w * num8) - num12;
        }

        public static QuaternionD Multiply(QuaternionD quaternion1, double scaleFactor)
        {
            QuaternionD nd;
            nd.X = quaternion1.X * scaleFactor;
            nd.Y = quaternion1.Y * scaleFactor;
            nd.Z = quaternion1.Z * scaleFactor;
            nd.W = quaternion1.W * scaleFactor;
            return nd;
        }

        public static void Multiply(ref QuaternionD quaternion1, double scaleFactor, out QuaternionD result)
        {
            result.X = quaternion1.X * scaleFactor;
            result.Y = quaternion1.Y * scaleFactor;
            result.Z = quaternion1.Z * scaleFactor;
            result.W = quaternion1.W * scaleFactor;
        }

        public static QuaternionD Divide(QuaternionD quaternion1, QuaternionD quaternion2)
        {
            QuaternionD nd;
            double x = quaternion1.X;
            double y = quaternion1.Y;
            double z = quaternion1.Z;
            double w = quaternion1.W;
            double num5 = 1.0 / ((((quaternion2.X * quaternion2.X) + (quaternion2.Y * quaternion2.Y)) + (quaternion2.Z * quaternion2.Z)) + (quaternion2.W * quaternion2.W));
            double num6 = -quaternion2.X * num5;
            double num7 = -quaternion2.Y * num5;
            double num8 = -quaternion2.Z * num5;
            double num9 = quaternion2.W * num5;
            double num10 = (y * num8) - (z * num7);
            double num11 = (z * num6) - (x * num8);
            double num12 = (x * num7) - (y * num6);
            double num13 = ((x * num6) + (y * num7)) + (z * num8);
            nd.X = ((x * num9) + (num6 * w)) + num10;
            nd.Y = ((y * num9) + (num7 * w)) + num11;
            nd.Z = ((z * num9) + (num8 * w)) + num12;
            nd.W = (w * num9) - num13;
            return nd;
        }

        public static void Divide(ref QuaternionD quaternion1, ref QuaternionD quaternion2, out QuaternionD result)
        {
            double x = quaternion1.X;
            double y = quaternion1.Y;
            double z = quaternion1.Z;
            double w = quaternion1.W;
            double num5 = 1.0 / ((((quaternion2.X * quaternion2.X) + (quaternion2.Y * quaternion2.Y)) + (quaternion2.Z * quaternion2.Z)) + (quaternion2.W * quaternion2.W));
            double num6 = -quaternion2.X * num5;
            double num7 = -quaternion2.Y * num5;
            double num8 = -quaternion2.Z * num5;
            double num9 = quaternion2.W * num5;
            double num10 = (y * num8) - (z * num7);
            double num11 = (z * num6) - (x * num8);
            double num12 = (x * num7) - (y * num6);
            double num13 = ((x * num6) + (y * num7)) + (z * num8);
            result.X = ((x * num9) + (num6 * w)) + num10;
            result.Y = ((y * num9) + (num7 * w)) + num11;
            result.Z = ((z * num9) + (num8 * w)) + num12;
            result.W = (w * num9) - num13;
        }

        public static QuaternionD FromVector4(Vector4D v) => 
            new QuaternionD(v.X, v.Y, v.Z, v.W);

        public Vector4D ToVector4() => 
            new Vector4D(this.X, this.Y, this.Z, this.W);

        public static bool IsZero(QuaternionD value) => 
            IsZero(value, 0.0001);

        public static bool IsZero(QuaternionD value, double epsilon) => 
            ((((Math.Abs(value.X) < epsilon) && (Math.Abs(value.Y) < epsilon)) && (Math.Abs(value.Z) < epsilon)) && (Math.Abs(value.W) < epsilon));

        public static void CreateFromTwoVectors(ref Vector3D firstVector, ref Vector3D secondVector, out QuaternionD result)
        {
            Vector3D vectord;
            Vector3D.Cross(ref firstVector, ref secondVector, out vectord);
            result = new QuaternionD(vectord.X, vectord.Y, vectord.Z, (double) Vector3.Dot((Vector3) firstVector, (Vector3) secondVector));
            result.W += result.Length();
            result.Normalize();
        }

        public static QuaternionD CreateFromTwoVectors(Vector3D firstVector, Vector3D secondVector)
        {
            QuaternionD nd;
            CreateFromTwoVectors(ref firstVector, ref secondVector, out nd);
            return nd;
        }
    }
}

