namespace VRageMath
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using VRage.Library.Utils;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct PlaneD : IEquatable<PlaneD>
    {
        public Vector3D Normal;
        public double D;
        private static MyRandom _random;
        public PlaneD(double a, double b, double c, double d)
        {
            this.Normal.X = a;
            this.Normal.Y = b;
            this.Normal.Z = c;
            this.D = d;
        }

        public PlaneD(Vector3D normal, double d)
        {
            this.Normal = normal;
            this.D = d;
        }

        public PlaneD(Vector3D position, Vector3D normal)
        {
            this.Normal = normal;
            this.D = -Vector3D.Dot(position, normal);
        }

        public PlaneD(Vector3D position, Vector3 normal)
        {
            this.Normal = normal;
            this.D = -Vector3D.Dot(position, normal);
        }

        public PlaneD(Vector4 value)
        {
            this.Normal.X = value.X;
            this.Normal.Y = value.Y;
            this.Normal.Z = value.Z;
            this.D = value.W;
        }

        public PlaneD(Vector3D point1, Vector3D point2, Vector3D point3)
        {
            double num = point2.X - point1.X;
            double num2 = point2.Y - point1.Y;
            double num3 = point2.Z - point1.Z;
            double num4 = point3.X - point1.X;
            double num5 = point3.Y - point1.Y;
            double num6 = point3.Z - point1.Z;
            double num7 = (num2 * num6) - (num3 * num5);
            double num8 = (num3 * num4) - (num * num6);
            double num9 = (num * num5) - (num2 * num4);
            double num10 = 1.0 / Math.Sqrt(((num7 * num7) + (num8 * num8)) + (num9 * num9));
            this.Normal.X = num7 * num10;
            this.Normal.Y = num8 * num10;
            this.Normal.Z = num9 * num10;
            this.D = -(((this.Normal.X * point1.X) + (this.Normal.Y * point1.Y)) + (this.Normal.Z * point1.Z));
        }

        public static bool operator ==(PlaneD lhs, PlaneD rhs) => 
            lhs.Equals(rhs);

        public static bool operator !=(PlaneD lhs, PlaneD rhs)
        {
            if (((lhs.Normal.X == rhs.Normal.X) && (lhs.Normal.Y == rhs.Normal.Y)) && (lhs.Normal.Z == rhs.Normal.Z))
            {
                return !(lhs.D == rhs.D);
            }
            return true;
        }

        public bool Equals(PlaneD other) => 
            ((((this.Normal.X == other.Normal.X) && (this.Normal.Y == other.Normal.Y)) && (this.Normal.Z == other.Normal.Z)) && (this.D == other.D));

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is PlaneD)
            {
                flag = this.Equals((PlaneD) obj);
            }
            return flag;
        }

        public override int GetHashCode() => 
            (this.Normal.GetHashCode() + this.D.GetHashCode());

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format(currentCulture, "{{Normal:{0} D:{1}}}", new object[] { this.Normal.ToString(), this.D.ToString(currentCulture) });
        }

        public void Normalize()
        {
            double d = ((this.Normal.X * this.Normal.X) + (this.Normal.Y * this.Normal.Y)) + (this.Normal.Z * this.Normal.Z);
            if (Math.Abs((double) (d - 1.0)) >= 1.19209289550781E-07)
            {
                double num2 = 1.0 / Math.Sqrt(d);
                this.Normal.X *= num2;
                this.Normal.Y *= num2;
                this.Normal.Z *= num2;
                this.D *= num2;
            }
        }

        public static PlaneD Normalize(PlaneD value)
        {
            PlaneD ed2;
            double d = ((value.Normal.X * value.Normal.X) + (value.Normal.Y * value.Normal.Y)) + (value.Normal.Z * value.Normal.Z);
            if (Math.Abs((double) (d - 1.0)) < 1.19209289550781E-07)
            {
                PlaneD ed;
                ed.Normal = value.Normal;
                ed.D = value.D;
                return ed;
            }
            double num2 = 1.0 / Math.Sqrt(d);
            ed2.Normal.X = value.Normal.X * num2;
            ed2.Normal.Y = value.Normal.Y * num2;
            ed2.Normal.Z = value.Normal.Z * num2;
            ed2.D = value.D * num2;
            return ed2;
        }

        public static void Normalize(ref PlaneD value, out PlaneD result)
        {
            double d = ((value.Normal.X * value.Normal.X) + (value.Normal.Y * value.Normal.Y)) + (value.Normal.Z * value.Normal.Z);
            if (Math.Abs((double) (d - 1.0)) < 1.19209289550781E-07)
            {
                result.Normal = value.Normal;
                result.D = value.D;
            }
            else
            {
                double num2 = 1.0 / Math.Sqrt(d);
                result.Normal.X = value.Normal.X * num2;
                result.Normal.Y = value.Normal.Y * num2;
                result.Normal.Z = value.Normal.Z * num2;
                result.D = value.D * num2;
            }
        }

        public static PlaneD Transform(PlaneD plane, MatrixD matrix)
        {
            PlaneD ed;
            Transform(ref plane, ref matrix, out ed);
            return ed;
        }

        public static void Transform(ref PlaneD plane, ref MatrixD matrix, out PlaneD result)
        {
            result = new PlaneD();
            Vector3D position = (Vector3D) (-plane.Normal * plane.D);
            Vector3D.TransformNormal(ref plane.Normal, ref matrix, out result.Normal);
            Vector3D.Transform(ref position, ref matrix, out position);
            Vector3D.Dot(ref position, ref result.Normal, out result.D);
            result.D = -result.D;
        }

        public double Dot(Vector4 value) => 
            ((((this.Normal.X * value.X) + (this.Normal.Y * value.Y)) + (this.Normal.Z * value.Z)) + (this.D * value.W));

        public void Dot(ref Vector4 value, out double result)
        {
            result = (((this.Normal.X * value.X) + (this.Normal.Y * value.Y)) + (this.Normal.Z * value.Z)) + (this.D * value.W);
        }

        public double DotCoordinate(Vector3D value) => 
            ((((this.Normal.X * value.X) + (this.Normal.Y * value.Y)) + (this.Normal.Z * value.Z)) + this.D);

        public void DotCoordinate(ref Vector3D value, out double result)
        {
            result = (((this.Normal.X * value.X) + (this.Normal.Y * value.Y)) + (this.Normal.Z * value.Z)) + this.D;
        }

        public double DotNormal(Vector3D value) => 
            (((this.Normal.X * value.X) + (this.Normal.Y * value.Y)) + (this.Normal.Z * value.Z));

        public void DotNormal(ref Vector3D value, out double result)
        {
            result = ((this.Normal.X * value.X) + (this.Normal.Y * value.Y)) + (this.Normal.Z * value.Z);
        }

        public PlaneIntersectionType Intersects(BoundingBoxD box)
        {
            Vector3D vectord;
            Vector3D vectord2;
            vectord.X = (this.Normal.X >= 0.0) ? box.Min.X : box.Max.X;
            vectord.Y = (this.Normal.Y >= 0.0) ? box.Min.Y : box.Max.Y;
            vectord.Z = (this.Normal.Z >= 0.0) ? box.Min.Z : box.Max.Z;
            vectord2.X = (this.Normal.X >= 0.0) ? box.Max.X : box.Min.X;
            vectord2.Y = (this.Normal.Y >= 0.0) ? box.Max.Y : box.Min.Y;
            vectord2.Z = (this.Normal.Z >= 0.0) ? box.Max.Z : box.Min.Z;
            if (((((this.Normal.X * vectord.X) + (this.Normal.Y * vectord.Y)) + (this.Normal.Z * vectord.Z)) + this.D) > 0.0)
            {
                return PlaneIntersectionType.Front;
            }
            if (((((this.Normal.X * vectord2.X) + (this.Normal.Y * vectord2.Y)) + (this.Normal.Z * vectord2.Z)) + this.D) >= 0.0)
            {
                return PlaneIntersectionType.Intersecting;
            }
            return PlaneIntersectionType.Back;
        }

        public void Intersects(ref BoundingBoxD box, out PlaneIntersectionType result)
        {
            Vector3D vectord;
            Vector3D vectord2;
            vectord.X = (this.Normal.X >= 0.0) ? box.Min.X : box.Max.X;
            vectord.Y = (this.Normal.Y >= 0.0) ? box.Min.Y : box.Max.Y;
            vectord.Z = (this.Normal.Z >= 0.0) ? box.Min.Z : box.Max.Z;
            vectord2.X = (this.Normal.X >= 0.0) ? box.Max.X : box.Min.X;
            vectord2.Y = (this.Normal.Y >= 0.0) ? box.Max.Y : box.Min.Y;
            vectord2.Z = (this.Normal.Z >= 0.0) ? box.Max.Z : box.Min.Z;
            if (((((this.Normal.X * vectord.X) + (this.Normal.Y * vectord.Y)) + (this.Normal.Z * vectord.Z)) + this.D) > 0.0)
            {
                result = PlaneIntersectionType.Front;
            }
            else if (((((this.Normal.X * vectord2.X) + (this.Normal.Y * vectord2.Y)) + (this.Normal.Z * vectord2.Z)) + this.D) < 0.0)
            {
                result = PlaneIntersectionType.Back;
            }
            else
            {
                result = PlaneIntersectionType.Intersecting;
            }
        }

        public PlaneIntersectionType Intersects(BoundingFrustumD frustum) => 
            frustum.Intersects(this);

        public PlaneIntersectionType Intersects(BoundingSphereD sphere)
        {
            double num = (((sphere.Center.X * this.Normal.X) + (sphere.Center.Y * this.Normal.Y)) + (sphere.Center.Z * this.Normal.Z)) + this.D;
            if (num > sphere.Radius)
            {
                return PlaneIntersectionType.Front;
            }
            if (num >= -sphere.Radius)
            {
                return PlaneIntersectionType.Intersecting;
            }
            return PlaneIntersectionType.Back;
        }

        public void Intersects(ref BoundingSphere sphere, out PlaneIntersectionType result)
        {
            double num = (((sphere.Center.X * this.Normal.X) + (sphere.Center.Y * this.Normal.Y)) + (sphere.Center.Z * this.Normal.Z)) + this.D;
            if (num > sphere.Radius)
            {
                result = PlaneIntersectionType.Front;
            }
            else if (num < -((double) sphere.Radius))
            {
                result = PlaneIntersectionType.Back;
            }
            else
            {
                result = PlaneIntersectionType.Intersecting;
            }
        }

        public Vector3D RandomPoint()
        {
            Vector3D vectord2;
            if (_random == null)
            {
                _random = new MyRandom();
            }
            Vector3D vectord = new Vector3D();
            do
            {
                vectord.X = (2.0 * _random.NextDouble()) - 1.0;
                vectord.Y = (2.0 * _random.NextDouble()) - 1.0;
                vectord.Z = (2.0 * _random.NextDouble()) - 1.0;
                vectord2 = Vector3D.Cross(vectord, this.Normal);
            }
            while (vectord2 == Vector3D.Zero);
            vectord2.Normalize();
            return (Vector3D) (vectord2 * Math.Sqrt(_random.NextDouble()));
        }

        public double DistanceToPoint(Vector3D point) => 
            (Vector3D.Dot(this.Normal, point) + this.D);

        public double DistanceToPoint(ref Vector3D point) => 
            (Vector3D.Dot(this.Normal, point) + this.D);

        public Vector3D ProjectPoint(ref Vector3D point) => 
            ((Vector3D) (point - (this.Normal * this.DistanceToPoint(ref point))));

        public Vector3D Intersection(ref Vector3D from, ref Vector3D direction)
        {
            double num = -(this.DotNormal(from) + this.D) / this.DotNormal(direction);
            return new Vector3D((Vector3) (from + (num * direction)));
        }
    }
}

