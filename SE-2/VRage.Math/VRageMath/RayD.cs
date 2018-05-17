namespace VRageMath
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct RayD : IEquatable<RayD>
    {
        public Vector3D Position;
        public Vector3D Direction;
        public RayD(Vector3D position, Vector3D direction)
        {
            this.Position = position;
            this.Direction = direction;
        }

        public static bool operator ==(RayD a, RayD b) => 
            (((((a.Position.X == b.Position.X) && (a.Position.Y == b.Position.Y)) && ((a.Position.Z == b.Position.Z) && (a.Direction.X == b.Direction.X))) && (a.Direction.Y == b.Direction.Y)) && (a.Direction.Z == b.Direction.Z));

        public static bool operator !=(RayD a, RayD b)
        {
            if ((((a.Position.X == b.Position.X) && (a.Position.Y == b.Position.Y)) && ((a.Position.Z == b.Position.Z) && (a.Direction.X == b.Direction.X))) && (a.Direction.Y == b.Direction.Y))
            {
                return !(a.Direction.Z == b.Direction.Z);
            }
            return true;
        }

        public bool Equals(RayD other) => 
            (((((this.Position.X == other.Position.X) && (this.Position.Y == other.Position.Y)) && ((this.Position.Z == other.Position.Z) && (this.Direction.X == other.Direction.X))) && (this.Direction.Y == other.Direction.Y)) && (this.Direction.Z == other.Direction.Z));

        public override bool Equals(object obj)
        {
            bool flag = false;
            if ((obj != null) && (obj is RayD))
            {
                flag = this.Equals((RayD) obj);
            }
            return flag;
        }

        public override int GetHashCode() => 
            (this.Position.GetHashCode() + this.Direction.GetHashCode());

        public override string ToString() => 
            string.Format(CultureInfo.CurrentCulture, "{{Position:{0} Direction:{1}}}", new object[] { this.Position.ToString(), this.Direction.ToString() });

        public double? Intersects(BoundingBoxD box) => 
            box.Intersects(this);

        public void Intersects(ref BoundingBoxD box, out double? result)
        {
            box.Intersects(ref this, out result);
        }

        public double? Intersects(BoundingFrustumD frustum) => 
            frustum?.Intersects(this);

        public double? Intersects(PlaneD plane)
        {
            double num = ((plane.Normal.X * this.Direction.X) + (plane.Normal.Y * this.Direction.Y)) + (plane.Normal.Z * this.Direction.Z);
            if (Math.Abs(num) < 9.99999974737875E-06)
            {
                return null;
            }
            double num2 = (float) (((plane.Normal.X * this.Position.X) + (plane.Normal.Y * this.Position.Y)) + (plane.Normal.Z * this.Position.Z));
            double num3 = (-plane.D - num2) / num;
            if (num3 < 0.0)
            {
                if (num3 < -9.99999974737875E-06)
                {
                    return null;
                }
                num3 = 0.0;
            }
            return new double?(num3);
        }

        public void Intersects(ref PlaneD plane, out double? result)
        {
            double num = ((plane.Normal.X * this.Direction.X) + (plane.Normal.Y * this.Direction.Y)) + (plane.Normal.Z * this.Direction.Z);
            if (Math.Abs(num) < 9.99999974737875E-06)
            {
                result = 0;
            }
            else
            {
                double num2 = ((plane.Normal.X * this.Position.X) + (plane.Normal.Y * this.Position.Y)) + (plane.Normal.Z * this.Position.Z);
                double num3 = (-plane.D - num2) / num;
                if (num3 < 0.0)
                {
                    if (num3 < -9.99999974737875E-06)
                    {
                        result = 0;
                        return;
                    }
                    result = 0.0;
                }
                result = new double?(num3);
            }
        }

        public double? Intersects(BoundingSphereD sphere)
        {
            double num = sphere.Center.X - this.Position.X;
            double num2 = sphere.Center.Y - this.Position.Y;
            double num3 = sphere.Center.Z - this.Position.Z;
            double num4 = ((num * num) + (num2 * num2)) + (num3 * num3);
            double num5 = sphere.Radius * sphere.Radius;
            if (num4 <= num5)
            {
                return 0.0;
            }
            double num6 = ((num * this.Direction.X) + (num2 * this.Direction.Y)) + (num3 * this.Direction.Z);
            if (num6 < 0.0)
            {
                return null;
            }
            double num7 = num4 - (num6 * num6);
            if (num7 > num5)
            {
                return null;
            }
            double num8 = Math.Sqrt(num5 - num7);
            return new double?(num6 - num8);
        }

        public void Intersects(ref BoundingSphere sphere, out double? result)
        {
            double num = sphere.Center.X - this.Position.X;
            double num2 = sphere.Center.Y - this.Position.Y;
            double num3 = sphere.Center.Z - this.Position.Z;
            double num4 = ((num * num) + (num2 * num2)) + (num3 * num3);
            double num5 = sphere.Radius * sphere.Radius;
            if (num4 <= num5)
            {
                result = 0.0;
            }
            else
            {
                result = 0;
                double num6 = ((num * this.Direction.X) + (num2 * this.Direction.Y)) + (num3 * this.Direction.Z);
                if (num6 >= 0.0)
                {
                    double num7 = num4 - (num6 * num6);
                    if (num7 <= num5)
                    {
                        double num8 = Math.Sqrt(num5 - num7);
                        result = new double?(num6 - num8);
                    }
                }
            }
        }
    }
}

