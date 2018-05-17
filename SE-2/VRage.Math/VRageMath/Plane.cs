namespace VRageMath
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using VRage.Library.Utils;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct Plane : IEquatable<Plane>
    {
        public Vector3 Normal;
        public float D;
        private static MyRandom _random;
        public Plane(float a, float b, float c, float d)
        {
            this.Normal.X = a;
            this.Normal.Y = b;
            this.Normal.Z = c;
            this.D = d;
        }

        public Plane(Vector3 normal, float d)
        {
            this.Normal = normal;
            this.D = d;
        }

        public Plane(Vector3 position, Vector3 normal)
        {
            this.Normal = normal;
            this.D = -Vector3.Dot(position, normal);
        }

        public Plane(Vector4 value)
        {
            this.Normal.X = value.X;
            this.Normal.Y = value.Y;
            this.Normal.Z = value.Z;
            this.D = value.W;
        }

        public Plane(Vector3 point1, Vector3 point2, Vector3 point3)
        {
            float num = point2.X - point1.X;
            float num2 = point2.Y - point1.Y;
            float num3 = point2.Z - point1.Z;
            float num4 = point3.X - point1.X;
            float num5 = point3.Y - point1.Y;
            float num6 = point3.Z - point1.Z;
            float num7 = (num2 * num6) - (num3 * num5);
            float num8 = (num3 * num4) - (num * num6);
            float num9 = (num * num5) - (num2 * num4);
            float num10 = 1f / ((float) Math.Sqrt(((num7 * num7) + (num8 * num8)) + (num9 * num9)));
            this.Normal.X = num7 * num10;
            this.Normal.Y = num8 * num10;
            this.Normal.Z = num9 * num10;
            this.D = -(((this.Normal.X * point1.X) + (this.Normal.Y * point1.Y)) + (this.Normal.Z * point1.Z));
        }

        public static bool operator ==(Plane lhs, Plane rhs) => 
            lhs.Equals(rhs);

        public static bool operator !=(Plane lhs, Plane rhs)
        {
            if (((lhs.Normal.X == rhs.Normal.X) && (lhs.Normal.Y == rhs.Normal.Y)) && (lhs.Normal.Z == rhs.Normal.Z))
            {
                return !(lhs.D == rhs.D);
            }
            return true;
        }

        public bool Equals(Plane other) => 
            ((((this.Normal.X == other.Normal.X) && (this.Normal.Y == other.Normal.Y)) && (this.Normal.Z == other.Normal.Z)) && (this.D == other.D));

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is Plane)
            {
                flag = this.Equals((Plane) obj);
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
            float num = ((this.Normal.X * this.Normal.X) + (this.Normal.Y * this.Normal.Y)) + (this.Normal.Z * this.Normal.Z);
            if (Math.Abs((float) (num - 1f)) >= 1.19209289550781E-07)
            {
                float num2 = 1f / ((float) Math.Sqrt((double) num));
                this.Normal.X *= num2;
                this.Normal.Y *= num2;
                this.Normal.Z *= num2;
                this.D *= num2;
            }
        }

        public static Plane Normalize(Plane value)
        {
            Plane plane2;
            float num = ((value.Normal.X * value.Normal.X) + (value.Normal.Y * value.Normal.Y)) + (value.Normal.Z * value.Normal.Z);
            if (Math.Abs((float) (num - 1f)) < 1.19209289550781E-07)
            {
                Plane plane;
                plane.Normal = value.Normal;
                plane.D = value.D;
                return plane;
            }
            float num2 = 1f / ((float) Math.Sqrt((double) num));
            plane2.Normal.X = value.Normal.X * num2;
            plane2.Normal.Y = value.Normal.Y * num2;
            plane2.Normal.Z = value.Normal.Z * num2;
            plane2.D = value.D * num2;
            return plane2;
        }

        public static void Normalize(ref Plane value, out Plane result)
        {
            float num = ((value.Normal.X * value.Normal.X) + (value.Normal.Y * value.Normal.Y)) + (value.Normal.Z * value.Normal.Z);
            if (Math.Abs((float) (num - 1f)) < 1.19209289550781E-07)
            {
                result.Normal = value.Normal;
                result.D = value.D;
            }
            else
            {
                float num2 = 1f / ((float) Math.Sqrt((double) num));
                result.Normal.X = value.Normal.X * num2;
                result.Normal.Y = value.Normal.Y * num2;
                result.Normal.Z = value.Normal.Z * num2;
                result.D = value.D * num2;
            }
        }

        public static Plane Transform(Plane plane, Matrix matrix)
        {
            Plane plane2;
            Transform(ref plane, ref matrix, out plane2);
            return plane2;
        }

        public static void Transform(ref Plane plane, ref Matrix matrix, out Plane result)
        {
            result = new Plane();
            Vector3 position = (Vector3) (-plane.Normal * plane.D);
            Vector3.TransformNormal(ref plane.Normal, ref matrix, out result.Normal);
            Vector3.Transform(ref position, ref matrix, out position);
            Vector3.Dot(ref position, ref result.Normal, out result.D);
            result.D = -result.D;
        }

        public float Dot(Vector4 value) => 
            ((((this.Normal.X * value.X) + (this.Normal.Y * value.Y)) + (this.Normal.Z * value.Z)) + (this.D * value.W));

        public void Dot(ref Vector4 value, out float result)
        {
            result = (((this.Normal.X * value.X) + (this.Normal.Y * value.Y)) + (this.Normal.Z * value.Z)) + (this.D * value.W);
        }

        public float DotCoordinate(Vector3 value) => 
            ((((this.Normal.X * value.X) + (this.Normal.Y * value.Y)) + (this.Normal.Z * value.Z)) + this.D);

        public void DotCoordinate(ref Vector3 value, out float result)
        {
            result = (((this.Normal.X * value.X) + (this.Normal.Y * value.Y)) + (this.Normal.Z * value.Z)) + this.D;
        }

        public float DotNormal(Vector3 value) => 
            (((this.Normal.X * value.X) + (this.Normal.Y * value.Y)) + (this.Normal.Z * value.Z));

        public void DotNormal(ref Vector3 value, out float result)
        {
            result = ((this.Normal.X * value.X) + (this.Normal.Y * value.Y)) + (this.Normal.Z * value.Z);
        }

        public PlaneIntersectionType Intersects(BoundingBox box)
        {
            Vector3 vector;
            Vector3 vector2;
            vector.X = (this.Normal.X >= 0.0) ? box.Min.X : box.Max.X;
            vector.Y = (this.Normal.Y >= 0.0) ? box.Min.Y : box.Max.Y;
            vector.Z = (this.Normal.Z >= 0.0) ? box.Min.Z : box.Max.Z;
            vector2.X = (this.Normal.X >= 0.0) ? box.Max.X : box.Min.X;
            vector2.Y = (this.Normal.Y >= 0.0) ? box.Max.Y : box.Min.Y;
            vector2.Z = (this.Normal.Z >= 0.0) ? box.Max.Z : box.Min.Z;
            if (((((this.Normal.X * vector.X) + (this.Normal.Y * vector.Y)) + (this.Normal.Z * vector.Z)) + this.D) > 0.0)
            {
                return PlaneIntersectionType.Front;
            }
            if (((((this.Normal.X * vector2.X) + (this.Normal.Y * vector2.Y)) + (this.Normal.Z * vector2.Z)) + this.D) >= 0.0)
            {
                return PlaneIntersectionType.Intersecting;
            }
            return PlaneIntersectionType.Back;
        }

        public void Intersects(ref BoundingBox box, out PlaneIntersectionType result)
        {
            Vector3 vector;
            Vector3 vector2;
            vector.X = (this.Normal.X >= 0.0) ? box.Min.X : box.Max.X;
            vector.Y = (this.Normal.Y >= 0.0) ? box.Min.Y : box.Max.Y;
            vector.Z = (this.Normal.Z >= 0.0) ? box.Min.Z : box.Max.Z;
            vector2.X = (this.Normal.X >= 0.0) ? box.Max.X : box.Min.X;
            vector2.Y = (this.Normal.Y >= 0.0) ? box.Max.Y : box.Min.Y;
            vector2.Z = (this.Normal.Z >= 0.0) ? box.Max.Z : box.Min.Z;
            if (((((this.Normal.X * vector.X) + (this.Normal.Y * vector.Y)) + (this.Normal.Z * vector.Z)) + this.D) > 0.0)
            {
                result = PlaneIntersectionType.Front;
            }
            else if (((((this.Normal.X * vector2.X) + (this.Normal.Y * vector2.Y)) + (this.Normal.Z * vector2.Z)) + this.D) < 0.0)
            {
                result = PlaneIntersectionType.Back;
            }
            else
            {
                result = PlaneIntersectionType.Intersecting;
            }
        }

        public PlaneIntersectionType Intersects(BoundingFrustum frustum) => 
            frustum.Intersects(this);

        public PlaneIntersectionType Intersects(BoundingSphere sphere)
        {
            float num = (((sphere.Center.X * this.Normal.X) + (sphere.Center.Y * this.Normal.Y)) + (sphere.Center.Z * this.Normal.Z)) + this.D;
            if (num > sphere.Radius)
            {
                return PlaneIntersectionType.Front;
            }
            if (num >= -((double) sphere.Radius))
            {
                return PlaneIntersectionType.Intersecting;
            }
            return PlaneIntersectionType.Back;
        }

        public void Intersects(ref BoundingSphere sphere, out PlaneIntersectionType result)
        {
            float num = (((sphere.Center.X * this.Normal.X) + (sphere.Center.Y * this.Normal.Y)) + (sphere.Center.Z * this.Normal.Z)) + this.D;
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

        public Vector3 RandomPoint()
        {
            Vector3 vector2;
            if (_random == null)
            {
                _random = new MyRandom();
            }
            Vector3 vector = new Vector3();
            do
            {
                vector.X = (2f * ((float) _random.NextDouble())) - 1f;
                vector.Y = (2f * ((float) _random.NextDouble())) - 1f;
                vector.Z = (2f * ((float) _random.NextDouble())) - 1f;
                vector2 = Vector3.Cross(vector, this.Normal);
            }
            while (vector2 == Vector3.Zero);
            vector2.Normalize();
            return (Vector3) (vector2 * ((float) Math.Sqrt(_random.NextDouble())));
        }
    }
}

