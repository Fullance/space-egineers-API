namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct Quaternion : IEquatable<Quaternion>
    {
        public static Quaternion Identity;
        public static Quaternion Zero;
        [ProtoMember(0x12)]
        public float X;
        [ProtoMember(0x17)]
        public float Y;
        [ProtoMember(0x1c)]
        public float Z;
        [ProtoMember(0x21)]
        public float W;
        public Vector3 Forward
        {
            get
            {
                Vector3 vector;
                GetForward(ref this, out vector);
                return vector;
            }
        }
        public Vector3 Right
        {
            get
            {
                Vector3 vector;
                GetRight(ref this, out vector);
                return vector;
            }
        }
        public Vector3 Up
        {
            get
            {
                Vector3 vector;
                GetUp(ref this, out vector);
                return vector;
            }
        }
        static Quaternion()
        {
            Identity = new Quaternion(0f, 0f, 0f, 1f);
            Zero = new Quaternion(0f, 0f, 0f, 0f);
        }

        public Quaternion(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public Quaternion(Vector3 vectorPart, float scalarPart)
        {
            this.X = vectorPart.X;
            this.Y = vectorPart.Y;
            this.Z = vectorPart.Z;
            this.W = scalarPart;
        }

        public static Quaternion operator -(Quaternion quaternion)
        {
            Quaternion quaternion2;
            quaternion2.X = -quaternion.X;
            quaternion2.Y = -quaternion.Y;
            quaternion2.Z = -quaternion.Z;
            quaternion2.W = -quaternion.W;
            return quaternion2;
        }

        public static bool operator ==(Quaternion quaternion1, Quaternion quaternion2) => 
            ((((quaternion1.X == quaternion2.X) && (quaternion1.Y == quaternion2.Y)) && (quaternion1.Z == quaternion2.Z)) && (quaternion1.W == quaternion2.W));

        public static bool operator !=(Quaternion quaternion1, Quaternion quaternion2)
        {
            if (((quaternion1.X == quaternion2.X) && (quaternion1.Y == quaternion2.Y)) && (quaternion1.Z == quaternion2.Z))
            {
                return !(quaternion1.W == quaternion2.W);
            }
            return true;
        }

        public static Quaternion operator +(Quaternion quaternion1, Quaternion quaternion2)
        {
            Quaternion quaternion;
            quaternion.X = quaternion1.X + quaternion2.X;
            quaternion.Y = quaternion1.Y + quaternion2.Y;
            quaternion.Z = quaternion1.Z + quaternion2.Z;
            quaternion.W = quaternion1.W + quaternion2.W;
            return quaternion;
        }

        public static Quaternion operator -(Quaternion quaternion1, Quaternion quaternion2)
        {
            Quaternion quaternion;
            quaternion.X = quaternion1.X - quaternion2.X;
            quaternion.Y = quaternion1.Y - quaternion2.Y;
            quaternion.Z = quaternion1.Z - quaternion2.Z;
            quaternion.W = quaternion1.W - quaternion2.W;
            return quaternion;
        }

        public static Quaternion operator *(Quaternion quaternion1, Quaternion quaternion2)
        {
            Quaternion quaternion;
            float x = quaternion1.X;
            float y = quaternion1.Y;
            float z = quaternion1.Z;
            float w = quaternion1.W;
            float num5 = quaternion2.X;
            float num6 = quaternion2.Y;
            float num7 = quaternion2.Z;
            float num8 = quaternion2.W;
            float num9 = (y * num7) - (z * num6);
            float num10 = (z * num5) - (x * num7);
            float num11 = (x * num6) - (y * num5);
            float num12 = ((x * num5) + (y * num6)) + (z * num7);
            quaternion.X = ((x * num8) + (num5 * w)) + num9;
            quaternion.Y = ((y * num8) + (num6 * w)) + num10;
            quaternion.Z = ((z * num8) + (num7 * w)) + num11;
            quaternion.W = (w * num8) - num12;
            return quaternion;
        }

        public static Quaternion operator *(Quaternion quaternion1, float scaleFactor)
        {
            Quaternion quaternion;
            quaternion.X = quaternion1.X * scaleFactor;
            quaternion.Y = quaternion1.Y * scaleFactor;
            quaternion.Z = quaternion1.Z * scaleFactor;
            quaternion.W = quaternion1.W * scaleFactor;
            return quaternion;
        }

        public static Quaternion operator /(Quaternion quaternion1, Quaternion quaternion2)
        {
            Quaternion quaternion;
            float x = quaternion1.X;
            float y = quaternion1.Y;
            float z = quaternion1.Z;
            float w = quaternion1.W;
            float num5 = 1f / ((((quaternion2.X * quaternion2.X) + (quaternion2.Y * quaternion2.Y)) + (quaternion2.Z * quaternion2.Z)) + (quaternion2.W * quaternion2.W));
            float num6 = -quaternion2.X * num5;
            float num7 = -quaternion2.Y * num5;
            float num8 = -quaternion2.Z * num5;
            float num9 = quaternion2.W * num5;
            float num10 = (y * num8) - (z * num7);
            float num11 = (z * num6) - (x * num8);
            float num12 = (x * num7) - (y * num6);
            float num13 = ((x * num6) + (y * num7)) + (z * num8);
            quaternion.X = ((x * num9) + (num6 * w)) + num10;
            quaternion.Y = ((y * num9) + (num7 * w)) + num11;
            quaternion.Z = ((z * num9) + (num8 * w)) + num12;
            quaternion.W = (w * num9) - num13;
            return quaternion;
        }

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format(currentCulture, "{{X:{0} Y:{1} Z:{2} W:{3}}}", new object[] { this.X.ToString(currentCulture), this.Y.ToString(currentCulture), this.Z.ToString(currentCulture), this.W.ToString(currentCulture) });
        }

        public string ToString(string format)
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format(currentCulture, "{{X:{0} Y:{1} Z:{2} W:{3}}}", new object[] { this.X.ToString(format, currentCulture), this.Y.ToString(format, currentCulture), this.Z.ToString(format, currentCulture), this.W.ToString(format, currentCulture) });
        }

        public string ToStringAxisAngle(string format = "G")
        {
            Vector3 vector;
            float num;
            this.GetAxisAngle(out vector, out num);
            return string.Format(CultureInfo.CurrentCulture, "{{{0}/{1}}}", vector.ToString(format), num.ToString(format));
        }

        public bool Equals(Quaternion other) => 
            ((((this.X == other.X) && (this.Y == other.Y)) && (this.Z == other.Z)) && (this.W == other.W));

        public bool Equals(Quaternion value, float epsilon) => 
            ((((Math.Abs((float) (this.X - value.X)) < epsilon) && (Math.Abs((float) (this.Y - value.Y)) < epsilon)) && (Math.Abs((float) (this.Z - value.Z)) < epsilon)) && (Math.Abs((float) (this.W - value.W)) < epsilon));

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is Quaternion)
            {
                flag = this.Equals((Quaternion) obj);
            }
            return flag;
        }

        public override int GetHashCode() => 
            (((this.X.GetHashCode() + this.Y.GetHashCode()) + this.Z.GetHashCode()) + this.W.GetHashCode());

        public float LengthSquared() => 
            ((((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z)) + (this.W * this.W));

        public float Length() => 
            ((float) Math.Sqrt((((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z)) + (this.W * this.W)));

        public void Normalize()
        {
            float num = 1f / ((float) Math.Sqrt((((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z)) + (this.W * this.W)));
            this.X *= num;
            this.Y *= num;
            this.Z *= num;
            this.W *= num;
        }

        public void GetAxisAngle(out Vector3 axis, out float angle)
        {
            axis.X = this.X;
            axis.Y = this.Y;
            axis.Z = this.Z;
            float num = axis.Length();
            float w = this.W;
            if (num != 0f)
            {
                axis.X /= num;
                axis.Y /= num;
                axis.Z /= num;
            }
            angle = ((float) Math.Atan2((double) num, (double) w)) * 2f;
        }

        public static Quaternion Normalize(Quaternion quaternion)
        {
            Quaternion quaternion2;
            float num = 1f / ((float) Math.Sqrt((((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y)) + (quaternion.Z * quaternion.Z)) + (quaternion.W * quaternion.W)));
            quaternion2.X = quaternion.X * num;
            quaternion2.Y = quaternion.Y * num;
            quaternion2.Z = quaternion.Z * num;
            quaternion2.W = quaternion.W * num;
            return quaternion2;
        }

        public static void Normalize(ref Quaternion quaternion, out Quaternion result)
        {
            float num = 1f / ((float) Math.Sqrt((((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y)) + (quaternion.Z * quaternion.Z)) + (quaternion.W * quaternion.W)));
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

        public static Quaternion Conjugate(Quaternion value)
        {
            Quaternion quaternion;
            quaternion.X = -value.X;
            quaternion.Y = -value.Y;
            quaternion.Z = -value.Z;
            quaternion.W = value.W;
            return quaternion;
        }

        public static void Conjugate(ref Quaternion value, out Quaternion result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
            result.Z = -value.Z;
            result.W = value.W;
        }

        public static Quaternion Inverse(Quaternion quaternion)
        {
            Quaternion quaternion2;
            float num = 1f / ((((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y)) + (quaternion.Z * quaternion.Z)) + (quaternion.W * quaternion.W));
            quaternion2.X = -quaternion.X * num;
            quaternion2.Y = -quaternion.Y * num;
            quaternion2.Z = -quaternion.Z * num;
            quaternion2.W = quaternion.W * num;
            return quaternion2;
        }

        public static void Inverse(ref Quaternion quaternion, out Quaternion result)
        {
            float num = 1f / ((((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y)) + (quaternion.Z * quaternion.Z)) + (quaternion.W * quaternion.W));
            result.X = -quaternion.X * num;
            result.Y = -quaternion.Y * num;
            result.Z = -quaternion.Z * num;
            result.W = quaternion.W * num;
        }

        public static Quaternion CreateFromAxisAngle(Vector3 axis, float angle)
        {
            Quaternion quaternion;
            float num = angle * 0.5f;
            float num2 = (float) Math.Sin((double) num);
            float num3 = (float) Math.Cos((double) num);
            quaternion.X = axis.X * num2;
            quaternion.Y = axis.Y * num2;
            quaternion.Z = axis.Z * num2;
            quaternion.W = num3;
            return quaternion;
        }

        public static void CreateFromAxisAngle(ref Vector3 axis, float angle, out Quaternion result)
        {
            float num = angle * 0.5f;
            float num2 = (float) Math.Sin((double) num);
            float num3 = (float) Math.Cos((double) num);
            result.X = axis.X * num2;
            result.Y = axis.Y * num2;
            result.Z = axis.Z * num2;
            result.W = num3;
        }

        public static Quaternion CreateFromYawPitchRoll(float yaw, float pitch, float roll)
        {
            Quaternion quaternion;
            float num = roll * 0.5f;
            float num2 = (float) Math.Sin((double) num);
            float num3 = (float) Math.Cos((double) num);
            float num4 = pitch * 0.5f;
            float num5 = (float) Math.Sin((double) num4);
            float num6 = (float) Math.Cos((double) num4);
            float num7 = yaw * 0.5f;
            float num8 = (float) Math.Sin((double) num7);
            float num9 = (float) Math.Cos((double) num7);
            quaternion.X = ((num9 * num5) * num3) + ((num8 * num6) * num2);
            quaternion.Y = ((num8 * num6) * num3) - ((num9 * num5) * num2);
            quaternion.Z = ((num9 * num6) * num2) - ((num8 * num5) * num3);
            quaternion.W = ((num9 * num6) * num3) + ((num8 * num5) * num2);
            return quaternion;
        }

        public static void CreateFromYawPitchRoll(float yaw, float pitch, float roll, out Quaternion result)
        {
            float num = roll * 0.5f;
            float num2 = (float) Math.Sin((double) num);
            float num3 = (float) Math.Cos((double) num);
            float num4 = pitch * 0.5f;
            float num5 = (float) Math.Sin((double) num4);
            float num6 = (float) Math.Cos((double) num4);
            float num7 = yaw * 0.5f;
            float num8 = (float) Math.Sin((double) num7);
            float num9 = (float) Math.Cos((double) num7);
            result.X = ((num9 * num5) * num3) + ((num8 * num6) * num2);
            result.Y = ((num8 * num6) * num3) - ((num9 * num5) * num2);
            result.Z = ((num9 * num6) * num2) - ((num8 * num5) * num3);
            result.W = ((num9 * num6) * num3) + ((num8 * num5) * num2);
        }

        public static Quaternion CreateFromForwardUp(Vector3 forward, Vector3 up)
        {
            Vector3 vector = -forward;
            Vector3 vector2 = Vector3.Cross(up, vector);
            Vector3 vector3 = Vector3.Cross(vector, vector2);
            float x = vector2.X;
            float y = vector2.Y;
            float z = vector2.Z;
            float num4 = vector3.X;
            float num5 = vector3.Y;
            float num6 = vector3.Z;
            float num7 = vector.X;
            float num8 = vector.Y;
            float num9 = vector.Z;
            float num10 = (x + num5) + num9;
            Quaternion quaternion = new Quaternion();
            if (num10 > 0f)
            {
                float num11 = (float) Math.Sqrt((double) (num10 + 1f));
                quaternion.W = num11 * 0.5f;
                num11 = 0.5f / num11;
                quaternion.X = (num6 - num8) * num11;
                quaternion.Y = (num7 - z) * num11;
                quaternion.Z = (y - num4) * num11;
                return quaternion;
            }
            if ((x >= num5) && (x >= num9))
            {
                float num12 = (float) Math.Sqrt((double) (((1f + x) - num5) - num9));
                float num13 = 0.5f / num12;
                quaternion.X = 0.5f * num12;
                quaternion.Y = (y + num4) * num13;
                quaternion.Z = (z + num7) * num13;
                quaternion.W = (num6 - num8) * num13;
                return quaternion;
            }
            if (num5 > num9)
            {
                float num14 = (float) Math.Sqrt((double) (((1f + num5) - x) - num9));
                float num15 = 0.5f / num14;
                quaternion.X = (num4 + y) * num15;
                quaternion.Y = 0.5f * num14;
                quaternion.Z = (num8 + num6) * num15;
                quaternion.W = (num7 - z) * num15;
                return quaternion;
            }
            float num16 = (float) Math.Sqrt((double) (((1f + num9) - x) - num5));
            float num17 = 0.5f / num16;
            quaternion.X = (num7 + z) * num17;
            quaternion.Y = (num8 + num6) * num17;
            quaternion.Z = 0.5f * num16;
            quaternion.W = (y - num4) * num17;
            return quaternion;
        }

        public static Quaternion CreateFromRotationMatrix(MatrixD matrix) => 
            CreateFromRotationMatrix((Matrix) matrix);

        public static Quaternion CreateFromRotationMatrix(Matrix matrix)
        {
            float num = (matrix.M11 + matrix.M22) + matrix.M33;
            Quaternion quaternion = new Quaternion();
            if (num > 0.0)
            {
                float num2 = (float) Math.Sqrt(num + 1.0);
                quaternion.W = num2 * 0.5f;
                float num3 = 0.5f / num2;
                quaternion.X = (matrix.M23 - matrix.M32) * num3;
                quaternion.Y = (matrix.M31 - matrix.M13) * num3;
                quaternion.Z = (matrix.M12 - matrix.M21) * num3;
                return quaternion;
            }
            if ((matrix.M11 >= matrix.M22) && (matrix.M11 >= matrix.M33))
            {
                float num4 = (float) Math.Sqrt(((1.0 + matrix.M11) - matrix.M22) - matrix.M33);
                float num5 = 0.5f / num4;
                quaternion.X = 0.5f * num4;
                quaternion.Y = (matrix.M12 + matrix.M21) * num5;
                quaternion.Z = (matrix.M13 + matrix.M31) * num5;
                quaternion.W = (matrix.M23 - matrix.M32) * num5;
                return quaternion;
            }
            if (matrix.M22 > matrix.M33)
            {
                float num6 = (float) Math.Sqrt(((1.0 + matrix.M22) - matrix.M11) - matrix.M33);
                float num7 = 0.5f / num6;
                quaternion.X = (matrix.M21 + matrix.M12) * num7;
                quaternion.Y = 0.5f * num6;
                quaternion.Z = (matrix.M32 + matrix.M23) * num7;
                quaternion.W = (matrix.M31 - matrix.M13) * num7;
                return quaternion;
            }
            float num8 = (float) Math.Sqrt(((1.0 + matrix.M33) - matrix.M11) - matrix.M22);
            float num9 = 0.5f / num8;
            quaternion.X = (matrix.M31 + matrix.M13) * num9;
            quaternion.Y = (matrix.M32 + matrix.M23) * num9;
            quaternion.Z = 0.5f * num8;
            quaternion.W = (matrix.M12 - matrix.M21) * num9;
            return quaternion;
        }

        public static void CreateFromRotationMatrix(ref MatrixD matrix, out Quaternion result)
        {
            Matrix matrix2 = (Matrix) matrix;
            CreateFromRotationMatrix(ref matrix2, out result);
        }

        public static void CreateFromTwoVectors(ref Vector3 firstVector, ref Vector3 secondVector, out Quaternion result)
        {
            Vector3 vector;
            Vector3.Cross(ref firstVector, ref secondVector, out vector);
            result = new Quaternion(vector.X, vector.Y, vector.Z, Vector3.Dot(firstVector, secondVector));
            result.W += result.Length();
            result.Normalize();
        }

        public static Quaternion CreateFromTwoVectors(Vector3 firstVector, Vector3 secondVector)
        {
            Quaternion quaternion;
            CreateFromTwoVectors(ref firstVector, ref secondVector, out quaternion);
            return quaternion;
        }

        public static void CreateFromRotationMatrix(ref Matrix matrix, out Quaternion result)
        {
            float num = (matrix.M11 + matrix.M22) + matrix.M33;
            if (num > 0.0)
            {
                float num2 = (float) Math.Sqrt(num + 1.0);
                result.W = num2 * 0.5f;
                float num3 = 0.5f / num2;
                result.X = (matrix.M23 - matrix.M32) * num3;
                result.Y = (matrix.M31 - matrix.M13) * num3;
                result.Z = (matrix.M12 - matrix.M21) * num3;
            }
            else if ((matrix.M11 >= matrix.M22) && (matrix.M11 >= matrix.M33))
            {
                float num4 = (float) Math.Sqrt(((1.0 + matrix.M11) - matrix.M22) - matrix.M33);
                float num5 = 0.5f / num4;
                result.X = 0.5f * num4;
                result.Y = (matrix.M12 + matrix.M21) * num5;
                result.Z = (matrix.M13 + matrix.M31) * num5;
                result.W = (matrix.M23 - matrix.M32) * num5;
            }
            else if (matrix.M22 > matrix.M33)
            {
                float num6 = (float) Math.Sqrt(((1.0 + matrix.M22) - matrix.M11) - matrix.M33);
                float num7 = 0.5f / num6;
                result.X = (matrix.M21 + matrix.M12) * num7;
                result.Y = 0.5f * num6;
                result.Z = (matrix.M32 + matrix.M23) * num7;
                result.W = (matrix.M31 - matrix.M13) * num7;
            }
            else
            {
                float num8 = (float) Math.Sqrt(((1.0 + matrix.M33) - matrix.M11) - matrix.M22);
                float num9 = 0.5f / num8;
                result.X = (matrix.M31 + matrix.M13) * num9;
                result.Y = (matrix.M32 + matrix.M23) * num9;
                result.Z = 0.5f * num8;
                result.W = (matrix.M12 - matrix.M21) * num9;
            }
        }

        public static float Dot(Quaternion quaternion1, Quaternion quaternion2) => 
            ((((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W));

        public static void Dot(ref Quaternion quaternion1, ref Quaternion quaternion2, out float result)
        {
            result = (((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W);
        }

        public static Quaternion Slerp(Quaternion quaternion1, Quaternion quaternion2, float amount)
        {
            float num3;
            float num4;
            Quaternion quaternion;
            float num = amount;
            float num2 = (((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W);
            bool flag = false;
            if (num2 < 0.0)
            {
                flag = true;
                num2 = -num2;
            }
            if (num2 > 0.999998986721039)
            {
                num3 = 1f - num;
                num4 = flag ? -num : num;
            }
            else
            {
                float num5 = (float) Math.Acos((double) num2);
                float num6 = (float) (1.0 / Math.Sin((double) num5));
                num3 = ((float) Math.Sin((1.0 - num) * num5)) * num6;
                num4 = flag ? (((float) -Math.Sin(num * num5)) * num6) : (((float) Math.Sin(num * num5)) * num6);
            }
            quaternion.X = (num3 * quaternion1.X) + (num4 * quaternion2.X);
            quaternion.Y = (num3 * quaternion1.Y) + (num4 * quaternion2.Y);
            quaternion.Z = (num3 * quaternion1.Z) + (num4 * quaternion2.Z);
            quaternion.W = (num3 * quaternion1.W) + (num4 * quaternion2.W);
            return quaternion;
        }

        public static void Slerp(ref Quaternion quaternion1, ref Quaternion quaternion2, float amount, out Quaternion result)
        {
            float num3;
            float num4;
            float num = amount;
            float num2 = (((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W);
            bool flag = false;
            if (num2 < 0.0)
            {
                flag = true;
                num2 = -num2;
            }
            if (num2 > 0.999998986721039)
            {
                num3 = 1f - num;
                num4 = flag ? -num : num;
            }
            else
            {
                float num5 = (float) Math.Acos((double) num2);
                float num6 = (float) (1.0 / Math.Sin((double) num5));
                num3 = ((float) Math.Sin((1.0 - num) * num5)) * num6;
                num4 = flag ? (((float) -Math.Sin(num * num5)) * num6) : (((float) Math.Sin(num * num5)) * num6);
            }
            result.X = (num3 * quaternion1.X) + (num4 * quaternion2.X);
            result.Y = (num3 * quaternion1.Y) + (num4 * quaternion2.Y);
            result.Z = (num3 * quaternion1.Z) + (num4 * quaternion2.Z);
            result.W = (num3 * quaternion1.W) + (num4 * quaternion2.W);
        }

        public static Quaternion Lerp(Quaternion quaternion1, Quaternion quaternion2, float amount)
        {
            float num = amount;
            float num2 = 1f - num;
            Quaternion quaternion = new Quaternion();
            if (((((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W)) >= 0.0)
            {
                quaternion.X = (num2 * quaternion1.X) + (num * quaternion2.X);
                quaternion.Y = (num2 * quaternion1.Y) + (num * quaternion2.Y);
                quaternion.Z = (num2 * quaternion1.Z) + (num * quaternion2.Z);
                quaternion.W = (num2 * quaternion1.W) + (num * quaternion2.W);
            }
            else
            {
                quaternion.X = (num2 * quaternion1.X) - (num * quaternion2.X);
                quaternion.Y = (num2 * quaternion1.Y) - (num * quaternion2.Y);
                quaternion.Z = (num2 * quaternion1.Z) - (num * quaternion2.Z);
                quaternion.W = (num2 * quaternion1.W) - (num * quaternion2.W);
            }
            float num3 = 1f / ((float) Math.Sqrt((((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y)) + (quaternion.Z * quaternion.Z)) + (quaternion.W * quaternion.W)));
            quaternion.X *= num3;
            quaternion.Y *= num3;
            quaternion.Z *= num3;
            quaternion.W *= num3;
            return quaternion;
        }

        public static void Lerp(ref Quaternion quaternion1, ref Quaternion quaternion2, float amount, out Quaternion result)
        {
            float num = amount;
            float num2 = 1f - num;
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
            float num3 = 1f / ((float) Math.Sqrt((((result.X * result.X) + (result.Y * result.Y)) + (result.Z * result.Z)) + (result.W * result.W)));
            result.X *= num3;
            result.Y *= num3;
            result.Z *= num3;
            result.W *= num3;
        }

        public static Quaternion Concatenate(Quaternion value1, Quaternion value2)
        {
            Quaternion quaternion;
            float x = value2.X;
            float y = value2.Y;
            float z = value2.Z;
            float w = value2.W;
            float num5 = value1.X;
            float num6 = value1.Y;
            float num7 = value1.Z;
            float num8 = value1.W;
            float num9 = (y * num7) - (z * num6);
            float num10 = (z * num5) - (x * num7);
            float num11 = (x * num6) - (y * num5);
            float num12 = ((x * num5) + (y * num6)) + (z * num7);
            quaternion.X = ((x * num8) + (num5 * w)) + num9;
            quaternion.Y = ((y * num8) + (num6 * w)) + num10;
            quaternion.Z = ((z * num8) + (num7 * w)) + num11;
            quaternion.W = (w * num8) - num12;
            return quaternion;
        }

        public static void Concatenate(ref Quaternion value1, ref Quaternion value2, out Quaternion result)
        {
            float x = value2.X;
            float y = value2.Y;
            float z = value2.Z;
            float w = value2.W;
            float num5 = value1.X;
            float num6 = value1.Y;
            float num7 = value1.Z;
            float num8 = value1.W;
            float num9 = (y * num7) - (z * num6);
            float num10 = (z * num5) - (x * num7);
            float num11 = (x * num6) - (y * num5);
            float num12 = ((x * num5) + (y * num6)) + (z * num7);
            result.X = ((x * num8) + (num5 * w)) + num9;
            result.Y = ((y * num8) + (num6 * w)) + num10;
            result.Z = ((z * num8) + (num7 * w)) + num11;
            result.W = (w * num8) - num12;
        }

        public static Quaternion Negate(Quaternion quaternion)
        {
            Quaternion quaternion2;
            quaternion2.X = -quaternion.X;
            quaternion2.Y = -quaternion.Y;
            quaternion2.Z = -quaternion.Z;
            quaternion2.W = -quaternion.W;
            return quaternion2;
        }

        public static void Negate(ref Quaternion quaternion, out Quaternion result)
        {
            result.X = -quaternion.X;
            result.Y = -quaternion.Y;
            result.Z = -quaternion.Z;
            result.W = -quaternion.W;
        }

        public static Quaternion Add(Quaternion quaternion1, Quaternion quaternion2)
        {
            Quaternion quaternion;
            quaternion.X = quaternion1.X + quaternion2.X;
            quaternion.Y = quaternion1.Y + quaternion2.Y;
            quaternion.Z = quaternion1.Z + quaternion2.Z;
            quaternion.W = quaternion1.W + quaternion2.W;
            return quaternion;
        }

        public static void Add(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
        {
            result.X = quaternion1.X + quaternion2.X;
            result.Y = quaternion1.Y + quaternion2.Y;
            result.Z = quaternion1.Z + quaternion2.Z;
            result.W = quaternion1.W + quaternion2.W;
        }

        public static Quaternion Subtract(Quaternion quaternion1, Quaternion quaternion2)
        {
            Quaternion quaternion;
            quaternion.X = quaternion1.X - quaternion2.X;
            quaternion.Y = quaternion1.Y - quaternion2.Y;
            quaternion.Z = quaternion1.Z - quaternion2.Z;
            quaternion.W = quaternion1.W - quaternion2.W;
            return quaternion;
        }

        public static void Subtract(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
        {
            result.X = quaternion1.X - quaternion2.X;
            result.Y = quaternion1.Y - quaternion2.Y;
            result.Z = quaternion1.Z - quaternion2.Z;
            result.W = quaternion1.W - quaternion2.W;
        }

        public static Quaternion Multiply(Quaternion quaternion1, Quaternion quaternion2)
        {
            Quaternion quaternion;
            float x = quaternion1.X;
            float y = quaternion1.Y;
            float z = quaternion1.Z;
            float w = quaternion1.W;
            float num5 = quaternion2.X;
            float num6 = quaternion2.Y;
            float num7 = quaternion2.Z;
            float num8 = quaternion2.W;
            float num9 = (y * num7) - (z * num6);
            float num10 = (z * num5) - (x * num7);
            float num11 = (x * num6) - (y * num5);
            float num12 = ((x * num5) + (y * num6)) + (z * num7);
            quaternion.X = ((x * num8) + (num5 * w)) + num9;
            quaternion.Y = ((y * num8) + (num6 * w)) + num10;
            quaternion.Z = ((z * num8) + (num7 * w)) + num11;
            quaternion.W = (w * num8) - num12;
            return quaternion;
        }

        public static void Multiply(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
        {
            float x = quaternion1.X;
            float y = quaternion1.Y;
            float z = quaternion1.Z;
            float w = quaternion1.W;
            float num5 = quaternion2.X;
            float num6 = quaternion2.Y;
            float num7 = quaternion2.Z;
            float num8 = quaternion2.W;
            float num9 = (y * num7) - (z * num6);
            float num10 = (z * num5) - (x * num7);
            float num11 = (x * num6) - (y * num5);
            float num12 = ((x * num5) + (y * num6)) + (z * num7);
            result.X = ((x * num8) + (num5 * w)) + num9;
            result.Y = ((y * num8) + (num6 * w)) + num10;
            result.Z = ((z * num8) + (num7 * w)) + num11;
            result.W = (w * num8) - num12;
        }

        public static Quaternion Multiply(Quaternion quaternion1, float scaleFactor)
        {
            Quaternion quaternion;
            quaternion.X = quaternion1.X * scaleFactor;
            quaternion.Y = quaternion1.Y * scaleFactor;
            quaternion.Z = quaternion1.Z * scaleFactor;
            quaternion.W = quaternion1.W * scaleFactor;
            return quaternion;
        }

        public static void Multiply(ref Quaternion quaternion1, float scaleFactor, out Quaternion result)
        {
            result.X = quaternion1.X * scaleFactor;
            result.Y = quaternion1.Y * scaleFactor;
            result.Z = quaternion1.Z * scaleFactor;
            result.W = quaternion1.W * scaleFactor;
        }

        public static Quaternion Divide(Quaternion quaternion1, Quaternion quaternion2)
        {
            Quaternion quaternion;
            float x = quaternion1.X;
            float y = quaternion1.Y;
            float z = quaternion1.Z;
            float w = quaternion1.W;
            float num5 = 1f / ((((quaternion2.X * quaternion2.X) + (quaternion2.Y * quaternion2.Y)) + (quaternion2.Z * quaternion2.Z)) + (quaternion2.W * quaternion2.W));
            float num6 = -quaternion2.X * num5;
            float num7 = -quaternion2.Y * num5;
            float num8 = -quaternion2.Z * num5;
            float num9 = quaternion2.W * num5;
            float num10 = (y * num8) - (z * num7);
            float num11 = (z * num6) - (x * num8);
            float num12 = (x * num7) - (y * num6);
            float num13 = ((x * num6) + (y * num7)) + (z * num8);
            quaternion.X = ((x * num9) + (num6 * w)) + num10;
            quaternion.Y = ((y * num9) + (num7 * w)) + num11;
            quaternion.Z = ((z * num9) + (num8 * w)) + num12;
            quaternion.W = (w * num9) - num13;
            return quaternion;
        }

        public static void Divide(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
        {
            float x = quaternion1.X;
            float y = quaternion1.Y;
            float z = quaternion1.Z;
            float w = quaternion1.W;
            float num5 = 1f / ((((quaternion2.X * quaternion2.X) + (quaternion2.Y * quaternion2.Y)) + (quaternion2.Z * quaternion2.Z)) + (quaternion2.W * quaternion2.W));
            float num6 = -quaternion2.X * num5;
            float num7 = -quaternion2.Y * num5;
            float num8 = -quaternion2.Z * num5;
            float num9 = quaternion2.W * num5;
            float num10 = (y * num8) - (z * num7);
            float num11 = (z * num6) - (x * num8);
            float num12 = (x * num7) - (y * num6);
            float num13 = ((x * num6) + (y * num7)) + (z * num8);
            result.X = ((x * num9) + (num6 * w)) + num10;
            result.Y = ((y * num9) + (num7 * w)) + num11;
            result.Z = ((z * num9) + (num8 * w)) + num12;
            result.W = (w * num9) - num13;
        }

        public static Quaternion FromVector4(Vector4 v) => 
            new Quaternion(v.X, v.Y, v.Z, v.W);

        public Vector4 ToVector4() => 
            new Vector4(this.X, this.Y, this.Z, this.W);

        public static bool IsZero(Quaternion value) => 
            IsZero(value, 0.0001f);

        public static bool IsZero(Quaternion value, float epsilon) => 
            ((((Math.Abs(value.X) < epsilon) && (Math.Abs(value.Y) < epsilon)) && (Math.Abs(value.Z) < epsilon)) && (Math.Abs(value.W) < epsilon));

        public static void GetForward(ref Quaternion q, out Vector3 result)
        {
            float num = q.X + q.X;
            float num2 = q.Y + q.Y;
            float num3 = q.Z + q.Z;
            float num4 = q.W * num;
            float num5 = q.W * num2;
            float num6 = q.X * num;
            float num7 = q.X * num3;
            float num8 = q.Y * num2;
            float num9 = q.Y * num3;
            result.X = -num7 - num5;
            result.Y = num4 - num9;
            result.Z = (num6 + num8) - 1f;
        }

        public static void GetRight(ref Quaternion q, out Vector3 result)
        {
            float num = q.Y + q.Y;
            float num2 = q.Z + q.Z;
            float num3 = q.W * num;
            float num4 = q.W * num2;
            float num5 = q.X * num;
            float num6 = q.X * num2;
            float num7 = q.Y * num;
            float num8 = q.Z * num2;
            result.X = (1f - num7) - num8;
            result.Y = num5 + num4;
            result.Z = num6 - num3;
        }

        public static void GetUp(ref Quaternion q, out Vector3 result)
        {
            float num = q.X + q.X;
            float num2 = q.Y + q.Y;
            float num3 = q.Z + q.Z;
            float num4 = q.W * num;
            float num5 = q.W * num3;
            float num6 = q.X * num;
            float num7 = q.X * num2;
            float num8 = q.Y * num3;
            float num9 = q.Z * num3;
            result.X = num7 - num5;
            result.Y = (1f - num6) - num9;
            result.Z = num8 + num4;
        }

        public float GetComponent(int index)
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
            return 0f;
        }

        public void SetComponent(int index, float value)
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
        }

        public int FindLargestIndex()
        {
            int num = 0;
            float x = this.X;
            for (int i = 1; i < 4; i++)
            {
                float num4 = Math.Abs(this.GetComponent(i));
                if (num4 > x)
                {
                    num = i;
                    x = num4;
                }
            }
            return num;
        }
    }
}

